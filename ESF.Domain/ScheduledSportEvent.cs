using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESF.Commons.Utilities;

namespace ESF.Domain
{
    public class ScheduledSportEvent
    {
        private Guid id;
        private string name;
        private Festival festival;
        private Sport sport;
        private Gender allowedGenders;
        private int minAge;
        private int maxAge;
        private int minTeamSize;
        private int maxTeamSize;
        private DateTime date;
        private TimeSpan startTime;
        private TimeSpan endTime;

        protected ScheduledSportEvent(){ }

        public ScheduledSportEvent(string name, Festival festival, Sport sport, int dayOffSetFromFestivalStartDate, 
            Gender allowedGenders, int minAge, int maxAge, int minTeamSize, int maxTeamSize, 
            TimeSpan startTime, TimeSpan endTime)
        {
            this.name = name;
            this.festival = festival;
            this.sport = sport;
            this.date = festival.StartDate.AddDays(Convert.ToDouble(dayOffSetFromFestivalStartDate));
            this.allowedGenders = allowedGenders;
            this.minAge = minAge;
            this.maxAge = maxAge;
            this.minTeamSize = minTeamSize;
            this.maxTeamSize = maxTeamSize;
            this.startTime = startTime;
            this.endTime = endTime;
        }

        public virtual Guid Id
        {
            get { return id; }
        }

        public virtual string Name
        {
            get { return name; }
        }

        public virtual Festival Festival
        {
            get { return festival; }
        }

        public virtual Sport Sport
        {
            get { return sport; }
        }

        public virtual Gender AllowedGenders
        {
            get { return allowedGenders; }
        }

        public virtual int MinAge
        {
            get { return minAge; }
        }

        public virtual int MaxAge
        {
            get { return maxAge; }
        }

        public virtual int MinTeamSize
        {
            get { return minTeamSize; }
            set { minTeamSize = value; }
        }

        public virtual int MaxTeamSize
        {
            get { return maxTeamSize; }
            set { maxTeamSize = value; }
        }

        public virtual bool IsTeamEvent
        {
            get { return minTeamSize > 1; }
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
