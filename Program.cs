using System;
using System.Collections.Generic;
using System.Linq;

namespace Galaxy_Meli
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion = '5';
            double day = 0;
            bool exit = false;
            Galaxy galaxy = new Galaxy();
            Prediction prediction = new Prediction();
            Result result = new Result();
            while (!exit)
            {
                Menu1();
                Console.Write("\n\n Opcion: ");
                while (int.TryParse(Console.ReadLine(), out opcion) && 0 > opcion && opcion > 6)
                {
                    Console.Write("\nIngrese una opcion valida: ");
                }
                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el día: ");
                        day = double.Parse(Console.ReadLine());
                        prediction = galaxy.PredictWeather(day);
                        prediction.ToShow();
                        Console.WriteLine("Presione una tecla para continuar");
                        Console.ReadKey();
                        break;
                    case 2:
                        prediction = new Prediction();
                        result = new Result();
                        result = galaxy.PredictWeatherPeriod(3650);
                        if (result.PredictionsList != null)
                        {

                            var predictions = result.PredictionsList.FindAll(x => x.Weather == "Sequia");
                            Console.WriteLine("La cantidad de periodos de sequia son: " + predictions.Count);

                            predictions = result.PredictionsList.FindAll(x => x.Weather == "Lluvia");
                            double dayPrevious = 0;
                            if (predictions.Count != 0)
                            {
                                dayPrevious = predictions.First().Day;
                            }
                            var aux = new List<Prediction>();
                            foreach (var item in predictions)
                            {
                                if (item.Day != (dayPrevious + 1) && item.Weather == "Lluvia")
                                    aux.Add(item);
                                dayPrevious = item.Day;
                            }
                            Console.WriteLine("La cantidad de periodos de lluvia: " + aux.Count);
                            var mlts = galaxy.Measuring.First().Rain;
                            double max = 0;
                            foreach (var item in galaxy.Measuring)
                            {
                                if (item.Rain > mlts)
                                    max = item.Rain;
                            }
                            var rains = galaxy.Measuring.FindAll(x => x.Rain == max);
                            Console.Write("El pico de lluvia maximo es: " + max + " y se produce el/los dia/s: ");
                            foreach (var item in rains)
                            {
                                Console.Write(item.Day + " - ");
                            }


                            predictions = result.PredictionsList.FindAll(x => x.Weather == "Presion y Temperatura Optima");
                            Console.WriteLine("La cantidad de periodos de presion y temperatura Optima: " + predictions.Count);

                        }
                        else
                            Console.WriteLine("no existe predicion");
                        Console.WriteLine("Presione una tecla para continuar");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Ingrese posicion angular de Ferengi: ");
                        double f = double.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese posicion angular de Vulcano: ");
                        double v = double.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese posicion angular de Betasoide: ");
                        double b = double.Parse(Console.ReadLine());
                        galaxy = new Galaxy(f, v, b);
                        Console.WriteLine("Presione una tecla para continuar");
                        Console.ReadKey();
                        break;
                    case 4:
                        if (result.PredictionsList != null && result.PredictionsList.Count != 0)
                        {
                            foreach (var item in result.PredictionsList)
                            {
                                item.ToShow();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Debe elegir la opcion 2 primero");
                        }
                        Console.WriteLine("Presione una tecla para continuar");
                        Console.ReadKey();
                        break;
                    case 5:
                        exit = true;
                        Console.WriteLine("Gracias por utilizar el programa");
                        Console.WriteLine("Presione una tecla para continuar");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Opcion invalida");
                        break;
                }
            }
           
        }
        private static void Menu1()
        {
            Console.WriteLine("\n\n\n");
            Console.WriteLine("           __________________________________________________________________\n");
            Console.WriteLine("          |                                                                  |\n");
            Console.WriteLine("          |                         MENU DE CONSOLA                          |\n");
            Console.WriteLine("          |                                                                  |\n");
            Console.WriteLine("          |                     1) Calcular un día                           |\n");
            Console.WriteLine("          |                                                                  |\n");
            Console.WriteLine("          |                     2) Calcular periodos en 10 años              |\n");
            Console.WriteLine("          |                                                                  |\n");
            Console.WriteLine("          |                     3) Setear pocision inicial de los planetas   |\n");
            Console.WriteLine("          |                                                                  |\n");
            Console.WriteLine("          |                     4) Mostrar Prediciones                       |\n");
            Console.WriteLine("          |                                                                  |\n");
            Console.WriteLine("          |                     5) Salir                                     |\n");
            Console.WriteLine("          |__________________________________________________________________|\n");
        }
    }
}
