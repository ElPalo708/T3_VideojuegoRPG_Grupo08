using T3_VideojuegoRPG_Grupo08.Modelos;
using System;

namespace T3_VideojuegoRPG_Grupo08.Sistema
{
    public class Combate
    {
        public void Iniciar(Jugador jugador)
        {
            Random rnd = new Random();

            int nivelEnemigo = rnd.Next(
                jugador.Nivel,
                jugador.Nivel + 4
            );

            int hpEnemigo = 30 + (nivelEnemigo * 10);

            Enemigo enemigo = new Enemigo(
                "Goblin",
                nivelEnemigo,
                hpEnemigo,
                6 + (nivelEnemigo * 2),
                3 + nivelEnemigo,
                8 + nivelEnemigo,
                20 * nivelEnemigo,
                15 * nivelEnemigo
            );
            
            bool jugadorPrimero = jugador.Velocidad >= enemigo.Velocidad;

            bool defendiendo = false;

            if (jugadorPrimero)
            {   
                Console.WriteLine("¡Eres más rápido y actuarás primero!");
            }
            else
            {
                Console.WriteLine($"{enemigo.Nombre} es más rápido y actuará primero.");
            }

            while (jugador.HP > 0 && enemigo.HP > 0)
            {
                Console.Clear();

                Console.WriteLine("=== COMBATE ===\n");

                Console.WriteLine("Jugador");
                Console.WriteLine($"HP: {jugador.HP}/{jugador.HPMax}");
                Console.WriteLine($"MP: {jugador.MP}/{jugador.MPMax}");
                Console.WriteLine($"VEL: {jugador.Velocidad}");

                Console.WriteLine();

                Console.WriteLine($"{enemigo.Nombre} (Nivel {enemigo.Nivel})");
                Console.WriteLine($"HP: {enemigo.HP}/{enemigo.HPMax}");
                Console.WriteLine($"VEL: {enemigo.Velocidad}");

                Console.WriteLine();
                Console.WriteLine("1. Atacar");
                Console.WriteLine("2. Defender");
                Console.WriteLine("3. Magia");
                Console.WriteLine("4. Escapar");

                string opcion = Console.ReadLine();

                if (!jugadorPrimero && enemigo.HP > 0)
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

                    Console.WriteLine("\nPresiona una tecla para continuar...");
                    Console.ReadKey(true);

                    if (jugador.HP <= 0)
                        break;
                }

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

                    defendiendo = true;

                    Console.WriteLine("Preparas tu defensa para el próximo ataque.");
                    Console.WriteLine($"Valor de defendiendo: {defendiendo}");

                    break;

                    case "3":

                        Console.WriteLine("=== HECHIZOS ===");
                        Console.WriteLine("1. Bola de Fuego (10 MP)");
                        Console.WriteLine("2. Rayo (15 MP)");
                        Console.WriteLine("3. Curación (12 MP)");

                        string hechizo = Console.ReadLine();

                        switch (hechizo)
                        {
                            case "1":

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

                            case "2":

                                if (jugador.MP >= 15)
                                {
                                    jugador.MP -= 15;

                                    int dañoRayo = jugador.Ataque + 25;

                                    enemigo.HP -= dañoRayo;

                                    Console.WriteLine(
                                        $"¡Rayo! Daño: {dañoRayo}"
                                    );
                                }
                                else
                                {
                                    Console.WriteLine("No tienes suficiente MP.");
                                }

                                break;

                            case "3":

                                if (jugador.MP >= 12)
                                {
                                    jugador.MP -= 12;

                                    int curacion = 30;

                                    jugador.HP += curacion;

                                    if (jugador.HP > jugador.HPMax)
                                        jugador.HP = jugador.HPMax;

                                    Console.WriteLine(
                                        $"¡Te curaste {curacion} HP!"
                                    );
                                }
                                else
                                {
                                    Console.WriteLine("No tienes suficiente MP.");
                                }

                                break;

                            default:
                                Console.WriteLine("Hechizo inválido.");
                                break;
                        }

                        break;

                    case "4":

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

                if (jugadorPrimero && enemigo.HP > 0)

                Console.WriteLine($"Antes del ataque enemigo: {defendiendo}");

                if (jugadorPrimero && enemigo.HP > 0)
                {
                    int dañoEnemigo =
                        (enemigo.Nivel + enemigo.Ataque)
                        - (jugador.Nivel + jugador.Defensa);

                    if (defendiendo)
                    {
                        dañoEnemigo -= jugador.Defensa * 2;
                        Console.WriteLine("¡Bloqueaste parte del ataque!");
                    }

                    if (dañoEnemigo < 1)
                        dañoEnemigo = 1;

                    jugador.HP -= dañoEnemigo;

                    Console.WriteLine(
                        $"{enemigo.Nombre} te hizo {dañoEnemigo} de daño."
                    );

                    defendiendo = false;
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

                int drop = rnd.Next(100);
                if (drop < 25)
                Console.WriteLine($"Drop: {drop}");
                {
                    Objeto objeto = GenerarObjeto();
                    Console.WriteLine($"¡El enemigo soltó {objeto.Nombre}!");
                    jugador.UsarObjeto(objeto);
                    
                }

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
        private Objeto GenerarObjeto()
        {
            Random rnd = new Random();

            int tipo = rnd.Next(5);

            switch (tipo)
            {
                case 0:
                    return new Objeto(
                        "Poción de Vida",
                        "HP",
                        30);

                case 1:
                    return new Objeto(
                        "Poción de Maná",
                        "MP",
                        20);

                case 2:
                    return new Objeto(
                        "Espada de Hierro",
                        "ATAQUE",
                        5);

                case 3:
                    return new Objeto(
                        "Escudo Reforzado",
                        "DEFENSA",
                        3);

                default:
                    return new Objeto(
                        "Botas Ligeras",
                        "VELOCIDAD",
                        2);
            }
        }
    }
}