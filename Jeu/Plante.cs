public abstract class Plante
{
    public char Affichage {get; set;}


    public Plante()
    {
        Affichage='@';
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
                Affichage='%';
                return;
            case "Vierge":
                Affichage='/';
                return;
            case "Laboure":
                Affichage='•';
                return;
            default:
                Affichage='@';
                return;
        }
    }
}


public class PlanteSimple : Plante
{
    public string Nom {get; set;}
    public double PrixAchat {get; set;}
    public double PrixVente {get; set;}
    public double Croissance  {get; set;}

    public PlanteSimple(char affichage, string nom,double prixAchat, double prixVente, double croissance) : base()
    {
        Affichage=affichage;
        Nom=nom;
        PrixAchat=prixAchat;
        PrixVente=prixVente;
        Croissance=croissance;
    }
}