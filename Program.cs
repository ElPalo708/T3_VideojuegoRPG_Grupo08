using T3_VideojuegoRPG_Grupo08.Modelos;
using T3_VideojuegoRPG_Grupo08.Mapa;
using T3_VideojuegoRPG_Grupo08.Sistema;

Console.WriteLine("=== RPG GRUPO 08 ===");
Console.WriteLine("Pulsa una tecla para comenzar...");
Console.ReadKey(true);
Console.Clear();

EncuentrosRandom encuentros = new EncuentrosRandom();

Jugador jugador = new Jugador
{
    PosX = 1,
    PosY = 1
};

Mapa mapa = new Mapa();

while (true)
{
    mapa.Dibujar(jugador);

    ConsoleKey tecla = Console.ReadKey(true).Key;

    int nuevoX = jugador.PosX;
    int nuevoY = jugador.PosY;

    switch (tecla)
    {
        case ConsoleKey.W:
            nuevoY--;
            break;

        case ConsoleKey.S:
            nuevoY++;
            break;

        case ConsoleKey.A:
            nuevoX--;
            break;

        case ConsoleKey.D:
            nuevoX++;
            break;
    }

    mapa.MoverJugador(jugador, nuevoX, nuevoY);

    if(encuentros.VerificarEncuentro())
    {
        Console.WriteLine("¡Has encontrado un enemigo!");
        Console.WriteLine("Presiona cualquier tecla para continuar...");
        Console.ReadKey(true);
    }
}