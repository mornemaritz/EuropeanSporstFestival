using System;
using System.Collections.Generic;

namespace ESF.Core.Services
{
    public interface IParticipantService
    {
        ParticipantDetailsCreateModel SaveParticipant(ParticipantDetailsCreateModel model);

        void UpdateParticipant(ParticipantDetailsEditModel model);

        Guid RetrieveParticipantIdByUserId(int userId);

        ParticipantDetailsViewModel RetrieveParticipantViewModelByUserId(int userId);

        ParticipantDetailsViewModel RetrieveParticipantViewModel(Guid participantId);

        ParticipantDetailsEditModel RetrieveParticipantEditModel(Guid participantId);

        IList<JamatkhanaItem> ListJamatkhanas();

        IList<CountyItem> ListCounties();

        IList<CountryItem> ListCountries();
    }
}
