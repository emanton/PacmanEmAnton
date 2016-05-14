using System;
using PacmanGame.DAL.EF;
using PacmanGame.DAL.Entities;
using PacmanGame.DAL.Interfaces;

namespace PacmanGame.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PacmanGameContext db;

        private bool disposed;
        private UserRepository userRepository;

        public UnitOfWork(string connectionString)
        {
            db = new PacmanGameContext(connectionString);
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }
    }
}