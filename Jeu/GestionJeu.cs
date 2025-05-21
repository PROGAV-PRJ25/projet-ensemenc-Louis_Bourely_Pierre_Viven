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
                    SimulationSemaine();
                    break;
                case 2:
                    Sauvegarde sauvegarde = new Sauvegarde(Partie);
                    sauvegarde.Sauvegarder();
                    SimulationSemaine();
                    break;
                case 3:
                    Sauvegarde sauvegarde2 = new Sauvegarde(Partie);
                    sauvegarde2.Sauvegarder();
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
            Console.WriteLine("Que voulez vous faire ? ENtrée pour simuler la semaine et passer à la suivante, Q pour quitter numéro 1 à 5 pour aller sur un terrain S pour sauegarder et quitter");
            Console.WriteLine($"Vos infos => VerdaMoula:{Partie.VerdaMoula} Semaine:{Partie.Semaine}");
            Console.WriteLine($"Vous avez => {Partie.ListePlantes[0]}Plante1,  {Partie.ListePlantes[1]}Plante2,...");
            Console.WriteLine($"Vous avez => {Partie.ListeSemis[0]}Semis1,  {Partie.ListeSemis[1]}Semis2,...");
            Console.WriteLine($"Vous avez => {Partie.ListeItems[0]}Item1,  {Partie.ListeItems[1]}Item2,...");
            switch(Console.ReadKey().Key)
            {
                case ConsoleKey.Enter:
                    return 1;
                case ConsoleKey.S:
                    return 3;
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
                case ConsoleKey.M:
                    Magasin();
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
        bool enCours = true;
        while(enCours)
        {
            Console.Clear();
            Afficher.Potager(Partie.ListeTerrains[terrain-1].Potager);
            Console.WriteLine($"Terrain {terrain} {Partie.ListeTerrains[terrain-1].Nom} Q pour quitter, P pour Planter");

            switch(Console.ReadKey().Key)
            {
                case ConsoleKey.Q:
                    enCours=false;
                    break;
                case ConsoleKey.P:
                    Planter(Partie.ListeTerrains[terrain-1]);
                    break;
                case ConsoleKey.I:
                    UtiliserItem(Partie.ListeTerrains[terrain-1]);
                    break;
                default:
                    break;

            }
        }
    }
    public void UtiliserItem(Terrain terrain)
    {
        bool enCours = true;
        while(enCours)
        {
            Console.Clear();
            Afficher.Potager(terrain.Potager);
            Console.WriteLine($"Vous avez => {Partie.ListeItems[0]}item1,  {Partie.ListeItems[1]}item2,...");
            Console.WriteLine($"Terrain {terrain} Q pour quitter, Initial de la plante pour plante");
            Console.WriteLine("");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Q:
                    enCours = false;
                    break;
                case ConsoleKey.A:
                    if (Partie.ListeItems[0] >= 1)
                    {
                        terrain.AgrandirPotager();
                        Partie.ListeItems[0]--;
                    }
                    else
                    {
                        Afficher.TexteEnProgressif("Vous ne possédez pas cette iteme va travailler pour te l'acheter feignasse     ", 50);
                    }
                    break;
                case ConsoleKey.B:
                    if (Partie.ListeItems[1] >= 1)
                    {
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            terrain.Labourer(demandeCase[0],demandeCase[1]);
                            Partie.ListeItems[0]--;
                        }
                    }
                    else
                    {
                        Afficher.TexteEnProgressif("Vous ne possédez pas cette iteme va travailler pour te l'acheter feignasse     ", 50);
                    }
                    break;
                case ConsoleKey.C:
                    if (Partie.ListeSemis[2] == 0)
                    {
                        Afficher.TexteEnProgressif("Vous n'avez pas ce semis va en acheter au magasin sale pauvre         ", 50);
                    }
                    else
                    {
                        PlanteSimple nouvellePlante = new PlanteTailler('c', "Cacruz", 150, 600, 3,"Comestible","Desert Delicat",[16,26],[6,9],[1,5],[0,10]);
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            terrain.Planter(nouvellePlante, demandeCase[0], demandeCase[1]);
                            Partie.ListePlantes[2]--;
                        }
                    }
                    break;
                case ConsoleKey.D:
                    if (Partie.ListeSemis[3] == 0)
                    {
                        Afficher.TexteEnProgressif("Vous n'avez pas ce semis va en acheter au magasin sale pauvre         ", 50);
                    }
                    else
                    {
                        PlanteSimple nouvellePlante = new PlanteSimple('d', "Demonia", 10, 40, 2, "Comestible", "Volcan Violent", [26, 33], [7, 9], [1, 3], [5, 15]);
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            terrain.Planter(nouvellePlante, demandeCase[0], demandeCase[1]);
                            Partie.ListePlantes[3]--;
                        }
                    }
                    break;
                case ConsoleKey.E:
                    if (Partie.ListeSemis[4] == 0)
                    {
                        Afficher.TexteEnProgressif("Vous n'avez pas ce semis va en acheter au magasin sale pauvre         ", 50);
                    }
                    else
                    {
                        PlanteSimple nouvellePlante = new PlanteSimple('e', "Erdomania", 3, 12, 2, "Comestible", "Plaines Paisibles", [14, 18], [7, 8], [4, 6], [15, 20]);
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            terrain.Planter(nouvellePlante, demandeCase[0], demandeCase[1]);
                            Partie.ListePlantes[4]--;
                        }
                    }
                    break;
                case ConsoleKey.F:
                    if (Partie.ListeSemis[5] == 0)
                    {
                        Afficher.TexteEnProgressif("Vous n'avez pas ce semis va en acheter au magasin sale pauvre         ", 50);
                    }
                    else
                    {
                        PlanteSimple nouvellePlante = new PlanteSimple('f', "Fenecia", 30, 240, 8, "Ornementale", "Volcan Violent", [28, 44], [8, 11], [1, 2], [5, 15]);
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            terrain.Planter(nouvellePlante, demandeCase[0], demandeCase[1]);
                            Partie.ListePlantes[5]--;
                        }
                    }
                    break;
                case ConsoleKey.G:
                    if (Partie.ListeSemis[6] == 0)
                    {
                        Afficher.TexteEnProgressif("Vous n'avez pas ce semis va en acheter au magasin sale pauvre         ", 50);
                    }
                    else
                    {
                        PlanteSimple nouvellePlante = new PlanteFilante('g', "Gorhy", 20, 120, 4, "Comestible", "Volcan Violent", [26, 35], [7, 9], [1, 3], [5, 15]);
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            terrain.Planter(nouvellePlante, demandeCase[0], demandeCase[1]);
                            Partie.ListePlantes[6]--;
                        }
                    }
                    break;
                case ConsoleKey.H:
                    if (Partie.ListeSemis[7] == 0)
                    {
                        Afficher.TexteEnProgressif("Vous n'avez pas ce semis va en acheter au magasin sale pauvre         ", 50);
                    }
                    else
                    {
                        PlanteSimple nouvellePlante = new PlanteSimple('h', "Humalis", 8, 64, 10, "Médicinale", "Plaines Paisibles", [12, 25], [6, 11], [3, 8], [10, 20]);
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            terrain.Planter(nouvellePlante, demandeCase[0], demandeCase[1]);
                            Partie.ListePlantes[7]--;
                        }
                    }
                    break;
                case ConsoleKey.I:
                    if (Partie.ListeSemis[8] == 0)
                    {
                        Afficher.TexteEnProgressif("Vous n'avez pas ce semis va en acheter au magasin sale pauvre         ", 50);
                    }
                    else
                    {
                        PlanteSimple nouvellePlante = new PlanteSimple('i', "Ivoina", 80, 480, 5, "Comestible", "Foret Facetieuse", [9, 18], [4, 6], [3, 4], [35, 45]);
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            terrain.Planter(nouvellePlante, demandeCase[0], demandeCase[1]);
                            Partie.ListePlantes[8]--;
                        }
                    }
                    break;
                case ConsoleKey.J:
                    if (Partie.ListeSemis[9] == 0)
                    {
                        Afficher.TexteEnProgressif("Vous n'avez pas ce semis va en acheter au magasin sale pauvre         ", 50);
                    }
                    else
                    {
                        PlanteSimple nouvellePlante = new PlanteFilante('j', "Jaunille", 300, 1800, 4, "Comestible", "Desert Delicat", [16, 26], [6, 9], [1, 5], [0, 10]);
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            terrain.Planter(nouvellePlante, demandeCase[0], demandeCase[1]);
                            Partie.ListePlantes[9]--;
                        }
                    }
                    break;
                case ConsoleKey.M:
                    if (Partie.ListeSemis[10] == 0)
                    {
                        Afficher.TexteEnProgressif("Vous n'avez pas ce semis va en acheter au magasin sale pauvre         ", 50);
                    }
                    else
                    {
                        PlanteSimple nouvellePlante = new PlanteTailler('m', "Mutina", 750, 3000, 3,"Comestible","Marecages Malins",[20,27],[7,11],[5,9],[60,90]);
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            terrain.Planter(nouvellePlante, demandeCase[0], demandeCase[1]);
                            Partie.ListePlantes[10]--;
                        }
                    }
                    break;
                case ConsoleKey.N:
                    if (Partie.ListeSemis[11] == 0)
                    {
                        Afficher.TexteEnProgressif("Vous n'avez pas ce semis va en acheter au magasin sale pauvre         ", 50);
                    }
                    else
                    {
                        PlanteSimple nouvellePlante = new PlanteSimple('n', "Nénustar", 1250, 7500, 5, "Comestible", "Marecages Malins", [20, 27], [7, 11], [5, 9], [60, 90]);
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            terrain.Planter(nouvellePlante, demandeCase[0], demandeCase[1]);
                            Partie.ListePlantes[11]--;
                        }
                    }
                    break;
                case ConsoleKey.P:
                    if (Partie.ListeSemis[12] == 0)
                    {
                        Afficher.TexteEnProgressif("Vous n'avez pas ce semis va en acheter au magasin sale pauvre         ", 50);
                    }
                    else
                    {
                        PlanteSimple nouvellePlante = new PlanteSimple('p', "Placinet", 50, 200, 2, "Comestible", "Foret Facetieuse", [9, 18], [4, 6], [3, 4], [35, 45]);
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            terrain.Planter(nouvellePlante, demandeCase[0], demandeCase[1]);
                            Partie.ListePlantes[12]--;
                        }
                    }
                    break;
                case ConsoleKey.K:
                    if (Partie.ListeSemis[13] == 0)
                    {
                        Afficher.TexteEnProgressif("Vous n'avez pas ce semis va en acheter au magasin sale pauvre         ", 50);
                    }
                    else
                    {
                        PlanteSimple nouvellePlante = new PlanteTailler('k', "Kuintefeuille", 2000, 16000, 8,"Ornementale","Marecages Malins",[20,27],[7,11],[5,9],[60,90]);
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            terrain.Planter(nouvellePlante, demandeCase[0], demandeCase[1]);
                            Partie.ListePlantes[13]--;
                        }
                    }
                    break;
                case ConsoleKey.Z:
                    if (Partie.ListeSemis[14] == 0)
                    {
                        Afficher.TexteEnProgressif("Vous n'avez pas ce semis va en acheter au magasin sale pauvre         ", 50);
                    }
                    else
                    {
                        PlanteSimple nouvellePlante = new PlanteFilante('z', "Zolia", 100, 1000, 10, "Ornementale", "Foret Facétieuse", [18, 24], [6, 8], [1, 3], [20, 30]);
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            terrain.Planter(nouvellePlante, demandeCase[0], demandeCase[1]);
                            Partie.ListePlantes[14]--;
                        }
                    }
                    break;
                default:
                    break;

            }
        }
    }
    

    public void Planter(Terrain terrain)
    {
        bool enCours = true;
        while (enCours)
        {
            Console.Clear();
            Afficher.Potager(terrain.Potager);
            Console.WriteLine($"Vous avez => {Partie.ListePlantes[0]}Plante1,  {Partie.ListePlantes[1]}Plante2,...");
            Console.WriteLine($"Terrain {terrain} Q pour quitter, Initial de la plante pour plante");
            Console.WriteLine("");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Q:
                    enCours = false;
                    break;
                case ConsoleKey.A:
                    if (Partie.ListeSemis[0] == 0)
                    {
                        Afficher.TexteEnProgressif("Vous n'avez pas ce semis va en acheter au magasin sale pauvre         ", 50);
                    }
                    else
                    {
                        PlanteSimple nouvellePlante = new PlanteSimple('a', "Arachnéide", 500, 5000, 7, "Médicinale", "Desert Delicat", [16, 26], [6, 9], [1, 5], [0, 10]);
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            terrain.Planter(nouvellePlante, demandeCase[0], demandeCase[1]);
                            Partie.ListePlantes[0]--;
                        }
                    }
                    break;
                case ConsoleKey.B:
                    if (Partie.ListeSemis[1] == 0)
                    {
                        Afficher.TexteEnProgressif("Vous n'avez pas ce semis va en acheter au magasin sale pauvre         ", 50);
                    }
                    else
                    {
                        PlanteSimple nouvellePlante = new PlanteSimple('b', "Brocélia", 5, 30, 3, "Comestible", "Plaines Paisibles", [18, 23], [8, 9], [3, 5], [17, 22]);
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            terrain.Planter(nouvellePlante, demandeCase[0], demandeCase[1]);
                            Partie.ListePlantes[1]--;
                        }
                    }
                    break;
                case ConsoleKey.C:
                    if (Partie.ListeSemis[2] == 0)
                    {
                        Afficher.TexteEnProgressif("Vous n'avez pas ce semis va en acheter au magasin sale pauvre         ", 50);
                    }
                    else
                    {
                        PlanteSimple nouvellePlante = new PlanteTailler('c', "Cacruz", 150, 600, 3, "Comestible", "Desert Delicat", [16, 26], [6, 9], [1, 5], [0, 10]);
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            terrain.Planter(nouvellePlante, demandeCase[0], demandeCase[1]);
                            Partie.ListePlantes[2]--;
                        }
                    }
                    break;
                case ConsoleKey.D:
                    if (Partie.ListeSemis[3] == 0)
                    {
                        Afficher.TexteEnProgressif("Vous n'avez pas ce semis va en acheter au magasin sale pauvre         ", 50);
                    }
                    else
                    {
                        PlanteSimple nouvellePlante = new PlanteSimple('d', "Demonia", 10, 40, 2, "Comestible", "Volcan Violent", [26, 33], [7, 9], [1, 3], [5, 15]);
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            terrain.Planter(nouvellePlante, demandeCase[0], demandeCase[1]);
                            Partie.ListePlantes[3]--;
                        }
                    }
                    break;
                case ConsoleKey.E:
                    if (Partie.ListeSemis[4] == 0)
                    {
                        Afficher.TexteEnProgressif("Vous n'avez pas ce semis va en acheter au magasin sale pauvre         ", 50);
                    }
                    else
                    {
                        PlanteSimple nouvellePlante = new PlanteSimple('e', "Erdomania", 3, 12, 2, "Comestible", "Plaines Paisibles", [14, 18], [7, 8], [4, 6], [15, 20]);
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            terrain.Planter(nouvellePlante, demandeCase[0], demandeCase[1]);
                            Partie.ListePlantes[4]--;
                        }
                    }
                    break;
                case ConsoleKey.F:
                    if (Partie.ListeSemis[5] == 0)
                    {
                        Afficher.TexteEnProgressif("Vous n'avez pas ce semis va en acheter au magasin sale pauvre         ", 50);
                    }
                    else
                    {
                        PlanteSimple nouvellePlante = new PlanteSimple('f', "Fenecia", 30, 240, 8, "Ornementale", "Volcan Violent", [28, 44], [8, 11], [1, 2], [5, 15]);
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            terrain.Planter(nouvellePlante, demandeCase[0], demandeCase[1]);
                            Partie.ListePlantes[5]--;
                        }
                    }
                    break;
                case ConsoleKey.G:
                    if (Partie.ListeSemis[6] == 0)
                    {
                        Afficher.TexteEnProgressif("Vous n'avez pas ce semis va en acheter au magasin sale pauvre         ", 50);
                    }
                    else
                    {
                        PlanteSimple nouvellePlante = new PlanteFilante('g', "Gorhy", 20, 120, 4, "Comestible", "Volcan Violent", [26, 35], [7, 9], [1, 3], [5, 15]);
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            terrain.Planter(nouvellePlante, demandeCase[0], demandeCase[1]);
                            Partie.ListePlantes[6]--;
                        }
                    }
                    break;
                case ConsoleKey.H:
                    if (Partie.ListeSemis[7] == 0)
                    {
                        Afficher.TexteEnProgressif("Vous n'avez pas ce semis va en acheter au magasin sale pauvre         ", 50);
                    }
                    else
                    {
                        PlanteSimple nouvellePlante = new PlanteSimple('h', "Humalis", 8, 64, 10, "Médicinale", "Plaines Paisibles", [12, 25], [6, 11], [3, 8], [10, 20]);
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            terrain.Planter(nouvellePlante, demandeCase[0], demandeCase[1]);
                            Partie.ListePlantes[7]--;
                        }
                    }
                    break;
                case ConsoleKey.I:
                    if (Partie.ListeSemis[8] == 0)
                    {
                        Afficher.TexteEnProgressif("Vous n'avez pas ce semis va en acheter au magasin sale pauvre         ", 50);
                    }
                    else
                    {
                        PlanteSimple nouvellePlante = new PlanteSimple('i', "Ivoina", 80, 480, 5, "Comestible", "Foret Facetieuse", [9, 18], [4, 6], [3, 4], [35, 45]);
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            terrain.Planter(nouvellePlante, demandeCase[0], demandeCase[1]);
                            Partie.ListePlantes[8]--;
                        }
                    }
                    break;
                case ConsoleKey.J:
                    if (Partie.ListeSemis[9] == 0)
                    {
                        Afficher.TexteEnProgressif("Vous n'avez pas ce semis va en acheter au magasin sale pauvre         ", 50);
                    }
                    else
                    {
                        PlanteSimple nouvellePlante = new PlanteFilante('j', "Jaunille", 300, 1800, 4, "Comestible", "Desert Delicat", [16, 26], [6, 9], [1, 5], [0, 10]);
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            terrain.Planter(nouvellePlante, demandeCase[0], demandeCase[1]);
                            Partie.ListePlantes[9]--;
                        }
                    }
                    break;
                case ConsoleKey.M:
                    if (Partie.ListeSemis[10] == 0)
                    {
                        Afficher.TexteEnProgressif("Vous n'avez pas ce semis va en acheter au magasin sale pauvre         ", 50);
                    }
                    else
                    {
                        PlanteSimple nouvellePlante = new PlanteTailler('m', "Mutina", 750, 3000, 3, "Comestible", "Marecages Malins", [20, 27], [7, 11], [5, 9], [60, 90]);
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            terrain.Planter(nouvellePlante, demandeCase[0], demandeCase[1]);
                            Partie.ListePlantes[10]--;
                        }
                    }
                    break;
                case ConsoleKey.N:
                    if (Partie.ListeSemis[11] == 0)
                    {
                        Afficher.TexteEnProgressif("Vous n'avez pas ce semis va en acheter au magasin sale pauvre         ", 50);
                    }
                    else
                    {
                        PlanteSimple nouvellePlante = new PlanteSimple('n', "Nénustar", 1250, 7500, 5, "Comestible", "Marecages Malins", [20, 27], [7, 11], [5, 9], [60, 90]);
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            terrain.Planter(nouvellePlante, demandeCase[0], demandeCase[1]);
                            Partie.ListePlantes[11]--;
                        }
                    }
                    break;
                case ConsoleKey.P:
                    if (Partie.ListeSemis[12] == 0)
                    {
                        Afficher.TexteEnProgressif("Vous n'avez pas ce semis va en acheter au magasin sale pauvre         ", 50);
                    }
                    else
                    {
                        PlanteSimple nouvellePlante = new PlanteSimple('p', "Placinet", 50, 200, 2, "Comestible", "Foret Facetieuse", [9, 18], [4, 6], [3, 4], [35, 45]);
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            terrain.Planter(nouvellePlante, demandeCase[0], demandeCase[1]);
                            Partie.ListePlantes[12]--;
                        }
                    }
                    break;
                case ConsoleKey.K:
                    if (Partie.ListeSemis[13] == 0)
                    {
                        Afficher.TexteEnProgressif("Vous n'avez pas ce semis va en acheter au magasin sale pauvre         ", 50);
                    }
                    else
                    {
                        PlanteSimple nouvellePlante = new PlanteTailler('k', "Kuintefeuille", 2000, 16000, 8, "Ornementale", "Marecages Malins", [20, 27], [7, 11], [5, 9], [60, 90]);
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            terrain.Planter(nouvellePlante, demandeCase[0], demandeCase[1]);
                            Partie.ListePlantes[13]--;
                        }
                    }
                    break;
                case ConsoleKey.Z:
                    if (Partie.ListeSemis[14] == 0)
                    {
                        Afficher.TexteEnProgressif("Vous n'avez pas ce semis va en acheter au magasin sale pauvre         ", 50);
                    }
                    else
                    {
                        PlanteSimple nouvellePlante = new PlanteFilante('z', "Zolia", 100, 1000, 10, "Ornementale", "Foret Facétieuse", [18, 24], [6, 8], [1, 3], [20, 30]);
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            terrain.Planter(nouvellePlante, demandeCase[0], demandeCase[1]);
                            Partie.ListePlantes[14]--;
                        }
                    }
                    break;
                default:
                    break;

            }
        }
    }

    public void Magasin()
    {
        bool enCours = true;
        while(enCours)
        {
            
            Console.Clear();
            Afficher.Magasin();
            switch(Console.ReadKey().Key)
            {
                case ConsoleKey.Q:
                    enCours=false;
                    break;
                case ConsoleKey.D1:
                    MagasinSemis();
                    break;
                case ConsoleKey.D2:
                    MagasinPlantes();
                    break;
                case ConsoleKey.D3:
                    MagasinItems();
                    break;
                default :
                    break;
            }
        }
    }

    public void MagasinSemis()
    {
        bool enCours = true;
        while(enCours)
        {
            Console.Clear();
            Console.WriteLine($"Verdamoula : {Partie.VerdaMoula}");
            Console.WriteLine($"Vous avez => {Partie.ListeSemis[0]}Semis1,  {Partie.ListeSemis[1]}Semis2,...");
            Console.WriteLine("mets l'initial pour acheter j'espère ta la thunasse");
            
            switch(Console.ReadKey().Key)
            {
                case ConsoleKey.Q:
                    enCours=false;
                    break;
                case ConsoleKey.A:
                    if(Partie.VerdaMoula>=500)
                    {
                        Partie.VerdaMoula-=500;
                        Partie.ListeSemis[0]++;
                    }
                    break;
                case ConsoleKey.B:
                    if(Partie.VerdaMoula>=5)
                    {
                        Partie.VerdaMoula-=5;
                        Partie.ListeSemis[1]++;
                    }
                    break;
                case ConsoleKey.C:
                    if(Partie.VerdaMoula>=150)
                    {
                        Partie.VerdaMoula-=150;
                        Partie.ListeSemis[2]++;
                    }
                    break;
                case ConsoleKey.D:
                    if(Partie.VerdaMoula>=10)
                    {
                        Partie.VerdaMoula-=10;
                        Partie.ListeSemis[3]++;
                    }
                    break;
                case ConsoleKey.E:
                    if(Partie.VerdaMoula>=3)
                    {
                        Partie.VerdaMoula-=3;
                        Partie.ListeSemis[4]++;
                    }
                    break;
                case ConsoleKey.F:
                    if(Partie.VerdaMoula>=30)
                    {
                        Partie.VerdaMoula-=30;
                        Partie.ListeSemis[5]++;
                    }
                    break;
                case ConsoleKey.G:
                    if(Partie.VerdaMoula>=20)
                    {
                        Partie.VerdaMoula-=20;
                        Partie.ListeSemis[6]++;
                    }
                    break;
                case ConsoleKey.H:
                    if(Partie.VerdaMoula>=8)
                    {
                        Partie.VerdaMoula-=8;
                        Partie.ListeSemis[7]++;
                    }
                    break;
                case ConsoleKey.I:
                    if(Partie.VerdaMoula>=80)
                    {
                        Partie.VerdaMoula-=80;
                        Partie.ListeSemis[8]++;
                    }
                    break;
                case ConsoleKey.J:
                    if(Partie.VerdaMoula>=300)
                    {
                        Partie.VerdaMoula-=300;
                        Partie.ListeSemis[9]++;
                    }
                    break;
                case ConsoleKey.M:
                    if(Partie.VerdaMoula>=750)
                    {
                        Partie.VerdaMoula-=750;
                        Partie.ListeSemis[10]++;
                    }
                    break;
                case ConsoleKey.N:
                    if(Partie.VerdaMoula>=1250)
                    {
                        Partie.VerdaMoula-=1250;
                        Partie.ListeSemis[11]++;
                    }
                    break;
                case ConsoleKey.P:
                    if(Partie.VerdaMoula>=50)
                    {
                        Partie.VerdaMoula-=50;
                        Partie.ListeSemis[12]++;
                    }
                    break;
                case ConsoleKey.K:
                    if(Partie.VerdaMoula>=2000)
                    {
                        Partie.VerdaMoula-=2000;
                        Partie.ListeSemis[13]++;
                    }
                    break;
                case ConsoleKey.Z:
                    if(Partie.VerdaMoula>=100)
                    {
                        Partie.VerdaMoula-=100;
                        Partie.ListeSemis[14]++;
                    }
                    break;
                default:
                    break;
            }
        }
    }

    public void MagasinPlantes()
    {
        bool enCours = true;
        while(enCours)
        {
            Console.Clear();
            Console.WriteLine($"Verdamoula : {Partie.VerdaMoula}");
            Console.WriteLine($"Vous avez => {Partie.ListePlantes[0]}Semis1,  {Partie.ListePlantes[1]}Semis2,...");
            Console.WriteLine("mets l'initial pour vendre et être à l'aise financierement");

            switch(Console.ReadKey().Key)
            {
                case ConsoleKey.Q:
                    enCours=false;
                    break;
                case ConsoleKey.A:
                    if(Partie.ListePlantes[0]>=1)
                    {
                        Partie.VerdaMoula+=5000;
                        Partie.ListePlantes[0]--;
                    }
                    break;
                case ConsoleKey.B:
                    if(Partie.ListePlantes[1]>=1)
                    {
                        Partie.VerdaMoula+=30;
                        Partie.ListePlantes[1]--;
                    }
                    break;
                case ConsoleKey.C:
                    if(Partie.ListePlantes[2]>=1)
                    {
                        Partie.VerdaMoula+=600;
                        Partie.ListePlantes[2]--;
                    }
                    break;
                case ConsoleKey.D:
                    if(Partie.ListePlantes[3]>=1)
                    {
                        Partie.VerdaMoula+=40;
                        Partie.ListePlantes[3]--;
                    }
                    break;
                case ConsoleKey.E:
                    if(Partie.ListePlantes[4]>=1)
                    {
                        Partie.VerdaMoula+=12;
                        Partie.ListePlantes[4]--;
                    }
                    break;
                case ConsoleKey.F:
                    if(Partie.ListePlantes[5]>=1)
                    {
                        Partie.VerdaMoula+=240;
                        Partie.ListePlantes[5]--;
                    }
                    break;
                case ConsoleKey.G:
                    if(Partie.ListePlantes[6]>=1)
                    {
                        Partie.VerdaMoula+=120;
                        Partie.ListePlantes[6]--;
                    }
                    break;
                case ConsoleKey.H:
                    if(Partie.ListePlantes[7]>=1)
                    {
                        Partie.VerdaMoula+=64;
                        Partie.ListePlantes[7]--;
                    }
                    break;
                case ConsoleKey.I:
                    if(Partie.ListePlantes[8]>=1)
                    {
                        Partie.VerdaMoula+=480;
                        Partie.ListePlantes[8]--;
                    }
                    break;
                case ConsoleKey.J:
                    if(Partie.ListePlantes[9]>=1)
                    {
                        Partie.VerdaMoula+=1800;
                        Partie.ListePlantes[9]--;
                    }
                    break;
                case ConsoleKey.M:
                    if(Partie.ListePlantes[10]>=1)
                    {
                        Partie.VerdaMoula+=3000;
                        Partie.ListePlantes[10]--;
                    }
                    break;
                case ConsoleKey.N:
                    if(Partie.ListePlantes[11]>=1)
                    {
                        Partie.VerdaMoula+=7500;
                        Partie.ListePlantes[11]--;
                    }
                    break;
                case ConsoleKey.P:
                    if(Partie.ListePlantes[12]>=1)
                    {
                        Partie.VerdaMoula+=200;
                        Partie.ListePlantes[12]--;
                    }
                    break;
                case ConsoleKey.K:
                    if(Partie.ListePlantes[13]>=1)
                    {
                        Partie.VerdaMoula+=16000;
                        Partie.ListePlantes[13]--;
                    }
                    break;
                case ConsoleKey.Z:
                    if(Partie.ListePlantes[14]>=1)
                    {
                        Partie.VerdaMoula+=1000;
                        Partie.ListePlantes[14]--;
                    }
                    break;
                default:
                    break;
            }
        }
    }
    
    
    public void MagasinItems()
    {
        bool enCours = true;
        while(enCours)
        {
            Console.Clear();
            Console.WriteLine($"Verdamoula : {Partie.VerdaMoula}");
            Console.WriteLine($"Vous avez => {Partie.ListeItems[0]}item1,  {Partie.ListeItems[1]}item2,...");
            Console.WriteLine("mets l'initial pour acheter j'espère ta la thunasse");

            switch(Console.ReadKey().Key)
            {
                case ConsoleKey.Q:
                    enCours=false;
                    break;
                case ConsoleKey.A:
                    if(Partie.VerdaMoula>=5)
                    {
                        Partie.VerdaMoula-=5;
                        Partie.ListeItems[0]++;
                    }
                    break;
                case ConsoleKey.B:
                    if(Partie.VerdaMoula>=5)
                    {
                        Partie.VerdaMoula-=5;
                        Partie.ListeItems[1]++;
                    }
                    break;
                case ConsoleKey.C:
                    if(Partie.VerdaMoula>=150)
                    {
                        Partie.VerdaMoula-=150;
                        Partie.ListeItems[2]++;
                    }
                    break;
                case ConsoleKey.D:
                    if(Partie.VerdaMoula>=10)
                    {
                        Partie.VerdaMoula-=10;
                        Partie.ListeItems[3]++;
                    }
                    break;
                case ConsoleKey.E:
                    if(Partie.VerdaMoula>=3)
                    {
                        Partie.VerdaMoula-=3;
                        Partie.ListeItems[4]++;
                    }
                    break;
                case ConsoleKey.F:
                    if(Partie.VerdaMoula>=30)
                    {
                        Partie.VerdaMoula-=30;
                        Partie.ListeItems[5]++;
                    }
                    break;
                case ConsoleKey.G:
                    if(Partie.VerdaMoula>=20)
                    {
                        Partie.VerdaMoula-=20;
                        Partie.ListeItems[6]++;
                    }
                    break;
                case ConsoleKey.H:
                    if(Partie.VerdaMoula>=8)
                    {
                        Partie.VerdaMoula-=8;
                        Partie.ListeItems[7]++;
                    }
                    break;
                case ConsoleKey.I:
                    if(Partie.VerdaMoula>=80)
                    {
                        Partie.VerdaMoula-=80;
                        Partie.ListeItems[8]++;
                    }
                    break;
                case ConsoleKey.J:
                    if(Partie.VerdaMoula>=300)
                    {
                        Partie.VerdaMoula-=300;
                        Partie.ListeItems[9]++;
                    }
                    break;
                default:
                    break;
            }
        }
    }

    


    public void SimulationSemaine()
    {
        Console.Clear();
        Afficher.TexteEnProgressif("Simulation semaine!!!!", 80);
        Thread.Sleep(800);
        for (int k = 0; k < Partie.ListeTerrains.Length; k++)
        {
            int saison = Partie.Semaine / 13 % 4;
            Partie.ListeTerrains[k].VerifTerrain(Partie.ListeTerrains[k], saison);
        }
        Partie.Semaine++;
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
    {
        Random random = new Random();
        int terrain = random.Next(0, 5);
        Console.Clear();
        Console.WriteLine($"Oh non un Rat mécréant sur votre terrain {Partie.ListeTerrains[terrain].Nom} mettez un raticide sinon il va dévorer toutes les plantes du terrain");
        Console.Write("Pour utiliser le raticide tapez O sinon tapez N ");
        bool enCours = true;
        while (enCours)
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.O:
                    if (Partie.ListeItems[0] >= 1)
                    {
                        Partie.ListeItems[0]--;
                        Afficher.TexteEnProgressif("Le Rat mécréant part la queue entre les jambes grâce au raticide    ", 50);
                    }
                    else
                    {
                        Afficher.TexteEnProgressif("Et non vous n'avez pas de raticide c'est tchao        ", 50);
                        for (int i = 0; i < Partie.ListeTerrains[terrain].Potager.GetLength(0); i++)
                        {
                            for (int j = 0; j < Partie.ListeTerrains[terrain].Potager.GetLength(1); j++)
                            {
                                if (Partie.ListeTerrains[terrain].Potager[i, j] is PlanteSimple)
                                {
                                    Partie.ListeTerrains[terrain].DetruirePlante(i, j);
                                }
                            }
                        }
                    }
                    enCours = false;
                    break;
                case ConsoleKey.N:
                    Afficher.TexteEnProgressif("Le rat dévore ça il se regale          ", 50);
                    enCours = false;
                    for (int i = 0; i < Partie.ListeTerrains[terrain].Potager.GetLength(0); i++)
                    {
                        for (int j = 0; j < Partie.ListeTerrains[terrain].Potager.GetLength(1); j++)
                        {
                            if (Partie.ListeTerrains[terrain].Potager[i, j] is PlanteSimple)
                            {
                                Partie.ListeTerrains[terrain].DetruirePlante(i, j);
                            }
                        }
                    }
                    break;
            }
        }
    }

    
    
    public void Galinace()
    {}

}