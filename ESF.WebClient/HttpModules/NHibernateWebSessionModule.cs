using System.Configuration;
using System.Web;
using ESF.Commons.Repository;

namespace ESF.WebClient.HttpModules
{
    public class NHibernateWebSessionModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            //NHibernateSessionManager.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            context.EndRequest += (sender, e) => NHibernateSessionManager.CloseSession();
        }

        public void Dispose()
        {
        }
    }
}