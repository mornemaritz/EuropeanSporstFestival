using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using ESF.Commons.Utilities;

namespace ESF.Domain.Mappings
{
    public class SportEventMap : ClassMap<SportEvent>
    {
        public SportEventMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.Name);
            Map(x => x.MinAge);
            Map(x => x.MaxAge);
            Map(x => x.Gender).CustomType(typeof(Gender?));
        }
    }
}
