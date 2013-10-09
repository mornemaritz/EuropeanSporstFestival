using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ESF.WebClient.Controllers;
using Moq;
using ESF.Core.Services;
using System.Collections.ObjectModel;
using System.Web.Mvc;

namespace ESF.WebClient.Tests
{
    [TestFixture]
    public class SportsEventControllerTests
    {
        private SportsEventController controllerUnderTest;

        private Mock<IParticipantService> participantService;
        private Mock<ISportsEventService> sportsEventService;

        private ICollection<SportsEventItem> sportsEvents;
        private Guid participantId = Guid.NewGuid();

        [SetUp]
        public void SetUp()
        {
            participantService = new Mock<IParticipantService>();
            sportsEventService = new Mock<ISportsEventService>();

            controllerUnderTest = new SportsEventController(participantService.Object, sportsEventService.Object);

            sportsEvents = new Collection<SportsEventItem> 
            {
                new SportsEventItem{ SportsEventId = Guid.NewGuid(), SportsEventName = "Football"},
                new SportsEventItem{ SportsEventId = Guid.NewGuid(), SportsEventName = "Tennis"}
            };
        }

        [Test]
        public void SignUp_Get_RetrievesAvailableSportEvents()
        {
            // Arrange
            sportsEventService.Setup(s => s.FindSportEventsAvailableToParticipant(It.IsAny<Guid>()))
                .Returns(sportsEvents);

            // Act
            var viewResult = controllerUnderTest.SignUp(participantId) as ViewResult;

            // Assert
            Assert.IsNotNull(viewResult, "ActionResult of type ViewResult expected. Something else, or nothign was returned.");

            var model = viewResult.Model as SportsEventSignUpModel;

            Assert.IsNotNull(viewResult.Model, "Model of type SportsEventSignUpModel expected.");
            Assert.AreEqual(participantId, model.ParticipantId);
            sportsEventService.Verify(s => s.FindSportEventsAvailableToParticipant(participantId), Times.Exactly(1));
        }
    }
}
