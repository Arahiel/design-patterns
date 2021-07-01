using Autofac;

namespace Singleton
{
    public static class Dependency
    {
        public static readonly IContainer Container;
        static Dependency()
        {
            var cb = new ContainerBuilder();
            cb.RegisterType<NormalDatabase>()
                .As<IDatabase>()
                .SingleInstance();
            cb.RegisterType<CityProvider>();

            Container = cb.Build();
        }
    }
}