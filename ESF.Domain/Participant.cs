using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESF.Commons.Utilities;

namespace ESF.Domain
{
    public class Participant
    {
        protected Guid id;
        protected string firstName;
        protected string lastName;
        protected int userId;
        protected string emailAddress;
        protected DateTime dateOfBirth;
        protected Gender gender;

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

        public virtual DateTime DateOfBirth
        {
            get{ return dateOfBirth; }
            set{ dateOfBirth = value;}
        }

        public virtual Gender Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public virtual int GetParticipantCurrentAge()
        {
            return GetParticipantAgeOnDate(DateTime.Today);
        }

        public virtual int GetParticipantAgeOnDate(DateTime date)
        {
            int age = 0;
            age = date.Year - dateOfBirth.Year;
            if (date.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }
    }
}
