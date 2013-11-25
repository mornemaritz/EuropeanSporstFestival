using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESF.Core.Services;
using ESF.Core.Repositories;
using ESF.Commons.Utilities;
using ESF.Domain;

namespace ESF.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly IParticipantRepository participantRepository;
        private readonly IJamatkhanaRepository jamatkhanaRepository;
        private readonly ICountyRepository countyRepository;
        private readonly ICountryRepository countryRepository;

        public ParticipantService(IParticipantRepository participantRepository, IJamatkhanaRepository jamatkhanaRepository, ICountyRepository countyRepository, ICountryRepository countryRepository)
        {
            Check.IsNotNull(participantRepository, "participantRepository may not be null");

            this.participantRepository = participantRepository;
            this.jamatkhanaRepository = jamatkhanaRepository;
            this.countyRepository = countyRepository;
            this.countryRepository = countryRepository;
        }

        public ParticipantDetailsCreateModel SaveParticipant(ParticipantDetailsCreateModel model)
        {
            var participant = participantRepository.Save(new Participant 
            { 
                UserId = model.UserId, 
                FirstName = model.FirstName, 
                LastName = model.LastName, 
                EmailAddress = model.EmailAddress,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,
                Jamatkhana = jamatkhanaRepository.Load(model.JamatkhanaId),
                MobileNumber = model.MobileNumber,
                HomePhoneNumber = model.HomePhoneNumber,
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                AddressLine3 = model.AddressLine3,
                AddressLine4 = model.AddressLine4,
                Town = model.Town,
                County = countyRepository.Load(model.CountyId),
                Country = countryRepository.Load(model.CountryId),
                Postcode = model.Postcode,
                HasDisability = model.HasDisability,
                IsInterestedInVolunteering = model.IsInterestedInVolunteering
            });

            model.ParticipantId = participant.Id;

            return model;
        }

        //public ParticipantDetailsModel RetrieveParticipant(Guid id)
        //{
        //    var participant = participantRepository.RetrieveParticipant(id);

        //    return new ParticipantDetailsModel { ParticipantId = participant.Id, UserId = participant.UserId, FirstName = participant.FirstName, LastName = participant.LastName, Gender = participant.Gender };
        //}

        //public ParticipantDetailsModel RetrieveParticipantByUserId(int userId)
        //{
        //    var participant = participantRepository.RetrieveParticipantByUserId(userId);

        //    if (participant == null) return null;

        //    return new ParticipantDetailsModel { ParticipantId = participant.Id, UserId = participant.UserId, FirstName = participant.FirstName, LastName = participant.LastName, Gender = participant.Gender };
        //}

        public void UpdateParticipant(ParticipantDetailsEditModel model)
        {
            var participant = participantRepository.RetrieveParticipant(model.ParticipantId);

            participant.Jamatkhana = jamatkhanaRepository.Load(model.JamatkhanaId);
            participant.MobileNumber = model.MobileNumber;
            participant.HomePhoneNumber = model.HomePhoneNumber;
            participant.AddressLine1 = model.AddressLine1;
            participant.AddressLine2 = model.AddressLine2;
            participant.AddressLine3 = model.AddressLine3;
            participant.AddressLine4 = model.AddressLine4;
            participant.Town = model.Town;
            participant.County = countyRepository.Load(model.CountyId);
            participant.Country = countryRepository.Load(model.CountryId);
            participant.Postcode = model.Postcode;
            participant.HasDisability = model.HasDisability;
            participant.IsInterestedInVolunteering = model.IsInterestedInVolunteering;

            participantRepository.Update(participant);
        }

        public ParticipantDetailsViewModel RetrieveParticipantViewModelByUserId(int userId)
        {
            return participantRepository.RetrieveParticipantViewModelByUserId(userId);
        }

        public ParticipantDetailsViewModel RetrieveParticipantViewModel(Guid participantId)
        {
            return participantRepository.RetrieveParticipantViewModel(participantId);
        }

        public ParticipantDetailsEditModel RetrieveParticipantEditModel(Guid participantId)
        {
            return participantRepository.RetrieveParticipantEditModel(participantId);
        }

        public IList<JamatkhanaItem> ListJamatkhanas()
        {
            return jamatkhanaRepository.FindJamatkhanas();
        }

        public IList<CountyItem> ListCounties()
        {
            return countyRepository.FindCounties();
        }

        public IList<CountryItem> ListCountries()
        {
            return countryRepository.FindCountries();
        }

        public Guid RetrieveParticipantIdByUserId(int userId)
        {
            return participantRepository.RetrieveParticipantIdByUserId(userId);
        }
    }
}
