using System.Collections.Generic;
using PacmanGame.ComputerLogics.Interfaces;

namespace PacmanGame.ComputerLogics.Models
{
    public class Ghost : Entity
    {
        private readonly IMovingLogic movingLogic;

        public Ghost(int x, int y, IMovingLogic movingLogic)
            : base(x, y)
        {
            this.movingLogic = movingLogic;
        }

        public void DoMove(IEnumerable<PointXY> blocks, Pacman pacman)
        {
            movingLogic.Move(this, blocks, pacman);
        }
    }
}