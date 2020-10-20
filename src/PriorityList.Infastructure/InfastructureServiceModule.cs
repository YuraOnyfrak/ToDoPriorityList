using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PriorityList.Domain.Repository;
using PriorityList.Domain.Repository.Common;
using PriorityList.Infastructure.Persistance;
using PriorityList.Infastructure.Repository;
using PriorityList.Infastructure.Repository.Common;
using System;

namespace PriorityList.Infastructure
{
    public class InfastructureServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.Register(c =>
            {
                var config = c.Resolve<IConfiguration>();

                var opt = new DbContextOptionsBuilder<ApplicationDbContext>();
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
                opt.UseInMemoryDatabase(Guid.NewGuid().ToString());

                return new ApplicationDbContext(opt.Options);
            }).As<IApplicationDbContext>().InstancePerLifetimeScope();

            builder.RegisterType<ToDoItemRepository>().As<IToDoItemRepository>().InstancePerLifetimeScope();
        }
    }
}
