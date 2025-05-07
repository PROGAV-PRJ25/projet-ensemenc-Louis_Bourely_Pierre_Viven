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

    public PlanteSimple(char affichage, string nom, double prixAchat, double prixVente, double croissance) : base()
    {
        Affichage = affichage;
        Nom = nom;
        PrixAchat = prixAchat;
        PrixVente = prixVente;
        Croissance = croissance;
    }

    public void TourDeJeuPlante()
    {
        // for (int i=0; i<Terrain.Potager.GetLength(0);i++)
        // {
        //     for(int j=0; j<Terrain.Potager.GetLength(1);j++)
        {
            //VerifCroissance()
            //VerifEtat(i,j)

        }
        // }
    }
    public PlanteSimple CreerErdomania()
    {
        PlanteSimple nouvellePlante = new PlanteSimple('e', "Erdomania", 3, 12, 2);
        return nouvellePlante;
    }
    public PlanteSimple CreerBrocélia()
    {
        PlanteSimple nouvellePlante = new PlanteSimple('b', "Brocélia", 5, 30, 3);
        return nouvellePlante;
    }
    public PlanteSimple CreerHumalis()
    {
        PlanteSimple nouvellePlante = new PlanteSimple('h', "Humalis", 8, 64, 10);
        return nouvellePlante;
    }
    public PlanteSimple CreerDemonia()
    {
        PlanteSimple nouvellePlante = new PlanteSimple('d', "Demonia", 10, 40, 2);
        return nouvellePlante;
    }
    public PlanteSimple CreerFenecia()
    {
        PlanteSimple nouvellePlante = new PlanteSimple('f', "Fenecia", 30, 240, 8);
        return nouvellePlante;
    }
    public PlanteSimple CreerArachnéide()
    {
        PlanteSimple nouvellePlante = new PlanteSimple('a', "Arachnéide", 500, 5000, 7);
        return nouvellePlante;
    }
    public PlanteSimple CreerNénustar()
    {
        PlanteSimple nouvellePlante = new PlanteSimple('n', "Nénustar", 1250, 7500, 5);
        return nouvellePlante;
    }
    public PlanteSimple CreerPlacinet()
    {
        PlanteSimple nouvellePlante = new PlanteSimple('p', "Placinet", 50, 200, 2);
        return nouvellePlante;
    }
    public PlanteSimple CreerIvoina()
    {
        PlanteSimple nouvellePlante = new PlanteSimple('i', "Ivoina", 80, 480, 5);
        return nouvellePlante;
    }
}