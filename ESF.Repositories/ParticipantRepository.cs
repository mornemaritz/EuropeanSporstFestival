using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESF.Core.Repositories;
using ESF.Domain;
using ESF.Commons.Utilities;
using NHibernate.Linq;
using ESF.Commons.Repository;
using NHibernate.Criterion;

namespace ESF.Repositories
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly IRepository<Participant> entityRepo;

        public ParticipantRepository(IRepository<Participant> entityRepo)
        {
            Check.IsNotNull(entityRepo, "entityRepo may not be null");

            this.entityRepo = entityRepo;
        }

        public Participant RetrieveParticipantByUserId(int userId)
        {
            Check.IsTrue(userId > 0, "userId must be a positive integer");

            var criteria = entityRepo.CreateDetachedCriteria()
                .Add(Restrictions.Eq("UserId", userId));

            return entityRepo.FindOne(criteria);
        }

        public Participant RetrieveParticipant(Guid participantId)
        {
            Check.IsNotNull(participantId, "participantId may not be null");
            Check.IsTrue(participantId != Guid.Empty, "participantId may not be an empty guid");

            return entityRepo.Get(participantId);
        }

        public void Save(Participant participant)
        {
            Check.IsNotNull(participant, "participant may not be null");

            entityRepo.Save(participant);
        }

        public void Update(Participant participant)
        {
            Check.IsNotNull(participant, "participant may not be null");

            entityRepo.Update(participant);
        }

        public Guid RetrieveParticipantIdByUserId(int userId)
        {
            var participant = RetrieveParticipantByUserId(userId);

            Check.IsNotNull(participant, "No participant exists for the specified userid");

            return participant.Id;
        }
    }
}
