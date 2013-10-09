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
    public class ParticipantRepository : IParticipantRepository
    {
        public Participant RetrieveParticipantByUserId(int userId)
        {
            Check.IsTrue(userId > 0, "userId must be a positive integer");

            Participant participant = null;

            using (var session = NHibernateHelper.OpenSession())
            using(var tx = session.BeginTransaction())  
            {
                participant = session.Query<Participant>().Where(p => p.UserId == userId).SingleOrDefault();
            }

            return participant;
        }

        public Participant RetrieveParticipant(Guid participantId)
        {
            Check.IsNotNull(participantId, "participantId may not be null");
            Check.IsTrue(participantId != Guid.Empty, "participantId may not be an empty guid");

            Participant participant = null;

            using (var session = NHibernateHelper.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                participant = session.Get<Participant>(participantId);
            }

            return participant;
        }

        public void Save(Participant participant)
        {
            Check.IsNotNull(participant, "participant may not be null");

            using (var session = NHibernateHelper.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                session.Save(participant);
                tx.Commit();
            }
        }

        public void Update(Participant participant)
        {
            Check.IsNotNull(participant, "participant may not be null");

            using (var session = NHibernateHelper.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                session.Update(participant);
                tx.Commit();
            }
        }

        public Guid RetrieveParticipantIdByUserId(int userId)
        {
            var participant = RetrieveParticipantByUserId(userId);

            Check.IsNotNull(participant, "No participant exists for the specified userid");

            return participant.Id;
        }
    }
}
