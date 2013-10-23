using FluentNHibernate.Mapping;
using ESF.Commons.Utilities;

namespace ESF.Domain.Mappings
{
    public class ParticipantMap : ClassMap<Participant>
    {
        public ParticipantMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.EmailAddress);
            Map(x => x.UserId);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.DateOfBirth);
            Map(x => x.Gender).CustomType(typeof(Gender)); // TODO: Implement GenericEnumMapper
        }
    }
}
