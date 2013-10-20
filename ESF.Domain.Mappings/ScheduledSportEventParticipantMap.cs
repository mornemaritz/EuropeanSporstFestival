using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using ESF.Commons.Utilities;

namespace ESF.Domain.Mappings
{
    public class ScheduledSportEventParticipantMap : ClassMap<ScheduledSportEventParticipant>
    {
        public ScheduledSportEventParticipantMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            References(x => x.ScheduledSportEvent, "ScheduledSportEventId");
            References(x => x.Participant, "ParticipantId");
            Map(x => x.TeamAllocationStatus, "TeamAllocationStatus").CustomType(typeof(GenericEnumMapper<TeamAllocationStatus>));
        }
    }
}
