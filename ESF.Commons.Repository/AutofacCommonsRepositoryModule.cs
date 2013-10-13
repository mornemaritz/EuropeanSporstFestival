using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace ESF.Commons.Repository
{
    public class AutofacCommonsRepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(RepositoryBase<>))
                .As(typeof(IRepository<>));
        }
    }
}
