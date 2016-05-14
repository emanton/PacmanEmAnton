using System;
using System.Collections.Generic;

namespace PacmanGame.ComputerLogics.Models
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public static class Map
    {
        public static List<PointXY> PlacesForGhosts { get; set; }
        private static int[,] map;
        public static int[,] MapArray { get { return map; } }
        public static int Height { get { return height; } }
        public static int Width { get { return width; } }
        private static int height = 19;
        private static int width = 19;
        static Random rand = new Random();

        public static List<PointXY> GetRandomMap()
        {
            InitializeRandomArray();
            var mapPoints = new List<PointXY>();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    
                    if (map[i, j] == 1)
                    {
                        mapPoints.Add(AddPoint(i, j));
                    }
                }
            }

            return mapPoints;
        }
        private static PointXY AddPoint(double x, double y)
        {
            return new PointXY { X = x * 30, Y = y * 30 };
        }
        public static void InitializeRandomArray()
        {
            map = new int[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    map[i, j] = 1;
                }
            }
            for (int i = 1; i < height - 1; i++)
            {
                map[i, 1] = 0;
                map[i, width - 2] = 0;
            }

            for (int i = 1; i < width - 1; i++)
            {
                map[1, i] = 0;
                map[height - 2, i] = 0;
            }

            //creating place for ghosts
            PlacesForGhosts = new List<PointXY>();
            int centerX = height / 2;
            int centerY = width / 2;
            map[centerY, centerX] = 0;
            map[centerY, centerX + 1] = 0;
            map[centerY, centerX - 1] = 0;
            map[centerY - 1, centerX] = 0;
            PlacesForGhosts.Add(new PointXY { X = centerX, Y = centerY });
            PlacesForGhosts.Add(new PointXY { X = centerX + 1, Y = centerY });
            PlacesForGhosts.Add(new PointXY { X = centerX - 1, Y = centerY });
            PlacesForGhosts.Add(new PointXY { X = centerX, Y = centerY - 1 });
            for (int i = centerX - 3; i < centerX + 4; i++)
            {
                map[centerY + 2, i] = 0;
                map[centerY - 2, i] = 0;
            }
            for (int i = centerY - 2; i < centerY + 2; i++)
            {
                map[i, centerX - 3] = 0;
                map[i, centerX + 3] = 0;
            }

            //создано основание, а затем добавляем к нему проходы. 
            //Сначало ищем подходящую точку, а затем достраиваем пока не пересечет какой нибудь проход
            int maxWays = 1000000;
            for (int i = 0; i < maxWays; i++)
            {
                Point point = FindWayBeginning();
                if (point.X == 0 || point.Y == 0)
                {
                    break;
                }
                CreateWay(point);
            }
        }


        static Point FindWayBeginning()
        {
            int y = 0, x = 0;
            int whichSide = rand.Next(1, 4);

            switch (whichSide)
            {
                case 1:
                    {
                        x = 2; //left
                        y = GetValue(0, x);
                    }
                    break;
                case 2:
                    {
                        x = height - 3; //right
                        y = GetValue(0, x);
                    }
                    break;
                case 3:
                    {
                        y = 2; //top
                        x = GetValue(y, 0);
                    }
                    break;
                case 4:
                    {
                        y = width - 3; //bottom
                        x = GetValue(y, 0);
                    }
                    break;
            }

            return new Point { X = x, Y = y };
        }

        static int GetValue(int y, int x)
        {
            int randomTimes = 30;
            Point pont = new Point();
            if (x == 0)
            {
                for (int i = 0; i < randomTimes; i++)
                {
                    int randomValue = rand.Next(2, width - 3);
                    if (IsEnable(new Point { X = randomValue, Y = y }))
                    {
                        pont.X = randomValue;
                        pont.Y = y;
                        return randomValue;
                    }
                }
            }
            else
            {
                for (int i = 0; i < randomTimes; i++)
                {
                    int randomValue = rand.Next(2, height - 3);
                    if (IsEnable(new Point { X = x, Y = randomValue }))
                    {
                        pont.X = x;
                        pont.Y = randomValue;
                        return randomValue;
                    }
                }
            }

            return 0;
        }

        static bool IsEnable(Point point)
        {
            if (GetWallNumber(point) == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void CreateWay(Point firstPoint)
        {
            map[firstPoint.Y, firstPoint.X] = 0;
            Point point = new Point { X = firstPoint.X, Y = firstPoint.Y };
            int counter = 0;
            while (!IsEndOfWay(point))
            {
                point = TryToBuild(point, firstPoint, ref counter);
            }
        }

        static bool IsEndOfWay(Point point)
        {
            if (GetWallNumber(point) < 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static int GetWallNumber(Point point)
        {
            int wallNumber = 0;
            if (point.Y == 0 || point.X == 0)
            {
                int a = 10;
            }
            if (map[point.Y - 1, point.X] == 1)
            {
                wallNumber++;
            }
            if (map[point.Y + 1, point.X] == 1)
            {
                wallNumber++;
            }
            if (map[point.Y, point.X - 1] == 1)
            {
                wallNumber++;
            }
            if (map[point.Y, point.X + 1] == 1)
            {
                wallNumber++;
            }

            return wallNumber;
        }

        static Point TryToBuild(Point point, Point firstPoint, ref int counter)
        {
            Point tempPoint = GetNewStep(point);
            if (IsNearToFirstPoint(tempPoint, firstPoint) && GetWallNumber(tempPoint) == 1)
            {
                if (counter < 20)
                {
                    counter++;
                    return point;
                }
            }
            if (IsSquareCreating(tempPoint))
            {
                if (counter < 20)
                {
                    counter++;
                    return point;
                }
            }
            if (map[tempPoint.Y, tempPoint.X] == 0)
            {
                counter++;
                return point;
            }

            counter = 0;
            map[tempPoint.Y, tempPoint.X] = 0;
            return tempPoint;
        }

        static bool IsNearToFirstPoint(Point point, Point firstPoint)
        {
            if (point.X + 1 == firstPoint.X && point.Y == firstPoint.Y)
            {
                return true;
            }
            if (point.X - 1 == firstPoint.X && point.Y == firstPoint.Y)
            {
                return true;
            }
            if (point.X == firstPoint.X && point.Y + 1 == firstPoint.Y)
            {
                return true;
            }
            if (point.X == firstPoint.X && point.Y - 1 == firstPoint.Y)
            {
                return true;
            }

            return false;
        }

        static bool IsSquareCreating(Point point)
        {
            int x = point.X, y = point.Y;
            if (map[y, x + 1] == 0 && map[y - 1, x] == 0 && map[y - 1, x + 1] == 0)
            {
                return true;
            }
            if (map[y, x + 1] == 0 && map[y + 1, x] == 0 && map[y + 1, x + 1] == 0)
            {
                return true;
            }
            if (map[y, x - 1] == 0 && map[y - 1, x] == 0 && map[y - 1, x - 1] == 0)
            {
                return true;
            }
            if (map[y, x - 1] == 0 && map[y + 1, x] == 0 && map[y + 1, x - 1] == 0)
            {
                return true;
            }
            return false;
        }

        static Point GetNewStep(Point point)
        {

            int y = 0, x = 0;
            int whichSide = rand.Next(1, 4);
            Point tempPoint = new Point();
            switch (whichSide)
            {
                case 1:
                    {
                        tempPoint.X = point.X + 1;
                        tempPoint.Y = point.Y;
                    }
                    break;
                case 2:
                    {
                        tempPoint.X = point.X - 1;
                        tempPoint.Y = point.Y;
                    }
                    break;
                case 3:
                    {
                        tempPoint.X = point.X;
                        tempPoint.Y = point.Y + 1;
                    }
                    break;
                case 4:
                    {
                        tempPoint.X = point.X;
                        tempPoint.Y = point.Y - 1;
                    }
                    break;
            }

            return tempPoint;
        }
    }
}