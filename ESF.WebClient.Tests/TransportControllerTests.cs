using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ESF.WebClient.Controllers;
using Moq;
using ESF.Core.Services;
using System.Web.Mvc;
using ESF.Core.Services.Models;
using ESF.Commons.Exceptions;

namespace ESF.WebClient.Tests
{
    [TestFixture]
    public class TransportControllerTests
    {
        private TransportController controllerUnderTest;

        private Mock<IParticipantService> participantService;
        private Mock<ITransportService> transportService;
        private Mock<ISportsEventService> sportEventService;

        private Guid participantGuid = new Guid("4cc8933c-5342-4079-afd4-a2630136d180");
        private ParticipantDetailsModel participantDetailsModel;
        private IList<TransportRequestItem> transportRequestItems;

        private Guid day1Id = new Guid("4dd8933c-5342-4079-afd4-a2630136d180");
        private Guid day1TransportRequestId = new Guid("4aa8933c-5342-4079-afd4-a2630136d180");
        private DateTime day1 = new DateTime(2014,04,18);

        private Guid day2Id = new Guid("4ee8933c-5342-4079-afd4-a2630136d180");
        private Guid day2TransportRequestId = new Guid("4bb8933c-5342-4079-afd4-a2630136d180");
        private DateTime day2 = new DateTime(2014, 04, 19);

        private Guid PickupPoint1Id = new Guid("4ff8933c-5342-4079-afd4-a2630136d180");
        private Guid PickupPoint2Id = new Guid("4118933c-5342-4079-afd4-a2630136d180");

        private IList<FestivalDayItem> festivalDaysWithNoTransportRequests;
        private IList<PickupPointItem> pickupPoints;
        private TransportRequestModel transportRequestModel;

        [SetUp]
        public void SetUp()
        {
            participantService = new Mock<IParticipantService>();
            transportService = new Mock<ITransportService>();
            sportEventService = new Mock<ISportsEventService>();

            controllerUnderTest = new TransportController(participantService.Object, transportService.Object, sportEventService.Object);

            participantDetailsModel = new ParticipantDetailsModel { ParticipantId = participantGuid };
            transportRequestItems = new List<TransportRequestItem>
            {
                new TransportRequestItem(day1TransportRequestId, participantGuid, day1, "Ismali Centre"),
                new TransportRequestItem(day2TransportRequestId, participantGuid, day2, "Ismali Centre"),
            };

            festivalDaysWithNoTransportRequests = new List<FestivalDayItem>
            {
                new FestivalDayItem(day1Id, day1),
                new FestivalDayItem(day2Id, day2)
            };

            pickupPoints = new List<PickupPointItem>
            {
                new PickupPointItem(PickupPoint1Id, "Ismaili Centre"),
                new PickupPointItem(PickupPoint2Id, "Victoria Station"),
            };

            transportRequestModel = new TransportRequestModel
            {
                ParticipantId = participantGuid,
                FestivalDayId = new Guid("4228933c-5342-4079-afd4-a2630136d180"),
                TransportPickupPointId = new Guid("4338933c-5342-4079-afd4-a2630136d180")
            };
        }

        [Test]
        public void ViewTransportShowsExistingTransportRequests()
        {
            // Arrange
            participantService.Setup(s => s.RetrieveParticipant(participantGuid)).Returns(participantDetailsModel);
            transportService.Setup(s => s.FindParticipantTransportRequests(participantGuid)).Returns(transportRequestItems);

            // Act
            var viewResult = controllerUnderTest.ViewTransport(participantGuid) as ViewResult;

            // Assert
            Assert.IsNotNull(viewResult, "An ActionResult of type ViewResult was expected. Something else, or nothing was returned.");
            var transportRequests = viewResult.ViewData.Model as IEnumerable<TransportRequestItem>;
            Assert.IsNotNull(transportRequests, "A collection of TransportRequest items was expected in the ViewBag. Something else, or nothing was found.");
            Assert.AreEqual(2, transportRequests.Count());

            participantService.Verify(s => s.RetrieveParticipant(participantGuid), Times.Exactly(1));
            transportService.Verify(s => s.FindParticipantTransportRequests(participantGuid), Times.Exactly(1));
        }

        [Test]
        public void RequestTransport_Get_SetsEmptyModel()
        { 
            // Arrange
            transportService.Setup(s => s.FindPickupPoints()).Returns(pickupPoints);
            transportService.Setup(x => x.FindDaysWithNoTransportRequests(participantGuid)).Returns(festivalDaysWithNoTransportRequests);

            // Act
            var viewResult = controllerUnderTest.RequestTransport(participantGuid) as ViewResult;

            // Assert
            Assert.IsNotNull(viewResult, "An ActionResult of type ViewResult was expected. Something else, or nothing was returned.");

            var model = viewResult.ViewData.Model as TransportRequestModel;
            Assert.IsNotNull(model, "A model of type TransportRequestModel was expected. Something else, or nothing was returned.");
            Assert.AreEqual(participantGuid, model.ParticipantId, "The ParticipantId was expected to be set in the model.");
            Assert.AreEqual(Guid.Empty, model.FestivalDayId, "The FestivalDayId property on the model was expected to an empty guid.");
            Assert.AreEqual(Guid.Empty, model.TransportPickupPointId, "The TransportPickupPointId property on the model was expected to an empty guid.");
        }

