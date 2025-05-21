public class PlanteTailler : PlanteSimple
{
    public bool Taillage { get; set; }

    public PlanteTailler(char affichage, string nom, double prixAchat, double prixVente, double croissance,string type, string terrainFavori, double[] temperature, double[] ensoleillement, double[] pluie, double[] humidité, bool taillage = true) : base(affichage, nom, prixAchat, prixVente, croissance,type,terrainFavori,temperature,ensoleillement,pluie,humidité)
    {
        Affichage = affichage;
        Nom = nom;
        PrixAchat = prixAchat;
        PrixVente = prixVente;
        Croissance = croissance;
        Taillage = taillage;
        Type = type;
        TerrainFavori = terrainFavori;
        Temperature = temperature;
        Ensoleillement = ensoleillement;
        Pluie = pluie;
        Humidité = humidité;
    }
    public override void SimulerCroissance(Terrain terrain,int i, int j)
    {
        Random random = new Random();
        int aleatoire = random.Next(0, 5);
        if ((Taillage== true) && (aleatoire == 1))
        {
            Taillage = false;
        }
        else if (Taillage==true)
        {base.SimulerCroissance(terrain,i,j);}
        
    }
    public void Tailler(int i, int j)
    {
        Taillage=true;
    }
    public PlanteTailler CreerCacruz()
    {
        PlanteTailler nouvellePlante = new PlanteTailler('c', "Cacruz", 150, 600, 3,"Comestible","Desert Delicat",[16,26],[6,9],[1,5],[0,10]);
        return nouvellePlante;
    }
    public PlanteTailler CreerMutina()
    {
        PlanteTailler nouvellePlante = new PlanteTailler('m', "Mutina", 750, 3000, 3,"Comestible","Marecages Malins",[20,27],[7,11],[5,9],[60,90]);
        return nouvellePlante;
    }
    public PlanteTailler CreerKuintefeuille()
    {
        PlanteTailler nouvellePlante = new PlanteTailler('k', "Kuintefeuille", 2000, 16000, 8,"Ornementale","Marecages Malins",[20,27],[7,11],[5,9],[60,90]);
        return nouvellePlante;
    }
}