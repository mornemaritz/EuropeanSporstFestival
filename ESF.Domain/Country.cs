using System;

namespace ESF.Domain
{
    public class Country
    {
        protected Guid id;
        protected string name;

        public virtual Guid Id
        {
            get { return id; }
        }

        public virtual string Name
        {
            get { return name; }
        }
    }
}