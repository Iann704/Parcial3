using System;

class Program
{
    static void Main()
    {
        Figura[] figuras = new Figura[3];
        figuras[0] = new Rectangulo(5, 3);
        figuras[1] = new Cuadrado(4);
        figuras[2] = new Triangulo(3, 4, 5);

        foreach (Figura f in figuras)
        {
            Console.WriteLine("Clase:     " + f.GetType().Name);
            Console.WriteLine("Área:      " + f.CalcularArea().ToString("F2"));
            Console.WriteLine("Perímetro: " + f.CalcularPerimetro().ToString("F2"));
            Console.WriteLine("-----------------------------");
        }
    }
}