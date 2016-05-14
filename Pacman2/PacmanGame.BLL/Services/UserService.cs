using System.Collections.Generic;
using AutoMapper;
using PacmanGame.BLL.Interfaces;
using PacmanGame.BLL.Packages;
using PacmanGame.DAL.Entities;
using PacmanGame.DAL.Interfaces;

namespace PacmanGame.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork db;

        public UserService(IUnitOfWork db)
        {
            this.db = db;
        }

        public bool Add(UserPackage client)
        {
            Mapper.CreateMap<UserPackage, User>();
            db.Users.Add(Mapper.Map<UserPackage, User>(client));
            db.Save();
            return true;
        }

        public IEnumerable<UserPackage> GetAll()
        {
            var packs = new List<UserPackage>();
            foreach (var user in db.Users.GetAll())
            {
                packs.Add(new UserPackage {Name = user.Name, Id = user.Id, Score = user.Score});
            }
            return packs;
            //Mapper.CreateMap<User, UserPackage>();
            //return Mapper.Map<IEnumerable<User>, IEnumerable<UserPackage>>(db.Users.GetAll());
        }
    }
}