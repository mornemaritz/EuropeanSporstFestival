using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using ESF.Commons.Utilities;

namespace ESF.Domain.Mappings
{
    public class ScheduledSportEventMap : ClassMap<ScheduledSportEvent>
    {
        public ScheduledSportEventMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.Name);
            References(x => x.Festival);
            References(x => x.Sport);
            Map(x => x.AllowedGenders).CustomType(typeof(Gender));
            Map(x => x.MinAge);
            Map(x => x.MaxAge);
            Map(x => x.MinTeamSize);
            Map(x => x.MaxTeamSize);
            Map(x => x.Date);
            Map(x => x.StartTime).CustomType("TimeAsTimeSpan");
            Map(x => x.EndTime).CustomType("TimeAsTimeSpan");
        }
    }
}
