using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESF.Domain
{
    public class Participant
    {
        protected Guid id;
        protected string firstName;
        protected string lastName;
        protected int userId;
        protected string emailAddress;

        public virtual Guid Id 
        {
            get { return id; }
        }

        public virtual string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        public virtual int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public virtual string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public virtual string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
    }
}
