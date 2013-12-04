using FluentNHibernate.Mapping;

namespace ESF.Domain.Mappings
{
    public class FestivalMap : ClassMap<Festival>
    {
        public FestivalMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.Name);
            Map(x => x.StartDate);
            Map(x => x.MorningStartTime).CustomType("TimeAsTimeSpan");
            Map(x => x.AfternoonStartTime).CustomType("TimeAsTimeSpan");
            Map(x => x.EveningStartTime).CustomType("TimeAsTimeSpan");
        }
    }
}
