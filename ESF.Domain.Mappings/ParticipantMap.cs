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
            Map(x => x.Gender).CustomType(typeof(GenericEnumMapper<Gender>));
            References(x => x.Jamatkhana);
            Map(x => x.MobileNumber);
            Map(x => x.HomePhoneNumber);
            Map(x => x.AddressLine1);
            Map(x => x.AddressLine2);
            Map(x => x.AddressLine3);
            Map(x => x.AddressLine4);
            Map(x => x.Town);
            References(x => x.County);
            References(x => x.Country);
            Map(x => x.Postcode);
            Map(x => x.HasDisability).CustomType(typeof (GenericEnumMapper<YesNo>));
            Map(x => x.IsInterestedInVolunteering);
        }
    }
}
