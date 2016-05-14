using System;
using PacmanGame.DAL.Entities;

namespace PacmanGame.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        void Save();
    }
}