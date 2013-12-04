using System;

namespace ESF.Domain
{
    public class Festival
    {
        private Guid id;
        private string name;
        private DateTime startDate;
        private TimeSpan morningStartTime;
        private TimeSpan afternoonStartTime;
        private TimeSpan eveningStartTime;

        protected Festival() { }

        public Festival(string name, DateTime startDate)
        {
            this.name = name;
            this.startDate = startDate;
        }

        public virtual  Guid Id
        {
            get { return id; }
        }

        public virtual  string Name 
        {
            get { return name; }
            set { name = value; }
        }

        public virtual  DateTime StartDate
        {
            get { return startDate; }
        }

        public virtual TimeSpan MorningStartTime
        {
            get { return morningStartTime; }
        }

        public virtual TimeSpan AfternoonStartTime
        {
            get { return afternoonStartTime; }
        }

        public virtual TimeSpan EveningStartTime
        {
            get { return eveningStartTime; }
        }
    }
}
