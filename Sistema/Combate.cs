using T3_VideojuegoRPG_Grupo08.Modelos;
using System;

namespace T3_VideojuegoRPG_Grupo08.Sistema
{
    public class Combate
    {
        public void Iniciar(Jugador jugador)
        {
            Enemigo enemigo = new Enemigo(
                "Goblin",
                1,
                40,
                10,
                3,
                8,
                20,
                15
            );

            while (jugador.HP > 0 && enemigo.HP > 0)
            {
                Console.Clear();

                Console.WriteLine("=== COMBATE ===\n");

                Console.WriteLine("Jugador");
                Console.WriteLine($"HP: {jugador.HP}/{jugador.HPMax}");
                Console.WriteLine($"MP: {jugador.MP}/{jugador.MPMax}");

                Console.WriteLine();

                Console.WriteLine(enemigo.Nombre);
                Console.WriteLine($"HP: {enemigo.HP}/{enemigo.HPMax}");

                Console.WriteLine();
                Console.WriteLine("1. Atacar");
                Console.WriteLine("2. Defender");
                Console.WriteLine("3. Magia");
                Console.WriteLine("4. Escapar");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":

                        int dañoJugador =
                            (jugador.Nivel + jugador.Ataque)
                            - (enemigo.Nivel + enemigo.Defensa);

                        if (dañoJugador < 1)
                            dañoJugador = 1;

                        enemigo.HP -= dañoJugador;

                        Console.WriteLine(
                            $"Golpeaste al {enemigo.Nombre} por {dañoJugador} puntos."
                        );

                        break;

                    case "2":

                        Console.WriteLine("Te preparas para defenderte.");

                        break;

                    case "3":

                        if (jugador.MP >= 10)
                        {
                            jugador.MP -= 10;

                            int dañoMagia = jugador.Ataque + 15;

                            enemigo.HP -= dañoMagia;

                            Console.WriteLine(
                                $"¡Bola de Fuego! Daño: {dañoMagia}"
                            );
                        }
                        else
                        {
                            Console.WriteLine("No tienes suficiente MP.");
                        }

                        break;

                    case "4":

                        Random rnd = new Random();

                        if (rnd.Next(100) < 50)
                        {
                            Console.WriteLine("¡Escapaste!");
                            Console.WriteLine("\nPresiona una tecla para continuar...");
                            Console.ReadKey(true);
                            return;
                        }

                        Console.WriteLine("No pudiste escapar.");
                        break;

                    default:

                        Console.WriteLine("Opción inválida.");
                        Console.WriteLine("\nPresiona una tecla para continuar...");
                        Console.ReadKey(true);
                        continue;
                }

                if (enemigo.HP > 0)
                {
                    int dañoEnemigo =
                        (enemigo.Nivel + enemigo.Ataque)
                        - (jugador.Nivel + jugador.Defensa);

                    if (dañoEnemigo < 1)
                        dañoEnemigo = 1;

                    jugador.HP -= dañoEnemigo;

                    Console.WriteLine(
                        $"{enemigo.Nombre} te hizo {dañoEnemigo} de daño."
                    );
                }

                Console.WriteLine("\nPresiona una tecla para continuar...");
                Console.ReadKey(true);
            }

            if (jugador.HP <= 0)
            {
                Console.WriteLine("Has muerto...");
            }
            else
            {
                Console.WriteLine("¡Victoria!");

                jugador.Oro += enemigo.Oro;
                jugador.GanarExperiencia(enemigo.Experiencia);

                Console.WriteLine();
                Console.WriteLine($"Ganaste {enemigo.Oro} de oro.");
                Console.WriteLine($"Ganaste {enemigo.Experiencia} de experiencia.");

                Console.WriteLine();
                Console.WriteLine("=== ESTADÍSTICAS ===");
                Console.WriteLine($"Nivel: {jugador.Nivel}");
                Console.WriteLine($"HP: {jugador.HP}/{jugador.HPMax}");
                Console.WriteLine($"MP: {jugador.MP}/{jugador.MPMax}");
                Console.WriteLine($"Ataque: {jugador.Ataque}");
                Console.WriteLine($"Defensa: {jugador.Defensa}");
                Console.WriteLine($"EXP: {jugador.Experiencia}/{jugador.Nivel * 100}");
                Console.WriteLine($"Oro: {jugador.Oro}");
            }
            Console.WriteLine("\nPresiona una tecla para volver al mapa...");
            Console.ReadKey(true);
        }
    }
}