namespace T3_VideojuegoRPG_Grupo08.Modelos;

public class Jugador
{
    public int PosX { get; set; }
    public int PosY { get; set; }

    public char Simbolo { get; set; } = '@';

    // Estadísticas RPG
    public int Nivel { get; set; } = 1;

    public int HP { get; set; } = 100;
    public int HPMax { get; set; } = 100;

    public int MP { get; set; } = 50;
    public int MPMax { get; set; } = 50;

    public int Ataque { get; set; } = 15;
    public int Defensa { get; set; } = 5;
    public int Velocidad { get; set; } = 10;

    public int Oro { get; set; } = 0;
    public int Experiencia { get; set; } = 0;

    public void GanarExperiencia(int exp)
    {
        Experiencia += exp;

        while (Experiencia >= Nivel * 100)
        {
            Experiencia -= Nivel * 100;
            Nivel++;

            HPMax += 20;
            HP = HPMax;

            MPMax += 10;
            MP = MPMax;

            Ataque += 3;
            Defensa += 2;
            Velocidad += 1;

            Console.WriteLine($"\n¡SUBISTE A NIVEL {Nivel}!");
            Console.WriteLine("Tus estadísticas han aumentado.");
            Console.WriteLine($"Velocidad actual: {Velocidad}");
        }
    }
    public void UsarObjeto(Objeto objeto)
    {
    switch (objeto.Tipo)
    {
        case "HP":
            HP += objeto.Valor;
            if (HP > HPMax)
                HP = HPMax;
            break;

        case "MP":
            MP += objeto.Valor;
            if (MP > MPMax)
                MP = MPMax;
            break;

        case "ATAQUE":
            Ataque += objeto.Valor;
            break;

        case "DEFENSA":
            Defensa += objeto.Valor;
            break;

        case "VELOCIDAD":
            Velocidad += objeto.Valor;
            break;
    }

    Console.WriteLine($"Obtuviste: {objeto.Nombre}");
    }    
}