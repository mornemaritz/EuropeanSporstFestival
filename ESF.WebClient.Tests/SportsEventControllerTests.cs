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
                new SportsEventItem(Guid.NewGuid(), "Football"),
                new SportsEventItem(Guid.NewGuid(), "Tennis")
            };
        }
    }
}
