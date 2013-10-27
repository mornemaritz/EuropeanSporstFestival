using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESF.Core.Services;
using ESF.Core.Services.Models;
using ESF.Domain;

namespace ESF.Core.Repositories
{
    public interface ITransportRequestRepository
    {
        IList<TransportRequestItem> FindParticipantTransportRequests(Guid participantId);

        TransportRequest Save(TransportRequest transportRequest);
    }
}
