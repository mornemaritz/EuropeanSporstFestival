using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESF.Core.Repositories;
using ESF.Domain;
using ESF.Commons.Utilities;
using NHibernate.Linq;

namespace ESF.Repositories
{
    public class SportEventRepository : ISportEventRepository
    {
        public IList<SportEvent> FindSportEventsAvailableToParticipant(Gender gender)
        {
            IList<SportEvent> sportEvents = new List<SportEvent>();

            using (var session = NHibernateHelper.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                sportEvents = session.Query<SportEvent>().Where(se => se.Gender.GetValueOrDefault(gender) == gender).ToList();
            }

            return sportEvents;
        }

        public SportEvent RetrieveById(Guid sportEventId)
        {
            Check.IsNotNull(sportEventId, "sportEventId may not be null");
            Check.IsTrue(sportEventId != Guid.Empty, "sportEventId may not be an empty guid");

            SportEvent sportEvent = null;

            using (var session = NHibernateHelper.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                sportEvent = session.Get<SportEvent>(sportEventId);
            }

            return sportEvent;
        }
    }
}
