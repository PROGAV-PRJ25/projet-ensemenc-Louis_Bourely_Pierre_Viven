public class PlanteFilante : PlanteSimple
{
    public bool Extension { get; set; }

    public PlanteFilante(char affichage, string nom, double prixAchat, double prixVente, double croissance, string type, string terrainFavori, double[] temperature, double[] ensoleillement, double[] pluie, double[] humidité, bool extension = false) : base(affichage, nom, prixAchat, prixVente, croissance, type, terrainFavori, temperature, ensoleillement, pluie, humidité)
    {
        Affichage = affichage;
        Nom = nom;
        PrixAchat = prixAchat;
        PrixVente = prixVente;
        Croissance = croissance;
        Extension = extension;
        Type = type;
        TerrainFavori = terrainFavori;
        Temperature = temperature;
        Ensoleillement = ensoleillement;
        Pluie = pluie;
        Humidité = humidité;
    }

    public void Etendre(Plante PlanteFilante, int i, int j)
    {
        // if ((i != 0) && (Terrain.Potager[i - 1, j].Affichage == "•"))
        // {
        //     Terrain.Planter(new PlanteFilante(), i - 1, j);
        // }
        // else if ((j != Terrain.Potager.GetLength(1)) && (Terrain.Potager[i, j + 1].Affichage == "•"))
        // {
        //     Terrain.Planter(new PlanteFilante(), i, j + 1);
        // }
        // else if ((i != Terrain.Potager.GetLength(0)) && (Terrain.Potager[i + 1, j].Affichage == "•"))
        // {
        //     Terrain.Planter(new PlanteFilante(), i + 1, j);
        // }
        // else if ((j != 0) && (Terrain.Potager[i, j - 1].Affichage == "•"))
        // {
        //     Terrain.Planter(new PlanteFilante(), i, j - 1);
        // }
        // else { }
    }
    public override void SimulerCroissance()
    {
        base.SimulerCroissance();
        Random random = new Random();
        int aleatoire = random.Next(0, 3);
        // if ((Extension == false) && (Croissance == ) && (aleatoire == 1))
        {
            //Etendre(i, j);
            Extension = true;
        }
    }
    public PlanteFilante CreerGorhy()
    {
        PlanteFilante nouvellePlante = new PlanteFilante('g', "Gorhy", 20, 120, 4, "Comestible", "Volcan Violent", [26, 35], [7, 9], [1, 3], [5, 15]);
        return nouvellePlante;
    }
    public PlanteFilante CreerJaunille()
    {
        PlanteFilante nouvellePlante = new PlanteFilante('j', "Jaunille", 300, 1800, 4, "Comestible", "Desert Delicat", [16, 26], [6, 9], [1, 5], [0, 10]);
        return nouvellePlante;
    }
    public PlanteFilante CreerZolia()
    {
        PlanteFilante nouvellePlante = new PlanteFilante('z', "Zolia", 100, 1000, 10, "Ornementale", "Foret Facétieuse", [18, 24], [6, 8], [1, 3], [20, 30]);
        return nouvellePlante;
    }
}