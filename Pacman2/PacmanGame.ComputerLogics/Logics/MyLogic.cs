using System;
using System.Collections.Generic;
using System.Linq;
using PacmanGame.ComputerLogics.Interfaces;
using PacmanGame.ComputerLogics.Models;

namespace PacmanGame.ComputerLogics.Logics
{
    public class MyLogic : IMovingLogic
    {
        private Random rand = new Random();
        public void Move(Ghost ghost, IEnumerable<PointXY> blocks, Pacman pacman)
        {
            if (ghost.X % 30 != 0 || ghost.Y % 30 != 0)
            {
                ghost.Move();
                return;
            }

            //if (this.CheckForNearPacman(ghost, pacman))
            //{
            //    ghost.NewDirection = pacman.Direction;
            //    ghost.Move();
            //    return;
            //}

            if (this.CanTurn(ghost))
            {
                this.ChangeDirection(ghost);
            }
            

            if (ghost.IsMovingAlowed(blocks, ghost.Direction))
            {
                ghost.Move();
                return;
            }
            else
            {
                if (ghost.IsMovingAlowed(blocks, ghost.Direction))
                {
                    ghost.Move();
                    return;
                }
            }

            ChangeDirection(ghost);
        }

        private bool CanTurn(Ghost ghost)
        {
            int x = (int)ghost.X/30, y = (int)ghost.Y/30;
            int walls = 0;
            if (Map.MapArray[x + 1, y] == 1)
            {
                walls++;
            }
            if (Map.MapArray[x - 1, y] == 1)
            {
                walls++;
            }
            if (Map.MapArray[x, y + 1] == 1)
            {
                walls++;
            }
            if (Map.MapArray[x, y - 1] == 1)
            {
                walls++;
            }

            if (walls < 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ChangeDirection(Ghost ghost)
        {
            int x = (int)ghost.X/30, y = (int)ghost.Y/30;
            bool isDirectionChoosed = false;
            while (!isDirectionChoosed)
            {
                int randValue = rand.Next(1, 50000);
                switch (randValue % 4)
                {
                    case 0:
                        {
                            if (Map.MapArray[x, y - 1] == 0)
                            {
                                ghost.NewDirection = 1;
                                isDirectionChoosed = true;
                            }
                        }
                        break;
                    case 1:
                        {
                            if (Map.MapArray[x + 1, y] == 0)
                            {
                                ghost.NewDirection = 2;
                                isDirectionChoosed = true;
                            }
                        }
                        break;
                    case 2:
                        {
                            if (Map.MapArray[x, y + 1] == 0)
                            {
                                ghost.NewDirection = 3;
                                isDirectionChoosed = true;
                            }
                        }
                        break;
                    case 3:
                        {
                            if (Map.MapArray[x - 1, y] == 0)
                            {
                                ghost.NewDirection = 4;
                                isDirectionChoosed = true;
                            }
                        }
                        break;
                }
            }
        }

        //private bool CheckForNearPacman(Ghost ghost, Pacman pacman)
        //{
        //    if (ghost.X + 30 > pacman.X && ghost.X < pacman.X && ghost.Y == pacman.Y)
        //    {
        //        return true;
        //    }
        //    if (ghost.X - 30 < pacman.X && ghost.X > pacman.X && ghost.Y == pacman.Y)
        //    {
        //        return true;
        //    }
        //    if (ghost.Y + 30 > pacman.Y && ghost.Y < pacman.Y && ghost.X == pacman.X)
        //    {
        //        return true;
        //    }
        //    if (ghost.Y - 30 < pacman.Y && ghost.Y > pacman.Y && ghost.X == pacman.X)
        //    {
        //        return true;
        //    }

        //    return false;
        //}
    }
}