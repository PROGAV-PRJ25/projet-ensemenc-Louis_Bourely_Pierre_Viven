public class PlanteTailler : PlanteSimple
{
    public bool Taillage { get; set; }

    public PlanteTailler(char affichage, string nom, double prixAchat, double prixVente, double croissance, bool taillage = true) : base(affichage, nom, prixAchat, prixVente, croissance)
    {
        Affichage = affichage;
        Nom = nom;
        PrixAchat = prixAchat;
        PrixVente = prixVente;
        Croissance = croissance;
        Taillage = taillage;
    }
    public void VerifEtat(int i, int j)
    {
        Random random = new Random();
        int aleatoire = random.Next(0, 3);
        // if ((Taillage== true) && (aleatoire == 1))
        {
            Taillage = false;
            //Croissance=;
        }
    }
    public void Tailler(int i, int j)
    {

        Taillage=true;
        //Croissance=;
    }
    public PlanteTailler CreerGorhy()
    {
        PlanteTailler nouvellePlante = new PlanteTailler('c', "Cacruz", 150, 600, 3);
        return nouvellePlante;
    }
    public PlanteTailler CreerMutina()
    {
        PlanteTailler nouvellePlante = new PlanteTailler('ù', "Mutina", 750, 3000, 3);
        return nouvellePlante;
    }
    public PlanteTailler CreerQuintefeuille()
    {
        PlanteTailler nouvellePlante = new PlanteTailler('q', "Quintefeuille", 2000, 16000, 8);
        return nouvellePlante;
    }
}