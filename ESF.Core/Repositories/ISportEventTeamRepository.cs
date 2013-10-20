using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESF.Domain;

namespace ESF.Core.Repositories
{
    public interface ISportEventTeamRepository
    {
        SportEventTeam FindByName(string sportEventTeamName, Guid scheduledSportEventId);

        void Update(SportEventTeam sportEventTeam);
    }
}
