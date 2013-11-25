using FluentNHibernate.Mapping;

namespace ESF.Domain.Mappings
{
    public class CountyMap : ClassMap<County>
    {
        public CountyMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.Name);
        }
    }
}
