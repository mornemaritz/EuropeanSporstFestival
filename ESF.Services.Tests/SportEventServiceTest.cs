using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESF.Commons.Utilities;
using ESF.Core.Repositories;
using ESF.Core.Services;
using ESF.Domain;
using Moq;
using NUnit.Framework;

namespace ESF.Services.Tests
{
    [TestFixture]
    public class SportEventServiceTest
    {
        private SportsEventService serviceUnderTest;

        private Mock<IParticipantRepository> participantRepository;
        private Mock<IScheduledSportEventParticipantRepository> sportEventParticipantRepository;
        private Mock<IScheduledSportEventRepository> scheduledSportEventRepository;
        private Mock<ISportEventTeamRepository> sportEventTeamRepository;

        private readonly Guid participantId = new Guid("193CE32C-F0A5-4050-A53E-A27C013522DD");
        private Participant participant;

        private Festival festival;

        private Sport golf;
        private Sport football;
        private Sport athletics;
        private Sport rounders;

        private readonly Guid scheduledGolfId = new Guid("193CE32C-F0A5-4050-A53E-A27C013522EE");
        private ScheduledSportEvent scheduledGolf;

        private readonly Guid scheduledMensOver35sFootballId = new Guid("193CE32C-F0A5-4050-A53E-A27C013522FF");
        private ScheduledSportEvent scheduledMensOver35sFootball;

        private readonly Guid scheduledAthleticsId = new Guid("193CE32C-F0A5-4050-A53E-A27C01352211");
        private ScheduledSportEvent scheduledAthletics;

        private readonly Guid scheduledMixedNetballId = new Guid("193CE32C-F0A5-4050-A53E-A27C01352233");
        private ScheduledSportEvent scheduledMixedNetball;

        private readonly Guid scheduledRoundersId = new Guid("193CE32C-F0A5-4050-A53E-A27C01352222");
        private ScheduledSportEvent scheduledRounders;

        private IList<ScheduledSportEvent> scheduledSportEvents;
        private IList<ScheduledSportEvent> signedUpSportEvents;

        [TestFixtureSetUp]
        public void SetUpFixture()
        {
            participant = new Participant { DateOfBirth = new DateTime(1975, 10, 12), Gender = Gender.Male };

            festival = new Festival("ESF", new DateTime(2014, 04, 18));

            football = new Sport("Football");
            golf = new Sport("Golf");
            athletics = new Sport("Athletics");
            rounders = new Sport("Rounders");

            scheduledGolf = new ScheduledSportEvent("Golf", festival, golf, 0, Gender.Male, 0, 150, 1, 1, new TimeSpan(08, 00, 00), new TimeSpan(22, 00, 00));
            scheduledGolf.Id = scheduledGolfId;

            scheduledAthletics = new ScheduledSportEvent("Athletics", festival, athletics, 0, Gender.Male | Gender.Female, 0, 150, 1, 1, new TimeSpan(12, 30, 00), new TimeSpan(16, 00, 00));
            scheduledAthletics.Id = scheduledAthleticsId;

            scheduledRounders = new ScheduledSportEvent("Rounders", festival, rounders, 1, Gender.Male | Gender.Female, 0, 150, 7, 12, new TimeSpan(13, 30, 00), new TimeSpan(17, 30, 00));
            scheduledRounders.Id = scheduledRoundersId;

            scheduledMensOver35sFootball = new ScheduledSportEvent("MensOver35sFootball", festival, football, 1, Gender.Male, 35, 150, 5, 10, new TimeSpan(14, 00, 00), new TimeSpan(16, 30, 00));
            scheduledMensOver35sFootball.Id = scheduledMensOver35sFootballId;

            scheduledMixedNetball = new ScheduledSportEvent("MixedNetball", festival, football, 1, Gender.Male, 35, 150, 5, 10, new TimeSpan(08, 00, 00), new TimeSpan(12, 30, 00));
            scheduledMixedNetball.Id = scheduledMixedNetballId;

            signedUpSportEvents = new List<ScheduledSportEvent>
                                      {
                                          scheduledGolf
                                      };

            scheduledSportEvents = new List<ScheduledSportEvent>(signedUpSportEvents)
                                       {
                                           scheduledMensOver35sFootball, scheduledAthletics, scheduledRounders
                                       };
        }

