using T3_VideojuegoRPG_Grupo08.Modelos;
using T3_VideojuegoRPG_Grupo08.Mapa;
using T3_VideojuegoRPG_Grupo08.Sistema;

Historia.MostrarIntro();

EncuentrosRandom encuentros = new EncuentrosRandom();

Jugador jugador = new Jugador
{
    PosX = 1,
    PosY = 1
};

Mapa mapa = new Mapa();

while (true)
{
    Historia.RevisarFinJuego(jugador);
<<<<<<< HEAD
=======

>>>>>>> f96793f471f02bc87ae6b6bee1c958260351417b
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

    if (encuentros.VerificarEncuentro())
    {
        Console.WriteLine("¡Has encontrado un enemigo!");
        Console.ReadKey(true);

        Combate combate = new Combate();
        combate.Iniciar(jugador);
    }
}  
