using NUnit.Framework;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Entities;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.ValueObjects;

namespace CodePace.GetWork.Tests
{
    [TestFixture]
    public class TechnicalTaskTests
    {
        [Test]
        public void Constructor_Default_ShouldInitializeWithDefaults()
        {
            // Arrange & Act
            var technicalTask = new TechnicalTask();

            // Assert
            Assert.AreEqual(string.Empty, technicalTask.Description);
            Assert.AreEqual(EDificultyStatus.Easy, technicalTask.Difficulty);
            Assert.NotNull(technicalTask.TaskProgress);
            Assert.AreEqual(0, technicalTask.TaskProgress.TechnicalTaskId);
        }

        [Test]
        public void Constructor_Parameterized_ShouldInitializeWithGivenValues()
        {
            // Arrange
            string description = "Sample task";
            EDificultyStatus difficulty = EDificultyStatus.Medium;

            // Act
            var technicalTask = new TechnicalTask(description, difficulty);

            // Assert
            Assert.AreEqual(description, technicalTask.Description);
            Assert.AreEqual(difficulty, technicalTask.Difficulty);
            Assert.NotNull(technicalTask.TaskProgress);
            Assert.AreEqual(0, technicalTask.TaskProgress.TechnicalTaskId);
        }

        [Test]
        public void UpdateDescription_ShouldChangeDescription()
        {
            // Arrange
            var technicalTask = new TechnicalTask();
            string newDescription = "Updated task description";

            // Act
            technicalTask.UpdateDescription(newDescription);

            // Assert
            Assert.AreEqual(newDescription, technicalTask.Description);
        }

        [Test]
        public void UpdateDifficulty_ShouldChangeDifficulty()
        {
            // Arrange
            var technicalTask = new TechnicalTask();
            EDificultyStatus newDifficulty = EDificultyStatus.Hard;

            // Act
            technicalTask.UpdateDifficulty(newDifficulty);

            // Assert
            Assert.AreEqual(newDifficulty, technicalTask.Difficulty);
        }
    }
}
