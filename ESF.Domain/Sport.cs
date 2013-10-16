using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESF.Commons.Utilities;

namespace ESF.Domain
{
    public class Sport
    {
        private Guid id;
        private string name;

        protected Sport() { }

        public Sport(string name)
        {
            this.name = name;
        }

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
