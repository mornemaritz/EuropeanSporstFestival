using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESF.Core.Services
{
    public class ParticipantDetailsModel
    {
        public Guid ParticipantId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}