using System;

namespace ESF.Domain
{
    public class TransportPickupPoint
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
