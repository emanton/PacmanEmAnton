using System.Collections.Generic;
using PacmanGame.ComputerLogics.Interfaces;
using PacmanGame.ComputerLogics.Models;

namespace PacmanGame.ComputerLogics.Logics
{
    public class MyLogic : IMovingLogic
    {
        public void Move(Ghost ghost, IEnumerable<PointXY> blocks, Pacman PacmanGame)
        {
            if (ghost.IsMovingAlowed(blocks, ghost.Direction))
            {
                ghost.Move();
                return;
            }

            for (var i = 1; i <= 4; i++)
            {
                if (ghost.IsMovingAlowed(blocks, i))
                {
                    ghost.Direction = i;
                    ghost.Move();
                    break;
                }
            }
        }
    }
}