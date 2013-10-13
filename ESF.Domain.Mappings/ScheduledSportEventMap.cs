using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace ESF.Domain.Mappings
{
    public class ScheduledSportEventMap : ClassMap<ScheduledSportEvent>
    {
        public ScheduledSportEventMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            References(x => x.Festival);
            References(x => x.SportEvent);
            Map(x => x.Date);
            Map(x => x.StartTime).CustomType("TimeAsTimeSpan");
            Map(x => x.EndTime).CustomType("TimeAsTimeSpan");
        }
    }
}
