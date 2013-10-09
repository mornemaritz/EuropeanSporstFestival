using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ESF.Commons.Utilities;

namespace ESF.Core.Services
{
    public class ParticipantDetailsModel
    {
        public Guid ParticipantId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthDay { get; set; }
        public Month BirthMonth { get; set; }
        public int BirthYear { get; set; }
        public Gender Gender { get; set; }
    }
}