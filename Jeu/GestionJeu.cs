using System.Runtime.CompilerServices;

public class GestionJeu
{
    Partie Partie {get; set;}
    Affichage Afficher{get;}

    public GestionJeu(Partie partie)
    {
        Partie=partie;
        Afficher=new Affichage();
    }
    public GestionJeu(string nom)
    {
        Partie=new Partie(nom);
        Afficher=new Affichage();
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
                case 5:
                    Console.WriteLine("ERREUR @@@");
                    break;
                default:
                    break;
            }
        }
    }

    public int Accueil(Partie partie)
    {
        bool semaineEnCours = true;
        while(semaineEnCours)
        {
            
            Console.Clear();
            Console.WriteLine($"Bienvenue dans votre monde Verdadura! {partie.Nom}");
            Console.WriteLine($"C'est la semaine {partie.Semaine}");
            Console.WriteLine("Que voulez vous faire ? T pour test Q pour quitter numéro 1 à 5 pour aller sur un terrain");switch(Console.ReadKey().Key)
            {
                case ConsoleKey.T:
                    return 1;
                case ConsoleKey.Q:
                    return 4;
                case ConsoleKey.D1:
                    VisualisationTerrain(1);
                    break;
                case ConsoleKey.D2:
                    VisualisationTerrain(2);
                    break;
                case ConsoleKey.D3:
                    VisualisationTerrain(3);
                    break;
                case ConsoleKey.D4:
                    VisualisationTerrain(4);
                    break;
                case ConsoleKey.D5:
                    VisualisationTerrain(5);
                    break;
                default :
                    break;
            }
        }
        //Affichage résumé
        //va dans magasin ou dans un terrain ou meteo ou semaine suivante ou aide
        return 5;
    }

    public void VisualisationTerrain(int terrain)
    {
        Console.Clear();
        Afficher.Potager(Partie.ListeTerrain[terrain-1].Potager);
        Console.WriteLine($"Terrain {terrain} Q pour quitter");
        bool enCours = true;
        while(enCours)
        {
            switch(Console.ReadKey().Key)
            {
                case ConsoleKey.Q:
                    enCours=false;
                    break;
                default :
                    break;

            }
        }
    }



    public void SimulationSemaine(Partie partie)
    {
        Console.Clear();
        Afficher.TexteEnProgressif("Simulation semaine!!!!",100);
        Thread.Sleep(800);
        //Faire pousser les plantes et simuler les évents de terrain
        //fais météo
        partie.Semaine++;
        /* Random random = new Random();
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
        } */
    }


    public void Rat()
    {}

    
    
    public void Galinace()
    {}

}