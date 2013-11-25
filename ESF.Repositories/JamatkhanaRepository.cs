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
    public class JamatkhanaRepository : IJamatkhanaRepository
    {
        private readonly IRepository<Jamatkhana> entityRepo;

        public JamatkhanaRepository(IRepository<Jamatkhana> entityRepo)
        {
            this.entityRepo = entityRepo;
        }

        public IList<JamatkhanaItem> FindJamatkhanas()
        {
            var  criteria = entityRepo.CreateDetachedCriteria();

            return entityRepo.ReportAll<JamatkhanaItem>(criteria, GetProjectionList()).ToList();
        }

        public Jamatkhana Load(Guid jamatkhanaId)
        {
            return entityRepo.Load(jamatkhanaId);
        }

        private static ProjectionList GetProjectionList()
        {
            return Projections.ProjectionList()
                .Add(Projections.Property<Jamatkhana>(x => x.Id), "JamatkhanaId")
                .Add(Projections.Property<Jamatkhana>(x => x.Name), "JamatkhanaName");
        }
    }
}
