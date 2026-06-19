namespace T3_VideojuegoRPG_Grupo08.Modelos;

public class Objeto
{
    public string Nombre { get; set; }
    public string Tipo { get; set; }
    public int Valor { get; set; }

    public Objeto(string nombre, string tipo, int valor)
    {
        Nombre = nombre;
        Tipo = tipo;
        Valor = valor;
    }
}