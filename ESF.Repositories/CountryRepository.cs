using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESF.Commons.Repository;
using ESF.Core.Repositories;
using ESF.Core.Services;
using ESF.Domain;
using NHibernate.Criterion;

namespace ESF.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly IRepository<Country> entityRepo;

        public CountryRepository(IRepository<Country> entityRepo)
        {
            this.entityRepo = entityRepo;
        }

        public IList<CountryItem> FindCountries()
        {
            var criteria = entityRepo.CreateDetachedCriteria();

            return entityRepo.ReportAll<CountryItem>(criteria, GetProjectionList()).ToList();
        }

        public Country Load(Guid countryId)
        {
            return entityRepo.Load(countryId);
        }

        private static ProjectionList GetProjectionList()
        {
            return Projections.ProjectionList()
                .Add(Projections.Property<Country>(x => x.Id), "CountryId")
                .Add(Projections.Property<Country>(x => x.Name), "CountryName");
        }
    }
}
