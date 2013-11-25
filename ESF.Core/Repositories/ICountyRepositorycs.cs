using System;
using System.Collections.Generic;
using ESF.Core.Services;
using ESF.Domain;

namespace ESF.Core.Repositories
{
    public interface ICountyRepository
    {
        IList<CountyItem> FindCounties();
        County Load(Guid countyId);
    }
}
