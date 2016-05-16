using System.Collections.Generic;

namespace PacmanGame.ComputerLogics.Models
{
    public class Entity : PointXY
    {
        public Entity(int x, int y)
        {
            X = x;
            Y = y;
            NewDirection = Direction = 1;
        }
        public int NewDirection { get; set; }
        public int Direction { get; set; }

        public void Move()
        {
            switch (Direction)
            {
                case 1:
                {
                    Y -= 10;
                }
                    break;
                case 2:
                {
                    X += 10;
                }
                    break;
                case 3:
                {
                    Y += 10;
                }
                    break;
                case 4:
                {
                    X -= 10;
                }
                    break;
            }
        }

        public bool IsMovingAlowed(IEnumerable<PointXY> blocks, int direction = -1)
        {
            if (this.X%30 != 0 || this.Y%30 != 0)
            {
                this.Move();
                return false;
            }

            var nextPoint1 = GetNextPoint(NewDirection);
            int x = (int)nextPoint1.X/30;
            int y = (int)nextPoint1.Y/30;
            if (Map.MapArray[x, y] == 0)
            {
                this.Direction = NewDirection;
            }
 
            var nextPoint = GetNextPoint(direction);
            x = (int)nextPoint.X / 30;
            y = (int)nextPoint.Y / 30;
            if (Map.MapArray[x, y] == 1)
            {
                return false;
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
                    point.Y = Y - 30;
                    point.X = X;
                }
                    break;
                case 2:
                {
                    point.Y = Y;
                    point.X = X + 30;
                }
                    break;
                case 3:
                {
                    point.Y = Y + 30;
                    point.X = X;
                }
                    break;
                case 4:
                {
                    point.Y = Y;
                    point.X = X - 30;
                }
                    break;
            }

            return point;
        }
    }
}