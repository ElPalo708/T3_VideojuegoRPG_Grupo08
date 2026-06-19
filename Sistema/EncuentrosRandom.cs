namespace T3_VideojuegoRPG_Grupo08.Sistema;
using T3_VideojuegoRPG_Grupo08.Modelos;

public class EncuentrosRandom
{
    Random random = new Random();
    
    public bool VerificarEncuentro()
    {
        int chance = random.Next(100);
        
        if (chance < 20)
        {
            return true;
        }
        return false;
    }
}