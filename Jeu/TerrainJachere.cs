public class TerrainAJachere : Terrain //Classe héritière de Terrain qui rajoute des jachère après chaque plante récoltées
{

    public TerrainAJachere() : base() //Un seul terrain Jachère
    {
        Temperature = [25, 18, 18, 25, 25];
        Humidite = [65, 95, 95, 65, 65];
        Pluie = [56, 42, 70, 84, 56];
        Ensoleillement = [8, 10, 7, 5, 8];
        Nom = "Marecages Malins";
        Emoji = "​​🌊​";
    }
    public override void VerifierTerrain(Terrain terrain, int saison) //Vérifie le terrain et diminue les temps d'attentes des jachères si besoin
    {
        base.VerifierTerrain(terrain, saison);
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
                        Potager[i, j] = new SolSimple("Laboure"); //Remplace par un sol labouré quand l'attente est fini
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