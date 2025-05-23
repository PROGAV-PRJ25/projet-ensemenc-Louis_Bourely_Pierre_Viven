public class TerrainMine : Terrain
{
    public TerrainMine() : base()
    {
        Temperature = [30, 30, 18, 18, 30];
        Humidite = [0, 0, 0, 0, 0];
        Pluie = [0, 0, 14, 28, 0];
        Ensoleillement = [14, 14, 8, 8, 14];
        Nom = "Desert Delicat";
    }
    public override void VerifTerrain(Terrain terrain, int saison)
    {
        base.VerifTerrain(terrain, saison);
        for (int i = 0; i < Potager.GetLength(0); i++)
        {
            for (int j = 0; j < Potager.GetLength(1); j++)
            {
                Random rng = new Random();
                int chance = rng.Next(0, 256);
                if (chance == 13)
                {
                    Potager[i, j] = new SolSimple("Friche");
                    DetruirePlante(i, j);
                }
            }
        }
    }
}