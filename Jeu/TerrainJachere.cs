public class TerrainAJachere : Terrain
{

    public TerrainAJachere() : base()
    {
        Temperature = [25, 18, 18, 25, 25];
        Humidite = [65, 95, 95, 65, 65];
        Pluie = [56, 42, 70, 84, 56];
        Ensoleillement = [8, 10, 7, 5, 8];
        Nom = "Marecages Malins";
    }
    public override void VerifTerrain(Terrain terrain, int saison)
    {
        base.VerifTerrain(terrain, saison);
        for (int i = 0; i < Potager.GetLength(0); i++)
        {
            for (int j = 0; j < Potager.GetLength(1); j++)
            {
                if (Potager[i, j].Affichage == '/')
                {
                    Potager[i, j] = new SolSimple("Jachère");
                }
                if (Potager[i, j] is SolSimple s)
                {
                    if (s.Jachere == 1)
                    {
                        Potager[i, j] = new SolSimple("Laboure");
                    }
                    else if (s.Jachere > 0)
                    {
                        s.Jachere--;
                    }
                }
            }
        }
    }
}