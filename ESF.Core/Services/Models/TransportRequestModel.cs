using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESF.Core.Services.Models
{
    public class TransportRequestModel
    {
        public Guid ParticipantId { get; set; }
        public Guid FestivalDayId { get; set; }
        public Guid TransportPickupPointId { get; set; }
    }
}
