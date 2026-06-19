using System;
using T3_VideojuegoRPG_Grupo08.Modelos;

namespace T3_VideojuegoRPG_Grupo08.Sistema;

public class Historia
{
    // 1. Historia inicial y bifurcaciones
    public static void MostrarIntro()
    {
        Console.Clear();
        Console.WriteLine("=== BIENVENIDO A SWORD ART ONLINE ===");
        Console.WriteLine("Estas atrapado en el juego. Si mueres aqui, mueres en la vida real.");
        Console.WriteLine("Elige tu camino inicial:");
        Console.WriteLine("1. Ir por el bosque oscuro.");
        Console.WriteLine("2. Ir por las ruinas antiguas.");
        Console.Write("Selecciona (1 o 2): ");

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
// [AUMENTADO AQUÍ] 2. Experiencia y Oro
    public static void DarRecompensas(Jugador jugador, int expGanada, int oroGanado)
    {
        Console.WriteLine("\n¡Ganaste la pelea!");
        Console.WriteLine("Oro obtenido: " + oroGanado);
        Console.WriteLine("Exp obtenida: " + expGanada);

        jugador.Oro = jugador.Oro + oroGanado;
        jugador.ExpActual = jugador.ExpActual + expGanada;
    }
}