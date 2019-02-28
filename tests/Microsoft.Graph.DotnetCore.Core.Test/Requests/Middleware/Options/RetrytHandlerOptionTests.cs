﻿// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Core.Test.Requests.Middleware.Options
{
    using System.Net.Http;
    using Xunit;

    public class RetrytHandlerOptionTests
    {
        [Fact]
        public void RetrytHandlerOption_ShouldUseDefaultValuesIfNotSpecified()
        {
            var retryOptions = new RetryHandlerOption();
            Assert.Equal(RetryHandlerOption.DEFAULT_DELAY, retryOptions.Delay);
            Assert.Equal(RetryHandlerOption.DEFAULT_MAX_RETRY, retryOptions.MaxRetry);
            Assert.True(retryOptions.ShouldRetry(0, 0, null));
        }

        [Fact]
        public void RetrytHandlerOption_ShouldThrowMaximumValueExceededExceptionForDelayAndMaxRetry()
        {
            try
            {
                Assert.Throws<ServiceException>(() => new RetryHandlerOption() { Delay = 181, MaxRetry = 11 });
            }
            catch (ServiceException exception)
            {
                Assert.Equal(exception.Error.Code, ErrorConstants.Codes.MaximumValueExceeded);
                throw;
            }
        }

        [Fact]
        public void RetrytHandlerOption_ShouldThrowMaximumValueExceededExceptionForDelay()
        {
            try
            {
                Assert.Throws<ServiceException>(() => new RetryHandlerOption() { Delay = 200 });
            }
            catch (ServiceException exception)
            {
                Assert.Equal(exception.Error.Code, ErrorConstants.Codes.MaximumValueExceeded);
                Assert.Equal(exception.Error.Message, string.Format(ErrorConstants.Messages.MaximumValueExceeded, "Delay", RetryHandlerOption.MAX_DELAY));
                throw;
            }
        }

        [Fact]
        public void RetrytHandlerOption_ShouldThrowMaximumValueExceededExceptionForMaxRetry()
        {
            try
            {
                Assert.Throws<ServiceException>(() => new RetryHandlerOption() { Delay = 180, MaxRetry = 15 });
            }
            catch (ServiceException exception)
            {
                Assert.Equal(exception.Error.Code, ErrorConstants.Codes.MaximumValueExceeded);
                Assert.Equal(exception.Error.Message, string.Format(ErrorConstants.Messages.MaximumValueExceeded, "MaxRetry", RetryHandlerOption.MAX_MAX_RETRY));
                throw;
            }
        }

        [Fact]
        public void RetrytHandlerOption_ShouldAcceptCorrectValue()
        {
            int delay = 20;
            int maxRetry = 5;
            var retryOptions = new RetryHandlerOption() { Delay = delay, MaxRetry = maxRetry, ShouldRetry = ShouldRetry };
            Assert.Equal(delay, retryOptions.Delay);
            Assert.Equal(maxRetry, retryOptions.MaxRetry);
            Assert.Equal(ShouldRetry, retryOptions.ShouldRetry);
        }

        private bool ShouldRetry(int delay, int attempts, HttpResponseMessage rwsponse)
        {
            return false;
        }
    }
}
