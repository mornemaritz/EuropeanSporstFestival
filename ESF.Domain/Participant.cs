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

        public virtual ScheduledSportEventParticipant SignUpToScheduledSportEvent(ScheduledSportEvent scheduledSportEvent)
        {
            //TODO: Re-enable once Gender Flags is working
            //if(!scheduledSportEvent.AllowedGenders.HasFlag(this.Gender))
            //{
            //    throw new InvalidOperationException(string.Format("This partipant cannot sign up for the select scheduled sport event. Their gender is '{0}' and the allowed gender for the selected event is '{1}'", this.Gender, scheduledSportEvent.AllowedGenders));
            //}

            var participantAgeOnDateOfSelectedEvent = this.GetParticipantAgeOnDate(scheduledSportEvent.Date);

            if (participantAgeOnDateOfSelectedEvent > scheduledSportEvent.MaxAge)
            {
                throw new InvalidOperationException(string.Format("This partipant cannot sign up for the select scheduled sport event. Their age is '{0}' and the maximum age for the selected event is '{1}'", participantAgeOnDateOfSelectedEvent, scheduledSportEvent.MaxAge));
            }

            if (this.GetParticipantAgeOnDate(scheduledSportEvent.Date) < scheduledSportEvent.MinAge)
            {
                throw new InvalidOperationException(string.Format("This partipant cannot sign up for the select scheduled sport event. Their age is '{0}' and the mimimum age for the selected event is '{1}'", participantAgeOnDateOfSelectedEvent, scheduledSportEvent.MinAge));
            }

            return new ScheduledSportEventParticipant(scheduledSportEvent, this);
        }
    }
}
