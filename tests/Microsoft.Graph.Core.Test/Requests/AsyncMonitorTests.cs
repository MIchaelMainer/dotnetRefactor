﻿// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.Core.Test.Requests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Graph;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;
    using Moq;
    using TestModels;

    [TestClass]
    public class AsyncMonitorTests
    {
        private const string itemUrl = "https://localhost/item";
        private const string monitorUrl = "https://localhost/monitor";

        private AsyncMonitor<DerivedTypeClass> asyncMonitor;
        private MockAuthenticationProvider authenticationProvider;
        private MockHttpProvider httpProvider;
        private HttpResponseMessage httpResponseMessage;
        private Mock<IBaseClient> client;
        private MockProgress progress;
        private MockSerializer serializer;

        [TestInitialize]
        public void Setup()
        {
            this.authenticationProvider = new MockAuthenticationProvider();
            this.serializer = new MockSerializer();

            this.httpResponseMessage = new HttpResponseMessage();
            this.httpProvider = new MockHttpProvider(this.httpResponseMessage, this.serializer.Object);

            this.client = new Mock<IBaseClient>(MockBehavior.Strict);
            this.client.SetupAllProperties();
            this.client.SetupGet(client => client.HttpProvider).Returns(this.httpProvider.Object);

            this.progress = new MockProgress();
            
            this.asyncMonitor = new AsyncMonitor<DerivedTypeClass>(this.client.Object, AsyncMonitorTests.monitorUrl);
        }

        [TestCleanup]
        public void Teardown()
        {
            this.httpResponseMessage.Dispose();
        }

        [TestMethod]
        public async Task PollForOperationCompletionAsync_IsCancelled()
        {
            var item = await this.asyncMonitor.PollForOperationCompletionAsync(this.progress.Object, new CancellationToken(true));
            Assert.IsNull(item, "Operation not cancelled.");
        }

        [TestMethod]
        public async Task PollForOperationCompletionAsync_OperationCompleted()
        {
            bool called = false;
            this.progress.Setup(
                mockProgress => mockProgress.Report(
                    It.IsAny<AsyncOperationStatus>()))
                .Callback<AsyncOperationStatus>(status => this.ProgressCallback(status, out called));

            this.serializer.Setup(serializer => serializer.DeserializeObject<AsyncOperationStatus>(It.IsAny<Stream>())).Returns(new AsyncOperationStatus());
            this.serializer.Setup(serializer => serializer.DeserializeObject<DerivedTypeClass>(It.IsAny<Stream>())).Returns(new DerivedTypeClass { Id = "id" });

            using (var redirectedResponseMessage = new HttpResponseMessage())
            using (var stringContent = new StringContent("content"))
            using (var redirectedStringContent = new StringContent("content"))
            {
                this.httpResponseMessage.Content = stringContent;
                this.httpResponseMessage.StatusCode = HttpStatusCode.Accepted;
                redirectedResponseMessage.Content = redirectedStringContent;

                this.httpProvider.Setup(provider =>
                    provider.SendAsync(
                        It.Is<HttpRequestMessage>(requestMessage => requestMessage.RequestUri.ToString().Equals(AsyncMonitorTests.itemUrl))))
                    .Returns(Task.FromResult(redirectedResponseMessage));

                var item = await this.asyncMonitor.PollForOperationCompletionAsync(this.progress.Object, CancellationToken.None);

                Assert.IsTrue(called, "Progress not called");
                Assert.IsNotNull(item, "No item returned.");
                Assert.AreEqual("id", item.Id, "Unexpected item returned.");
            }
        }

        [TestMethod]
        public async Task PollForOperationCompletionAsync_OperationCancelled()
        {
            this.serializer.Setup(
                serializer => serializer.DeserializeObject<AsyncOperationStatus>(
                    It.IsAny<Stream>()))
                .Returns(new AsyncOperationStatus { Status = "cancelled" });

            using (var stringContent = new StringContent("content"))
            {
                this.httpResponseMessage.Content = stringContent;
                this.httpResponseMessage.StatusCode = HttpStatusCode.Accepted;
                
                var item = await this.asyncMonitor.PollForOperationCompletionAsync(this.progress.Object, CancellationToken.None);
                Assert.IsNull(item, "Unexpected item returned.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public async Task PollForOperationCompletionAsync_OperationDeleteFailed()
        {
            this.serializer.Setup(
                serializer => serializer.DeserializeObject<AsyncOperationStatus>(
                    It.IsAny<Stream>()))
                .Returns(new AsyncOperationStatus { Status = "deleteFailed" });

            using (var stringContent = new StringContent("content"))
            {
                this.httpResponseMessage.Content = stringContent;
                this.httpResponseMessage.StatusCode = HttpStatusCode.Accepted;

                try
                {
                    await this.asyncMonitor.PollForOperationCompletionAsync(this.progress.Object, CancellationToken.None);
                }
                catch (ServiceException exception)
                {
                    Assert.AreEqual(ErrorConstants.Codes.GeneralException, exception.Error.Code, "Unexpected error code.");
                    throw;
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public async Task PollForOperationCompletionAsync_OperationFailed()
        {
            this.serializer.Setup(
                serializer => serializer.DeserializeObject<AsyncOperationStatus>(
                    It.IsAny<Stream>()))
                .Returns(new AsyncOperationStatus
                    {
                        AdditionalData = new Dictionary<string, object> { { "message", "message" } },
                        Status = "failed"
                    });

            using (var stringContent = new StringContent("content"))
            {
                this.httpResponseMessage.Content = stringContent;
                this.httpResponseMessage.StatusCode = HttpStatusCode.Accepted;

                try
                {
                    await this.asyncMonitor.PollForOperationCompletionAsync(this.progress.Object, CancellationToken.None);
                }
                catch (ServiceException exception)
                {
                    Assert.AreEqual(ErrorConstants.Codes.GeneralException, exception.Error.Code, "Unexpected error code.");
                    Assert.AreEqual("message", exception.Error.Message, "Unexpected error message.");
                    throw;
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public async Task PollForOperationCompletionAsync_OperationNull()
        {
            this.serializer.Setup(
                serializer => serializer.DeserializeObject<AsyncOperationStatus>(
                    It.IsAny<Stream>()))
                .Returns((AsyncOperationStatus)null);

            using (var stringContent = new StringContent("content"))
            {
                this.httpResponseMessage.Content = stringContent;
                this.httpResponseMessage.StatusCode = HttpStatusCode.Accepted;

                try
                {
                    await this.asyncMonitor.PollForOperationCompletionAsync(this.progress.Object, CancellationToken.None);
                }
                catch (ServiceException exception)
                {
                    Assert.AreEqual(ErrorConstants.Codes.GeneralException, exception.Error.Code, "Unexpected error code.");
                    throw;
                }
            }
        }

        public void ProgressCallback(AsyncOperationStatus asyncOperationStatus, out bool called)
        {
            this.httpResponseMessage.StatusCode = HttpStatusCode.OK;
            this.asyncMonitor.monitorUrl = AsyncMonitorTests.itemUrl;

            called = true;
        }
    }
}
