using FluentNHibernate.Mapping;

namespace ESF.Domain.Mappings
{
    public class ScheduledSportEventOverLapMap : ClassMap<ScheduledSportEventOverLap>
    {
        public ScheduledSportEventOverLapMap()
        {
            Id(x => x.Id);
            References(x => x.ScheduledSportEvent);
            References(x => x.OverLappingScheduledSportEvent, "OverLappingScheduledSportEventId");
        }
    }
}
