namespace T3_VideojuegoRPG_Grupo08.Modelos
{
    public class Enemigo
    {
        public string Nombre { get; set; }
        public int Nivel { get; set; }
        public int HP { get; set; }
        public int HPMax { get; set; }
        public int Ataque { get; set; }
        public int Defensa { get; set; }
        public int Velocidad { get; set; }
        public int Oro { get; set; }
        public int Experiencia { get; set; }

        public Enemigo(
            string nombre,
            int nivel,
            int hp,
            int ataque,
            int defensa,
            int velocidad,
            int oro,
            int experiencia)
        {
            Nombre = nombre;
            Nivel = nivel;
            HP = hp;
            HPMax = hp;
            Ataque = ataque;
            Defensa = defensa;
            Velocidad = velocidad;
            Oro = oro;
            Experiencia = experiencia;
        }
    }
}