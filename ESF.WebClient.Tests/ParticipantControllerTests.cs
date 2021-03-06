﻿using System;
using NUnit.Framework;
using ESF.WebClient.Controllers;
using System.Web.Mvc;
using Moq;
using ESF.Core.Services;
using ESF.Commons.Exceptions;

namespace ESF.WebClient.Tests
{
    [TestFixture]
    public class ParticipantControllerTests
    {
        private ParticipantController controllerUnderTest;

        private Mock<IParticipantService> participantService;

        private Guid participantId = new Guid("399864D2-2D89-47A6-B875-EFE948BBED6E");

        private ParticipantDetailsViewModel participantDetailsViewModel;

        [SetUp]
        public void SetUp()
        {
            participantService = new Mock<IParticipantService>();

            controllerUnderTest = new ParticipantController(participantService.Object);

            participantDetailsViewModel = new ParticipantDetailsViewModel();
        }

        [Test]
        public void ViewPersonalDetails_Get_ShowsPersonalDetails()
        { 
            // Arrange
            participantService.Setup(s => s.RetrieveParticipantViewModel(It.IsAny<Guid>()))
                .Returns(participantDetailsViewModel);

            // Act
            var viewResult = controllerUnderTest.ViewParticipant(participantId) as ViewResult;

            // Assert
            Assert.IsNotNull(viewResult, "ActionResult of type ViewResult expected. Something else, or nothign was returned.");
            Assert.IsInstanceOf(typeof(ParticipantDetailsViewModel), viewResult.Model, "Model of type PersonalDetailsModel expected.");
            participantService.Verify(s => s.RetrieveParticipantViewModel(It.IsAny<Guid>()), Times.Exactly(1));
        }

        [Test, ExpectedException(typeof(AssertionFailedException)), Ignore("Until WebSecurity has been mocked.")]
        public void ViewPersonalDetails_Get_WhenParticipantIdEmptyGuid_ThrowsAssertionFailedException()
        {
            controllerUnderTest.ViewParticipant(Guid.Empty);
        }
    }
}
