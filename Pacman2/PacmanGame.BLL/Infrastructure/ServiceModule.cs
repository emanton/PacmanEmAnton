using Ninject.Modules;
using PacmanGame.DAL.Interfaces;
using PacmanGame.DAL.Repositories;

namespace PacmanGame.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private readonly string connectionString;

        public ServiceModule(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}