        [Test]
        public void RequestTransport_Get_SetsDaysWithNoTranportRequests()
        {
            // Arrange
            transportService.Setup(s => s.FindPickupPoints()).Returns(pickupPoints);
            transportService.Setup(x => x.FindDaysWithNoTransportRequests(participantGuid)).Returns(festivalDaysWithNoTransportRequests);

            // Act
            var viewResult = controllerUnderTest.RequestTransport(participantGuid) as ViewResult;

            // Assert
            Assert.IsNotNull(viewResult, "An ActionResult of type ViewResult was expected. Something else, or nothing was returned.");
            var actualDays = viewResult.ViewBag.Days as IEnumerable<SelectListItem>;
            
            foreach(var actualDay in actualDays)
            {
                var day = festivalDaysWithNoTransportRequests.SingleOrDefault(d => d.FestivalDayId.ToString() == actualDay.Value);
                Assert.IsNotNull(day, "Expected Item Not found");
                Assert.AreEqual(day.DisplayDate, actualDay.Text, "Mismatching Items found.");
            }

            transportService.Verify(x => x.FindDaysWithNoTransportRequests(participantGuid), Times.Exactly(1));
        }

        [Test]
        public void RequestTransport_Get_SetsTransportPickupPoints()
        {
            // Arrange
            transportService.Setup(s => s.FindPickupPoints()).Returns(pickupPoints);
            transportService.Setup(x => x.FindDaysWithNoTransportRequests(participantGuid)).Returns(festivalDaysWithNoTransportRequests);

            // Act
            var viewResult = controllerUnderTest.RequestTransport(participantGuid) as ViewResult;

            // Assert
            Assert.IsNotNull(viewResult, "An ActionResult of type ViewResult was expected. Something else, or nothing was returned.");

            var actualPickupPoints = viewResult.ViewBag.PickupPoints as IEnumerable<SelectListItem>;
            
            //TODO: Could use IEnumerable<T>.Intersect to test all in single line of code?

            foreach(var actualPickupPoint in actualPickupPoints)
            {
                var pickupPoint = pickupPoints.SingleOrDefault(p => p.PickupPointId.ToString() == actualPickupPoint.Value);
                Assert.IsNotNull(pickupPoint, "Expected Item Not found");
                Assert.AreEqual(pickupPoint.PickupPointName, actualPickupPoint.Text, "Mismatching Items found.");
            }

            transportService.Verify(s => s.FindPickupPoints(), Times.Exactly(1));
        }

        [Test]
        public void RequestTransport_Post_SavesTransportRequest()
        { 
            // Arrange

            // Act
            var redirectResult = controllerUnderTest.RequestTransport(transportRequestModel) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(redirectResult, "An ActionResult of type RedirectToRouteResult expected. Something else, or nothing was returned.");
            //Assert.AreEqual(string.Format("/Transport/ViewTransport/{0}", participantGuid), redirectResult.RouteName);
            transportService.Verify(s => s.CreateTransportRequest(transportRequestModel), Times.Exactly(1));
        }

        [Test, ExpectedException(typeof(AssertionFailedException))]
        public void RequestTransport_Post_WhenModelIsNull_ThrowsAssertionFailedException()
        {
            controllerUnderTest.RequestTransport((TransportRequestModel)null);
        }

        [Test]
        public void RequestTransport_Post_WhenBusinessExceptionOccurs_RedirectsToRequestTransportGetAction()
        {
            transportService.Setup(s => s.CreateTransportRequest(transportRequestModel)).Throws(new BusinessException("BusinessException"));

            var redirectResult = controllerUnderTest.RequestTransport(transportRequestModel) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(redirectResult, "An ActionResult of type RedirectToRouteResult expected. Something else, or nothing was returned.");
            //Assert.AreEqual(string.Format("/Transport/RequestTransport/{0}", participantGuid), redirectResult.RouteName);
            Assert.IsNotNull(controllerUnderTest.TempData["TransportRequestModel"], "TransportRequestModel expected in TempData");
            Assert.AreEqual("BusinessException", (controllerUnderTest.TempData["RequestTransportErrorMessage"] ?? string.Empty).ToString(), "BusinessException Mesage expected in TempData");

            transportService.Verify(s => s.CreateTransportRequest(transportRequestModel), Times.Exactly(1));
        }

        [Test]
        public void CancelTransportRequest_DeletesTransportRequest()
        {
            // Arrange
            var transportrequestid = new Guid("4118944c-5342-4079-afd4-a2630136d180");

            // Act
            var redirectToRouteResult = controllerUnderTest.CancelTransportRequest(participantGuid, transportrequestid);

            // Assert
            Assert.IsNotNull(redirectToRouteResult, "An ActionResult of type RedirectToRouteResult expected. Something else, or nothing was returned.");
            transportService.Verify(s => s.CancelTransportRequest(transportrequestid), Times.Exactly(1));
        }

        [Test]
        public void CancelTransportRequest_OnBusinessException_SetsErrorMessageInTempData()
        {
            // Arrange
            var transportrequestid = new Guid("4118944c-5342-4079-afd4-a2630136d180");
            transportService.Setup(s => s.CancelTransportRequest(transportrequestid)).Throws(new BusinessException("BusinessException"));

            // Act
            var redirectToRouteResult = controllerUnderTest.CancelTransportRequest(participantGuid, transportrequestid);

            // Assert
            Assert.IsNotNull(redirectToRouteResult, "An ActionResult of type RedirectToRouteResult expected. Something else, or nothing was returned.");
            transportService.Verify(s => s.CancelTransportRequest(transportrequestid), Times.Exactly(1));
            Assert.AreEqual("BusinessException", (controllerUnderTest.TempData["TransportRequestDeleteErrorMessage"] ?? string.Empty).ToString());
        }
    }
}
