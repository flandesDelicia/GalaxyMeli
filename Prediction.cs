using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxy_Meli
{
    class Prediction
    {
        public int Id { get; set; }
        public double Day { get; set; }
        public String Weather { get; set; }

        public Prediction(double day, String weather)
        {
            this.Day = day;
            this.Weather = weather;
        }

        public Prediction()
        {
            this.Day = 0;
            this.Weather = "Nada";
        }

        public void ToShow()
        {
            Console.WriteLine("Dia: " + Day);
            Console.WriteLine("Clima: " + Weather);
        }
    }
}
