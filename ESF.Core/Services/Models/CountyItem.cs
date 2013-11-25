using System;

namespace ESF.Core.Services
{
    public class CountyItem
    {
        public CountyItem(Guid countyId, string countyName)
        {
            CountyId = countyId;
            CountyName = countyName;
        }

        public Guid CountyId { get; private set; }
        public string CountyName { get; private set; }
    }
}