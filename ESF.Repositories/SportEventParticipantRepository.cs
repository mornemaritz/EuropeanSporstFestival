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
    public class SportEventParticipantRepository : ISportEventParticipantRepository
    {
        public SportEventParticipant Save(SportEventParticipant sportEventParticipant)
        {
            Check.IsNotNull(sportEventParticipant, "participant may not be null");

            using (var session = NHibernateHelper.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                session.Save(sportEventParticipant);
                tx.Commit();
            }

            return sportEventParticipant;
        }

        public IList<SportEventParticipant> FindSignedUpSportsEvents(Guid participantId)
        {
            IList<SportEventParticipant> sportEventParticipants = new List<SportEventParticipant>();

            using (var session = NHibernateHelper.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                sportEventParticipants = session.Query<SportEventParticipant>().Where(sep => sep.Participant.Id == participantId).ToList();
            }

            return sportEventParticipants;
        }
    }
}
