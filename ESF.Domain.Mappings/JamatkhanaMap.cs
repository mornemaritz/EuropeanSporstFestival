using ESF.Commons.Utilities;
using FluentNHibernate.Mapping;

namespace ESF.Domain.Mappings
{
    public class JamatkhanaMap : ClassMap<Jamatkhana>
    {
        public JamatkhanaMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.Name);
            Map(x => x.Area).CustomType(typeof (GenericEnumMapper<JamatkhanaArea>));
        }
    }
}
