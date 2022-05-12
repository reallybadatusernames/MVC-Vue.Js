using System;
using System.Linq;
using System.Web.Mvc;

using SimpleInjector;
using SimpleInjector.Lifestyles;
using SimpleInjector.Integration.Web.Mvc;

using mvc.vuejs.infrastructure;
using mvc.vuejs.infrastructure.Context;

namespace mvc.vuejs.example.App_Start
{
    public static class Bootstrap
    {
        public static void Initialize()
        {
            var container = new Container();

            container.Options.ResolveUnregisteredConcreteTypes = true;
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            container.RegisterMvcIntegratedFilterProvider();

            container.Register<QueryDispatcher>();
            container.Register<CommandDispatcher>();
            container.Register<GameContext>(Lifestyle.Singleton);

            var queryHandlers = new[] { typeof(IQueryHandler<,>).Assembly };
            container.Collection.Register(typeof(IQueryHandler<,>), queryHandlers);

            var queryAsyncHandlers = new[] { typeof(IQueryHandlerAsync<,>).Assembly };
            container.Collection.Register(typeof(IQueryHandlerAsync<,>), queryAsyncHandlers);

            var commandHandlers = new[] { typeof(ICommandHandler<>).Assembly };
            container.Collection.Register(typeof(ICommandHandler<>), queryHandlers);

            var commandAsyncHandlers = new[] { typeof(ICommandHandlerAsync<>).Assembly };
            container.Collection.Register(typeof(ICommandHandlerAsync<>), queryAsyncHandlers);

            //CQS Types
            var assembly = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.ToLower().Contains("mvc.vuejs.infrastructure")).FirstOrDefault();
            if (assembly != null)
            {
                var registrations = from type in assembly.GetExportedTypes()
                                    where !string.IsNullOrEmpty(type.Namespace) && type.Namespace.ToLower().StartsWith("mvc.vuejs.infrastructure")
                                    from service in type.GetInterfaces()
                                    select new { service, implementation = type };

                foreach (var reg in registrations)
                {
                    if (reg.implementation.Name == "ApplicationUserManager" ||
                        reg.implementation.Name == "ApplicationPasswordValidator" ||
                        reg.implementation.Name == "IJob"
                        || reg.implementation.Name == "GameContext")
                        continue;

                    try
                    {
                        container.Register(reg.service, reg.implementation, Lifestyle.Transient);
                    }
                    catch { }

                }
            }

            container.ResolveUnregisteredType += (s, e) =>
            {
                if (e.UnregisteredServiceType.IsGenericType)
                {
                    var def = e.UnregisteredServiceType.GetGenericTypeDefinition();
                    if (def == typeof(IQueryHandler<,>))
                    {
                        e.Register(() =>
                        {
                            return Activator.CreateInstance(def);
                        });
                    }

                    if (def == typeof(ICommandHandlerAsync<>))
                    {
                        e.Register(() =>
                        {
                            return Activator.CreateInstance(def);
                        });
                    }

                    if (def == typeof(ICommandHandler<>))
                    {
                        e.Register(() =>
                        {
                            return Activator.CreateInstance(def);
                        });
                    }

                    if (def == typeof(IQueryHandlerAsync<,>))
                    {
                        e.Register(() =>
                        {
                            return Activator.CreateInstance(def);
                        });
                    }
                }

                Type t = e.UnregisteredServiceType;

                if (typeof(IQuery).IsAssignableFrom(t))
                {
                    e.Register(() =>
                    {
                        return Activator.CreateInstance(t);
                    });
                }
            };

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}