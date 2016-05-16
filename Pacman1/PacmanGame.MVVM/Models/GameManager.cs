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
    }
}