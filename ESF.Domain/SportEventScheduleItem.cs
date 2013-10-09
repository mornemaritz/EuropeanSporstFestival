using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESF.Domain
{
    public class SportEventScheduleItem
    {
        private Guid id;
        private Festival festival;
        private int dayOffSetFromFestivalStartDate;
        private SportEvent sportEvent;
        private DateTime date;
        private TimeSpan startTime;
        private TimeSpan endTime;

        private SportEventScheduleItem()
        { 
        }

        public SportEventScheduleItem(Festival festival, int dayOffSetFromFestivalStartDate, SportEvent sportEvent, TimeSpan startTime, TimeSpan endTime)
        {
            this.sportEvent = sportEvent;
            this.date = festival.StartDate.AddDays(Convert.ToDouble(dayOffSetFromFestivalStartDate));
            this.festival = festival;
            this.startTime = startTime;
            this.endTime = endTime;
        }

        public Guid Id
        {
            get { return id; }
        }

        public Festival Festival
        {
            get { return festival; }
        }

        public SportEvent SportEvent
        {
            get { return sportEvent; }
        }

        public DateTime Date
        {
            get { return date; }
        }

        public string DayOfWeek
        {
            get { return date.DayOfWeek.ToString(); }
        }

        public TimeSpan StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        public TimeSpan EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        public DateTime MoveDate(int dayOffSetFromFestivalStartDate)
        {
            date = festival.StartDate.AddDays(Convert.ToDouble(dayOffSetFromFestivalStartDate));
            return date;
        }
    }
}
