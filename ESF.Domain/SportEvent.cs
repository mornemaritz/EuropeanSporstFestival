using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESF.Commons.Utilities;

namespace ESF.Domain
{
    public class SportEvent
    {
        private Guid id;
        private string name;
        private int minAge;
        private int maxAge;
        private Gender? gender;
        private bool isTeamEvent;

        protected SportEvent() { }

        public SportEvent(string name, int minAge, int maxAge, Gender? gender, bool isTeamEvent)
        {
            this.name = name;
            this.minAge = minAge;
            this.gender = gender;
            this.maxAge = maxAge;
            this.isTeamEvent = isTeamEvent;
        }

        public virtual Guid Id 
        {
            get { return id; }
        }

        public virtual string Name
        {
            get { return name; }
        }

        public virtual int MinAge
        {
            get { return minAge; }
        }

        public virtual int MaxAge 
        {
            get { return maxAge; }
        }

        public virtual Gender? Gender
        {
            get { return gender; }
        }

        public virtual bool IsTeamEvent
        {
            get { return isTeamEvent; }
        }
    }
}
