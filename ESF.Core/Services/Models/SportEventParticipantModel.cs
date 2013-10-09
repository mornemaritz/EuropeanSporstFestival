using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESF.Core.Services
{
    public class SportEventParticipantModel
    {
        public Guid SportEventParticipantId { get; set; }
        public string SportName { get; set; }
        public bool RequiresTeamAssignment { get; set; }
    }
}
