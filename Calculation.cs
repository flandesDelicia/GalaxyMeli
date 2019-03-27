using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxy_Meli
{
    class Calculation
    {
        private static readonly double PRESICION = 0.01;
        // Caso 1: Los planetas se encuentran alineados con el sol. Si la posicion angular de los 3 planetas es la misma o la misma posicion mas +- 180 grados.
        public bool IsAlignedWithTheSun(Coordinates ferengi, Coordinates vulcano, Coordinates betasoide)
        {
            bool result = false;
            double v180 = vulcano.Theta + 180 >= 360 ? vulcano.Theta - 180 : vulcano.Theta + 180;
            double b180 = betasoide.Theta + 180 >= 360 ? betasoide.Theta - 180 : betasoide.Theta + 180;
            if ((Math.Abs(ferengi.Theta - vulcano.Theta) < PRESICION || Math.Abs(ferengi.Theta - v180) < PRESICION) && (Math.Abs(vulcano.Theta - betasoide.Theta) < PRESICION || Math.Abs(vulcano.Theta - b180) < PRESICION))
                result = true;
            return result;
        }

        // Caso 2: Los planetas se encuentran alineados. Si no se cumple el caso 1 entra al caso 2. Se traza una recta entre 2 planetas y se verifica si el 3º planeta se encuentra alineado usando la ecuacion de la recta que pasa por 2 puntos.
        public bool IsAligned(Coordinates ferengi, Coordinates vulcano, Coordinates betasoide)
        {
            bool result = false;
            double firstTerm, secondTerm;
            firstTerm = (betasoide.Y - ferengi.Y) / (betasoide.X - ferengi.X);
            secondTerm = (vulcano.Y - ferengi.Y) / (vulcano.X - ferengi.X);
            if (Math.Abs(firstTerm - secondTerm) < PRESICION)
                result = true;
            return result;
        }

        // Caso 5: Los Planetas forman un triangulo y el sol se encuentra fuera del triangulo. Se traza una recta en direccion hacia un planeta, si los demas planetas se encuentran todos de un lado, es porque el sol esta fuera del triangulo si no, se verifica si esta condicion se cumple para los demas planetas.
        public bool IsSunOutsideTriangle(Coordinates ferengi, Coordinates vulcano, Coordinates betasoide)
        {
            double range1, range2;
            double f180 = ferengi.Theta + 180 >= 360 ? ferengi.Theta - 180 : ferengi.Theta + 180;
            double v180 = vulcano.Theta + 180 >= 360 ? vulcano.Theta - 180 : vulcano.Theta + 180;
            double b180 = betasoide.Theta + 180 >= 360 ? betasoide.Theta - 180 : betasoide.Theta + 180;

            range1 = ferengi.Theta;
            range2 = f180;
            OrderRange(ref range1, ref range2);
            if (SameSide(range1, range2, vulcano.Theta, betasoide.Theta))
                return true;

            range1 = vulcano.Theta;
            range2 = v180;
            OrderRange(ref range1, ref range2);
            if (SameSide(range1, range2, ferengi.Theta, betasoide.Theta))
                return true;

            range1 = betasoide.Theta;
            range2 = b180;
            OrderRange(ref range1, ref range2);
            if (SameSide(range1, range2, ferengi.Theta, vulcano.Theta))
                return true;

            return false;
        }

        // Metodo auxiliar para ordenar los rangos de menor a mayor.
        private void OrderRange(ref double x, ref double y)
        {
            double aux;
            if (x > y)
            {
                aux = y;
                y = x;
                x = aux;
            }
        }

        // Metodo auxiliar para verificar si 2 puntos se encuentran en un mismo lado separando el sistema en 2 partes con una recta.
        private bool SameSide(double range1, double range2, double x, double y)
        {
            bool xSatisfy = false;
            bool ySatisfy = false;
            if (range1 <= x && x <= range2)
                xSatisfy = true;
            if (range1 <= y && y <= range2)
                ySatisfy = true;
            return (!(xSatisfy ^ ySatisfy));
        }

        // Calculamos el los perimetros de los triangulos
        public double getPerimeter(Coordinates ferengi, Coordinates vulcano, Coordinates betasoide)
        {
            double side1, side2, side3;
            side1 = Math.Sqrt(Math.Pow(vulcano.X - ferengi.X, 2) + Math.Pow(vulcano.Y - ferengi.Y, 2));
            side2 = Math.Sqrt(Math.Pow(betasoide.X - vulcano.X, 2) + Math.Pow(betasoide.Y - vulcano.Y, 2));
            side3 = Math.Sqrt(Math.Pow(ferengi.X - betasoide.X, 2) + Math.Pow(ferengi.Y - betasoide.Y, 2));
            return side1 + side2 + side3;
        }
    }
}
