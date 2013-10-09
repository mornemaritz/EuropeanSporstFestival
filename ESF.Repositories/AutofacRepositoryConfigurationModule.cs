using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Module = Autofac.Module;
using Autofac;
using System.Reflection;

namespace ESF.Repositories
{
    public class AutofacRepositoryConfigurationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
        }
    }
}
