using System;
using ESF.Commons.Utilities;
using Moq;
using NUnit.Framework;

namespace ESF.Domain.Tests
{
    [TestFixture]
    public class ScheduledSportEventTests
    {
        private Mock<ScheduledSportEvent> otherEvent;
        private ScheduledSportEvent testEvent;

        [SetUp]
        public void SetUp()
        {
            otherEvent = new Mock<ScheduledSportEvent>();

            testEvent = new ScheduledSportEvent("TestEvent", new Festival("Festival", new DateTime(2001, 06, 01)), new Sport("Sport"), 0, Gender.Male, 0, 150, 0, 10, new TimeSpan(10, 00, 00), new TimeSpan(15, 00, 00));
        }

        [Test]
        public void OtherEventEncompassingTestEventOverLaps()
        {
            // Arrange
            otherEvent.SetupGet(e => e.StartDateTime).Returns(new DateTime(2001, 06, 01,8,00,00));
            otherEvent.SetupGet(e => e.EndDateTime).Returns(new DateTime(2001, 06, 01, 16, 00, 00));

            // Act & Assert
            Assert.IsTrue(testEvent.OverLapsWith(otherEvent.Object));
        }

        [Test]
        public void TestEventEncompassingOtherEventOverLaps()
        {
            // Arrange
            otherEvent.SetupGet(e => e.StartDateTime).Returns(new DateTime(2001, 06, 01, 11, 00, 00));
            otherEvent.SetupGet(e => e.EndDateTime).Returns(new DateTime(2001, 06, 01, 14, 00, 00));

            // Act & Assert
            Assert.IsTrue(testEvent.OverLapsWith(otherEvent.Object));
        }

        [Test]
        public void OtherEventWithStartDateTimeSameAsTestEventEndDateTimeOverLaps()
        {
            // Arrange
            otherEvent.SetupGet(e => e.StartDateTime).Returns(new DateTime(2001, 06, 01, 15, 00, 00));
            otherEvent.SetupGet(e => e.EndDateTime).Returns(new DateTime(2001, 06, 01, 16, 00, 00));

            // Act & Assert
            Assert.IsTrue(testEvent.OverLapsWith(otherEvent.Object));
        }

        [Test]
        public void OtherEventWithEndDateTimeSameAsTestEventStartDateTimeOverLaps()
        {
            // Arrange
            otherEvent.SetupGet(e => e.StartDateTime).Returns(new DateTime(2001, 06, 01, 8, 00, 00));
            otherEvent.SetupGet(e => e.EndDateTime).Returns(new DateTime(2001, 06, 01, 10, 00, 00));

            // Act & Assert
            Assert.IsTrue(testEvent.OverLapsWith(otherEvent.Object));
        }

        [Test]
        public void OtherEventWithStartDateTimeBeforeTestEventEndDateTimeOverLaps()
        {
            // Arrange
            otherEvent.SetupGet(e => e.StartDateTime).Returns(new DateTime(2001, 06, 01, 14, 00, 00));
            otherEvent.SetupGet(e => e.EndDateTime).Returns(new DateTime(2001, 06, 01, 16, 00, 00));

            // Act & Assert
            Assert.IsTrue(testEvent.OverLapsWith(otherEvent.Object));
        }

        [Test]
        public void OtherEventWithEndDateTimeAfterTestEventStartDateTimeOverLaps()
        {
            // Arrange
            otherEvent.SetupGet(e => e.StartDateTime).Returns(new DateTime(2001, 06, 01, 8, 00, 00));
            otherEvent.SetupGet(e => e.EndDateTime).Returns(new DateTime(2001, 06, 01, 12, 00, 00));

            // Act & Assert
            Assert.IsTrue(testEvent.OverLapsWith(otherEvent.Object));
        }

        [Test]
        public void OtherEventWithStartDateTimeAfterTestEventEndDateTimeDoesNotOverLap()
        {
            // Arrange
            otherEvent.SetupGet(e => e.StartDateTime).Returns(new DateTime(2001, 06, 01, 16, 00, 00));
            otherEvent.SetupGet(e => e.EndDateTime).Returns(new DateTime(2001, 06, 01, 20, 00, 00));

            // Act & Assert
            Assert.IsFalse(testEvent.OverLapsWith(otherEvent.Object));
        }

        [Test]
        public void OtherEventWithEndDateTimeBeforeTestEventStartDateTimeDoesNotOverLap()
        {
            // Arrange
            otherEvent.SetupGet(e => e.StartDateTime).Returns(new DateTime(2001, 05, 31, 8, 00, 00));
            otherEvent.SetupGet(e => e.EndDateTime).Returns(new DateTime(2001, 05, 31, 16, 00, 00));

            // Act & Assert
            Assert.IsFalse(testEvent.OverLapsWith(otherEvent.Object));
        }
    }
}
