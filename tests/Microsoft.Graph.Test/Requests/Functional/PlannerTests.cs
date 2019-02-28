using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using Async = System.Threading.Tasks;

namespace Microsoft.Graph.Test.Requests.Functional
{
   
    [TestClass]
    [Ignore]
    public class PlannerTests : GraphTestBase
    {
        private Group testGroup;

        [TestCleanup]
        public async void TestCleanUp()
        {
            Group toDelete = testGroup;
            await graphClient.Groups[toDelete.Id].Request().DeleteAsync();
        }

        public async Async.Task<Group> CreateGroup()
        {
            // Create a group. There can only be a single planner plan per group.
            var clientOnlyGroup = new Group();
            clientOnlyGroup.Description = "A temporary group to that contains a planner plan that we'll test.";
            clientOnlyGroup.DisplayName = "Test group";
            clientOnlyGroup.GroupTypes = new List<string>() { "Unified" };
            clientOnlyGroup.MailEnabled = true;
            clientOnlyGroup.MailNickname = "BobTestGroup" + Guid.NewGuid();
            clientOnlyGroup.SecurityEnabled = false;

            // Call Graph service API to create the new group.
            var syncdGroup = await graphClient.Groups.Request().AddAsync(clientOnlyGroup);

            var thisUser = await graphClient.Me.Request().GetAsync();

            // add the current user as member.
            await graphClient.Groups[syncdGroup.Id].Members.References.Request().AddAsync(thisUser);

            // The group may take a few seconds to be available in Planner.
            await Async.Task.Delay(20000);

            return syncdGroup;
        }

        public Async.Task DeleteGroup(Group group)
        {
            return graphClient.Groups[group.Id].Request().DeleteAsync();
        }

        public async Async.Task<PlannerPlan> CreatePlan(Group owner)
        {
            PlannerPlan forCreate = new PlannerPlan();

            forCreate.Title = "Test Plan" + Guid.NewGuid();
            forCreate.Owner = owner.Id;

            return await graphClient.Planner.Plans.Request().AddAsync(forCreate);
        }

        // Working as expected.
        [TestMethod]
        public async Async.Task PlannerGetPlannerPlan()
        {
            try
            {
                var plannerPlan = await GetPlannerPlan();

                Assert.IsNotNull(plannerPlan);
                Assert.IsInstanceOfType(plannerPlan, typeof(PlannerPlan));
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                Assert.Fail("Something happened, check out a trace. Error: {0}", e.Error);
            }
        }

        public async Async.Task<PlannerPlan> GetPlannerPlan(string planId = "")
        {
            if (planId == "")
            {
                planId = "X64sGtz57EO5q2KVrqEfVmUAEAYw"; // OnlineMarketingGroup PlanId in test tenant.
            }

            try
            {
                return await graphClient.Planner.Plans[planId].Request().GetAsync();
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                Assert.Fail("Tried to get a PlannerPlan and failed. Error: {0}", e.Error);
            }
            return null;
        }

        // Successful 4/27/2017 - Gets planner tasks
        [TestMethod]
        public async Async.Task PlannerGetPlannerTasks()
        {
            try
            {
                // Get a default plan
                var plannerPlan = await GetPlannerPlan();

                var plannerPlanTasksCollectionPage = await graphClient.Planner.Plans[plannerPlan.Id].Tasks.Request().GetAsync();

                Assert.IsNotNull(plannerPlanTasksCollectionPage);
                Assert.IsInstanceOfType(plannerPlanTasksCollectionPage, typeof(IPlannerPlanTasksCollectionPage));
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                Assert.Fail("Something happened, check out a trace. Error: {0}", e.Error);
            }
        }

        // Successful 4/27/2017 - Creates a task without a bucket.
        [TestMethod]
        //https://developer.microsoft.com/en-us/graph/docs/api-reference/beta/api/planner_post_tasks
        public async Async.Task PlannerTaskCreate()
        {
            // Get a default plan
            var group = await CreateGroup();
            this.testGroup = group;
            await Async.Task.Delay(5000);
            var plannerPlan = await CreatePlan(group);

            PlannerTask taskToCreate = new PlannerTask();
            taskToCreate.PlanId = plannerPlan.Id;
            taskToCreate.Title = "New task title";
            taskToCreate.Assignments = new PlannerAssignments();
            taskToCreate.Assignments.AddAssignee("me");
            taskToCreate.AppliedCategories = new PlannerAppliedCategories();
            taskToCreate.AppliedCategories.Category3 = true;
            taskToCreate.DueDateTime = DateTimeOffset.UtcNow.AddDays(3);

            PlannerTask createdTask = await graphClient.Planner.Tasks.Request().AddAsync(taskToCreate);

            Assert.IsNotNull(createdTask);
            Assert.AreEqual(taskToCreate.Title, createdTask.Title);
            Assert.AreEqual(1, createdTask.Assignments.Count);
            Assert.AreEqual(createdTask.Assignments.Assignees.First(), createdTask.Assignments.First().Value.AssignedBy.User.Id);
            Assert.AreEqual(true, createdTask.AppliedCategories.Category3);
            Assert.AreEqual(taskToCreate.DueDateTime, createdTask.DueDateTime);
        }

