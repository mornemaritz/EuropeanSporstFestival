using System;
using ESF.Core.Repositories;
using ESF.Core.Services;
using ESF.Domain;
using ESF.Commons.Utilities;
using ESF.Commons.Repository;
using FluentNHibernate.Mapping;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;

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

        public ParticipantDetailsViewModel RetrieveParticipantViewModelByUserId(int userId)
        {
            Check.IsTrue(userId > 0, "userId must be a positive integer");

            var criteria = entityRepo.CreateDetachedCriteria()
                .CreateAlias("Jamatkhana", "Jamatkhana", JoinType.InnerJoin)
                .SetFetchMode("Jamatkhana", FetchMode.Eager)
                .CreateAlias("County", "County", JoinType.InnerJoin)
                .SetFetchMode("County", FetchMode.Eager)
                .CreateAlias("Country", "Country", JoinType.InnerJoin)
                .SetFetchMode("Country", FetchMode.Eager)
                .Add(Restrictions.Eq("UserId", userId));

            return entityRepo.ReportOne<ParticipantDetailsViewModel>(criteria, GetViewModelProjectionList());
        }

        public ParticipantDetailsViewModel RetrieveParticipantViewModel(Guid participantId)
        {
            Check.IsTrue(participantId != Guid.Empty, "Invalid participantid");

            var criteria = entityRepo.CreateDetachedCriteria()
                .CreateAlias("Jamatkhana", "Jamatkhana", JoinType.InnerJoin)
                .SetFetchMode("Jamatkhana", FetchMode.Eager)
                .CreateAlias("County", "County", JoinType.InnerJoin)
                .SetFetchMode("County", FetchMode.Eager)
                .CreateAlias("Country", "Country", JoinType.InnerJoin)
                .SetFetchMode("Country", FetchMode.Eager)
                .Add(Restrictions.Eq("Id", participantId));

            return entityRepo.ReportOne<ParticipantDetailsViewModel>(criteria, GetViewModelProjectionList());
        }

        public ParticipantDetailsEditModel RetrieveParticipantEditModel(Guid participantId)
        {
            Check.IsTrue(participantId != Guid.Empty, "Invalid participantid");

            var criteria = entityRepo.CreateDetachedCriteria()
                .Add(Restrictions.Eq("Id", participantId));

            return entityRepo.ReportOne<ParticipantDetailsEditModel>(criteria, GetEditModelProjectionList());
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

            return participant == null
                       ? Guid.Empty
                       : participant.Id;
        }


        private static ProjectionList GetViewModelProjectionList()
        {
            return Projections.ProjectionList()
                .Add(Projections.Property<Participant>(x => x.Id), "ParticipantId")
                .Add(Projections.Property<Participant>(x => x.FirstName), "FirstName")
                .Add(Projections.Property<Participant>(x => x.LastName), "LastName")
                .Add(Projections.Property<Participant>(x => x.DateOfBirth), "DateOfBirth")
                //.Add(Projections.Cast(NHibernateUtil.GuessType(typeof(GenericEnumMapper<Gender>)), Projections.Property<Participant>(x => x.Gender)), "Gender")
                .Add(Projections.Cast(NHibernateUtil.String, Projections.Property<Participant>(x => x.Gender)), "Gender")
                .Add(Projections.Property<Participant>(x => x.EmailAddress), "EmailAddress")
                .Add(Projections.Property<Participant>(x => x.Jamatkhana.Name), "JamatkhanaName")
                .Add(Projections.Property<Participant>(x => x.MobileNumber), "MobileNumber")
                .Add(Projections.Property<Participant>(x => x.HomePhoneNumber), "HomePhoneNumber")
                .Add(Projections.Property<Participant>(x => x.AddressLine1), "AddressLine1")
                .Add(Projections.Property<Participant>(x => x.AddressLine2), "AddressLine2")
                .Add(Projections.Property<Participant>(x => x.AddressLine3), "AddressLine3")
                .Add(Projections.Property<Participant>(x => x.AddressLine4), "AddressLine4")
                .Add(Projections.Property<Participant>(x => x.Town), "Town")
                .Add(Projections.Property<Participant>(x => x.County.Name), "CountyName")
                .Add(Projections.Property<Participant>(x => x.Country.Name), "CountryName")
                .Add(Projections.Property<Participant>(x => x.Postcode), "Postcode")
                //.Add(Projections.Cast(NHibernateUtil.GuessType(typeof(GenericEnumMapper<YesNo>)), Projections.Property<Participant>(x => x.HasDisability)), "HasDisability")
                .Add(Projections.Cast(NHibernateUtil.String, Projections.Property<Participant>(x => x.HasDisability)), "HasDisability")
                .Add(Projections.Property<Participant>(x => x.IsInterestedInVolunteering), "IsInterestedInVolunteering");
        }

        private static ProjectionList GetEditModelProjectionList()
        {
            return Projections.ProjectionList()
                .Add(Projections.Property<Participant>(x => x.Id), "ParticipantId")
                .Add(Projections.Property<Participant>(x => x.FirstName), "FirstName")
                .Add(Projections.Property<Participant>(x => x.LastName), "LastName")
                .Add(Projections.Property<Participant>(x => x.DateOfBirth), "DateOfBirth")
                //.Add(Projections.Cast(NHibernateUtil.GuessType(typeof(GenericEnumMapper<Gender>)), Projections.Property<Participant>(x => x.Gender)), "Gender")
                .Add(Projections.Cast(NHibernateUtil.String, Projections.Property<Participant>(x => x.Gender)), "Gender")
                .Add(Projections.Property<Participant>(x => x.EmailAddress), "EmailAddress")
                .Add(Projections.Property<Participant>(x => x.Jamatkhana.Id), "JamatkhanaId")
                .Add(Projections.Property<Participant>(x => x.MobileNumber), "MobileNumber")
                .Add(Projections.Property<Participant>(x => x.HomePhoneNumber), "HomePhoneNumber")
                .Add(Projections.Property<Participant>(x => x.AddressLine1), "AddressLine1")
                .Add(Projections.Property<Participant>(x => x.AddressLine2), "AddressLine2")
                .Add(Projections.Property<Participant>(x => x.AddressLine3), "AddressLine3")
                .Add(Projections.Property<Participant>(x => x.AddressLine4), "AddressLine4")
                .Add(Projections.Property<Participant>(x => x.Town), "Town")
                .Add(Projections.Property<Participant>(x => x.County.Id), "CountyId")
                .Add(Projections.Property<Participant>(x => x.Country.Id), "CountryId")
                .Add(Projections.Property<Participant>(x => x.Postcode), "Postcode")
                //.Add(Projections.Cast(NHibernateUtil.GuessType(typeof(GenericEnumMapper<YesNo>)), Projections.Property<Participant>(x => x.HasDisability)), "HasDisability")
                .Add(Projections.Cast(NHibernateUtil.String, Projections.Property<Participant>(x => x.HasDisability)), "HasDisability")
                .Add(Projections.Property<Participant>(x => x.IsInterestedInVolunteering), "IsInterestedInVolunteering");
        }
    }
}
