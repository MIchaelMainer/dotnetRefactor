﻿// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Graph.DotnetCore.Test.Requests.Functional
{
    public class UserTests : GraphTestBase
    {


        [Fact(Skip = "No CI set up for functional tests - add email addresses to run this test.")]
        public async System.Threading.Tasks.Task UserGetMailtipsTestEnumFlags()
        {
            try
            {
                var emailAddresses = new List<string>();
                emailAddresses.Add("katiej@MOD810997.onmicrosoft.com");
                emailAddresses.Add("garretv@MOD810997.onmicrosoft.com");
                emailAddresses.Add("annew@MOD810997.onmicrosoft.com");

                var mailTipsCollectionPage = await graphClient.Me.GetMailTips(emailAddresses, MailTipsType.AutomaticReplies |
                                                                                              MailTipsType.CustomMailTip |
                                                                                              MailTipsType.MaxMessageSize |
                                                                                              MailTipsType.RecipientScope |
                                                                                              MailTipsType.TotalMemberCount).Request().PostAsync();

                foreach (var mt in mailTipsCollectionPage)
                {
                    // All of the supplied users should have an email address.
                    Assert.NotNull(mt.EmailAddress);
                }
            }
            catch (Exception e)
            {
                Assert.True(false, "Something happened, check out a trace. Error code: " + e.Message);
            }
        }

        // Currently (10/5/2016), you can only set the mailboxsettings directly on the property, 
        // not with a patched user. Opened issue against service API.
        [Fact(Skip = "No CI set up for functional tests")]
        public async System.Threading.Tasks.Task UserGetSetAutomaticReply()
        {
            try
            {
                var query = new List<Option>()
                {
                    new QueryOption("$select", "mailboxsettings")
                };

                var user = await graphClient.Me.Request(query).GetAsync();

                await graphClient.Me.Request().UpdateAsync(user);
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                Assert.True(false, $"The service doesn't yet support PATCH on entity with mailboxsettings: {e.Error.Code}");
            }

            /* Notes
             * 
             * GET https://graph.microsoft.com/v1.0/me?$select=mailboxsettings 
             * 
             * RESPONSE
             * 
             * {
                    "@odata.context": "https://graph.microsoft.com/v1.0/$metadata#users(mailboxSettings)/$entity",
                    "id": "c8616fa2-6a9e-4196-9912-e7fbea37fbd1@d0b7ccde-8426-4e94-a77b-a53e1bcd66c6",
                    "mailboxSettings": {
                        "automaticRepliesSetting": {
                            "status": "alwaysEnabled",
                            "externalAudience": "all",
                            "scheduledStartDateTime": {
                                "dateTime": "2016-09-30T21:00:00.0000000",
                                "timeZone": "UTC"
                            },
                            "scheduledEndDateTime": {
                                "dateTime": "2016-10-01T21:00:00.0000000",
                                "timeZone": "UTC"
                            },
                            "internalReplyMessage": "<html>\n<body>\nI am currently on vacation.\n</body>\n</html>\n",
                            "externalReplyMessage": ""
                        },
                        "timeZone": "Pacific Standard Time",
                        "language": {
                            "locale": "en-US",
                            "displayName": "English (United States)"
                        }
                    }
                }
             * GET https://graph.microsoft.com/v1.0/me/mailboxsettings
             * 
             * RESPONSE
             * 
             * {
                    "@odata.context": "https://graph.microsoft.com/v1.0/$metadata#users('c8616fa2-6a9e-4196-9912-e7fbea37fbd1')/mailboxSettings",
                    "automaticRepliesSetting": {
                        "status": "alwaysEnabled",
                        "externalAudience": "all",
                        "scheduledStartDateTime": {
                            "dateTime": "2016-09-30T21:00:00.0000000",
                            "timeZone": "UTC"
                        },
                        "scheduledEndDateTime": {
                            "dateTime": "2016-10-01T21:00:00.0000000",
                            "timeZone": "UTC"
                        },
                        "internalReplyMessage": "<html>\n<body>\nI am currently on vacation. Sorry :(\n</body>\n</html>\n",
                        "externalReplyMessage": ""
                    },
                    "timeZone": "Pacific Standard Time",
                    "language": {
                        "locale": "en-US",
                        "displayName": "English (United States)"
                    }
                }
             * This PATCH is successful
             * PATCH https://graph.microsoft.com/v1.0/me/mailboxsettings
             * 
             * {
                    "@odata.context": "https://graph.microsoft.com/v1.0/$metadata#users('c8616fa2-6a9e-4196-9912-e7fbea37fbd1')/mailboxSettings",
                    "automaticRepliesSetting": {
                        "status": "alwaysEnabled",
                        "externalAudience": "all",
                        "scheduledStartDateTime": {
                            "dateTime": "2016-09-30T21:00:00.0000000",
                            "timeZone": "UTC"
                        },
                        "scheduledEndDateTime": {
                            "dateTime": "2016-10-01T21:00:00.0000000",
                            "timeZone": "UTC"
                        },
                        "internalReplyMessage": "<html>\n<body>\nI am currently on vacation. Sorry :(\n</body>\n</html>\n",
                        "externalReplyMessage": ""
                    },
                    "timeZone": "Pacific Standard Time",
                    "language": {
                        "locale": "en-US"
                    }
                }
             * This PATCH is unsuccessful
             * PATCH https://graph.microsoft.com/v1.0/me
             * 
             * {
             *      "id": "c8616fa2-6a9e-4196-9912-e7fbea37fbd1@d0b7ccde-8426-4e94-a77b-a53e1bcd66c6",
                    "@odata.context": "https://graph.microsoft.com/v1.0/$metadata#users(mailboxSettings)/$entity"
                    "mailboxSettings": {
                        "automaticRepliesSetting": {
                            "status": "alwaysEnabled",
                            "externalAudience": "all",
                            "scheduledStartDateTime": {
                                "dateTime": "10/03/2016 07:00:00",
                                "timeZone": "UTC"
                            },
                            "scheduledEndDateTime": {
                                "dateTime": "10/04/2016 07:00:00",
                                "timeZone": "UTC"
                            },
                            "internalReplyMessage": "<html>\n<body>\nI am currently on vacation. Sorry :(\n</body>\n</html>\n",
                            "externalReplyMessage": ""
                        },
                        "timeZone": "Pacific Standard Time",
                        "language": {
                            "locale": "en-US",
                            "displayName": "English (United States)"
                        }
                    },
                }
             */


        }

        // Filter on displayname
        // https://github.com/microsoftgraph/msgraph-sdk-dotnet/issues/41
        [Fact(Skip = "No CI set up for functional tests")]
        public async System.Threading.Tasks.Task UserFilterStartsWith()
        {
            try
            {
                var usersQuery = await graphClient.Users.Request().Filter("startswith(displayName,'A')").GetAsync();
                foreach (User u in usersQuery)
                {
                    Assert.StartsWith("A", u.DisplayName); // Expected a display name that started with the letter A.
                }
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                Assert.True(false, $"Something happened, check out a trace. Error code: {e.Error.Code}");
            }
        }

        // Get the test user's photo.
        [Fact(Skip = "No CI set up for functional tests")]
        public async System.Threading.Tasks.Task UserGetPhoto()
        {
            try
            {
                // Gets the user's photo.
                // http://graph.microsoft.io/en-us/docs/api-reference/v1.0/api/profilephoto_get
                // GET https://graph.microsoft.com/v1.0/me/photo/$value
                var originalPhoto = await graphClient.Me.Photo.Content.Request().GetAsync();

                Assert.NotNull(originalPhoto); // The photo value is null
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                if (e.Error.Code == "ErrorItemNotFound")
                {
                    Assert.True(false, "We didn't get a photo back from the service. Check that the target account has a photo.");
                }
                else
                {
                    Assert.True(false, "Something happened. Catch the HTTP traffic and find out what happened.");
                }
            }
        }

        // Update the test user's photo
        //[Fact(Skip = "No CI set up for functional tests. Need to update with ImageSharp.")]
        //public async System.Threading.Tasks.Task UserUpdatePhoto()
        //{
        //    try
        //    {
        //        System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
        //        var buff = (byte[])converter.ConvertTo(Microsoft.Graph.Test.Properties.Resources.hamilton, typeof(byte[]));
        //        using (System.IO.MemoryStream ms = new System.IO.MemoryStream(buff))
        //        {
        //            // Sets the user's photo.
        //            // http://graph.microsoft.io/en-us/docs/api-reference/v1.0/api/profilephoto_update
        //            // PUT https://graph.microsoft.com/v1.0/me/photo/$value
        //            await graphClient.Me.Photo.Content.Request().PutAsync(ms);
        //        }
        //    }
        //    catch (Microsoft.Graph.ServiceException e)
        //    {
        //        Assert.True(false, $"Something happened, check out a trace. Error code: {e.Error.Code}");
        //    }
        //}

        // Get the test user.
        [Fact(Skip = "No CI set up for functional tests")]
        public async System.Threading.Tasks.Task UserGetUser()
        {
            try
            {
                var user = await graphClient.Me.Request().GetAsync();
                Assert.NotNull(user.UserPrincipalName); // User principal name is not set.
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                Assert.True(false, $"Something happened. Error code: {e.Error.Code}");
            }
        }

        [Fact(Skip = "No CI set up for functional tests")]
        public async System.Threading.Tasks.Task UserGetManager()
        {
            try
            {
                var managerDirObj = (User)await graphClient.Me.Manager.Request().GetAsync();

                Assert.NotNull(managerDirObj); // The manager wasn't returned.
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                Assert.True(false, $"Something happened. Error code: {e.Error.Code}");
            }
        }

        // PUT https://graph.microsoft.com/v1.0/me/manager/$ref
        // {    "@odata.id": "https://graph.microsoft.com/v1.0/users/55aa3346-08cb-4e98-8567-879b039a72c1" }
        // http://graph.microsoft.io/en-us/docs/api-reference/v1.0/api/user_post_manager
        // We are getting and setting the user's manager.
        // Must be an admin to set this
        [Fact(Skip = "No CI set up for functional tests")]
        public async System.Threading.Tasks.Task UserUpdateManager()
        {
            try
            {
                var managerDirObj = (User)await graphClient.Me.Manager.Request().GetAsync();

                await graphClient.Me.Manager.Reference.Request().PutAsync(managerDirObj.Id);
                Assert.NotNull(managerDirObj); // The manager wasn't returned.
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                Assert.True(false, $"Something happened. Error code: {e.Error.Code}");
            }
        }

        [Fact(Skip = "No CI set up for functional tests")]
        public async System.Threading.Tasks.Task UserAssignLicense()
        {
            try
            {
                // This is expected to fail since we aren't providing licenses.
                var user = await graphClient.Me.AssignLicense(new List<AssignedLicense>(), new List<System.Guid>()).Request().PostAsync();
                Assert.Null(user); // Expected that the request would cause a ServiceException. Last assumption is that setting an empty collection of licenses causes an error.

            }
            catch (Microsoft.Graph.ServiceException e)
            {
                Assert.Equal("Request_BadRequest", e.Error.Code); // Expected error: Request_BadRequest, actual error: {0}
            }
        }

        /// <summary>
        /// Tests building a request for an action with a required parameter that's set.
        /// Tests the get member groups action with a set parameter.
        /// </summary>
        [Fact(Skip = "No CI set up for functional tests")]
        public async System.Threading.Tasks.Task UserGetMemberGroups_SecurityEnabledOnly_ValueSet()
        {
            try
            {
                var getMemberGroupsRequest = graphClient.Me
                                                        .GetMemberGroups(true)
                                                        .Request() as DirectoryObjectGetMemberGroupsRequest;

                var directoryObjectGetMemberGroupsCollectionPage = await getMemberGroupsRequest.PostAsync();

                Assert.NotNull(directoryObjectGetMemberGroupsCollectionPage); // Unexpected results.
                Assert.Equal("POST", getMemberGroupsRequest.Method); // Unexpected HTTP method
                Assert.True(getMemberGroupsRequest.RequestBody.SecurityEnabledOnly.Value, "Unexpected value for SecurityEnabledOnly in request body.");
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                Assert.True(false, $"Something happened. Error code: {e.Error.Code}");
            }
        }

        /// <summary>
        /// Tests building a request for an action with a required parameter set to null.
        /// Tests the get member groups action without a set parameter, default is null.
        /// </summary>
        [Fact(Skip = "No CI set up for functional tests")]
        public async System.Threading.Tasks.Task UserGetMemberGroups_SecurityEnabledOnly_ValueNotSet()
        {
            try
            {
                var getMemberGroupsRequest = graphClient.Me
                                                        .GetMemberGroups()
                                                        .Request() as DirectoryObjectGetMemberGroupsRequest;

                var directoryObjectGetMemberGroupsCollectionPage = await getMemberGroupsRequest.PostAsync();
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                Assert.Equal("Request_BadRequest", e.Error.Code); // Unexpected error occurred.
            }
        }

        // Need admin perms.
        [Fact(Skip = "No CI set up for functional tests")]
        // Addressing https://github.com/microsoftgraph/msgraph-sdk-dotnet/issues/28
        public async System.Threading.Tasks.Task UpdateUser()
        {
            try
            {
                var me = await graphClient.Me.Request().GetAsync();

                var oldMe = new User()
                {
                    GivenName = me.GivenName
                };

                var betterMe = new User()
                {
                    GivenName = "Beth"
                };

                // Update the user to Beth
                await graphClient.Users[me.UserPrincipalName].Request().UpdateAsync(betterMe);

                // Update the user back to me.
                await graphClient.Users[me.UserPrincipalName].Request().UpdateAsync(oldMe);
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                Assert.True(false, $"Something happened. Error code: {e.Error.Code}");
            }
        }
    }
}
