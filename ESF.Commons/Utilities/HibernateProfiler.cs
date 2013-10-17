using System;
using System.Configuration;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using HibernatingRhinos.Profiler.Appender.StackTraces;

namespace ESF.Commons.Utilities
{
    public class HibernateProfiler
    {
        public static void StartNhibernateProfiler()
        {
#if DEBUG
            var startNhibernateProfiler = Convert.ToBoolean(ConfigurationManager.AppSettings["enableHibernateProfiler"]);

            if (!startNhibernateProfiler) return;

            var enableHibernateProfilerStackTrace =
                Convert.ToBoolean(ConfigurationManager.AppSettings["enableHibernateProfilerStackTrace"]);

            var cfg = enableHibernateProfilerStackTrace
                          ? new NHibernateAppenderConfiguration()
                          : new NHibernateAppenderConfiguration(new IStackTraceFilter[] {})
                                {DotNotFixDynamicProxyStackTrace = true};

            NHibernateProfiler.Initialize(cfg);
#endif
        }

        public static void StopNhibernateProfiler()
        {
#if DEBUG
            NHibernateProfiler.Stop();
#endif
        }

    }
}
