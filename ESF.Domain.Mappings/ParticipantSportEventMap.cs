using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace ESF.Domain.Mappings
{
    public class ParticipantSportEventMap : ClassMap<ParticipantSportEvent>
    {
        public ParticipantSportEventMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            References(x => x.ScheduledSportEvent, "ScheduledSportEventId");
            References(x => x.Participant);
        }
    }
}
