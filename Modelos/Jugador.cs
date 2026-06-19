namespace T3_VideojuegoRPG_Grupo08.Modelos;

public class Jugador
{
    // Lo que ya tenían tus compañeros
    public int PosX { get; set; }
    public int PosY { get; set; }
    public char Simbolo { get; set; } = '@';

    // Tus variables de estadísticas básicas (Nivel y Vida)
    public int Nivel { get; set; } = 1;
    public int VidaActual { get; set; } = 100;
    public int VidaMaxima { get; set; } = 100;
    public int Ataque { get; set; } = 15;
    public int Defensa { get; set; } = 10;

    // Tus variables de progresión
    public int Oro { get; set; } = 0;
    public int ExpActual { get; set; } = 0;
    public int ExpRequerida { get; set; } = 100;
}