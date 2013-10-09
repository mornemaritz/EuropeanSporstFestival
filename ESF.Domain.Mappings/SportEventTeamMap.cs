using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace ESF.Domain.Mappings
{
    public class SportEventTeamMap : ClassMap<SportEventTeam>
    {
        public SportEventTeamMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.Name);
            References(x => x.SportEvent);
            References(x => x.Captain);
            References(x => x.TeamMembers);
        }
    }
}
