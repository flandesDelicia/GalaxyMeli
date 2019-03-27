using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxy_Meli
{
    class Coordinates
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Radius { get; set; }
        public double Theta { get; set; }


        public Coordinates(double theta, double radius)
        {
            this.Theta = theta;
            this.Radius = radius;
        }
    }
}
