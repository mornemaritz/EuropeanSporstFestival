using System;
using System.Configuration;
using System.Web;
using ESF.Domain.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;

namespace ESF.Commons.Repository
{
    public class NHibernateSessionManager
    {
        private static ISessionFactory Factory { get; set; }

        public static string ConnectionString { get; set; }

        static NHibernateSessionManager()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private static ISessionFactory GetFactory<T>() where T : ICurrentSessionContext
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
#if DEBUG
                .ShowSql()
#endif
                .ConnectionString(c => c.Is(ConnectionString)))
                .Mappings(m =>

                            m.FluentMappings
                                .AddFromAssemblyOf<ParticipantMap>()
                                .Conventions.Add(
                                    PrimaryKey.Name.Is(x => x.EntityType.Name + "Id"),
                                    DefaultAccess.CamelCaseField(),
                                    Table.Is(x => "T" + x.EntityType.Name),
                                    ForeignKey.Format((fluentNHibernateMember, type) => type.Name + "Id"))
                            //.ExportTo(@"C:\Work\EuropeanSporstFestival\xmlmappings")

                    )
                .CurrentSessionContext<T>()
                //.ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                .BuildSessionFactory();
        }


        /// <summary>
        /// Gets the current session.
        /// </summary>
        public static ISession GetCurrentSession()
        {
            if (Factory == null)
                Factory = HttpContext.Current != null ? GetFactory<WebSessionContext>() : GetFactory<ThreadStaticSessionContext>();

            if (CurrentSessionContext.HasBind(Factory))
                return Factory.GetCurrentSession();

            var session = Factory.OpenSession();
            CurrentSessionContext.Bind(session);

            return session;
        }


        /// <summary>
        /// Closes the session.
        /// </summary>
        public static void CloseSession()
        {
            if (Factory != null && CurrentSessionContext.HasBind(Factory))
            {
                var session = CurrentSessionContext.Unbind(Factory);
                session.Close();
            }
        }


        /// <summary>
        /// Commits the session.
        /// </summary>
        /// <param name="session">The session.</param>
        public static void CommitSession(ISession session)
        {
            try
            {
                session.Transaction.Commit();
            }
            catch (Exception)
            {
                session.Transaction.Rollback();
                throw;
            }
        }


        ///// <summary>
        ///// Creates the database from mapping in this assembly
        ///// </summary>
        //public static void CreateSchemaFromMappings()
        //{
        //    var config = Fluently.Configure()
        //        .Database(MsSqlConfiguration.MsSql2008
        //        .ShowSql()
        //        .ConnectionString(c => c.Is(ConnectionString)))
        //        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<NHibernateSessionManager>());

        //    new SchemaExport(config.BuildConfiguration()).Create(false, true);
        //}
    }
}
