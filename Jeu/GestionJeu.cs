using System.Runtime.CompilerServices;

public class GestionJeu
{
    Partie Partie { get; set; }
    Affichage Afficher { get; }

    public GestionJeu(Partie partie)
    {
        Partie = partie;
        Afficher = new Affichage();
    }
    public GestionJeu(string nom)
    {
        Partie = new Partie(nom);
        Afficher = new Affichage();
        Tutoriel();
    }


    public void Tutoriel()
    {
        Afficher.Tutoriel(Partie.Nom);
        bool enCours = true;
        while(enCours)
        {
            switch(Console.ReadKey().Key)
            {
                case ConsoleKey.Enter:
                    enCours = false;
                    break;
                default:
                    break;
            }
        }
    }

    public void Jouer()
    {
        bool enCours = true;
        while (enCours)
        {
            switch (Accueil(Partie))
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
                    enCours = false;
                    break;
                case 4:
                    enCours = false;
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

        while (semaineEnCours)
        {
            Console.Clear();
            Afficher.Accueil();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("═══════════════════════════════════════════════════════════════════");
            Console.WriteLine($"🏝️   Bienvenue dans votre monde : {partie.Nom}");
            Console.WriteLine($"📅  Semaine actuelle : {partie.Semaine}");
            string[] Saisons = ["🌼​ Éveil fleuri ", "☀️ Éclat Profond", "🍂 Le Repli d’Or", "❄️ Repos Blanc"];
            Console.WriteLine($"📅  Saison : {Saisons[Partie.Semaine / 13 % 4]}");
            Console.WriteLine($"💰  VerdaMoula : {Partie.VerdaMoula}");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════");
            Console.ResetColor();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("🎮 Que souhaitez-vous faire ?");
            Console.WriteLine("Appuyez sur :");
            Console.WriteLine("  Entrée        ▶ Simuler la semaine suivante🔜");
            Console.WriteLine("  Espace        ▶ Sauvegarder et Simuler💾 🔜");
            Console.WriteLine("  S             ▶ Sauvegarder et quitter💾 ❌​");
            Console.WriteLine("  1 à 5         ▶ Accéder à un terrain🌍​");
            Console.WriteLine("  B             ▶ Consulter le bulletin météo⛅​");
            Console.WriteLine("  M             ▶ Aller au magasin🏪");
            Console.WriteLine("  Q             ▶ Quitter le jeu❌​​");
            Console.ResetColor();
            Console.WriteLine();
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Enter:
                    return 1;
                case ConsoleKey.S:
                    return 3;
                case ConsoleKey.Escape:
                    return 2;
                case ConsoleKey.Q:
                    return 4;
                case ConsoleKey.B:
                    BulletinMeteo();
                    break;
                case ConsoleKey.D1:
                    VisualisationTerrain(Partie.ListeTerrains[0]);
                    break;
                case ConsoleKey.D2:
                    VisualisationTerrain(Partie.ListeTerrains[1]);
                    break;
                case ConsoleKey.D3:
                    VisualisationTerrain(Partie.ListeTerrains[2]);
                    break;
                case ConsoleKey.D4:
                    VisualisationTerrain(Partie.ListeTerrains[3]);
                    break;
                case ConsoleKey.D5:
                    VisualisationTerrain(Partie.ListeTerrains[4]);
                    break;
                case ConsoleKey.M:
                    Magasin();
                    break;
                default:
                    break;
            }
        }
        return 5;
    }


