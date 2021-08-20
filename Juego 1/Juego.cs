using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab2_clase2
{
    class Posicion
    {
        public int x;
        public int y;

        public Posicion(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        
        public static bool operator == (Posicion posicion1, Posicion posicion2)
        {
            // Operador para comprar 2 posiciones
            //
            return posicion1.x == posicion2.x && posicion1.y == posicion2.y;
        }

        public static bool operator != (Posicion posicion1, Posicion posicion2)
        {
            // Operador para comprar 2 posiciones
            //
            return posicion1.x != posicion2.x || posicion1.y != posicion2.y;
        }
    }

    class Juego
    {
        private Random rand_ = new Random();
        private bool terminado_ = false;
        private int puntos_ = 0;
        private List<Posicion> objetivos_ = new List<Posicion>();
        private List<Posicion> enemigos_ = new List<Posicion>();
        private Posicion jugador_ = new Posicion(0, 0);

        private void AgregarEnemigo(int x, int y)
        {
            this.enemigos_.Add(new Posicion(x, y));
        }

        private void AgregarObjetivo(int x, int y)
        {
            this.objetivos_.Add(new Posicion(x, y));
        }

        private void MoverArriba()
        {
            if (jugador_.y > 0)
                jugador_.y -= 1;
        }

        private void MoverAbajo()
        {
            if (jugador_.y < 20)
                jugador_.y += 1;
        }

        private void MoverIzquierda()
        {
            if (jugador_.x > 0)
                jugador_.x -= 1;
        }

        private void MoverDerecha()
        {
            if (jugador_.x < 40)
                jugador_.x += 1;
        }

        private void Update()
        {
            // Verificar colision con enemigos
            //
            this.enemigos_.ForEach((enemigo) =>
            {
                if (enemigo == jugador_)
                {
                    terminado_ = true;
                }
            });

            // Actualizar posicion de los enemigos
            //

            this.enemigos_.ForEach((enemigo) =>
            {
                if (enemigo.y == 0)
                    enemigo.y += 1;
                else if (enemigo.y == 20)
                    enemigo.y -= 1;
                else
                    enemigo.y += rand_.Next(-1, 2);

                if (enemigo.x == 0)
                    enemigo.x += 1;
                else if (enemigo.x == 40)
                    enemigo.x -= 1;
                else
                    enemigo.x += rand_.Next(-1, 2);
            });

            // Verificar colision con objetivos
            //
            this.objetivos_.ForEach((objetivo) =>
            {
                if (objetivo == jugador_)
                {
                    ++puntos_;
                }
            });

            // Eliminar el objetivo que colisionó con el jugador
            //
            this.objetivos_.RemoveAll((objetivo) => objetivo == jugador_);
        }

        private void Dibujar()
        {
            Thread.Sleep(10);

            Console.Clear();

            // Dibujar jugador
            //
            Console.SetCursorPosition(jugador_.x, jugador_.y);
            Console.Write("A");

            // Dibujar enemigos
            //
            this.enemigos_.ForEach((enemigo) =>
            {
                Console.SetCursorPosition(enemigo.x, enemigo.y);
                Console.Write("@");
            });

            // Dibujar objetivos
            //
            this.objetivos_.ForEach((objetivo) =>
            {
                Console.SetCursorPosition(objetivo.x, objetivo.y);
                Console.Write("O");
            });

            // Dibujar puntaje
            //
            Console.SetCursorPosition(0, 0);
            Console.Write(puntos_);
        }

        public bool Jugar()
        {
            if (terminado_ || objetivos_.Count() == 0)
                return false;

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.UpArrow)
                    this.MoverArriba();
                if (cki.Key == ConsoleKey.DownArrow)
                    this.MoverAbajo();
                if (cki.Key == ConsoleKey.LeftArrow)
                    this.MoverIzquierda();
                if (cki.Key == ConsoleKey.RightArrow)
                    this.MoverDerecha();
            }

            this.Update();
            this.Dibujar();

            return true;
        }

        public int GetPuntuacion()
        {
            return this.puntos_;
        }

        public Juego(int jugador_x, int jugador_y, int num_enemigos, int num_objectivos)
        {
            Random rand = new Random();

            // Inicializar enemigos
            //
            for (int i = 0; i < num_enemigos; i++)
            {
                this.AgregarEnemigo(rand_.Next(0, 40), rand_.Next(0, 20));
            }

            // Inicializar objetivos
            //
            for (int i = 0; i < num_objectivos; i++)
            {
                this.AgregarObjetivo(rand_.Next(0, 40), rand_.Next(0, 20));
            }

            // Inicializar posición jugador
            this.jugador_.x = jugador_x;
            this.jugador_.y = jugador_y;
        }
    }
}
