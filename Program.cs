using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_clase1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ejercicio1
            //Número al azar del 1 al 100
            //
            Random rand = new Random();
            Console.WriteLine("Ejercicio 1: " + rand.Next(1, 100));

            //Ejercicio 2
            //
            Console.WriteLine("Ejercicio 2: " + rand.Next(1, 10));
            Console.WriteLine("Ejercicio 2: " + rand.Next(11, 20));

            //Ejercicio 3 y 4
            //
            Console.WriteLine("Ejercicio 3 y 4! intente adivinar el número en 13 intentos :0");

            int intento = 0; //Variable que guarda el intento del usuario
            int objetivo = rand.Next(1, 10000); //Número a adivinar

            for (int i = 0; i < 13; i++)
            {
                Console.WriteLine("Intento numero: " + i);

                intento = Convert.ToInt32(Console.ReadLine()); //Convertir de string a int

                if (intento == objetivo)
                {
                    Console.WriteLine("Has adivinado!");

                    Console.ReadKey();
                    return;
                }
                else if (intento < objetivo)
                    Console.WriteLine("Te has quedado corto!");
                else
                    Console.WriteLine("Te has pasado!");
            }

            //Si el programa llega a este punto es porque no adivinó en los 13 intentos
            //
            Console.WriteLine("Perdiste xD");
            Console.WriteLine("El aleatorio era el " + objetivo);

            Console.ReadKey();
        }
    }
}
