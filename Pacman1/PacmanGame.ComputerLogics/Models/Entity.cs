using System.Collections.Generic;

namespace PacmanGame.ComputerLogics.Models
{
    public class Entity : PointXY
    {
        public Entity(int x, int y)
        {
            X = x;
            Y = y;
            Direction = 1;
        }

        public int Direction { get; set; }

        public void Move()
        {
            switch (Direction)
            {
                case 1:
                {
                    Y -= 40;
                }
                    break;
                case 2:
                {
                    X += 40;
                }
                    break;
                case 3:
                {
                    Y += 40;
                }
                    break;
                case 4:
                {
                    X -= 40;
                }
                    break;
            }
        }

        public bool IsMovingAlowed(IEnumerable<PointXY> blocks, int direction = -1)
        {
            var nextPoint = GetNextPoint(direction);

            if (nextPoint.X < 0 || nextPoint.X >= 480 || nextPoint.Y < 0 || nextPoint.Y >= 280)
            {
                return false;
            }

            foreach (var block in blocks)
            {
                if (nextPoint.X == block.X && nextPoint.Y == block.Y)
                {
                    return false;
                }
            }

            return true;
        }

        private PointXY GetNextPoint(int direction = -1)
        {
            if (direction == -1)
            {
                direction = Direction;
            }

            var point = new PointXY();
            switch (direction)
            {
                case 1:
                {
                    point.Y = Y - 40;
                    point.X = X;
                }
                    break;
                case 2:
                {
                    point.Y = Y;
                    point.X = X + 40;
                }
                    break;
                case 3:
                {
                    point.Y = Y + 40;
                    point.X = X;
                }
                    break;
                case 4:
                {
                    point.Y = Y;
                    point.X = X - 40;
                }
                    break;
            }

            return point;
        }
    }
}