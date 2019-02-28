﻿// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using Microsoft.Graph;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Graph.DotnetCore.Test.Requests.Generated
{
    public class CollectionWithReferencesRequestTests : RequestTestBase
    {
        /// <summary>
        /// Tests building a request for an entity collection that has a $ref navigation.
        /// </summary>
        [Fact]
        public void BuildRequest()
        {
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/groups/groupId/members");
            var membersCollectionRequestBuilder = this.graphServiceClient.Groups["groupId"].Members as GroupMembersCollectionWithReferencesRequestBuilder;

            Assert.NotNull(membersCollectionRequestBuilder);
            Assert.Equal(expectedRequestUri, new Uri(membersCollectionRequestBuilder.RequestUrl));

            var membersCollectionRequest = membersCollectionRequestBuilder.Request() as GroupMembersCollectionWithReferencesRequest;
            Assert.NotNull(membersCollectionRequest);
            Assert.Equal(expectedRequestUri, new Uri(membersCollectionRequest.RequestUrl));
        }

        /// <summary>
        /// Tests the GetAsync() method on the request for an entity collection that has a $ref navigation.
        /// </summary>
        [Fact]
        public async System.Threading.Tasks.Task GetAsync()
        {
            using (var httpResponseMessage = new HttpResponseMessage())
            using (var responseStream = new MemoryStream())
            using (var streamContent = new StreamContent(responseStream))
            {
                httpResponseMessage.Content = streamContent;

                var nextQueryKey = "key";
                var nextQueryValue = "value";

                var requestUrl = string.Format("{0}/groups/groupId/members", this.graphBaseUrl);
                var nextPageRequestUrl = string.Format("{0}?{1}={2}", requestUrl, nextQueryKey, nextQueryValue);

                this.httpProvider.Setup(
                    provider => provider.SendAsync(
                        It.Is<HttpRequestMessage>(
                            request => request.RequestUri.ToString().StartsWith(requestUrl)
                                && request.Method == HttpMethod.Get),
                        HttpCompletionOption.ResponseContentRead,
                        CancellationToken.None))
                    .Returns(System.Threading.Tasks.Task.FromResult(httpResponseMessage));

                var membersCollectionPage = new GroupMembersCollectionWithReferencesPage
                {
                    new User(),
                };

                var membersCollectionResponse = new GroupMembersCollectionWithReferencesResponse
                {
                    Value = membersCollectionPage,
                    AdditionalData = new Dictionary<string, object> { { "@odata.nextLink", nextPageRequestUrl } },
                };

                this.serializer.Setup(
                    serializer => serializer.DeserializeObject<GroupMembersCollectionWithReferencesResponse>(It.IsAny<string>()))
                    .Returns(membersCollectionResponse);

                var returnedCollectionPage = await this.graphServiceClient.Groups["groupId"].Members.Request().GetAsync() as GroupMembersCollectionWithReferencesPage;

                Assert.NotNull(returnedCollectionPage);
                Assert.Equal(membersCollectionPage, returnedCollectionPage);
                Assert.Equal(
                    membersCollectionResponse.AdditionalData,
                    returnedCollectionPage.AdditionalData);

                var nextPageRequest = returnedCollectionPage.NextPageRequest as GroupMembersCollectionWithReferencesRequest;

                Assert.NotNull(nextPageRequest);
                Assert.Equal(new Uri(requestUrl), new Uri(nextPageRequest.RequestUrl));
                Assert.Equal(1, nextPageRequest.QueryOptions.Count);
                Assert.Equal(nextQueryKey, nextPageRequest.QueryOptions[0].Name);
                Assert.Equal(nextQueryValue, nextPageRequest.QueryOptions[0].Value);
            }
        }

#if false // This test can no longer run at this time since the Graph does not have a $ref navigation that allows expand.
        /// <summary>
        /// Tests the Expand() method on the request for an entity collection that has a $ref navigation.
        /// </summary>
        [TestMethod]
        public void Expand()
        {
            var expectedRequestUrl = string.Format("{0}/groups/groupId/members", this.graphBaseUrl);

            var groupMembersRequest = this.graphServiceClient.Groups["groupId"].Members.Request().Expand("value") as GroupMembersCollectionWithReferencesRequest;

            Assert.IsNotNull(groupMembersRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(groupMembersRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual(1, groupMembersRequest.QueryOptions.Count, "Unexpected number of query options.");
            Assert.AreEqual("$expand", groupMembersRequest.QueryOptions[0].Name, "Unexpected query option name.");
            Assert.AreEqual("value", groupMembersRequest.QueryOptions[0].Value, "Unexpected query option value.");
        }
#endif

#if false // This test can no longer run at this time since the Graph does not have a $ref navigation that allows select.
        /// <summary>
        /// Tests the Select() method on an entity collection that has a $ref navigation.
        /// </summary>
        [TestMethod]
        public void Select()
        {
            var expectedRequestUrl = string.Format("{0}/groups/groupId/members", this.graphBaseUrl);

            var groupMembersRequest = this.graphServiceClient.Groups["groupId"].Members.Request().Select("value") as GroupMembersCollectionWithReferencesRequest;

            Assert.IsNotNull(groupMembersRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(groupMembersRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual(1, groupMembersRequest.QueryOptions.Count, "Unexpected number of query options.");
            Assert.AreEqual("$select", groupMembersRequest.QueryOptions[0].Name, "Unexpected query option name.");
            Assert.AreEqual("value", groupMembersRequest.QueryOptions[0].Value, "Unexpected query option value.");
        }
#endif

        /// <summary>
        /// Tests the Top() method on an entity collection that has a $ref navigation.
        /// </summary>
        [Fact]
        public void Top()
        {
            var expectedRequestUrl = string.Format("{0}/groups/groupId/members", this.graphBaseUrl);

            var groupMembersRequest = this.graphServiceClient.Groups["groupId"].Members.Request().Top(1) as GroupMembersCollectionWithReferencesRequest;

            Assert.NotNull(groupMembersRequest);
            Assert.Equal(new Uri(expectedRequestUrl), new Uri(groupMembersRequest.RequestUrl));
            Assert.Equal(1, groupMembersRequest.QueryOptions.Count);
            Assert.Equal("$top", groupMembersRequest.QueryOptions[0].Name);
            Assert.Equal("1", groupMembersRequest.QueryOptions[0].Value);
        }

#if false // This test can no longer run at this time since the Graph does not have a $ref navigation that allows filter.
        /// <summary>
        /// Tests the Filter() method on an entity collection that has a $ref navigation.
        /// </summary>
        [TestMethod]
        public void Filter()
        {
            var expectedRequestUrl = string.Format("{0}/groups/groupId/members", this.graphBaseUrl);

            var groupMembersRequest = this.graphServiceClient.Groups["groupId"].Members.Request().Filter("value") as GroupMembersCollectionWithReferencesRequest;

            Assert.IsNotNull(groupMembersRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(groupMembersRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual(1, groupMembersRequest.QueryOptions.Count, "Unexpected number of query options.");
            Assert.AreEqual("$filter", groupMembersRequest.QueryOptions[0].Name, "Unexpected query option name.");
            Assert.AreEqual("value", groupMembersRequest.QueryOptions[0].Value, "Unexpected query option value.");
        }
#endif

#if false // This test can no longer run at this time since the Graph does not have a $ref navigation that allows skip.
        /// <summary>
        /// Tests the Skip() method on an entity collection that has a $ref navigation.
        /// </summary>
        [TestMethod]
        public void Skip()
        {
            var expectedRequestUrl = string.Format("{0}/groups/groupId/members", this.graphBaseUrl);

            var groupMembersRequest = this.graphServiceClient.Groups["groupId"].Members.Request().Skip(1) as GroupMembersCollectionWithReferencesRequest;

            Assert.IsNotNull(groupMembersRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(groupMembersRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual(1, groupMembersRequest.QueryOptions.Count, "Unexpected number of query options.");
            Assert.AreEqual("$skip", groupMembersRequest.QueryOptions[0].Name, "Unexpected query option name.");
            Assert.AreEqual("1", groupMembersRequest.QueryOptions[0].Value, "Unexpected query option value.");
        }
#endif

        /// <summary>
        /// Tests the OrderBy() method on an entity collection that has a $ref navigation.
        /// </summary>
        [Fact]
        public void OrderBy()
        {
            var expectedRequestUrl = string.Format("{0}/groups/groupId/members", this.graphBaseUrl);

            var groupMembersRequest = this.graphServiceClient.Groups["groupId"].Members.Request().OrderBy("value") as GroupMembersCollectionWithReferencesRequest;

            Assert.NotNull(groupMembersRequest);
            Assert.Equal(new Uri(expectedRequestUrl), new Uri(groupMembersRequest.RequestUrl));
            Assert.Equal(1, groupMembersRequest.QueryOptions.Count);
            Assert.Equal("$orderby", groupMembersRequest.QueryOptions[0].Name);
            Assert.Equal("value", groupMembersRequest.QueryOptions[0].Value);
        }
    }
}
