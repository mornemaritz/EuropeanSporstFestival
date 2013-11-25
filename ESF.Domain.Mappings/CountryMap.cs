using FluentNHibernate.Mapping;

namespace ESF.Domain.Mappings
{
    public class CountryMap : ClassMap<Country>
    {
        public CountryMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.Name);
        }
    }
}
