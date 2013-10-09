using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESF.Domain
{
    public class SportEvent
    {
        private Guid id;
        private string name;

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
