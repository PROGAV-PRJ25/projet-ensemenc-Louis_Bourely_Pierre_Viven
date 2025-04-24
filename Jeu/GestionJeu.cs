using System.Runtime.CompilerServices;

public class GestionJeu
{
    Partie Partie {get; set;}

    public GestionJeu(Partie partie)
    {
        Partie=partie;
    }
    public GestionJeu(string nom)
    {
        Partie=new Partie(nom);
        Tutoriel();
    }


    public void Tutoriel()
    {
        //code blabla affichage des règles ascii ?
    }

    public void Jouer()
    {
        bool enCours =true;
        while(enCours)
        {
            switch(Accueil(Partie))
            {
                case 1:
                    SimulationSemaine(Partie);
                    break;
                case 2:
                    //Sauvegarder(Partie);
                    SimulationSemaine(Partie);
                    break;
                case 3:
                    //Sauvegarder(Partie);
                    enCours=false;
                    break;
                case 4:
                    enCours=false;
                    break;
            }
        }
    }

    public int Accueil(Partie partie)
    {
        Console.Clear();
        Console.WriteLine("Bienvenue dans votre monde Verdadura!");
        //Affichage résumé
        //Boucle while de décision
        //va dans magasin ou dans un terrain ou meteo ou semaine suivante ou aide
        return 1;
    }

    public void SimulationSemaine(Partie partie)
    {
        Console.Clear();
        Console.WriteLine("!!"); //Affichage chargement pendant 5 secondes
        //Faire pousser les plantes et simuler les évents de terrain
        Random random = new Random();
        int urgences = random.Next(1, 51);
        switch(urgences)
        {
            case 10:
                Rat();
                break;
            case 11:
                Galinace();
                break;
            default:
                break;
        }
    }


    public void Rat()
    {}

    
    
    public void Galinace()
    {}

}