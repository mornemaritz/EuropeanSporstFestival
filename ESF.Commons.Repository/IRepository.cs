using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;

namespace ESF.Commons.Repository
{
    public interface IRepository<T> where T: class
    {
        DetachedCriteria CreateDetachedCriteria();

        T Load(object id);

        T Get(object id);
        T Save(T entity);
        T Update(T entity);

        TProj ReportOne<TProj>(DetachedCriteria criteria, ProjectionList projectionList);
        ICollection<TProj> ReportAll<TProj>(DetachedCriteria criteria, ProjectionList projectionList);

        T FindOne(DetachedCriteria criteria);
        ICollection<T> FindAll(DetachedCriteria criteria);
        void Delete(T entityToDelete);
    }
}
