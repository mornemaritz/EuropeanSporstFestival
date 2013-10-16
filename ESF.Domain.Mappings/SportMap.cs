using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using ESF.Commons.Utilities;

namespace ESF.Domain.Mappings
{
    public class SportMap : ClassMap<Sport>
    {
        public SportMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.Name);
        }
    }
}
