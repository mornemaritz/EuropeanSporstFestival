using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESF.Domain
{
    public class Festival
    {
        private Guid id;
        private string name;
        private DateTime startDate;

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
    }
}
