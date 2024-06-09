using NUnit.Framework;
using CodePace.GetWork.API;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Entities;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.ValueObjects;

namespace CodePace.GetWork.Tests
{
    [TestFixture]
    public class TaskProgressTests
    {
        [Test]
        public void Constructor_Default_ShouldInitializeWithDefaults()
        {
            // Arrange & Act
            var taskProgress = new TaskProgress();

            // Assert
            Assert.AreEqual(0, taskProgress.UserId);
            Assert.AreEqual(EProgress.Earrings, taskProgress.Progress);
            Assert.AreEqual(0, taskProgress.TechnicalTaskId);
            Assert.IsNull(taskProgress.TechnicalTask);
        }

        [Test]
        public void Constructor_Parameterized_ShouldInitializeWithGivenValues()
        {
            // Arrange
            int userId = 1;
            int technicalTaskId = 2;

            // Act
            var taskProgress = new TaskProgress(userId, technicalTaskId);

            // Assert
            Assert.AreEqual(userId, taskProgress.UserId);
            Assert.AreEqual(technicalTaskId, taskProgress.TechnicalTaskId);
            Assert.AreEqual(EProgress.Earrings, taskProgress.Progress);
            Assert.IsNull(taskProgress.TechnicalTask);
        }

        [Test]
        public void UpdateUserId_ShouldChangeUserId()
        {
            // Arrange
            var taskProgress = new TaskProgress();
            int newUserId = 3;

            // Act
            taskProgress.UpdateUserId(newUserId);

            // Assert
            Assert.AreEqual(newUserId, taskProgress.UserId);
        }

        [Test]
        public void UpdateProgress_ShouldChangeProgress()
        {
            // Arrange
            var taskProgress = new TaskProgress();
            EProgress newProgress = EProgress.InProgress;

            // Act
            taskProgress.UpdateProgress(newProgress);

            // Assert
            Assert.AreEqual(newProgress, taskProgress.Progress);
        }
    }
}