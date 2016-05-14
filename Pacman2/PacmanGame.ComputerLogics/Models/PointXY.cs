using PacmanGame.ComputerLogics.Core;

namespace PacmanGame.ComputerLogics.Models
{
    public class PointXY : ObservableObject
    {
        private double x;
        private double y;

        public double X
        {
            get { return x; }
            set
            {
                x = value;
                RaisePropertyChangedEvent("X");
            }
        }

        public double Y
        {
            get { return y; }
            set
            {
                y = value;
                RaisePropertyChangedEvent("Y");
            }
        }
    }
}