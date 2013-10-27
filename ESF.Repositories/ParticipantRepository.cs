using System;
using ESF.Core.Repositories;
using ESF.Domain;
using ESF.Commons.Utilities;
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

        public Participant Load(Guid participantId)
        {
            return entityRepo.Load(participantId);
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

        public Participant RetrieveByEmailAddress(string emailAddress)
        {
            if (emailAddress == string.Empty) return null;

            var criteria = entityRepo.CreateDetachedCriteria()
                .Add(Restrictions.Eq("EmailAddress", emailAddress));

            return entityRepo.FindOne(criteria);
        }

        public Participant Save(Participant participant)
        {
            Check.IsNotNull(participant, "participant may not be null");

            return entityRepo.Save(participant);
        }

        public void Update(Participant participant)
        {
            Check.IsNotNull(participant, "participant may not be null");

            entityRepo.Update(participant);
        }

        public Participant Get(Guid participantId)
        {
            Check.IsNotNull(participantId, "participantId may not be null");
            Check.IsTrue(participantId != Guid.Empty, "participantId may not be an empty guid");

            return entityRepo.Get(participantId);
        }

        public Guid RetrieveParticipantIdByUserId(int userId)
        {
            var participant = RetrieveParticipantByUserId(userId);

            Check.IsNotNull(participant, "No participant exists for the specified userid");

            return participant.Id;
        }
    }
}
