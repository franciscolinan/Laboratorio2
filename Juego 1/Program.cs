using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_clase2
{
    class Program
    {
        static void Main(string[] args)
        {
            Juego juego = new Juego(10, 10, 5, 10);

            while (juego.Jugar()) {}

            Console.Clear();
            Console.WriteLine("El juego finalizo con una puntuación de: " + juego.GetPuntuacion());
            Console.ReadLine();
        }
    }
}