        [TestMethod]
        public async Async.Task PlannerTaskDetailsUpdate()
        {
            var group = await CreateGroup();
            this.testGroup = group;
            var plannerPlan = await CreatePlan(group); // You may need to add a Delay in this since there is some latency.

            PlannerTask taskToCreate = new PlannerTask();
            taskToCreate.PlanId = plannerPlan.Id;
            taskToCreate.Title = "New task title";

            PlannerTask createdTask = await graphClient.Planner.Tasks.Request().AddAsync(taskToCreate);
            PlannerTaskDetails taskDetails = await graphClient.Planner.Tasks[createdTask.Id].Details.Request().GetAsync();

            PlannerTaskDetails taskDetailsToUpdate = new PlannerTaskDetails();
            taskDetailsToUpdate.Checklist = new PlannerChecklistItems();
            string checklistItemId1 = taskDetailsToUpdate.Checklist.AddChecklistItem("Do something");
            string checklistItemId2 = taskDetailsToUpdate.Checklist.AddChecklistItem("Do something else");

            taskDetailsToUpdate.References = new PlannerExternalReferences();
            taskDetailsToUpdate.References.AddReference("http://developer.microsoft.com", "Developer resources");

            taskDetailsToUpdate.PreviewType = PlannerPreviewType.Checklist;
            taskDetailsToUpdate.Description = "Description of the task";

            string etag = taskDetails.GetEtag();
            PlannerTaskDetails updatedTaskDetails = await graphClient.Planner.Tasks[createdTask.Id].Details.Request().Header("If-Match", etag).Header("Prefer", "return=representation").UpdateAsync(taskDetailsToUpdate);

            Assert.AreEqual("Description of the task", updatedTaskDetails.Description);
            Assert.AreEqual(PlannerPreviewType.Checklist, updatedTaskDetails.PreviewType);
            Assert.AreEqual(2, updatedTaskDetails.Checklist.Count());
            Assert.AreEqual("Do something", updatedTaskDetails.Checklist[checklistItemId1]?.Title);
            Assert.AreEqual("Do something else", updatedTaskDetails.Checklist[checklistItemId2]?.Title);
            Assert.AreEqual(1, updatedTaskDetails.References.Count());
            Assert.AreEqual("Developer resources", updatedTaskDetails.References["http://developer.microsoft.com"]?.Alias);
        }

        [TestMethod]
        public async Async.Task PlannerPlanDetailsUpdate()
        {
            var group = await CreateGroup();
            this.testGroup = group;
            await Async.Task.Delay(3000); // sometimes we need to delay, the group information needs to be set before we can create a plan.
            var plannerPlan = await CreatePlan(group);

            PlannerPlanDetails planDetails = await graphClient.Planner.Plans[plannerPlan.Id].Details.Request().GetAsync();

            string etag = planDetails.GetEtag();
            PlannerPlanDetails planDetailsToUpdate = new PlannerPlanDetails();
            planDetailsToUpdate.CategoryDescriptions = new PlannerCategoryDescriptions();
            planDetailsToUpdate.CategoryDescriptions.Category1 = "First category";
            planDetailsToUpdate.CategoryDescriptions.Category4 = "Category 4";
            planDetailsToUpdate.SharedWith = new PlannerUserIds();
            planDetailsToUpdate.SharedWith.Add("me");

            PlannerPlanDetails updatedPlanDetails = await graphClient.Planner.Plans[plannerPlan.Id].Details.Request().Header("If-Match", etag).Header("Prefer", "return=representation").UpdateAsync(planDetailsToUpdate);

            Assert.AreEqual("First category", updatedPlanDetails.CategoryDescriptions.Category1);
            Assert.AreEqual("Category 4", updatedPlanDetails.CategoryDescriptions.Category4);

            // plan creator is the current user as well, we can get the id from there.
            Assert.IsTrue(updatedPlanDetails.SharedWith.Contains(plannerPlan.CreatedBy.User.Id));
        }

