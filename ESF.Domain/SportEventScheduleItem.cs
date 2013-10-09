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

        protected SportEventScheduleItem(){ }

        public SportEventScheduleItem(Festival festival, int dayOffSetFromFestivalStartDate, SportEvent sportEvent, TimeSpan startTime, TimeSpan endTime)
        {
            this.sportEvent = sportEvent;
            this.date = festival.StartDate.AddDays(Convert.ToDouble(dayOffSetFromFestivalStartDate));
            this.festival = festival;
            this.startTime = startTime;
            this.endTime = endTime;
        }

        public virtual Guid Id
        {
            get { return id; }
        }

        public virtual Festival Festival
        {
            get { return festival; }
        }

        public virtual SportEvent SportEvent
        {
            get { return sportEvent; }
        }

        public virtual DateTime Date
        {
            get { return date; }
        }

        public virtual string DayOfWeek
        {
            get { return date.DayOfWeek.ToString(); }
        }

        public virtual TimeSpan StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        public virtual TimeSpan EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        public virtual DateTime MoveDate(int dayOffSetFromFestivalStartDate)
        {
            date = festival.StartDate.AddDays(Convert.ToDouble(dayOffSetFromFestivalStartDate));
            return date;
        }
    }
}
