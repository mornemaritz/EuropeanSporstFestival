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
    public class CountyRepository : ICountyRepository
    {
        private readonly IRepository<County> entityRepo;

        public CountyRepository(IRepository<County> entityRepo)
        {
            this.entityRepo = entityRepo;
        }

        public IList<CountyItem> FindCounties()
        {
            var criteria = entityRepo.CreateDetachedCriteria();

            return entityRepo.ReportAll<CountyItem>(criteria, GetProjectionList()).ToList();
        }

        public County Load(Guid countyId)
        {
            return entityRepo.Load(countyId);
        }

        private static ProjectionList GetProjectionList()
        {
            return Projections.ProjectionList()
                .Add(Projections.Property<County>(x => x.Id), "CountyId")
                .Add(Projections.Property<County>(x => x.Name), "CountyName");
        }
    }
}
