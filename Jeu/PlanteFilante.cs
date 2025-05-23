public class PlanteFilante : PlanteSimple
{
    public bool Extension { get; set; }

    public PlanteFilante(char affichage, string nom, double prixAchat, double prixVente, double croissance, string type, string terrainFavori, double[] temperature, double[] ensoleillement, double[] pluie, double[] humidité) : base(affichage, nom, prixAchat, prixVente, croissance, type, terrainFavori, temperature, ensoleillement, pluie, humidité)
    {
        Extension = false;
    }

    public void Etendre(int i, int j, Terrain terrain)
    {
        if ((i != 0) && (terrain.Potager[i - 1, j].Affichage == '•'))
        {
            if (Nom == "Jaunille")
            {
                terrain.Planter(CreerJaunille(), i - 1, j);
            }
            else if (Nom == "Gorhy")
            {
                terrain.Planter(CreerGorhy(), i - 1, j);
            }
            else if (Nom == "Zolia")
            {
                terrain.Planter(CreerZolia(), i - 1, j);
            }
        }
        else if ((j + 1 < terrain.Potager.GetLength(1)) && (terrain.Potager[i, j + 1].Affichage == '•'))
        {
            if (Nom == "Jaunille")
            {
                terrain.Planter(CreerJaunille(), i, j+1);
            }
            else if (Nom == "Gorhy")
            {
                terrain.Planter(CreerGorhy(), i, j+1);
            }
            else if (Nom == "Zolia")
            {
                terrain.Planter(CreerZolia(), i, j+1);
            }
        }
        else if ((i + 1 < terrain.Potager.GetLength(0)) && (terrain.Potager[i + 1, j].Affichage == '•'))
        {
            if (Nom == "Jaunille")
            {
                terrain.Planter(CreerJaunille(), i+1, j);
            }
            else if (Nom == "Gorhy")
            {
                terrain.Planter(CreerGorhy(), i+1, j);
            }
            else if (Nom == "Zolia")
            {
                terrain.Planter(CreerZolia(), i+1, j);
            }
        }
        else if ((j != 0) && (terrain.Potager[i, j - 1].Affichage == '•'))
        {
            if (Nom == "Jaunille")
            {
                terrain.Planter(CreerJaunille(), i, j-1);
            }
            else if (Nom == "Gorhy")
            {
                terrain.Planter(CreerGorhy(), i, j-1);
            }
            else if (Nom == "Zolia")
            {
                terrain.Planter(CreerZolia(), i, j-1);
            }
        }
        else { }
    }
    public override void SimulerCroissance(Terrain terrain, int i, int j)
    {
        base.SimulerCroissance(terrain,i,j);
        Random random = new Random();
        int aleatoire = random.Next(0, 3);
        if ((Extension == false) && (Croissance != 0) && (aleatoire == 1))
        {
            Etendre(i, j, terrain);
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