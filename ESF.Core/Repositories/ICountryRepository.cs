using System;
using System.Collections.Generic;
using ESF.Core.Services;
using ESF.Domain;

namespace ESF.Core.Repositories
{
    public interface ICountryRepository
    {
        IList<CountryItem> FindCountries();
        Country Load(Guid countryId);
    }
}