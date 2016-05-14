using System.Collections.ObjectModel;
using PacmanGame.ComputerLogics.Models;
using z.Core;

namespace PacmanGame.MVVM.Models
{
    public static class GameManager
    {
        public static int CheckForYam(Pacman pacman, ObservableCollection<PointXY> points)
        {
            for (var i = 0; i < points.Count; i++)
            {
                if (points[i].X == pacman.X && points[i].Y == pacman.Y)
                {
                    if (points[i] is Yam)
                    {
                        DispatchService.Invoke(() => { points.Remove(points[i]); });
                        return 1;
                    }
                }
            }

            return 0;
        }

        public static bool IsPacmanCatched(Pacman pacman, Ghost ghost)
        {
            if (ghost.X + 30 > pacman.X && ghost.X < pacman.X && ghost.Y == pacman.Y)
            {
                return true;
            }
            if (ghost.X - 30 < pacman.X && ghost.X > pacman.X && ghost.Y == pacman.Y)
            {
                return true;
            }
            if (ghost.Y + 30 > pacman.Y && ghost.Y < pacman.Y && ghost.X == pacman.X)
            {
                return true;
            }
            if (ghost.Y - 30 < pacman.Y && ghost.Y > pacman.Y && ghost.X == pacman.X)
            {
                return true;
            }

            return false;
        }
    }
}