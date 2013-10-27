using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace ESF.Domain.Mappings
{
    public class FestivalDayMap : ClassMap<FestivalDay>
    {
        public FestivalDayMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            References(x => x.Festival, "FestivalId");
            Map(x => x.Day);
            Map(x => x.Date);
        }
    }
}