        [TestMethod]
        public async Async.Task PlannerTaskAssignedToTaskBoardFormatUpdate()
        {
            var group = await CreateGroup();
            this.testGroup = group;
            var plannerPlan = await CreatePlan(group);

            PlannerTask taskToCreate = new PlannerTask();
            taskToCreate.PlanId = plannerPlan.Id;
            taskToCreate.Title = "Top";
            taskToCreate.Assignments = new PlannerAssignments();
            taskToCreate.Assignments.AddAssignee("me");

            PlannerTask topTask = await graphClient.Planner.Tasks.Request().AddAsync(taskToCreate);

            taskToCreate = new PlannerTask();
            taskToCreate.PlanId = plannerPlan.Id;
            taskToCreate.Title = "Bottom";
            taskToCreate.Assignments = new PlannerAssignments();
            taskToCreate.Assignments.AddAssignee("me");

            PlannerTask bottomTask = await graphClient.Planner.Tasks.Request().AddAsync(taskToCreate);

            taskToCreate = new PlannerTask();
            taskToCreate.PlanId = plannerPlan.Id;
            taskToCreate.Title = "Middle";
            taskToCreate.Assignments = new PlannerAssignments();
            taskToCreate.Assignments.AddAssignee("me");

            PlannerTask middleTask = await graphClient.Planner.Tasks.Request().AddAsync(taskToCreate);

            // give it two second to ensure asynchronous processing is completed.
            await Async.Task.Delay(10000);

            var myUserId = plannerPlan.CreatedBy.User.Id;

            // get assigned to task board formats of the tasks in plan.
            var taskIdsWithTaskBoardFormats = await graphClient.Planner.Plans[plannerPlan.Id].Tasks.Request().Select("id").Expand("assignedToTaskBoardFormat").GetAsync();
            IDictionary<string, PlannerAssignedToTaskBoardTaskFormat> formatsByTasks = taskIdsWithTaskBoardFormats.ToDictionary(item => item.Id, item => item.AssignedToTaskBoardFormat);

            var bottomTaskFormatUpdate = new PlannerAssignedToTaskBoardTaskFormat();
            bottomTaskFormatUpdate.OrderHintsByAssignee = new PlannerOrderHintsByAssignee();
            bottomTaskFormatUpdate.OrderHintsByAssignee[myUserId] = $"{formatsByTasks[topTask.Id].GetOrderHintForAssignee(myUserId)} !"; // after top task.

            var middleTaskFormatUpdate = new PlannerAssignedToTaskBoardTaskFormat();
            middleTaskFormatUpdate.OrderHintsByAssignee = new PlannerOrderHintsByAssignee();
            middleTaskFormatUpdate.OrderHintsByAssignee[myUserId] = $"{formatsByTasks[topTask.Id].GetOrderHintForAssignee(myUserId)} {bottomTaskFormatUpdate.GetOrderHintForAssignee(myUserId)}!"; // after top task, before bottom task's client side new value.

            string etag = formatsByTasks[bottomTask.Id].GetEtag();
            formatsByTasks[bottomTask.Id] = await graphClient
                .Planner
                .Tasks[bottomTask.Id]
                .AssignedToTaskBoardFormat
                .Request()
                .Header("If-Match", etag)
                .Header("Prefer", "return=representation")
                .UpdateAsync(bottomTaskFormatUpdate);

            etag = formatsByTasks[middleTask.Id].GetEtag();
            formatsByTasks[middleTask.Id] = await graphClient
                .Planner
                .Tasks[middleTask.Id]
                .AssignedToTaskBoardFormat
                .Request()
                .Header("If-Match", etag)
                .Header("Prefer", "return=representation")
                .UpdateAsync(middleTaskFormatUpdate);

            // verify final order
            var orderedTaskFormats = formatsByTasks.OrderBy(kvp => kvp.Value.GetOrderHintForAssignee(myUserId), StringComparer.Ordinal).ToList();
            Assert.AreEqual(topTask.Id, orderedTaskFormats[0].Key);
            Assert.AreEqual(middleTask.Id, orderedTaskFormats[1].Key);
            Assert.AreEqual(bottomTask.Id, orderedTaskFormats[2].Key);
        }
    }
}
