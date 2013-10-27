using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESF.Domain
{
    public class FestivalDay
    {
        private Guid id;
        private Festival festival;
        private int day;
        private DateTime date;

        public virtual Guid Id
        {
            get { return id; }
        }

        public virtual Festival Festival
        {
            get { return festival; }
        }

        public virtual int Day
        {
            get { return day; }
        }

        public virtual DateTime Date
        {
            get { return date; }
        }
    }
}
