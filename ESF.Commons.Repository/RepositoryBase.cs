using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;

namespace ESF.Commons.Repository
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        public DetachedCriteria CreateDetachedCriteria()
        {
            return DetachedCriteria.For<T>();
        }

        public T Load(object id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Load<T>(id);
            }
        }

        public T Get(object id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Get<T>(id);
            }
        }

        public T Save(T entity)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                session.Save(entity);
                tx.Commit();
            }

            return entity;
        }

        public T Update(T entity)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                session.Update(entity);
                tx.Commit();
            }

            return entity;
        }

        public TProj ReportOne<TProj>(DetachedCriteria criteria, ProjectionList projectionList)
        {
            criteria.SetProjection(projectionList);
            criteria.SetResultTransformer(new TypedResultTransformer<TProj>());

            using(var session = NHibernateHelper.OpenSession())
            {
                var exec = criteria.GetExecutableCriteria(NHibernateHelper.OpenSession());

                return exec.UniqueResult<TProj>();
            }
        }

        public ICollection<TProj> ReportAll<TProj>(DetachedCriteria criteria, ProjectionList projectionList)
        {
            criteria.SetProjection(projectionList);
            criteria.SetResultTransformer(new TypedResultTransformer<TProj>());

            using (var session = NHibernateHelper.OpenSession())
            {
                var exec = criteria.GetExecutableCriteria(session);
                return exec.List<TProj>();
            }
        }

        public T FindOne(DetachedCriteria criteria)
        {
            using(var session = NHibernateHelper.OpenSession())
            {
                var exec = criteria.GetExecutableCriteria(session);
                return exec.UniqueResult<T>();
            }
        }

        public ICollection<T> FindAll(DetachedCriteria criteria)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var exec = criteria.GetExecutableCriteria(session);
                return exec.List<T>();
            }
        }
    }
}
