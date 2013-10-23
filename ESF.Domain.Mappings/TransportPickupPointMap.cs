using FluentNHibernate.Mapping;

namespace ESF.Domain.Mappings
{
    public class TransportPickupPointMap : ClassMap<TransportPickupPoint>
    {
        public TransportPickupPointMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.Name);
        }
    }
}
