using System;
using ESF.Commons.Utilities;

namespace ESF.Domain
{
    public class Jamatkhana
    {
        protected Guid id;
        protected string name;
        private JamatkhanaArea area;

        public virtual Guid Id
        {
            get { return id; }
        }

        public virtual string Name
        {
            get { return name; }
        }

        public virtual JamatkhanaArea Area
        {
            get { return area; }
        }
    }
}