    public void VisualisationTerrain(Terrain terrain)
    {
        bool enCours = true;
        while (enCours)
        {
            Console.Clear();

            double prixAgrandir = Afficher.Potager(terrain.Potager,terrain.Nom);
            Console.WriteLine($"\n💰 Verdamoula actuelle : {Partie.VerdaMoula}\n");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Pour planter un Semis🌱 tapez P,\nPour utiliser un Item 🛠️  tapez I,\nPour Récolter les plantes🌳 tapez R,");
            Console.WriteLine($"Pour obtenir la Documentation📄 du terrain tapez D,\nPour Agrandir le terrain ({prixAgrandir} 💰) tapez A,\nPour Quitter❌​ tapez Q");
            Console.ForegroundColor = ConsoleColor.White;


            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Q:
                    enCours = false;
                    break;
                case ConsoleKey.A:
                    if (Partie.VerdaMoula >= prixAgrandir)
                    {
                        terrain.AgrandirPotager();
                        Partie.VerdaMoula -= prixAgrandir;
                    }
                    break;
                case ConsoleKey.R:
                    int[] recolte = terrain.Recolter();
                    for (int k = 0; k < recolte.Length; k++)
                    {
                        Partie.ListePlantes[k] += recolte[k];
                    }
                    break;
                case ConsoleKey.D:
                    Afficher.InfoTerrain(terrain);
                    break;
                case ConsoleKey.P:
                    Planter(terrain);
                    break;
                case ConsoleKey.I:
                    UtiliserItem(terrain);
                    break;
                default:
                    break;

            }
        }
    }
    public void UtiliserItem(Terrain terrain)
    {
        bool enCours = true;
        while (enCours)
        {
            Console.Clear();
            Afficher.Potager(terrain.Potager, terrain.Nom);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n🛠️ Vos Items disponibles :");
            Console.ResetColor();

            for (int i = 3; i < Partie.ListeItems.Length; i++)
            {
                if (Partie.ListeItems[i] > 2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (Partie.ListeItems[i] > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
                //Console.Write($"{Partie.ListeInfoItems[i].Affichage}-{Partie.ListeInfoItems[i].Nom,-20} : {Partie.ListeItems[i]}        ");

                if ((i + 1) % 3 == 0)
                    Console.WriteLine();
            }
            Console.ResetColor();
            Console.WriteLine($"\n\nTapez l'initial d'item pour l'utiliser🛠️ \nTapez Q pour Quitter❌​​");
            Console.WriteLine("");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Q:
                    enCours = false;
                    break;
                case ConsoleKey.A:
                    break;
                case ConsoleKey.B:
                    if (Partie.ListeSemis[8] >= 1)
                    {
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            terrain.Labourer(demandeCase[0], demandeCase[1]);
                            Partie.ListeSemis[8]--;
                        }
                    }
                    break;
                case ConsoleKey.S:
                    if (Partie.ListeSemis[7] >= 1)
                    {
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            if (terrain.Potager[demandeCase[0], demandeCase[1]] is PlanteTailler p)
                            {
                                p.Tailler();
                            }
                            Partie.ListeSemis[7]--;
                        }
                    }
                    break;
                case ConsoleKey.E:
                    if (Partie.ListeSemis[6] >= 1)
                    {
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            if (terrain.Potager[demandeCase[0], demandeCase[1]] is PlanteSimple p)
                            {
                                p.Croissance--;
                            }
                            Partie.ListeSemis[6]--;
                        }
                    }
                    break;
                case ConsoleKey.P:
                    if (Partie.ListeSemis[5] >= 1)
                    {
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            if (terrain.Potager[demandeCase[0], demandeCase[1]] is PlanteSimple p)
                            {
                                Random random = new Random();
                                int proba = random.Next(1, 11);
                                switch (proba)
                                {
                                    case 1:
                                    case 2:
                                    case 3:
                                    case 4:
                                        p.Croissance--;
                                        break;
                                    case 5:
                                    case 6:
                                        p.Croissance++;
                                        break;
                                    case 8:
                                        terrain.DetruirePlante(demandeCase[0], demandeCase[1]);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            Partie.ListeSemis[5]--;
                        }
                    }
                    break;
                case ConsoleKey.C:
                    if (Partie.ListeSemis[4] >= 1)
                    {
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            if (terrain.Potager[demandeCase[0], demandeCase[1]] is PlanteSimple p)
                            {
                                p.Immunite=1;
                            }
                            Partie.ListeSemis[4]--;
                        }
                    }
                    break;
                case ConsoleKey.M:
                    if (Partie.ListeSemis[3] >= 1)
                    {
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            if (terrain.Potager[demandeCase[0], demandeCase[1]] is PlanteSimple p)
                            {
                                p.Immunite=-1;
                            }
                            Partie.ListeSemis[3]--;
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
            Afficher.Potager(terrain.Potager, terrain.Nom);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n🌱 Vos Semis disponibles :");
            Console.ResetColor();

            for (int i = 0; i < Partie.ListeSemis.Length; i++)
            {
                if (Partie.ListeSemis[i] > 2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (Partie.ListeSemis[i] > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
                Console.Write($"{char.ToUpper(Partie.ListeInfoPlantes[i].Affichage)}-{Partie.ListeInfoPlantes[i].Nom,-13} : {Partie.ListeSemis[i]}        ");

                if ((i + 1) % 4 == 0)
                    Console.WriteLine();
            }
            Console.ResetColor();

            Console.WriteLine($"\n\nTapez l'initial de la Plante pour la planter🌳 \nTapez Q pour Quitter❌​​");
            Console.WriteLine("");

            List<char> touches = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'M', 'N', 'P', 'K', 'Z'};
            ConsoleKeyInfo touche = Console.ReadKey(true);
            switch (touche.Key)
            {
                case ConsoleKey.Q:
                    enCours = false;
                    break;
                case ConsoleKey.A:
                case ConsoleKey.B:
                case ConsoleKey.C:
                case ConsoleKey.D:
                case ConsoleKey.E:
                case ConsoleKey.F:
                case ConsoleKey.G:
                case ConsoleKey.H:
                case ConsoleKey.I:
                case ConsoleKey.J:
                case ConsoleKey.M:
                case ConsoleKey.N:
                case ConsoleKey.P:
                case ConsoleKey.K:
                case ConsoleKey.Z:
                    int index = touches.IndexOf(char.ToUpper(touche.KeyChar));
                    if (index >= 0 && Partie.ListeSemis[index] > 0)
                    {
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            terrain.Planter(Partie.ListeInfoPlantes[index].Clone(), demandeCase[0], demandeCase[1]);
                            Partie.ListeSemis[index]--;
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
        while (enCours)
        {

            Console.Clear();
            Afficher.Magasin();
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Q:
                    enCours = false;
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
                default:
                    break;
            }
        }
    }

    public void MagasinSemis()
    {
        bool enCours = true;
        ConsoleColor fondInitial = Console.BackgroundColor;
        ConsoleColor couleurInitiale = Console.ForegroundColor;

        while (enCours)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                               ✦✦ ACHETEZ DES SEMIS DE QUALITÉ✦✦                               ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n💰 Verdamoula : {Partie.VerdaMoula}\n");
            Console.ResetColor();

            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║ Semis disponibles :                                                                           ║");
            Console.WriteLine("╠═══════════════════════════════════════════════════════════════════════════════════════════════╣");

            List<char> touches = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'M', 'N', 'P', 'K', 'Z' };

            for (int i = 0; i < 15; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($" {touches[i]} ");
                Console.ResetColor();
                Console.Write($"- {Partie.ListeInfoPlantes[i].Nom,-13} : ");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{Partie.ListeSemis[i],-3} unités");
                Console.ResetColor();

                Console.Write("  → ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{Partie.ListeInfoPlantes[i].PrixAchat,-5} Verdamoula");
                Console.ResetColor();
                Console.WriteLine();
            }

            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════════╝\n");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Tapez la touche du semis que vous souhaitez achetez (A-Z). Tapez Q pour quitter le magasin.\n");
            Console.ResetColor();

            ConsoleKeyInfo touche = Console.ReadKey(true);
            switch (touche.Key)
            {
                case ConsoleKey.Q:
                    enCours = false;
                    break;
                case ConsoleKey.A:
                case ConsoleKey.B:
                case ConsoleKey.C:
                case ConsoleKey.D:
                case ConsoleKey.E:
                case ConsoleKey.F:
                case ConsoleKey.G:
                case ConsoleKey.H:
                case ConsoleKey.I:
                case ConsoleKey.J:
                case ConsoleKey.M:
                case ConsoleKey.N:
                case ConsoleKey.P:
                case ConsoleKey.K:
                case ConsoleKey.Z:
                    int index = touches.IndexOf(char.ToUpper(touche.KeyChar));
                    if (index >= 0 && Partie.VerdaMoula >= Partie.ListeInfoPlantes[index].PrixAchat)
                    {
                        Partie.VerdaMoula -= Partie.ListeInfoPlantes[index].PrixAchat;
                        Partie.ListeSemis[index]++;
                    }
                    break;
                default:
                    break;
            }

            Console.BackgroundColor = fondInitial;
            Console.ForegroundColor = couleurInitiale;
        }
    }

    public void MagasinPlantes()
    {
        bool enCours = true;
        ConsoleColor fondInitial = Console.BackgroundColor;
        ConsoleColor couleurInitiale = Console.ForegroundColor;

        while (enCours)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                           ✦✦ VENDEZ VOS PLANTES AU MEILLEUR PRIX✦✦                            ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n💰 Verdamoula actuelle : {Partie.VerdaMoula}\n");
            Console.ResetColor();

            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║ Vos Plantes :                                                                                 ║");
            Console.WriteLine("╠═══════════════════════════════════════════════════════════════════════════════════════════════╣");

            List<char> touches = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'M', 'N', 'P', 'K', 'Z' };

            for (int i = 0; i < 15; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($" {touches[i]} ");
                Console.ResetColor();
                Console.Write($"- {Partie.ListeInfoPlantes[i].Nom,-13} : ");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{Partie.ListePlantes[i],-3} unités");
                Console.ResetColor();

                Console.Write("  → ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"+{Partie.ListeInfoPlantes[i].PrixVente,-5} Verdamoula");
                Console.ResetColor();
                Console.WriteLine();
            }

            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════════╝\n");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Tapez la touche de la plante que vous souhaitez vendre (A-Z). Tapez Q pour quitter le magasin.\n");
            Console.ResetColor();
            ConsoleKeyInfo touche = Console.ReadKey(true);
            switch (touche.Key)
            {
                case ConsoleKey.Q:
                    enCours = false;
                    break;
                case ConsoleKey.A:
                case ConsoleKey.B:
                case ConsoleKey.C:
                case ConsoleKey.D:
                case ConsoleKey.E:
                case ConsoleKey.F:
                case ConsoleKey.G:
                case ConsoleKey.H:
                case ConsoleKey.I:
                case ConsoleKey.J:
                case ConsoleKey.M:
                case ConsoleKey.N:
                case ConsoleKey.P:
                case ConsoleKey.K:
                case ConsoleKey.Z:
                    int index = touches.IndexOf(char.ToUpper(touche.KeyChar));
                    if (index >= 0 && Partie.ListePlantes[index] >= 1)
                    {
                        Partie.VerdaMoula += Partie.ListeInfoPlantes[index].PrixVente;
                        Partie.ListePlantes[index]--;
                    }
                    break;
                default:
                    break;
            }

            Console.BackgroundColor = fondInitial;
            Console.ForegroundColor = couleurInitiale;
        }
    }


    public void MagasinItems()
    {
        bool enCours = true;
        while (enCours)
        {
            Console.Clear();
            Console.WriteLine($"Verdamoula : {Partie.VerdaMoula}");
            Console.WriteLine($"Vous avez => {Partie.ListeItems[0]}item1,  {Partie.ListeItems[1]}item2,...");
            Console.WriteLine("mets l'initial pour acheter j'espère ta la thunasse");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Q:
                    enCours = false;
                    break;
                case ConsoleKey.A:
                    if (Partie.VerdaMoula >= 5)
                    {
                        Partie.VerdaMoula -= 5;
                        Partie.ListeItems[0]++;
                    }
                    break;
                case ConsoleKey.B:
                    if (Partie.VerdaMoula >= 5)
                    {
                        Partie.VerdaMoula -= 5;
                        Partie.ListeItems[1]++;
                    }
                    break;
                case ConsoleKey.C:
                    if (Partie.VerdaMoula >= 150)
                    {
                        Partie.VerdaMoula -= 150;
                        Partie.ListeItems[2]++;
                    }
                    break;
                case ConsoleKey.D:
                    if (Partie.VerdaMoula >= 10)
                    {
                        Partie.VerdaMoula -= 10;
                        Partie.ListeItems[3]++;
                    }
                    break;
                case ConsoleKey.E:
                    if (Partie.VerdaMoula >= 3)
                    {
                        Partie.VerdaMoula -= 3;
                        Partie.ListeItems[4]++;
                    }
                    break;
                case ConsoleKey.F:
                    if (Partie.VerdaMoula >= 30)
                    {
                        Partie.VerdaMoula -= 30;
                        Partie.ListeItems[5]++;
                    }
                    break;
                case ConsoleKey.G:
                    if (Partie.VerdaMoula >= 20)
                    {
                        Partie.VerdaMoula -= 20;
                        Partie.ListeItems[6]++;
                    }
                    break;
                case ConsoleKey.H:
                    if (Partie.VerdaMoula >= 8)
                    {
                        Partie.VerdaMoula -= 8;
                        Partie.ListeItems[7]++;
                    }
                    break;
                case ConsoleKey.I:
                    if (Partie.VerdaMoula >= 80)
                    {
                        Partie.VerdaMoula -= 80;
                        Partie.ListeItems[8]++;
                    }
                    break;
                case ConsoleKey.J:
                    if (Partie.VerdaMoula >= 300)
                    {
                        Partie.VerdaMoula -= 300;
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
        Partie.chenille = false;
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
        switch (urgences)
        {
            case 10:
                Rat();
                break;
            case 11:
                Galinace();
                break;
            case 12:
                Chenille();
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
    {
        Random random = new Random();
        int terrain = random.Next(0, 5);
        Console.Clear();
        Console.WriteLine($"Oh non un Gallinacé Hargneux est arrivé sur votre terrain {Partie.ListeTerrains[terrain].Nom} utilisez un tir de fusil sinon il va dévorer toutes les plantes comestibles du terrain");
        Console.Write("Pour utiliser le tir de fusil tapez O sinon tapez N ");
        bool enCours = true;
        while (enCours)
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.O:
                    if (Partie.ListeItems[1] >= 1)
                    {
                        Partie.ListeItems[1]--;
                        Afficher.TexteEnProgressif("Le Gallinacé Hargneux part les plumes entre les jambes grâce au tir de fusil    ", 50);
                    }
                    else
                    {
                        Afficher.TexteEnProgressif("Et non! vous n'avez pas de tir de fusil c'est tchao        ", 50);
                        for (int i = 0; i < Partie.ListeTerrains[terrain].Potager.GetLength(0); i++)
                        {
                            for (int j = 0; j < Partie.ListeTerrains[terrain].Potager.GetLength(1); j++)
                            {
                                if (Partie.ListeTerrains[terrain].Potager[i, j] is PlanteSimple plante)
                                {
                                    if (plante.Type == "Comestible")
                                    {
                                        Partie.ListeTerrains[terrain].DetruirePlante(i, j);
                                    }

                                }
                            }
                        }
                    }
                    enCours = false;
                    break;
                case ConsoleKey.N:
                    Afficher.TexteEnProgressif("Le Gallinacé Hargneux détruit toutes les plantes comestibles          ", 50);
                    enCours = false;
                    for (int i = 0; i < Partie.ListeTerrains[terrain].Potager.GetLength(0); i++)
                    {
                        for (int j = 0; j < Partie.ListeTerrains[terrain].Potager.GetLength(1); j++)
                        {
                            if (Partie.ListeTerrains[terrain].Potager[i, j] is PlanteSimple plante)
                            {
                                if (plante.Type == "Comestible")
                                {
                                    Partie.ListeTerrains[terrain].DetruirePlante(i, j);
                                }

                            }
                        }
                    }
                    break;
            }

        }
    }
    public void Chenille()
    {
        Console.Clear();
        Console.WriteLine($"Oh non une Cheeeeeniiiiiiillllle est apparue, utilisez un insecticide à chenille sinon il va dévorer le bulletin météo de la semaine prochaine");
        Console.Write("Pour utiliser un insecticide à Chenille tapez O sinon tapez N ");
        bool enCours = true;
        while (enCours)
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.O:
                    if (Partie.ListeItems[1] >= 1)
                    {
                        Partie.ListeItems[1]--;
                        Afficher.TexteEnProgressif("Vous avez éliminé la cheeeeeniiiiillle", 50);
                    }
                    else
                    {
                        Afficher.TexteEnProgressif("Et non! vous n'avez pas d'insecticide, vous pouvez tirer une croix sur votre bulletin météo        ", 50);
                        Partie.chenille = true;
                    }
                    enCours = false;
                    break;
                case ConsoleKey.N:
                    Afficher.TexteEnProgressif("La chenille n'est pas éliminée, vous pouvez alors tirer une croix sur votre bulletin météo de la semaine          ", 50);
                    Partie.chenille = true;
                    enCours = false;
                    break;
            }
        }
    }

    public void BulletinMeteo()
    {
        bool enCours = true;
        Console.Clear();
        if (Partie.chenille)
        {
            Afficher.Chenille();
        }

        else
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                     ✦✦ BULLETIN METEO ✦✦                                      ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════════╗");
            for (int i = 0; i < Partie.ListeTerrains.Length; i++)
            {
                Console.WriteLine($"║               📍 Terrain : {Partie.ListeTerrains[i].Nom,-30}                                     ║");
                Console.WriteLine("╠═══════════════════════════════════════════════════════════════════════════════════════════════╣");

                // Données météo formatées et alignées
                Console.WriteLine($"║ 🌡️  Température moyenne    : {Partie.ListeTerrains[i].Temperature[4],-4} °C                                                           ║");
                Console.WriteLine($"║ 💧 Humidité moyenne       : {Partie.ListeTerrains[i].Humidite[4],-4} %                                                            ║");
                Console.WriteLine($"║ 🌧️  Niveau de pluie moyen  : {Partie.ListeTerrains[i].Pluie[4],-4} mm                                                           ║");
                Console.WriteLine($"║ ☀️  Ensoleillement moyen   : {Partie.ListeTerrains[i].Ensoleillement[4],-4} h                                                            ║");

                Console.WriteLine("╠═══════════════════════════════════════════════════════════════════════════════════════════════╣");
            }
            Console.Write("   Tapez Q pour Quitter ❌: ");
        }
        while (enCours)
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Q:
                    enCours = false;
                    break;
            }
        }
    }
}
