using System;
using ESF.Commons.Utilities;

namespace ESF.Core.Services
{
    public class NewTeamMemberModel
    {
        public Guid SportEventTeamId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string EmailAddress { get; set; }
        public int BirthDay { get; set; }
        public Month BirthMonth { get; set; }
        public int BirthYear { get; set; }
        public Gender Gender { get; set; }

        public bool ParticipantAlreadyExists { get; set; }
        public bool AddExistingParticipant { get; set; }
    }
}
