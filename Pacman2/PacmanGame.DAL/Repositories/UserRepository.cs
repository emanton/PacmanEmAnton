using System.Collections.Generic;
using PacmanGame.DAL.EF;
using PacmanGame.DAL.Entities;
using PacmanGame.DAL.Interfaces;

namespace PacmanGame.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly PacmanGameContext db;

        public UserRepository(PacmanGameContext context)
        {
            db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public void Add(User item)
        {
            db.Users.Add(item);
        }
    }
}