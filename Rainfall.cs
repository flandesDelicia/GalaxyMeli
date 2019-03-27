using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxy_Meli
{
    class Rainfall
    {
        public double Day { get; set; }
        public double Rain { get; set; }

        public void ToShow()
        {
            Console.WriteLine("Dia: " + Day);
            Console.WriteLine("LLuvia: " + Rain);
        }
    }
}
