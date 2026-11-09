using Newtonsoft.Json;
using System;

namespace Parcial3_parte_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var persona = new
            {
                Nombre = "Cristell",
                Edad = 20,
                Carrera = "Ingeniería en Sistemas"
            };
            string json = JsonConvert.SerializeObject(persona);

            Console.WriteLine(json);
            Console.ReadKey();
        }
    }
}