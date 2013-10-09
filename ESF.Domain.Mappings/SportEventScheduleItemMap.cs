using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace ESF.Domain.Mappings
{
    public class SportEventScheduleItemMap : ClassMap<SportEventScheduleItem>
    {
        public SportEventScheduleItemMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            References(x => x.Festival);
            References(x => x.SportEvent);
            Map(x => x.Date);
            Map(x => x.StartTime);
            Map(x => x.EndTime);
        }
    }
}
