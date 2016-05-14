using System.Collections.Generic;
using PacmanGame.BLL.Packages;

namespace PacmanGame.BLL.Interfaces
{
    public interface IUserService
    {
        bool Add(UserPackage client);
        IEnumerable<UserPackage> GetAll();
    }
}