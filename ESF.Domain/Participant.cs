using System;
using ESF.Commons.Utilities;
using ESF.Commons.Exceptions;

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
            // TODO: These invariants need to be checked during entity validation
            //       Move the invariants when validation has been implemented.
            if (!scheduledSportEvent.AllowedGenders.HasFlag(this.Gender))
            {
                throw new BusinessException(string.Format("This partipant cannot sign up for the select scheduled sport event. Their gender is '{0}' and the allowed gender for the selected event is '{1}'", this.Gender, scheduledSportEvent.AllowedGenders));
            }

            var participantAgeOnDateOfSelectedEvent = this.GetParticipantAgeOnDate(scheduledSportEvent.Date);

            if (participantAgeOnDateOfSelectedEvent > scheduledSportEvent.MaxAge)
            {
                throw new BusinessException(string.Format("This partipant cannot sign up for the select scheduled sport event. Their age is '{0}' and the maximum age for the selected event is '{1}'", participantAgeOnDateOfSelectedEvent, scheduledSportEvent.MaxAge));
            }

            if (participantAgeOnDateOfSelectedEvent < scheduledSportEvent.MinAge)
            {
                throw new BusinessException(string.Format("This partipant cannot sign up for the select scheduled sport event. Their age is '{0}' and the mimimum age for the selected event is '{1}'", participantAgeOnDateOfSelectedEvent, scheduledSportEvent.MinAge));
            }

            return new ScheduledSportEventParticipant(scheduledSportEvent, this);
        }

        public virtual bool IsWithinAgeAndGenderBracket(Gender allowedGenders, DateTime onDate, int minAge, int maxAge)
        {
            if (!allowedGenders.HasFlag(gender)) return false;

            var age = GetParticipantAgeOnDate(onDate);

            return age <= maxAge && age >= minAge;
        }

        public virtual bool CanParticipateInSportEvent(ScheduledSportEvent scheduledSportEvent)
        {
            return IsWithinAgeAndGenderBracket(scheduledSportEvent.AllowedGenders, scheduledSportEvent.Date, scheduledSportEvent.MinAge, scheduledSportEvent.MaxAge);
        }
    }
}
