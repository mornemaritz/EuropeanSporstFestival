using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace ESF.Domain.Mappings
{
    public class SportEventParticipantMap : ClassMap<SportEventParticipant>
    {
        public SportEventParticipantMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            References(x => x.SportEvent).Column("SportEventId");
            References(x => x.Participant);
        }
    }
}
