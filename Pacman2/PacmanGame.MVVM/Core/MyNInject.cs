using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using PacmanGame.BLL.Infrastructure;
using PacmanGame.BLL.Interfaces;
using PacmanGame.BLL.Services;

namespace PacmanGame.MVVM.Core
{
    public class MyNInject
    {
        private static StandardKernel kernel;

        static MyNInject()
        {
            var connection = System.Configuration.ConfigurationManager.ConnectionStrings["PacmanMVVM.Properties.Settings._123ConnectionString"].ConnectionString;
            var modules = new INinjectModule[] { new ServiceModule(connection) };
            kernel = new StandardKernel(modules);
            kernel.Bind<IUserService>().To<UserService>();
        }
        public static StandardKernel GetKernel()
        {
            return kernel;
        }
    }
}
