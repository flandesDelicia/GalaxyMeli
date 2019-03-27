using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxy_Meli
{
    class Planet
    {
        public String Name { get; set; }
        public double AngularVelocity { get; set; }
        public int Radius { get; set; }
        public double Theta { get; set; }

        public Planet(String name, double angularVelocity, int radius, double theta)
        {
            this.Name = name;
            this.AngularVelocity = angularVelocity;
            this.Radius = radius;
            this.Theta = theta;
        }

        public Coordinates GetCoordinates(double day)
        {
            Coordinates coordinates = new Coordinates(Theta, Radius);
            double thetaAux = Theta + (AngularVelocity * day);
            double periodicity = Math.Truncate(thetaAux / 360);
            coordinates.Theta = thetaAux - (periodicity * 360);
            // Transformamos los angulos negativos en su correspondiente positivo
            if (coordinates.Theta < 0)
                coordinates.Theta += 360;
            // La funcion cos y sin funciona con radianes por lo que se debe hacer la transformacion de grados a radianes
            coordinates.X = Radius * Math.Round(Math.Cos(coordinates.Theta * (Math.PI / 180)), 4);
            var algo1 = coordinates.Theta * (Math.PI / 180.0);
            var algo = Math.Sin(coordinates.Theta * (Math.PI / 180.0));
            coordinates.Y = Radius * Math.Round(Math.Sin(coordinates.Theta * (Math.PI / 180)), 4);

            return coordinates;
        }
    }
}
