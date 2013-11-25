using System;

namespace ESF.Core.Services
{
    public class CountryItem
    {
        public CountryItem(Guid countryId, string countryName)
        {
            CountryId = countryId;
            CountryName = countryName;
        }

        public Guid CountryId { get; private set; }
        public string CountryName { get; private set; }
    }
}