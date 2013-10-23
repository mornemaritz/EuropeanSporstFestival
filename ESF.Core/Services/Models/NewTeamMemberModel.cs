using System;

namespace ESF.Core.Services
{
    public class NewTeamMemberModel
    {
        public Guid SportEventTeamId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}
