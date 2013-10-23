using System;

namespace ESF.Domain
{
    public class TransportPickupPoint
    {
        private Guid id;
        private string name;

        public Guid Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
        }
    }
}
