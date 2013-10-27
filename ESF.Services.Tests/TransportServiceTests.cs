using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using ESF.Core.Repositories;
using ESF.Core.Services;
using ESF.Core.Services.Models;
using ESF.Domain;

namespace ESF.Services.Tests
{
    [TestFixture]
    public class TransportServiceTests
    {
        private TransportService serviceUnderTest;

        private Mock<ITransportPickupPointRepository> transportPickupPointRepository;
        private Mock<ITransportRequestRepository> transportRequestRepository;
        private Mock<IFestivalDayRepository> festivalDayRepository;
        private Mock<IParticipantRepository> participantRepository;

        private Guid participantId = new Guid("4cc8933c-5342-4079-afd4-a2630136d180");

        private IList<TransportRequestItem> transportRequestItems;

        private Guid day1TransportRequestId = new Guid("4aa8933c-5342-4079-afd4-a2630136d180");
        private DateTime day1 = new DateTime(2014, 04, 18);

        private Guid day2TransportRequestId = new Guid("4bb8933c-5342-4079-afd4-a2630136d180");
        private DateTime day2 = new DateTime(2014, 04, 19);

        [SetUp]
        public void SetUp()
        {
            transportPickupPointRepository = new Mock<ITransportPickupPointRepository>();
            transportRequestRepository = new Mock<ITransportRequestRepository>();
            festivalDayRepository = new Mock<IFestivalDayRepository>();
            participantRepository = new Mock<IParticipantRepository>();

            serviceUnderTest = new TransportService(transportPickupPointRepository.Object, transportRequestRepository.Object, festivalDayRepository.Object, participantRepository.Object);

            transportRequestItems = new List<TransportRequestItem>
            {
                new TransportRequestItem(day1TransportRequestId, participantId, day1, "Ismaili Centre"),
                new TransportRequestItem(day2TransportRequestId, participantId, day2, "Ismaili Centre")
            };
        }

        [Test]
        public void FindParticipantTransportRequests_ReturnsTransportRequestItems()
        { 
            // Arrange
            transportRequestRepository.Setup(r => r.FindParticipantTransportRequests(participantId)).Returns(transportRequestItems);

            // Act
            var actualTransportRequestItems = serviceUnderTest.FindParticipantTransportRequests(participantId);

            // Assert
            Assert.AreEqual(transportRequestItems, actualTransportRequestItems, "A list of TransportRequestItems was expected. Something else or nothing was returned.");
        }

        [Test]
        public void CreateTransportRequest_SavesNewTransportRequest()
        { 
            // Arrange
            var transportRequestModel = new TransportRequestModel
            {
                ParticipantId = participantId,
                FestivalDayId = new Guid("4228933c-5342-4079-afd4-a2630136d180"),
                TransportPickupPointId = new Guid("4338933c-5342-4079-afd4-a2630136d180")
            };

            participantRepository.Setup(r => r.Load(It.IsAny<Guid>())).Returns(new Participant());
            festivalDayRepository.Setup(r => r.Load(It.IsAny<Guid>())).Returns(new FestivalDay());
            transportPickupPointRepository.Setup(r => r.Load(It.IsAny<Guid>())).Returns(new TransportPickupPoint());

            // Act
            serviceUnderTest.CreateTransportRequest(transportRequestModel);

            // Assert
            transportRequestRepository.Verify(r => r.Save(It.IsAny<TransportRequest>()), Times.Exactly(1));
        }
    }
}
