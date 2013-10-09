using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac.Core;
using Autofac;
using Module = Autofac.Module;
using System.Reflection;
using ESF.Repositories;

namespace ESF.Services
{
    public class AutofacServiceConfigurationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            builder.RegisterModule<AutofacRepositoryConfigurationModule>();
        }
    }
}
