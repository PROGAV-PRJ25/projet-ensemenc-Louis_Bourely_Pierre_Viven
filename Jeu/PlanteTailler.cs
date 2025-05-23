public class PlanteTailler : PlanteSimple
{
    public bool Taillage { get; set; }

    public PlanteTailler(char affichage, string nom, double prixAchat, double prixVente, double croissance,string type, string terrainFavori, double[] temperature, double[] ensoleillement, double[] pluie, double[] humidité) : base(affichage, nom, prixAchat, prixVente, croissance,type,terrainFavori,temperature,ensoleillement,pluie,humidité)
    {
        Taillage = true;
    }
    public override void SimulerCroissance(Terrain terrain,int i, int j)
    {
        Random random = new Random();
        int aleatoire = random.Next(0, 5);
        if ((Taillage == true) && (aleatoire == 1) && Croissance != 0)
        {
            Taillage = false;
        }
        else if (Taillage == true)
        { base.SimulerCroissance(terrain, i, j); }
        
    }
    public void Tailler()
    {
        Taillage=true;
    }
}