public class PlanteSimple : Plante //Classe qui va regrouper toutes les plantes dites vivantes c'est à dire qui peuvent être plantées, récoltées et vendues par le joueur
{
    public string Nom { get; set; }
    public double PrixAchat { get; set; }
    public double PrixVente { get; set; }
    public double Croissance { get; set; } //Variable qui stocke l'avancement de croissance de la plante en semaine restantes
    public string Type { get; set; }
    public string TerrainFavori { get; set; } 
    //Données d'environnemts:
    public double[] Temperature { get; set; } 
    public double[] Ensoleillement { get; set; }
    public double[] Pluie { get; set; }
    public double[] Humidite { get; set; }
    public int Immunite { get; set; } //Protection pour ne pas mourir selon les conditions

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
    
    public PlanteSimple Clone() //fonctions permettent de créer une nouvelle plante différente
    {
        return new PlanteSimple(Affichage, Nom, PrixAchat, PrixVente, Croissance, Type, TerrainFavori,Temperature, Ensoleillement,Pluie, Humidite);
    }

    public virtual void SimulerCroissance(Terrain terrain, int i, int j) //fonction appellée dans VerifierTerrain qui permet de faire grandir ou mourir selon les conditions de la semaine
    {
        int condition = 0;
        if (terrain.Temperature[4] >= Temperature[0] && terrain.Temperature[4] <= Temperature[1]) condition++;    // dans le tableau terrain.Temperature, la 5ème case (terrain.Température[4]) comprend la température actuelle du terrain. 
        if (terrain.Humidite[4] >= Humidite[0] && terrain.Humidite[4] <= Humidite[1]) condition++;
        if (terrain.Pluie[4] >= Pluie[0] && terrain.Pluie[4] <= Pluie[1]) condition++;
        if (terrain.Ensoleillement[4] >= Ensoleillement[0] && terrain.Ensoleillement[4] <= Ensoleillement[1]) condition++;

        bool estTerrainFavori = TerrainFavori == terrain.Nom;
        if ((estTerrainFavori && condition >= 2 && Croissance > 0) || (!estTerrainFavori && condition >= 3 && Croissance > 0)) //grandit si 3 conditions sont dans la fanêtre de la plante ou deux si on est sur le terrain favori
        {
            Croissance--;
        }
        //Immunite=0 signifie non protégée, =1 protection temporaire, =-1 protection permanente. S'obtient via des items
        else if ((estTerrainFavori && condition == 0 && Croissance > 0 && Immunite == 0) || (!estTerrainFavori && condition <= 1 && Croissance > 0 && Immunite == 0)) //Meurt si pas assez de conditions respectées
        {
            terrain.DetruirePlante(i, j);
        }
        if (Croissance <= 0) //Affiche en Majuscule si la plante a fini sa croissance
        {
            Affichage = char.ToUpper(Affichage);
        }
        if (Immunite == 1) //Enlève l'immunité dans le cas ou elle est temporaire
        {
            Immunite--;
        }
        
    }
}