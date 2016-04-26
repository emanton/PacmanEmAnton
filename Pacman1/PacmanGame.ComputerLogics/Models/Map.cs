using System;
using System.Collections.Generic;

namespace PacmanGame.ComputerLogics.Models
{
    public class Map
    {
        public Map()
        {
            Maps = new List<List<PointXY>>();
            CreateMaps();
        }

        public List<List<PointXY>> Maps { get; set; }

        private void CreateMaps()
        {
            var map1 = new List<PointXY>();
            map1.Add(AddPoint(1, 1));
            map1.Add(AddPoint(2, 1));
            map1.Add(AddPoint(3, 1));
            map1.Add(AddPoint(4, 1));
            map1.Add(AddPoint(5, 1));
            map1.Add(AddPoint(6, 1));
            map1.Add(AddPoint(7, 1));
            map1.Add(AddPoint(8, 1));
            map1.Add(AddPoint(9, 1));
            map1.Add(AddPoint(10, 1));

            map1.Add(AddPoint(1, 3));
            map1.Add(AddPoint(1, 4));
            map1.Add(AddPoint(1, 5));

            map1.Add(AddPoint(3, 3));
            map1.Add(AddPoint(4, 3));
            map1.Add(AddPoint(5, 3));
            map1.Add(AddPoint(6, 3));
            map1.Add(AddPoint(7, 3));
            map1.Add(AddPoint(8, 3));

            map1.Add(AddPoint(10, 3));
            map1.Add(AddPoint(10, 4));
            map1.Add(AddPoint(10, 5));

            map1.Add(AddPoint(3, 5));
            map1.Add(AddPoint(4, 5));

            map1.Add(AddPoint(6, 5));
            map1.Add(AddPoint(7, 5));
            map1.Add(AddPoint(8, 5));
            Maps.Add(map1);
        }


        private PointXY AddPoint(double x, double y)
        {
            if (x > 12 || y > 7)
            {
                throw new ArgumentException();
            }

            return new PointXY {X = x*40, Y = y*40};
        }
    }
}