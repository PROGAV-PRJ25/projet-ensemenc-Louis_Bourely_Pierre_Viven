using System.Collections;
using System.Runtime.CompilerServices;

public class GestionJeu //Classe qui permet de jouer une partie
{
    Partie Partie { get; set; }
    Affichage Afficher { get; }

    public GestionJeu(Partie partie) //Joue avec une partie déjà crée 
    {
        Partie = partie;
        Afficher = new Affichage();
    }
    public GestionJeu(string nom) //créer une partie avec le nom en paramètre
    {
        Partie = new Partie(nom);
        Afficher = new Affichage();
        Tutoriel(); //Lance le tutoriel car c'est une nouvelle partie
    }


    public void Tutoriel() //Affiche le tutoriel et permet de passer avec Entrée
    {
        Afficher.Tutoriel(Partie.Nom);
        bool enCours = true;
        while (enCours)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Enter:
                    enCours = false;
                    break;
                default:
                    break;
            }
        }
    }

    public void Jouer() //récupère une donnée de accueil et fait une action en réponse 
    {
        bool enCours = true;
        while (enCours)
        {
            switch (Accueil(Partie))
            {
                case 1: //Semaine suivante
                    SimulationSemaine();
                    break;
                case 2: //Sauvegarde et semaine suivante
                    Sauvegarde sauvegarde = new Sauvegarde(Partie);
                    sauvegarde.Sauvegarder();
                    SimulationSemaine();
                    break;
                case 3: //Sauvegarde et quitte
                    Sauvegarde sauvegarde2 = new Sauvegarde(Partie);
                    sauvegarde2.Sauvegarder();
                    enCours = false;
                    break;
                case 4: //Quitte sans sauvegarder
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

    public int Accueil(Partie partie) //Accueil du jeu qui permet d'accéder aux différentes parties du jeu et de passer à la semaine suivante de sauvegarder ou quitter
    {
        bool semaineEnCours = true;

        while (semaineEnCours)
        {
            Console.Clear();
            Afficher.Accueil();

            Console.ForegroundColor = ConsoleColor.Green; //Recap des infos
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
                case ConsoleKey.Spacebar:
                    return 2;
                case ConsoleKey.Q:
                    return 4;
                case ConsoleKey.B:
                    BulletinMeteo();
                    break;
                case ConsoleKey.D1:
                    VisualiserTerrain(Partie.ListeTerrains[0]);
                    break;
                case ConsoleKey.D2:
                    VisualiserTerrain(Partie.ListeTerrains[1]);
                    break;
                case ConsoleKey.D3:
                    VisualiserTerrain(Partie.ListeTerrains[2]);
                    break;
                case ConsoleKey.D4:
                    VisualiserTerrain(Partie.ListeTerrains[3]);
                    break;
                case ConsoleKey.D5:
                    VisualiserTerrain(Partie.ListeTerrains[4]);
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

    public void VisualiserTerrain(Terrain terrain) //Affiche le potager d'un terrain et permet d'effectuer des actions
    {
        bool enCours = true;
        while (enCours)
        {
            Console.Clear();

            double prixAgrandir = Afficher.Potager(terrain.Potager, terrain.Nom,terrain.Emoji);
            Console.WriteLine($"\n💰 Verdamoula actuelle : {Partie.VerdaMoula}\n");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Pour planter un Semis🌱 tapez P,\nPour utiliser un Item 🛠️  tapez I,\nPour Récolter les plantes🌳 tapez R,");
            Console.WriteLine($"Pour obtenir la Documentation📄 du terrain tapez D,\nPour Agrandir le terrain ({prixAgrandir} 💰) tapez A,\nPour Quitter❌​ tapez Q");
            Console.ForegroundColor = ConsoleColor.White;


            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Q:
                    enCours = false;
                    break;
                case ConsoleKey.A: //Agrandit d'une colonne en rempl^ant les friches par des soles vierges
                    if (Partie.VerdaMoula >= prixAgrandir)
                    {
                        terrain.AgrandirPotager();
                        Partie.VerdaMoula -= prixAgrandir;
                    }
                    break;
                case ConsoleKey.R: //recolte les plantes mûres
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
    public void UtiliserItem(Terrain terrain) //permet d'utiliser un item sur un terrain
    {
        bool enCours = true;
        while (enCours)
        {
            Console.Clear();
            Afficher.Potager(terrain.Potager, terrain.Nom,terrain.Emoji);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n🛠️ Vos Items disponibles :");
            Console.ResetColor();

            for (int i = 3; i < Partie.ListeItems.Length; i++) //Affiche seulement les items utiles pour les terrains
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
                Console.Write($"{Partie.ListeInfoItems[i].Affichage}-{Partie.ListeInfoItems[i].Nom,-20} : {Partie.ListeItems[i]}        ");

                if ((i + 1) % 3 == 0)
                    Console.WriteLine();
            }
            Console.ResetColor();
            Console.WriteLine($"\n\nTapez l'initial d'item pour l'utiliser🛠️ \nTapez Q pour Quitter❌​​");
            Console.WriteLine("");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Q:
                    enCours = false;
                    break;
                case ConsoleKey.B: //Bêche qui laboure une case
                    if (Partie.ListeItems[8] >= 1)
                    {
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            terrain.Labourer(demandeCase[0], demandeCase[1]);
                            Partie.ListeItems[8]--;
                        }
                    }
                    break;
                case ConsoleKey.U: //Super bêche qui laboure le terrain
                    for (int i = 0; i < terrain.Potager.GetLength(0); i++)
                    {
                        for (int j = 0; j < terrain.Potager.GetLength(1); j++)
                        {
                            terrain.Labourer(i, j);
                        }
                    }
                    Partie.ListeItems[9]--;
                    break;
                case ConsoleKey.S: //Sécateur qui taille la plante (peut être réutilisé)
                    if (Partie.ListeItems[7] >= 1)
                    {
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            if (terrain.Potager[demandeCase[0], demandeCase[1]] is PlanteTailler p)
                            {
                                p.Tailler();
                            }
                        }
                    }
                    break;
                case ConsoleKey.E: //Engrais qui avance la croissance d'une semaine
                    if (Partie.ListeItems[6] >= 1)
                    {
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            if (terrain.Potager[demandeCase[0], demandeCase[1]] is PlanteSimple p)
                            {
                                p.Croissance--;
                                if (p.Croissance <= 0)
                                {
                                    p.Affichage = char.ToUpper(p.Affichage);
                                }
                            }
                            Partie.ListeItems[6]--;
                        }
                    }
                    break;
                case ConsoleKey.P: //Potion qui donne un effet aléatoire entre grandir, rapettir, rien et mourir
                    if (Partie.ListeItems[5] >= 1)
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
                            Partie.ListeItems[5]--;
                        }
                    }
                    break;
                case ConsoleKey.C: //Casque qui protège la plante des conditions pour un tour
                    if (Partie.ListeItems[4] >= 1)
                    {
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            if (terrain.Potager[demandeCase[0], demandeCase[1]] is PlanteSimple p)
                            {
                                p.Immunite = 1;
                            }
                            Partie.ListeItems[4]--;
                        }
                    }
                    break;
                case ConsoleKey.M: //MegaItem qui protège la plante des conditions à vie
                    if (Partie.ListeItems[3] >= 1)
                    {
                        int[] demandeCase = Afficher.DemandeCasePotage();
                        if (demandeCase[0] != 99)
                        {
                            if (terrain.Potager[demandeCase[0], demandeCase[1]] is PlanteSimple p)
                            {
                                p.Immunite = -1;
                            }
                            Partie.ListeItems[3]--;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }

    public void Planter(Terrain terrain) // permet de planter une plante sur un terrain
    {
        bool enCours = true;
        while (enCours)
        {
            Console.Clear();
            Afficher.Potager(terrain.Potager, terrain.Nom,terrain.Emoji);

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

            List<char> touches = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'M', 'N', 'P', 'K', 'Z' };
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
                    int index = touches.IndexOf(char.ToUpper(touche.KeyChar)); //Récupère l'index de la lettre pour utilser les informations adéquates
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

    public void Magasin() //menu du magasin
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
                case ConsoleKey.W: //Affiche la documentation des plantes
                    Wiki();
                    break;
                case ConsoleKey.G: //Affiche la documentation des items
                    Garage();
                    break;
                default:
                    break;
            }
        }
    }

    public void Wiki() //Affiche la documentation des plantes
    {
        bool enCours = true;
        ConsoleColor fondInitial = Console.BackgroundColor;
        ConsoleColor couleurInitiale = Console.ForegroundColor;
        int afficheInfo = -1;

        while (enCours)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                               ✦✦   WikiVerdadura Plantes 🌳    ✦✦                             ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║ 🌳 Plantes connues :                                                                          ║");
            Console.WriteLine("╠═══════════════════════════════════════════════════════════════════════════════════════════════╣");

            List<char> touches = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'M', 'N', 'P', 'K', 'Z' };

            for (int i = 0; i < 15; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($" {touches[i]} ");
                Console.ResetColor();
                Console.Write($"- {Partie.ListeInfoPlantes[i].Nom,-13}  ");
                Console.WriteLine();
            }

            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════════╝\n");

            Console.WriteLine("🏪 Vous pouvez acquérir les Semis de ces Plante au Magasin enchanté...");
            Console.ResetColor();

            Console.WriteLine("🌦️ À vous de percer le secret des saisons et de choisir les Terrains où elles s’épanouiront, sans quoi elles faneront, hélas... 💀");
            Console.WriteLine("🛠️ N’ayez crainte d’user des Items mystiques pour stimuler leur croissance... ou pour faire face aux sombres périls qui rôdent parfois... ⚔️");

            Console.WriteLine("🌳 Lorsque votre Plante atteindra sa pleine maturité, elle rayonnera en lettres MAJUSCULES... ✨ Récoltez-la alors sans tarder !");
            Console.WriteLine("💰 On murmure que ces merveilles se revendent à prix d’or au Magasin... une manne précieuse pour tout Jardinier avisé !\n");


            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Tapez la touche de la Plante 🌳 dont vous souhaitez avoir les informations (A-Z). Tapez Q pour Quitter le WikiVerdadura❌\n");
            Console.ResetColor();

            if (afficheInfo >= 0)
            {

                Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════════");
                Console.WriteLine($"🌳   PLANTE : {Partie.ListeInfoPlantes[afficheInfo].Nom}   ");
                Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════════");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.ResetColor();

                Console.WriteLine($"  📜 Type        : {Partie.ListeInfoPlantes[afficheInfo].Type}");
                Console.WriteLine($"  🌍 Terrain     : {Partie.ListeInfoPlantes[afficheInfo].TerrainFavori}");
                Console.WriteLine($"  💰 Achat/Vente : {Partie.ListeInfoPlantes[afficheInfo].PrixAchat} / {Partie.ListeInfoPlantes[afficheInfo].PrixVente}");
                Console.WriteLine($"  🌡️  Température : entre {Partie.ListeInfoPlantes[afficheInfo].Temperature[0]}-{Partie.ListeInfoPlantes[afficheInfo].Temperature[1]}°C");
                Console.WriteLine($"  ☀️  Ensoleillement : entre {Partie.ListeInfoPlantes[afficheInfo].Ensoleillement[0]}-{Partie.ListeInfoPlantes[afficheInfo].Ensoleillement[1]}H");
                Console.WriteLine($"  🌧️  Pluie       : entre {Partie.ListeInfoPlantes[afficheInfo].Pluie[0]}-{Partie.ListeInfoPlantes[afficheInfo].Pluie[1]}mm");
                Console.WriteLine($"  💧 Humidité    : entre {Partie.ListeInfoPlantes[afficheInfo].Humidite[0]}-{Partie.ListeInfoPlantes[afficheInfo].Humidite[1]}%");
                Console.WriteLine($"  ⏳ Temps Croissance   : {Partie.ListeInfoPlantes[afficheInfo].Croissance}");
                Console.Write($"  🛠️  Capacité     : {Partie.ListeInfoPlantes[afficheInfo].GetType()}");
                if (Partie.ListeInfoPlantes[afficheInfo] is PlanteFilante)
                {
                    Console.WriteLine(" (Plante ayant la capcité de se propoger sur une case adjacente une fois dans sa vie aléatoirement)");
                }
                else if (Partie.ListeInfoPlantes[afficheInfo] is PlanteTailler)
                {
                    Console.WriteLine(" (Plante qui s'affiche en vert lorsqu'elle doit être taillée, nécessite un Sécateur pour la tailler)");
                }
                else
                {
                    Console.WriteLine("");
                }
                Console.WriteLine("──────────────────────────────────────────────────────────────────────────────\n");
            }

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
                    if (index >= 0)
                    {
                        afficheInfo = index; //Change la plante affichée 
                    }
                    break;
                default:
                    break;
            }
            Console.BackgroundColor = fondInitial;
            Console.ForegroundColor = couleurInitiale;
        }
    }

    public void Garage() //Affiche la documentation des items (même principe que Wiki)
    {
        bool enCours = true;
        ConsoleColor fondInitial = Console.BackgroundColor;
        ConsoleColor couleurInitiale = Console.ForegroundColor;
        int afficheInfo = -1;

        while (enCours)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                               ✦✦  Garage & Conseils en Items 🛠️    ✦✦                          ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║ 🛠️  Items connues :                                                                            ║");
            Console.WriteLine("╠═══════════════════════════════════════════════════════════════════════════════════════════════╣");

            List<char> touches = new List<char> { 'R', 'T', 'I', 'M', 'C', 'P', 'E', 'S', 'B', 'U' };

            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($" {touches[i]} ");
                Console.ResetColor();
                Console.Write($"- {Partie.ListeInfoItems[i].Nom,-13}  ");
                Console.WriteLine();
            }

            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════════╝\n");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Tapez la touche de l'Item 🛠️ dont vous souhaitez avoir les informations (A-Z). Tapez Q pour Quitter le garage❌\n");
            Console.ResetColor();

            if (afficheInfo >= 0)
            {

                Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════════");
                Console.WriteLine($"🛠️   Item : {Partie.ListeInfoItems[afficheInfo].Nom}   ");
                Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════════");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.ResetColor();


                Console.WriteLine($"  💰 Prix : {Partie.ListeInfoItems[afficheInfo].PrixAchat} ");
                Console.WriteLine($"  🧾​  Description :  {Partie.ListeInfoItems[afficheInfo].Description}");
                Console.WriteLine("──────────────────────────────────────────────────────────────────────────────\n");
            }

            ConsoleKeyInfo touche = Console.ReadKey(true);
            switch (touche.Key)
            {
                case ConsoleKey.Q:
                    enCours = false;
                    break;
                case ConsoleKey.R:
                case ConsoleKey.T:
                case ConsoleKey.I:
                case ConsoleKey.M:
                case ConsoleKey.C:
                case ConsoleKey.P:
                case ConsoleKey.E:
                case ConsoleKey.S:
                case ConsoleKey.B:
                case ConsoleKey.U:
                    int index = touches.IndexOf(char.ToUpper(touche.KeyChar));
                    if (index >= 0)
                    {
                        afficheInfo = index;
                    }
                    break;
                default:
                    break;
            }
            Console.BackgroundColor = fondInitial;
            Console.ForegroundColor = couleurInitiale;
        }
    }

    public void MagasinSemis() //Pemret d'acheter des semis
    {
        bool enCours = true;
        ConsoleColor fondInitial = Console.BackgroundColor;
        ConsoleColor couleurInitiale = Console.ForegroundColor;

        while (enCours)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                               ✦✦ ACHETEZ DES SEMIS DE QUALITÉ 🌱✦✦                            ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n💰 Verdamoula : {Partie.VerdaMoula}\n");
            Console.ResetColor();

            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║ 🌱 Semis disponibles :                                                                        ║");
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
            Console.WriteLine("Tapez la touche du Semis 🌱 que vous souhaitez achetez (A-Z). Tapez Q pour Quitter le magasin❌\n");
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

    public void MagasinPlantes() //Pemret d'acheter des plantes
    {
        bool enCours = true;
        ConsoleColor fondInitial = Console.BackgroundColor;
        ConsoleColor couleurInitiale = Console.ForegroundColor;

        while (enCours)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                           ✦✦ VENDEZ VOS PLANTES AU MEILLEUR PRIX 🌳✦✦                         ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n💰 Verdamoula actuelle : {Partie.VerdaMoula}\n");
            Console.ResetColor();

            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║ 🌳 Vos Plantes :                                                                              ║");
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
            Console.WriteLine("Tapez la touche de la Plante 🌳 que vous souhaitez vendre (A-Z). Tapez Q pour quitter le magasin❌\n");
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

    public void MagasinItems() //Pemret d'acheter des items
    {
        bool enCours = true;
        ConsoleColor fondInitial = Console.BackgroundColor;
        ConsoleColor couleurInitiale = Console.ForegroundColor;

        while (enCours)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                               ✦✦ ACHETEZ DES ITEMS DE QUALITÉ 🛠️ ✦✦                            ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n💰 Verdamoula : {Partie.VerdaMoula}\n");
            Console.ResetColor();

            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║ 🛠️  Items disponibles :                                                                       ║");
            Console.WriteLine("╠═══════════════════════════════════════════════════════════════════════════════════════════════╣");

            List<char> touches = new List<char> { 'R', 'T', 'I', 'M', 'C', 'P', 'E', 'S', 'B', 'U' };
            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($" {touches[i]} ");
                Console.ResetColor();
                Console.Write($"- {Partie.ListeInfoItems[i].Nom,-19} : ");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{Partie.ListeItems[i],-3} unités");
                Console.ResetColor();

                Console.Write("  → ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{Partie.ListeInfoItems[i].PrixAchat,-5} Verdamoula");
                Console.ResetColor();
                Console.WriteLine();
            }

            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════════╝\n");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Tapez la touche de l'Item 🛠️ que vous souhaitez achetez (A-Z). Tapez Q pour quitter le magasin❌\n");
            Console.ResetColor();

            ConsoleKeyInfo touche = Console.ReadKey(true);
            switch (touche.Key)
            {
                case ConsoleKey.Q:
                    enCours = false;
                    break;
                case ConsoleKey.R:
                case ConsoleKey.T:
                case ConsoleKey.I:
                case ConsoleKey.M:
                case ConsoleKey.C:
                case ConsoleKey.P:
                case ConsoleKey.E:
                case ConsoleKey.S:
                case ConsoleKey.B:
                case ConsoleKey.U:
                    int index = touches.IndexOf(char.ToUpper(touche.KeyChar));
                    if (index >= 0 && Partie.VerdaMoula >= Partie.ListeInfoItems[index].PrixAchat)
                    {
                        Partie.VerdaMoula -= Partie.ListeInfoItems[index].PrixAchat;
                        Partie.ListeItems[index]++;
                    }
                    break;
                default:
                    break;
            }

            Console.BackgroundColor = fondInitial;
            Console.ForegroundColor = couleurInitiale;
        }
    }


    public void SimulationSemaine()
    {
        Partie.chenille = false;

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Gray;
        Afficher.TexteEnProgressif("Simulation de la semaine ...  ", 80);
        Console.ForegroundColor = ConsoleColor.White;
        Thread.Sleep(800);

        Partie.Semaine++; //rajoute une semaine
        Random random = new Random();
        int urgences = random.Next(1, 31); //Génère une probabilté d'une urgence Bonus/Malus
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
            case 13:
                FeeDesPlantes();
                break;
            case 14:
            case 15:
                AverseOR();
                break;
            default:
                break;
        }
        for (int k = 0; k < Partie.ListeTerrains.Length; k++) //Lance VerificationTerrain dans chaque terrain pour faire simuler la croissance des plantes
        {
            int saison = Partie.Semaine / 13 % 4;
            Partie.ListeTerrains[k].VerifierTerrain(Partie.ListeTerrains[k], saison);
        }
    }
    public void AverseOR() //Urgence de l'averse d'or qui fait gagner de l'argent
    {
        Random random = new Random();
        int montant = random.Next(0, 10);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Afficher.Pluie();
        Afficher.TexteEnProgressif("Le ciel est menacant mais les nuages 💨​ sont d'une couleur jaune dorée.\nC'est une averse OR(ageuse) qui touche votre monde. Vous allez donc aléatoirement reçevoir de la verdamoula💰🤑​  \n", 50);
        switch (montant)
        {
            case 0:
                Partie.VerdaMoula += 1;
                Afficher.TexteEnProgressif("Vous avez gagné 1 VerdaMoula 💰🤑​💰  ", 50);
                break;
            case 1:
                Partie.VerdaMoula += 25;
                Afficher.TexteEnProgressif("Vous avez gagné 25 VerdaMoula 💰🤑​💰  ", 50);
                break;
            case 2:
                Partie.VerdaMoula += 100;
                Afficher.TexteEnProgressif("Vous avez gagné 100 VerdaMoula 💰🤑​💰  ", 50);
                break;
            case 3:
                Partie.VerdaMoula += 200;
                Afficher.TexteEnProgressif("Vous avez gagné 200 VerdaMoula 💰🤑​💰  ", 50);
                break;
            case 4:
                Partie.VerdaMoula += 500;
                Afficher.TexteEnProgressif("Vous avez gagné 500 VerdaMoula 💰🤑​💰  ", 50);
                break;
            case 5:
                Partie.VerdaMoula += 100;
                Afficher.TexteEnProgressif("Vous avez gagné 100 VerdaMoula 💰🤑​💰  ", 50);
                break;
            case 6:
                Partie.VerdaMoula += 200;
                Afficher.TexteEnProgressif("Vous avez gagné 200 VerdaMoula 💰🤑​💰  ", 50);
                break;
            case 7:
                Partie.VerdaMoula += 500;
                Afficher.TexteEnProgressif("Vous avez gagné 500 VerdaMoula 💰🤑​💰  ", 50);
                break;
            case 8:
                Partie.VerdaMoula += 1500;
                Afficher.TexteEnProgressif("Vous avez gagné 1500 VerdaMoula 💰🤑​💰  ", 50);
                break;
            case 9:
                Partie.VerdaMoula += 5000;
                Afficher.TexteEnProgressif("Vous avez gagné 5000 VerdaMoula 💰🤑​💰  ", 50);
                break;
        }
        Console.ForegroundColor = ConsoleColor.White;
    }
    public void FeeDesPlantes() //Urgence de la fee des plantes qui accélere la croissance des plantes d'un terrain
    {
        Random random = new Random();
        int terrain = random.Next(0, 5);
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Afficher.Fee();
        Console.WriteLine($"YOUPI, une Fée des plantes apparaît sur votre terrain {Partie.ListeTerrains[terrain].Nom}{Partie.ListeTerrains[terrain].Emoji}.\nChaque plante qui pousse actuellement sur ce terrain a une probablité de voir sa croissance se terminer immédiatement.");
        bool enCours = true;
        while (enCours)
        {
            Afficher.TexteEnProgressif("La Fée des plantes parcourt votre terrain         ", 30);
            for (int i = 0; i < Partie.ListeTerrains[terrain].Potager.GetLength(0); i++)
            {
                for (int j = 0; j < Partie.ListeTerrains[terrain].Potager.GetLength(1); j++)
                {
                    if (Partie.ListeTerrains[terrain].Potager[i, j] is PlanteSimple plante)
                    {
                        int croissanceInstantane = random.Next(0, 3);
                        if (croissanceInstantane == 1)
                        {
                            plante.Croissance = 0;
                        }

                    }
                }
            }
            enCours = false;
        }
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void Rat() //Urgence du rat qui détruit toute les plante sauf utilisation du raticide
    {
        Random random = new Random();
        int terrain = random.Next(0, 5);

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Clear();
        Afficher.Rat();
        Console.WriteLine($"Oh non un Rat mécréant 🐀​ sur votre terrain {Partie.ListeTerrains[terrain].Nom}{Partie.ListeTerrains[terrain].Emoji} mettez un raticide sinon il va dévorer toutes les plantes du terrain");
        Console.WriteLine("Pour utiliser le raticide tapez O sinon tapez N ");
        bool enCours = true;
        while (enCours)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.O:
                    if (Partie.ListeItems[0] >= 1)
                    {
                        Partie.ListeItems[0]--;
                        Afficher.TexteEnProgressif("Le Rat mécréant🐀​  part la queue entre les jambes grâce au raticide    ", 30);
                    }
                    else
                    {
                        Afficher.TexteEnProgressif("Et non vous n'avez pas de raticide quelle dommage...  🐀​     ", 30);
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
                    Afficher.TexteEnProgressif("Le rat 🐀​ dévore les plantes oh nooooooo....          ", 30);
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
        Console.ForegroundColor = ConsoleColor.White;
    }
    public void Galinace() //Urgence du galinace qui détruit toute les plante commestible sauf utilisation du tir de fusil
    {
        Random random = new Random();
        int terrain = random.Next(0, 5);

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Clear();
        Afficher.Poule();
        Console.WriteLine($"Oh non un Gallinacé Hargneux 🐔​ est arrivé sur votre terrain {Partie.ListeTerrains[terrain].Nom}{Partie.ListeTerrains[terrain].Emoji} utilisez un tir de fusil sinon il va dévorer toutes les plantes comestibles du terrain");
        Console.WriteLine("Pour utiliser le tir de fusil tapez O sinon tapez N ");
        bool enCours = true;
        while (enCours)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.O:
                    if (Partie.ListeItems[1] >= 1)
                    {
                        Partie.ListeItems[1]--;
                        Afficher.TexteEnProgressif("Le Gallinacé Hargneux 🐔​ part les plumes entre les jambes grâce au tir de fusil    ", 30);
                    }
                    else
                    {
                        Afficher.TexteEnProgressif("Et non! vous n'avez pas de tir de fusil quel dommage ...  🐔​      ", 30);
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
                    Afficher.TexteEnProgressif("Le Gallinacé Hargneux 🐔​ détruit toutes les plantes comestibles oh noooooo         ", 30);
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
        Console.ForegroundColor = ConsoleColor.White;
    }
    public void Chenille() //Urgence de la chenille qui fait disparaitre le bulletin méteo sauf utilisation de l'insecticide
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Clear();
        Afficher.Chenille();
        Console.WriteLine($"Oh non une Cheeeeeniiiiiiillllle 🐛 est apparue, utilisez un insecticide à chenille sinon il va dévorer le bulletin météo de la semaine prochaine");
        Console.Write("Pour utiliser un insecticide à Chenille tapez O sinon tapez N ");
        bool enCours = true;
        while (enCours)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.O:
                    if (Partie.ListeItems[2] >= 1)
                    {
                        Partie.ListeItems[2]--;
                        Afficher.TexteEnProgressif("Vous avez éliminé la cheeeeeniiiiillle 🐛", 30);
                    }
                    else
                    {
                        Afficher.TexteEnProgressif("Et non! vous n'avez pas d'insecticide, vous pouvez tirer une croix sur votre bulletin météo ...   🐛     ", 30);
                        Partie.chenille = true;
                    }
                    enCours = false;
                    break;
                case ConsoleKey.N:
                    Afficher.TexteEnProgressif("La chenille 🐛 n'est pas éliminée, vous pouvez alors tirer une croix sur votre bulletin météo de la semaine          ", 30);
                    Partie.chenille = true;
                    enCours = false;
                    break;
            }
        }
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void BulletinMeteo() //Affiche le bulletin météo
    {
        bool enCours = true;
        Console.Clear();
        if (Partie.chenille)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Afficher.Chenille();
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                     ✦✦ BULLETIN METEO ⛅✦✦                                    ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════════╗");
            for (int i = 0; i < Partie.ListeTerrains.Length; i++)
            {
                Console.WriteLine($"║             📍 Terrain : {Partie.ListeTerrains[i].Emoji}{Partie.ListeTerrains[i].Nom,-30}                                     ║");
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
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Q:
                    enCours = false;
                    break;
            }
        }
    }
}
