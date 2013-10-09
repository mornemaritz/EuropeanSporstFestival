using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using ESF.Core.Repositories;

namespace ESF.Services.Tests
{
    [TestFixture]
    public class ParticipantServiceTests
    {
        private ParticipantService serviceUnderTest;

        private Mock<IParticipantRepository> participantRepository;

        [SetUp]
        public void SetUp()
        {
            participantRepository = new Mock<IParticipantRepository>();

            serviceUnderTest = new ParticipantService(participantRepository.Object);
        }
    }
}
