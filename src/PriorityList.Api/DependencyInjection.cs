using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PriorityList.Application.Common.Interfaces;
using PriorityList.Infastructure;
using PriorityList.Infastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriorityList.Api
{
    public static class DependencyInjection
    {
        public static  AutofacServiceProvider RegisterServices(this IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<InfastructureServiceModule>();
            builder.Populate(services);

            var container = builder.Build();
            return new AutofacServiceProvider(container);
        }
    }
}
