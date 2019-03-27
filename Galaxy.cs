using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxy_Meli
{
    class Galaxy
    {
        public int DayForYear { get; set; }
        public Planet Ferengi { get; set; }
        public Planet Vulcano { get; set; }
        public Planet Betasoide { get; set; }
        public List<Rainfall> Measuring { get; set; }

        public Galaxy()
        {
            this.DayForYear = 365;
            this.Ferengi = new Planet("Ferengi", -1, 500, 0);
            this.Vulcano = new Planet("Vulcano", 5, 1000, 0);
            this.Betasoide = new Planet("Betasoide", -3, 2000, 0);
            this.Measuring = new List<Rainfall>();
        }

        public Galaxy(double x, double y, double z)
        {
            this.DayForYear = 365;
            this.Ferengi = new Planet("Ferengi", -1, 500, x);
            this.Vulcano = new Planet("Vulcano", 5, 1000, y);
            this.Betasoide = new Planet("Betasoide", -3, 2000, z);
            this.Measuring = new List<Rainfall>();
        }

        public Prediction PredictWeather(double day)
        {
            Calculation calculation = new Calculation();
            Prediction prediction = new Prediction(day, "Sequia"); ;

            Coordinates coordinatesFerengi = Ferengi.GetCoordinates(day);
            Coordinates coordinatesVulcano = Vulcano.GetCoordinates(day);
            Coordinates coordinatesBetasoide = Betasoide.GetCoordinates(day);

            if (calculation.IsAlignedWithTheSun(coordinatesFerengi, coordinatesVulcano, coordinatesBetasoide))
            {
                prediction.Weather = "Sequia";
            }
            else
            {
                if (calculation.IsAligned(coordinatesFerengi, coordinatesVulcano, coordinatesBetasoide))
                {
                    prediction.Weather = "Presion y Temperatura Optima";
                }
                else
                {
                    if (calculation.IsSunOutsideTriangle(coordinatesFerengi, coordinatesVulcano, coordinatesBetasoide))
                        prediction.Weather = "Nublado";
                    else
                    {
                        prediction.Weather = "Lluvia";
                    }
                }
            }

            return prediction;
        }

        public Result PredictWeatherPeriod(double toDay)
        {
            Result result = new Result();
            Calculation calculation = new Calculation();
            for (double i = 0; i < toDay; i++)
            {
                Prediction prediction = new Prediction(Math.Truncate(i), "Sequia");
                Coordinates coordinatesFerengi = Ferengi.GetCoordinates(i);
                Coordinates coordinatesVulcano = Vulcano.GetCoordinates(i);
                Coordinates coordinatesBetasoide = Betasoide.GetCoordinates(i);
                if (calculation.IsAlignedWithTheSun(coordinatesFerengi, coordinatesVulcano, coordinatesBetasoide))
                    prediction.Weather = "Sequia";
                else
                {
                    if (calculation.IsAligned(coordinatesFerengi, coordinatesVulcano, coordinatesBetasoide))
                        prediction.Weather = "Presion y Temperatura Optima";
                    else
                    {
                        if (calculation.IsSunOutsideTriangle(coordinatesFerengi, coordinatesVulcano, coordinatesBetasoide))
                            prediction.Weather = "Nublado";
                        else
                        {
                            prediction.Weather = "Lluvia";
                            Rainfall rainfall = new Rainfall
                            {
                                Day = Math.Truncate((double)i),
                                Rain = calculation.getPerimeter(coordinatesFerengi, coordinatesVulcano, coordinatesBetasoide)
                            };
                            Measuring.Add(rainfall);
                            Measuring.Sort((x, y) => x.Rain.CompareTo(y.Rain));
                        }
                    }
                }
                result.PredictionsList.Add(prediction);
            }
            return result;
        }
    }
}