        [SetUp]
        public void SetUp()
        {
            participantRepository = new Mock<IParticipantRepository>();
            sportEventParticipantRepository = new Mock<IScheduledSportEventParticipantRepository>();
            scheduledSportEventRepository = new Mock<IScheduledSportEventRepository>();
            sportEventTeamRepository = new Mock<ISportEventTeamRepository>();

            serviceUnderTest = new SportsEventService(participantRepository.Object, sportEventParticipantRepository.Object, scheduledSportEventRepository.Object, sportEventTeamRepository.Object);
        }
/*
        [Test]
        public void FindSportsEventsWithParticipantSelection_WhenAlreadySignedUp_ReturnsSignedUpSportAsSignedUpAndUnSelectable()
        {
            // Arrange
            participantRepository.Setup(x => x.Get(participantId)).Returns(participant);
            scheduledSportEventRepository.Setup(r => r.RetrieveSignedUpSportsEvents(participantId))
                .Returns(signedUpSportEvents);
            scheduledSportEventRepository.Setup(r => r.RetrieveScheduledSportEventsForAgeAndGender(participant.GetParticipantCurrentAge(), participant.Gender))
                .Returns(scheduledSportEvents);

            // Act
            var actualEvents = serviceUnderTest.FindSportsEventsWithParticipantSelection(participantId);

            // Assert
            Assert.AreEqual(4, actualEvents.Count);

            var actualGolf = actualEvents.SingleOrDefault(e => e.ScheduledSportEventName == scheduledGolf.Name);
            Assert.IsNotNull(actualGolf);
            Assert.IsTrue(actualGolf.CurrentParticipantAlreadySignedUp);
            Assert.IsFalse(actualGolf.IsSelectable);
            Assert.AreEqual(scheduledAthleticsId.ToString(), actualGolf.OverLappingEventIds);
        }

        [Test]
        public void FindSportsEventsWithParticipantSelection_WhenAlreadySignedUp_ReturnsOverLappingSportAsUnSelectable()
        {
            // Arrange
            participantRepository.Setup(x => x.Get(participantId)).Returns(participant);
            scheduledSportEventRepository.Setup(r => r.RetrieveSignedUpSportsEvents(participantId))
                .Returns(signedUpSportEvents);
            scheduledSportEventRepository.Setup(r => r.RetrieveScheduledSportEventsForAgeAndGender(participant.GetParticipantCurrentAge(), participant.Gender))
                .Returns(scheduledSportEvents);

            // Act
            var actualEvents = serviceUnderTest.FindSportsEventsWithParticipantSelection(participantId);

            // Assert
            var actualAthletics = actualEvents.SingleOrDefault(e => e.ScheduledSportEventName == scheduledAthletics.Name);
            Assert.IsNotNull(actualAthletics);
            Assert.IsFalse(actualAthletics.CurrentParticipantAlreadySignedUp);
            Assert.IsFalse(actualAthletics.IsSelectable);
            Assert.AreEqual(scheduledGolfId.ToString(), actualAthletics.OverLappingEventIds);
        }

        [Test]
        public void FindSportsEventsWithParticipantSelection_WithUnSelectedSports_ReturnsOverLappingSportsAsSelectableAndLinked()
        {
            // Arrange
            participantRepository.Setup(x => x.Get(participantId)).Returns(participant);
            scheduledSportEventRepository.Setup(r => r.RetrieveSignedUpSportsEvents(participantId))
                .Returns(signedUpSportEvents);
            scheduledSportEventRepository.Setup(r => r.RetrieveScheduledSportEventsForAgeAndGender(participant.GetParticipantCurrentAge(), participant.Gender))
                .Returns(scheduledSportEvents);

            // Act
            var actualEvents = serviceUnderTest.FindSportsEventsWithParticipantSelection(participantId);

            // Assert
            var actualMensOver35sFootBall = actualEvents.SingleOrDefault(e => e.ScheduledSportEventName == scheduledMensOver35sFootball.Name);
            Assert.IsNotNull(actualMensOver35sFootBall);
            Assert.IsFalse(actualMensOver35sFootBall.CurrentParticipantAlreadySignedUp);
            Assert.IsTrue(actualMensOver35sFootBall.IsSelectable);
            Assert.AreEqual(scheduledRoundersId.ToString(), actualMensOver35sFootBall.OverLappingEventIds);

            var actualRounders = actualEvents.SingleOrDefault(e => e.ScheduledSportEventName == scheduledRounders.Name);
            Assert.IsNotNull(actualRounders);
            Assert.IsFalse(actualRounders.CurrentParticipantAlreadySignedUp);
            Assert.IsTrue(actualRounders.IsSelectable);
            Assert.AreEqual(scheduledMensOver35sFootballId.ToString(), actualRounders.OverLappingEventIds);
        }
 * 
 */
    }
}
