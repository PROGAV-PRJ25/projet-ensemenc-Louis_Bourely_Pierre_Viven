public abstract class Plante
{
    public char Affichage { get; set; }


    public Plante()
    {
        Affichage = '@';
    }

    public override string ToString()
    {
        string mess = $" {Affichage} ";
        return mess;
    }
}


public class SolSimple : Plante
{
    public SolSimple(string type) : base()
    {
        switch (type)
        {
            case "Friche":
                Affichage = '%';
                return;
            case "Vierge":
                Affichage = '/';
                return;
            case "Laboure":
                Affichage = '•';
                return;
            case "Jachère":
                Affichage = 'x';
                return;
            default:
                Affichage = '@';
                return;
        }
    }
}


public class PlanteSimple : Plante
{
    public string Nom { get; set; }
    public double PrixAchat { get; set; }
    public double PrixVente { get; set; }
    public double Croissance { get; set; }
    public string Type { get; set; }
    public string TerrainFavori { get; set; }
    public double[] Temperature { get; set; }
    public double[] Ensoleillement { get; set; }
    public double[] Pluie { get; set; }
    public double[] Humidité { get; set; }

    public PlanteSimple(char affichage, string nom, double prixAchat, double prixVente, double croissance, string type, string terrainFavori, double[] temperature, double[] ensoleillement, double[] pluie, double[] humidité) : base()
    {
        Affichage = affichage;
        Nom = nom;
        PrixAchat = prixAchat;
        PrixVente = prixVente;
        Croissance = croissance;
        Type = type;
        TerrainFavori = terrainFavori;
        Temperature = temperature;
        Ensoleillement = ensoleillement;
        Pluie = pluie;
        Humidité = humidité;
    }

    public void TourDeJeuPlante(Terrain terrain)
    {
        {
            //SimulerCroissance(terrain)
        }

    }
    public PlanteSimple CreerErdomania()
    {
        PlanteSimple nouvellePlante = new PlanteSimple('e', "Erdomania", 3, 12, 2, "Comestible", "Plaines Paisibles", [14, 18], [7, 8], [4, 6], [15, 20]);
        return nouvellePlante;
    }
    public PlanteSimple CreerBrocélia()
    {
        PlanteSimple nouvellePlante = new PlanteSimple('b', "Brocélia", 5, 30, 3, "Comestible", "Plaines Paisibles", [18, 23], [8, 9], [3, 5], [17, 22]);
        return nouvellePlante;
    }
    public PlanteSimple CreerHumalis()
    {
        PlanteSimple nouvellePlante = new PlanteSimple('h', "Humalis", 8, 64, 10, "Médicinale", "Plaines Paisibles", [12, 25], [6, 11], [3, 8], [10, 20]);
        return nouvellePlante;
    }
    public PlanteSimple CreerDemonia()
    {
        PlanteSimple nouvellePlante = new PlanteSimple('d', "Demonia", 10, 40, 2, "Comestible", "Volcan Violent", [26, 33], [7, 9], [1, 3], [5, 15]);
        return nouvellePlante;
    }
    public PlanteSimple CreerFenecia()
    {
        PlanteSimple nouvellePlante = new PlanteSimple('f', "Fenecia", 30, 240, 8, "Ornementale", "Volcan Violent", [28, 44], [8, 11], [1, 2], [5, 15]);
        return nouvellePlante;
    }
    public PlanteSimple CreerArachnéide()
    {
        PlanteSimple nouvellePlante = new PlanteSimple('a', "Arachnéide", 500, 5000, 7, "Médicinale", "Desert Delicat", [16, 26], [6, 9], [1, 5], [0, 10]);
        return nouvellePlante;
    }
    public PlanteSimple CreerNénustar()
    {
        PlanteSimple nouvellePlante = new PlanteSimple('n', "Nénustar", 1250, 7500, 5, "Comestible", "Marecages Malins", [20, 27], [7, 11], [5, 9], [60, 90]);
        return nouvellePlante;
    }
    public PlanteSimple CreerPlacinet()
    {
        PlanteSimple nouvellePlante = new PlanteSimple('p', "Placinet", 50, 200, 2, "Comestible", "Foret Facetieuse", [9, 18], [4, 6], [3, 4], [35, 45]);
        return nouvellePlante;
    }
    public PlanteSimple CreerIvoina()
    {
        PlanteSimple nouvellePlante = new PlanteSimple('i', "Ivoina", 80, 480, 5, "Comestible", "Foret Facetieuse", [9, 18], [4, 6], [3, 4], [35, 45]);
        return nouvellePlante;
    }
    public virtual void SimulerCroissance(Terrain terrain)
    {
        int condition = 0;
       // if (terrain.Temperature >= Temperature[0] && terrain.Temperature <= Temperature[1]) condition++;
        //if (terrain.Humidité >= Humidité[0] && terrain.Humidité <= Humidité[1]) condition++;
        //if (terrain.Pluie >= Pluie[0] && terrain.Pluie <= Pluie[1]) condition++;
        //if (terrain.Ensoleillement >= Ensoleillement[0] && terrain.Ensoleillement <= Ensoleillement[1]) condition++;

        bool estTerrainFavori = (TerrainFavori == terrain.Nom);
        if ((estTerrainFavori && condition >= 2) || (!estTerrainFavori && condition >= 3))
        {
            Croissance--;
        }
        else if ((estTerrainFavori && condition == 0) || (!estTerrainFavori && condition <= 1))
        {
            Affichage = '%'; // Représente "plante morte"
                             // Pour "supprimer réellement la plante", voir explication ci-dessous
        }
        if (Croissance == 0)
        {
            Affichage = char.ToUpper(Affichage);
        }
    }
}