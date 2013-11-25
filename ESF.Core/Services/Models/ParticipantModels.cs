using System;
using ESF.Commons.Utilities;

namespace ESF.Core.Services
{
    public class ParticipantDetailsViewModel
    {
        public ParticipantDetailsViewModel()
        {
        }

        public ParticipantDetailsViewModel(Guid participantId, string firstName, string lastName, DateTime dateOfBirth, string gender, 
            string emailAddress, string jamatkhanaName, string mobileNumber, string homePhoneNumber, 
            string addressLine1, string addressLine2, string addressLine3, string addressLine4, string town, string countyName, string countryName, string postcode,
            string hasDisability, bool isInterestedInVolunteering)
        {
            ParticipantId = participantId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth.ToShortDateString();
            //Gender = gender;
            Gender = (Gender) Enum.Parse(typeof (Gender), gender); // TODO: Unsafe Casting. Need to refactor
            EmailAddress = emailAddress;
            JamatkhanaName = jamatkhanaName;
            MobileNumber = mobileNumber;
            HomePhoneNumber = homePhoneNumber;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            AddressLine3 = addressLine3;
            AddressLine4 = addressLine4;
            Town = town;
            CountyName = countyName;
            CountryName = countryName;
            Postcode = postcode;
            //HasDisability = hasDisability;
            HasDisability = (YesNo)Enum.Parse(typeof(YesNo), hasDisability); // TODO: Unsafe Casting. Need to refactor
            IsInterestedInVolunteering = isInterestedInVolunteering;
        }

        public Guid ParticipantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string EmailAddress { get; set; }
        public string JamatkhanaName { get; set; }
        public string MobileNumber { get; set; }
        public string HomePhoneNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string Town { get; set; }
        public string CountyName { get; set; }
        public string CountryName { get; set; }
        public string Postcode { get; set; }
        public YesNo HasDisability { get; set; }
        public bool IsInterestedInVolunteering { get; set; }
    }

    public class ParticipantDetailsEditModel
    {
        public ParticipantDetailsEditModel()
        {
        }

        public ParticipantDetailsEditModel(Guid participantId, string firstName, string lastName, DateTime dateOfBirth, string gender, 
            string emailAddress, Guid jamatkhanaId, string mobileNumber, string homePhoneNumber,
            string addressLine1, string addressLine2, string addressLine3, string addressLine4, string town, Guid countyId, Guid countryId, string postcode, 
            string hasDisability, bool isInterestedInVolunteering)
        {
            ParticipantId = participantId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth.ToShortDateString();
            Gender = (Gender)Enum.Parse(typeof(Gender), gender); // TODO: Unsafe Casting. Need to refactor
            EmailAddress = emailAddress;
            JamatkhanaId = jamatkhanaId;
            MobileNumber = mobileNumber;
            HomePhoneNumber = homePhoneNumber;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            AddressLine3 = addressLine3;
            AddressLine4 = addressLine4;
            Town = town;
            CountyId = countyId;
            CountryId = countryId;
            Postcode = postcode;
            HasDisability = (YesNo)Enum.Parse(typeof(YesNo), hasDisability); // TODO: Unsafe Casting. Need to refactor
            IsInterestedInVolunteering = isInterestedInVolunteering;
        }

        public Guid ParticipantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string EmailAddress { get; set; }
        public Guid JamatkhanaId { get; set; }
        public string MobileNumber { get; set; }
        public string HomePhoneNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string Town { get; set; }
        public Guid CountyId { get; set; }
        public Guid CountryId { get; set; }
        public string Postcode { get; set; }
        public YesNo HasDisability { get; set; }
        public bool IsInterestedInVolunteering { get; set; }
    }

    public class ParticipantDetailsCreateModel
    {
        public Guid ParticipantId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string EmailAddress { get; set; }
        public Guid JamatkhanaId { get; set; }
        public string MobileNumber { get; set; }
        public string HomePhoneNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string Town { get; set; }
        public Guid CountyId { get; set; }
        public Guid CountryId { get; set; }
        public string Postcode { get; set; }
        public YesNo HasDisability { get; set; }
        public bool IsInterestedInVolunteering { get; set; }
    }

}