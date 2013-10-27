using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESF.Domain
{
    public class TransportRequest
    {
        private Guid id;
        private FestivalDay pickupDay;
        private Participant participant;
        private TransportPickupPoint pickupPoint;

        public virtual Guid Id 
        {
            get { return id; }
        }

        public virtual Participant Participant
        {
            get { return participant; }
            set { participant = value; }
        }

        public virtual FestivalDay PickupDay
        {
            get { return pickupDay; }
            set { pickupDay = value; }
        }

        public virtual TransportPickupPoint PickupPoint
        {
            get { return pickupPoint; }
            set { pickupPoint = value; }
        }

        public virtual void ChangePickupPoint(TransportPickupPoint newPickupPoint)
        {
            pickupPoint = newPickupPoint; 
        }
    }
}
