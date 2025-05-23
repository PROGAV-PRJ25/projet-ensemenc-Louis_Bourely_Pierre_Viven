public class TerrainMine : Terrain //Classe héritière de Terrain qui fait exploser aléatoirement des cases 
{
    public TerrainMine() : base() //un seul terrain miné
    {
        Temperature = [30, 30, 18, 18, 30];
        Humidite = [0, 0, 0, 0, 0];
        Pluie = [0, 0, 14, 28, 0];
        Ensoleillement = [14, 14, 8, 8, 14];
        Nom = "Desert Delicat";
        Emoji = "​​🌵​​";
    }
    public override void VerifierTerrain(Terrain terrain, int saison)
    {
        base.VerifierTerrain(terrain, saison);
        for (int i = 0; i < Potager.GetLength(0); i++)
        {
            for (int j = 0; j < Potager.GetLength(1); j++)
            {
                Random rng = new Random();
                int chance = rng.Next(0, 256); //une chance sur 256 de faire exploser la case
                if (chance == 13)
                {
                    DetruirePlante(i, j); //Transforme en sol vierge
                }
            }
        }
    }
}