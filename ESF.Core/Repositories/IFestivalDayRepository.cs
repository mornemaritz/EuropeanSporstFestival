using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESF.Core.Services.Models;
using ESF.Domain;

namespace ESF.Core.Repositories
{
    public interface IFestivalDayRepository
    {
        IList<FestivalDayItem> FindDaysWithNoTransportRequests(Guid participantId);

        FestivalDay Load(Guid festivalDayId);
    }
}
