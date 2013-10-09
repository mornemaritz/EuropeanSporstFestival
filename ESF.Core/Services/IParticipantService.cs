using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESF.Core.Services
{
    public interface IParticipantService
    {
        void SaveParticipant(ParticipantDetailsModel model);

        ParticipantDetailsModel RetrieveParticipant(Guid id);

        ParticipantDetailsModel RetrieveParticipantByUserId(int userId);

        void UpdateParticipant(ParticipantDetailsModel model);

        Guid RetrieveParticipantIdByUserId(int userId);
    }
}
