using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESF.Domain;
using ESF.Commons.Utilities;

namespace ESF.Core.Repositories
{
    public interface ISportEventRepository
    {
        IList<SportEvent> FindSportEventsAvailableToParticipant(Gender gender);

        SportEvent RetrieveById(Guid guid);
    }
}
