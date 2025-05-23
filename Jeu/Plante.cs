public abstract class Plante
{
    public char Affichage { get; set; }


    public Plante()
    {
        Affichage = '@';
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
    public double[] Humidite { get; set; }
    public int Immunite { get; set; }

    public PlanteSimple(char affichage, string nom, double prixAchat, double prixVente, double croissance, string type, string terrainFavori, double[] temperature, double[] ensoleillement, double[] pluie, double[] humidite) : base()
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
        Humidite = humidite;
        Immunite = 0;
    }
    
    public PlanteSimple Clone()
    {
        return new PlanteSimple(Affichage, Nom, PrixAchat, PrixVente, Croissance, Type, TerrainFavori,Temperature, Ensoleillement,Pluie, Humidite);
    }

    public virtual void SimulerCroissance(Terrain terrain, int i, int j)
    {
        int condition = 0;
        if (terrain.Temperature[4] >= Temperature[0] && terrain.Temperature[4] <= Temperature[1]) condition++;    // dans le tableau terrain.Temperature, la 5è case, soit terrain.Température[4] comprendra toujours la température actuelle du terrain. 
        if (terrain.Humidite[4] >= Humidite[0] && terrain.Humidite[4] <= Humidite[1]) condition++;
        if (terrain.Pluie[4] >= Pluie[0] && terrain.Pluie[4] <= Pluie[1]) condition++;
        if (terrain.Ensoleillement[4] >= Ensoleillement[0] && terrain.Ensoleillement[4] <= Ensoleillement[1]) condition++;

        bool estTerrainFavori = TerrainFavori == terrain.Nom;
        if ((estTerrainFavori && condition >= 2 && Croissance != 0 && Immunite==0) || (!estTerrainFavori && condition >= 3 && Croissance != 0 && Immunite==0))
        {
            Croissance--;
        }
        else if ((estTerrainFavori && condition == 0 && Croissance != 0 && Immunite == 0) || (!estTerrainFavori && condition <= 1 && Croissance != 0 && Immunite == 0))
        {
            terrain.DetruirePlante(i, j);
        }
        if (Croissance == 0)
        {
            Affichage = char.ToUpper(Affichage);
        }
        if (Immunite == 1)
        {
            Immunite--;
        }
        
    }
}