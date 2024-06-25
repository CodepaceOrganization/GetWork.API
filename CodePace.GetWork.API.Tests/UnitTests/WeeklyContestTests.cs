using NUnit.Framework;
using System;
using CodePace.GetWork.API.contest.Domain.Model.Entities;

namespace CodePace.GetWork.Tests
{
    [TestFixture]
    public class WeeklyContestTests
    {
        [Test]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            int contestId = 1;
            string title = "Sample Contest";
            string urlImage = "http://example.com/image.jpg";
            DateTime date = DateTime.Now;

            // Act
            var weeklyContest = new WeeklyContest(contestId, title, urlImage, date);

            // Assert
            Assert.AreEqual(contestId, weeklyContest.ContestId);
            Assert.AreEqual(title, weeklyContest.Title);
            Assert.AreEqual(urlImage, weeklyContest.UrlImage);
            Assert.AreEqual(date, weeklyContest.Date);
        }

        [Test]
        public void UpdateTitle_ShouldUpdateTitle()
        {
            // Arrange
            var weeklyContest = new WeeklyContest(1, "Sample Contest", "http://example.com/image.jpg", DateTime.Now);
            string newTitle = "Updated Contest Title";

            // Act
            weeklyContest.UpdateTitle(newTitle);

            // Assert
            Assert.AreEqual(newTitle, weeklyContest.Title);
        }

        [Test]
        public void UpdateTitle_ShouldThrowException_WhenTitleIsNullOrEmpty()
        {
            // Arrange
            var weeklyContest = new WeeklyContest(1, "Sample Contest", "http://example.com/image.jpg", DateTime.Now);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => weeklyContest.UpdateTitle(null));
            Assert.Throws<ArgumentException>(() => weeklyContest.UpdateTitle(""));
        }

        [Test]
        public void UpdateUrlImage_ShouldUpdateUrlImage()
        {
            // Arrange
            var weeklyContest = new WeeklyContest(1, "Sample Contest", "http://example.com/image.jpg", DateTime.Now);
            string newUrlImage = "http://example.com/newimage.jpg";

            // Act
            weeklyContest.UpdateUrlImage(newUrlImage);

            // Assert
            Assert.AreEqual(newUrlImage, weeklyContest.UrlImage);
        }

        [Test]
        public void UpdateUrlImage_ShouldThrowException_WhenUrlImageIsNullOrEmpty()
        {
            // Arrange
            var weeklyContest = new WeeklyContest(1, "Sample Contest", "http://example.com/image.jpg", DateTime.Now);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => weeklyContest.UpdateUrlImage(null));
            Assert.Throws<ArgumentException>(() => weeklyContest.UpdateUrlImage(""));
        }

        [Test]
        public void UpdateDate_ShouldUpdateDate()
        {
            // Arrange
            var weeklyContest = new WeeklyContest(1, "Sample Contest", "http://example.com/image.jpg", DateTime.Now);
            DateTime newDate = DateTime.Now.AddDays(1);

            // Act
            weeklyContest.UpdateDate(newDate);

            // Assert
            Assert.AreEqual(newDate, weeklyContest.Date);
        }

        [Test]
        public void UpdateDate_ShouldThrowException_WhenDateIsDefault()
        {
            // Arrange
            var weeklyContest = new WeeklyContest(1, "Sample Contest", "http://example.com/image.jpg", DateTime.Now);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => weeklyContest.UpdateDate(default));
        }
    }
}
