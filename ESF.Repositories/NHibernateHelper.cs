using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using ESF.Domain.Mappings;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Conventions.Helpers;
using System.Configuration;

namespace ESF.Repositories
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory();

                return _sessionFactory;
            }
        }

        private static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                              .ConnectionString(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)
                              .ShowSql()
                )
                .Mappings(m => 
                    
                            m.FluentMappings
                                .AddFromAssemblyOf<ParticipantMap>()
                                .Conventions.Add(
                                    PrimaryKey.Name.Is(x => x.EntityType.Name + "Id"),
                                    DefaultAccess.CamelCaseField(),
                                    Table.Is(x => "T" + x.EntityType.Name),
                                    ForeignKey.Format((x, y) => { return y.Name + "Id"; }))
                                 //.ExportTo(@"C:\Work\EuropeanSporstFestival\xmlmappings")
                           )
                //.ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
