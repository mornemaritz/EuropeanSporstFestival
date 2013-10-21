using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace ESF.Commons.Repository
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        private ISession session 
        {
            get { return NHibernateSessionManager.GetCurrentSession(); }
        }

        public DetachedCriteria CreateDetachedCriteria()
        {
            return DetachedCriteria.For<T>();
        }

        public T Load(object id)
        {
            return session.Load<T>(id);
        }

        public T Get(object id)
        {
            return session.Get<T>(id);
        }

        public T Save(T entity)
        {
            using (var tx = session.BeginTransaction())
            {
                session.Save(entity);
                tx.Commit();
            }

            return entity;
        }

        public T Update(T entity)
        {
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

            var exec = criteria.GetExecutableCriteria(session);

            return exec.UniqueResult<TProj>();
        }

        public ICollection<TProj> ReportAll<TProj>(DetachedCriteria criteria, ProjectionList projectionList)
        {
            criteria.SetProjection(projectionList);
            criteria.SetResultTransformer(new TypedResultTransformer<TProj>());

            var exec = criteria.GetExecutableCriteria(session);
            return exec.List<TProj>();
        }

        public T FindOne(DetachedCriteria criteria)
        {
            var exec = criteria.GetExecutableCriteria(session);
            return exec.UniqueResult<T>();
        }

        public ICollection<T> FindAll(DetachedCriteria criteria)
        {
            var exec = criteria.GetExecutableCriteria(session);
            return exec.List<T>();
        }
    }
}
