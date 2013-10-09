using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

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
            //Table("TParticipant");
        }
    }
}
