using System.Collections.Generic;

namespace ESF.Core.Services
{
    public class SportEventGroup
    {
        private IList<ScheduledSportEventDetail> sportEvents = new List<ScheduledSportEventDetail>();

        public SportEventGroup(string dayOfWeek, string period, int festivalDay)
        {
            DayOfWeek = dayOfWeek;
            Period = period;
            FestivalDay = festivalDay;
        }

        public string Period { get; private set; }
        public string DayOfWeek { get; private set; }
        public int FestivalDay { get; private set; }

        public IList<ScheduledSportEventDetail> SportEvents
        {
            get { return sportEvents; }
            set { sportEvents = value; }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", DayOfWeek, Period);
        }
    }
}
