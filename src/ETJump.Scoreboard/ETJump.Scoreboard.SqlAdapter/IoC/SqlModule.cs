using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using Module = Autofac.Module;

namespace ETJump.Scoreboard.SqlAdapter.IoC
{
    public class SqlModule : Module
    {
        private readonly string _database;

        public SqlModule(string database)
        {
            _database = database;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.Register(c => new ApplicationContext(_database))
                .AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}
