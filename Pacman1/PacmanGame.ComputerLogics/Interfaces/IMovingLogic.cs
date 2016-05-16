using System.Collections.Generic;
using PacmanGame.ComputerLogics.Models;

namespace PacmanGame.ComputerLogics.Interfaces
{
    public interface IMovingLogic
    {
        void Move(Ghost ghost, IEnumerable<PointXY> blocks, Pacman PacmanGame);
    }
}