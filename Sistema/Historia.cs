    using System;
    using T3_VideojuegoRPG_Grupo08.Modelos;

    namespace T3_VideojuegoRPG_Grupo08.Sistema;

    public class Historia
    {
        // 1. Historia inicial y bifurcaciones
        public static void MostrarIntro()
        {
            Console.Clear();
                Console.WriteLine("==========================================================");
                Console.WriteLine("||                                                      ||");
                Console.WriteLine("||           BIENVENIDO A SWORD ART ONLINE              ||");
                Console.WriteLine("||                                                      ||");
                Console.WriteLine("==========================================================");
                Console.WriteLine("\n[SISTEMA]: Has quedado atrapado en el mundo de Aincrad.");
                Console.WriteLine("La única forma de salir es alcanzar el piso 100 y derrotar al jefe.");
                Console.WriteLine("Si tu vida llega a cero en el juego, morirás en la vida real.");
                Console.WriteLine("\nEl destino de miles de jugadores está en tus manos...");
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("Elige tu punto de partida:");
                Console.WriteLine("1. Bosque de los Lamentos (Zona de inicio).");
                Console.WriteLine("2. Ruinas de la Fortaleza (Zona de alto riesgo).");
                Console.Write("\nSelecciona tu destino (1 o 2): ");

            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                Console.WriteLine("\nElegiste el bosque. Avanzas con cuidado entre los arboles...");
            }
            else
            {
                Console.WriteLine("\nElegiste las ruinas. Hay peligro por todos lados...");
            }
            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }
        public static void RevisarFinJuego(Jugador jugador)
        {
            // Condicion de derrota
            if (jugador.HP <= 0)
            {
                Console.Clear();
                Console.WriteLine("========================");
                Console.WriteLine("      GAME OVER         ");
                Console.WriteLine("========================");
                Console.WriteLine("Moriste en el juego. Fin de la partida.");
                Environment.Exit(0);
            }

            // Condicion de victoria
            if (jugador.Oro >= 1000)
            {
                Console.Clear();
                Console.WriteLine("========================");
                Console.WriteLine("    ¡GANASTE EL JUEGO!  ");
                Console.WriteLine("========================");
                Console.WriteLine("Conseguiste el oro suficiente para escapar de SAO.");
                Environment.Exit(0);
            }
        }
    }
