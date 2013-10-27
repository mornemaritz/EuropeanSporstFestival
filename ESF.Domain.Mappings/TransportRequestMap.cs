using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace ESF.Domain.Mappings
{
    public class TransportRequestMap : ClassMap<TransportRequest>
    {
        public TransportRequestMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            References(x => x.Participant, "ParticipantId");
            References(x => x.PickupDay, "FestivalDayId");
            References(x => x.PickupPoint, "TransportPickupPointId");
        }
    }
}
