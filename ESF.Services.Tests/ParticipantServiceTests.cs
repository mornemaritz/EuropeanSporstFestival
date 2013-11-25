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
        private Mock<ICountryRepository> countryRepository;
        private Mock<IJamatkhanaRepository> jamatkhanaRepository;
        private Mock<ICountyRepository> countyRepository;

        [SetUp]
        public void SetUp()
        {
            participantRepository = new Mock<IParticipantRepository>();
            countryRepository = new Mock<ICountryRepository>();
            countyRepository = new Mock<ICountyRepository>();
            jamatkhanaRepository = new Mock<IJamatkhanaRepository>();

            serviceUnderTest = new ParticipantService(participantRepository.Object,jamatkhanaRepository.Object, countyRepository.Object, countryRepository.Object);
        }
    }
}
