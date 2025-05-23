public class PlanteTailler : PlanteSimple //Classe héritiaire de PlanteSimple qui rajoute un entretien qui consiste à tailler la plante
{
    public bool Taillage { get; set; }

    public PlanteTailler(char affichage, string nom, double prixAchat, double prixVente, double croissance,string type, string terrainFavori, double[] temperature, double[] ensoleillement, double[] pluie, double[] humidité) : base(affichage, nom, prixAchat, prixVente, croissance,type,terrainFavori,temperature,ensoleillement,pluie,humidité)
    {
        Taillage = true; //Paramètre pour savoir si la plante et à tailler
    }
    public override void SimulerCroissance(Terrain terrain,int i, int j)
    {
        Random random = new Random();
        int aleatoire = random.Next(0, 5);
        if ((Taillage == true) && (aleatoire == 1) && Croissance != 0)
        {
            Taillage = false; //S'affiche en vert si non taillée
        }
        else if (Taillage == true) //Stoppe la croissance si non taillée (nécessite un item pour être taillée)
        { base.SimulerCroissance(terrain, i, j); }
        
    }
    public void Tailler() //Taille la plante
    {
        Taillage=true;
    }
}