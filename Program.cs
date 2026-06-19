using T3_VideojuegoRPG_Grupo08.Modelos;
using T3_VideojuegoRPG_Grupo08.Mapa;
using T3_VideojuegoRPG_Grupo08.Sistema;

Console.Clear();
            Console.WriteLine("==========================================================");
            Console.WriteLine("||                                                      ||");
            Console.WriteLine("||            BIENVENIDO A SWORD ART ONLINE             ||");
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
string zonaActual = "";

if (opcion == "1")
{
    zonaActual = "BOSQUE OSCURO";
    Console.WriteLine("\nElegiste el bosque. Avanzas con cuidado entre los arboles...");
}
else
{
    zonaActual = "RUINAS ANTIGUAS";
    Console.WriteLine("\nElegiste las ruinas. Hay peligro por todos lados...");
}
Console.WriteLine("Presiona una tecla para ingresar al mapa...");
Console.ReadKey(true);

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

    mapa.Dibujar(jugador);
    
    Console.WriteLine($"\n📍 REGIÓN: {zonaActual}");
    Console.WriteLine($" Nivel: {jugador.Nivel} | Vida: {jugador.VidaActual}/{jugador.VidaMaxima} | Oro: {jugador.Oro}/200 | EXP: {jugador.ExpActual}/{jugador.ExpRequerida}");

    ConsoleKey tecla = Console.ReadKey(true).Key;

    int nuevoX = jugador.PosX;
    int nuevoY = jugador.PosY;

    switch (tecla)
    {
        case ConsoleKey.W: nuevoY--; break;
        case ConsoleKey.S: nuevoY++; break;
        case ConsoleKey.A: nuevoX--; break;
        case ConsoleKey.D: nuevoX++; break;
    }

    mapa.MoverJugador(jugador, nuevoX, nuevoY);

    if(encuentros.VerificarEncuentro())
    {
        Console.WriteLine("\n¡Has encontrado un enemigo!");
        Console.WriteLine("Presiona cualquier tecla para continuar...");
        Console.ReadKey(true);
    }
}
