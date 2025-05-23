using System.Formats.Asn1;
using System.Reflection.Metadata;
using System.Xml;
//Classe Affichage permet de stocker les codes d'affichage longs afin de garder un code lisible.
//Cette classe est composé uniquement de méthode avec simplement le nom de ce qu'elles affichent
public class Affichage
{
    public double Potager(Plante[,] potager, string nom,string emoji)   //Affiche le Potager d'un terrain et renvoie le prix de l'agrandissement en fonction de son nom
    {
        double prixAgrandir = 0;
        char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };

        ConsoleColor couleur = Console.ForegroundColor;
        
        switch (nom) //Change le prix en fonction du nom du terrain
        {
            case "Marecages Malins":
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                prixAgrandir = 2000;
                break;
            case "Desert Delicat":
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                prixAgrandir = 1000;
                break;
            case "Foret Facetieuse":
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                prixAgrandir = 200;
                break;
            case "Volcan Violent":
                Console.ForegroundColor = ConsoleColor.DarkRed;
                prixAgrandir = 50;
                break;
            case "Plaines Paisibles":
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                prixAgrandir = 10;
                break;
            default:
                break;
        }


        Console.Write("  "); //espace pour aligner les chiffres
        for (int j = 0; j < potager.GetLength(1); j++) //création de la ligne de nombres du haut 
        {
            if (j < 9)
            {
                Console.Write($"  {j + 1} ");
            }
            else
            {
                if (j == 9)
                {
                    Console.Write(" "); //adaptation de la taille pour les nombres à 2 chiffres
                }
                Console.Write($"{j + 1}  ");
            }
        }
        Console.WriteLine();

        Console.Write("  ");
        for (int j = 0; j < potager.GetLength(1); j++) //création de la délimitation de la première ligne  
        {
            Console.Write("+---");
        }
        Console.Write("+");
        Console.WriteLine();

        for (int i = 0; i < potager.GetLength(0); i++) //Boucle servant à afficher et remplir les cases du plateau 
        {
            Console.Write(alphabet[i] + " "); //afficher les lettres sur le coté gauche du plateau

            for (int j = 0; j < potager.GetLength(1); j++)
            {
                Plante(potager[i, j]); // Appel de la fonction Plante qui affiche la Plante correctement en fonction de ses paramètres
            }
            Console.Write("|");
            Console.WriteLine();

            Console.Write("  ");
            for (int j = 0; j < potager.GetLength(1); j++) //création de la délimitation du bas de la ligne
            {
                Console.Write("+---");
            }
            Console.Write("+");
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine("--- " + nom.ToUpper() + emoji+ " ---");
        Console.WriteLine();

        Console.ForegroundColor = couleur;

        return prixAgrandir;
    }

    public void Plante(Plante plante) //Affiche la plante en fonction de sa classe et de ses paramètres spéciaux si besoin
    {
        ConsoleColor couleur = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.White;

        if (plante is PlanteSimple pl)
        {
            if (pl.Immunite == 1) //Affiche le fond en Bleu si la Plante est protégée pour 1 tour
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
            }
            else if (pl.Immunite < 0) //Affiche le fond en Jaune si la Plante est protégée indéfiniment
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
            }

        }


        if (plante is SolSimple)
        {
            Console.Write($"| {plante.Affichage} ");
        }
        else if (plante is PlanteTailler p)
        {
            if (p.Taillage == false) //Affiche la lettre en Vert si elle doit être taillé
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            Console.Write($"| {plante.Affichage} ");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.Write($"| {plante.Affichage} ");
            Console.ForegroundColor = ConsoleColor.White;
        }
        Console.ForegroundColor = couleur;
        Console.BackgroundColor = ConsoleColor.Black;
    }
    
    public void TexteEnProgressif(string texte, int pause) //Affiche du texte lettre par lettre pour un effet visuel agréable, la pause est le temps entre chaque lettre
    {
        for (int i = 0; i < texte.Length; i++)
        {
            Console.Write(texte[i]);
            Thread.Sleep(pause);
        }
        Console.WriteLine("");
    }

    public void Magasin() //Affiche le design et les instruction de l'accueil du magasin
    {
        Console.ForegroundColor = ConsoleColor.Magenta;

        Console.WriteLine("⠀ ⠀   ⠀⠀⠀⠀⠀⢀⣀⣀⣀⣀⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ ⠀");
        Console.WriteLine("  ⢀⣀⣀⣀⣀⣀⣀⣠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣄⣀⣀⣀⣀⣀⣀⡀⠀⠀");
        Console.WriteLine("⠀⠀⢠⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⡄⠀⠀");
        Console.WriteLine("⠀⠀⣿⣿⣿⣿⣿⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⢹⣿⣿⣿⣿⡟⣿⣿⣿⣿⣿⠀⠀");
        Console.WriteLine("⠀⠀⣿⣿⣿⣿⡟⢸⣿⣿⣿⣿⢹⣿⣿⣿⣿⡘⣿⣿⣿⣿⡇⢻⣿⣿⣿⣿⠀⠀   ███╗   ███╗ █████╗  ██████╗  █████╗ ███████╗██╗███╗   ██╗");
        Console.WriteLine("⠀⢀⣛⣛⣛⣛⠃⣛⣛⣛⣛⡋⠈⣛⣛⣛⣛⠁⢛⣛⣛⣛⣛⠘⣛⣛⣛⣛⡀⠀   ████╗ ████║██╔══██╗██╔════╝ ██╔══██╗██╔════╝██║████╗  ██║");
        Console.WriteLine("⠀⠈⠻⠿⠿⠋⣀⠈⠻⠿⠟⢁⡀⠙⠿⠿⠋⢀⡈⠻⠿⠟⠁⣀⠙⠿⠿⠟⠁⠀   ██╔████╔██║███████║██║  ███╗███████║███████╗██║██╔██╗ ██║");
        Console.WriteLine("⠀⢸⣷⣦⣶⣿⣿⣿⣶⣤⣶⣿⣿⣷⣦⣴⣾⣿⣿⣶⣤⣶⣿⣿⣿⣶⣴⣾⡇⠀   ██║╚██╔╝██║██╔══██║██║   ██║██╔══██║╚════██║██║██║╚██╗██║");
        Console.WriteLine("⠀⢸⣿⡏⣉⣉⣉⣉⣉⣉⣉⣉⣉⣉⣉⣉⣉⡉⢹⣿⠉⣉⣉⣉⣉⣉⢹⣿⡇⠀   ██║ ╚═╝ ██║██║  ██║╚██████╔╝██║  ██║███████║██║██║ ╚████║");
        Console.WriteLine("⠀⢸⣿⡇⣿⠉⢉⣩⣭⣽⣿⣿⣿⣿⣿⣿⣿⡇⢸⣿⠀⣿⣿⣿⣿⣿⢸⣿⡇⠀   ╚═╝     ╚═╝╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝╚═╝╚═╝  ╚═══╝");
        Console.WriteLine("⠀⢸⣿⡇⣿⢀⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⢸⣿⠀⠿⠿⠿⠿⠿⢸⣿⡇⠀");
        Console.WriteLine("⠀⢸⣿⡇⣿⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⢸⣿⠀⠶⠶⠶⠶⠶⢸⣿⡇⠀");
        Console.WriteLine("⠀⢸⣿⡇⣿⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⢸⣿⠀⠶⠶⠶⠶⠶⢸⣿⡇⠀");
        Console.WriteLine("⠀⢸⣿⡇⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠇⢸⣿⠀⣶⣶⣶⣶⣶⢸⣿⡇⠀");
        Console.WriteLine("⠀⢸⣿⣷⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣾⣿⠀⣿⣿⣿⣿⣿⢸⣿⡇⠀");
        Console.WriteLine("⠀⠈⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠀⠉⠉⠉⠉⠉⠈⠉⠁⠀");


        Console.WriteLine("\n\nBienvenue dans le magasin 🏪​! \nTapez 1 pour acheter des Semis 🌱\nTapez 2 pour vendre vos Plantes🌳\nTapez 3 pour acheter un item 🛠️\nTapez W pour consulter le WikiVerdadura des Plantes un item 🧾\nTapez G pour demander des renseignement sur les items au Garage 🧰​");
        Console.WriteLine("Tapez Q pour Quitter❌");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public int[] DemandeCasePotage() //Programme permettant de demander avec robustesse la case du Potager sur laquelle le joueur souhaite agir
    {
        Console.Write("Rentrez la case ou vous souhaitez agir : ");
        string casePlante = Console.ReadLine()!;


        int[][] coordonnees = new int[20 * 10][]; //Création d'une liste imbriquée de toutes les postions possibles classées dans l'ordre
        int p = 0;

        // Remplir le tableau coordonnees avec les positions de la matrice
        for (int i = 0; i < 10; i++)  // Colonnes (10 lettres)
        {
            for (int j = 0; j < 20; j++)  // Lignes (20 numéros)
            {
                coordonnees[p] = [i, j];
                p++;
            }
        }
        string[] casesLettres = new string[]
        {
            "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "A9", "A10", "A11", "A12", "A13", "A14", "A15",
            "A16", "A17", "A18", "A19", "A20",
            "B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8", "B9", "B10", "B11", "B12", "B13", "B14", "B15",
            "B16", "B17", "B18", "B19", "B20",
            "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "C10", "C11", "C12", "C13", "C14", "C15",
            "C16", "C17", "C18", "C19", "C20",
            "D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9", "D10", "D11", "D12", "D13", "D14", "D15",
            "D16", "D17", "D18", "D19", "D20",
            "E1", "E2", "E3", "E4", "E5", "E6", "E7", "E8", "E9", "E10", "E11", "E12", "E13", "E14", "E15",
            "E16", "E17", "E18", "E19", "E20",
            "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12", "F13", "F14", "F15",
            "F16", "F17", "F18", "F19", "F20",
            "G1", "G2", "G3", "G4", "G5", "G6", "G7", "G8", "G9", "G10", "G11", "G12", "G13", "G14", "G15",
            "G16", "G17", "G18", "G19", "G20",
            "H1", "H2", "H3", "H4", "H5", "H6", "H7", "H8", "H9", "H10", "H11", "H12", "H13", "H14", "H15",
            "H16", "H17", "H18", "H19", "H20",
            "I1", "I2", "I3", "I4", "I5", "I6", "I7", "I8", "I9", "I10", "I11", "I12", "I13", "I14", "I15",
            "I16", "I17", "I18", "I19", "I20",
            "J1", "J2", "J3", "J4", "J5", "J6", "J7", "J8", "J9", "J10", "J11", "J12", "J13", "J14", "J15",
            "J16", "J17", "J18", "J19", "J20",
        };
        for (int i = 0; i < casesLettres.Length; i++)
        {
            if (casePlante.ToUpper() == casesLettres[i])
            {
                return [coordonnees[i][0], coordonnees[i][1]];
            }
        }
        TexteEnProgressif("Case non valide!!!          ", 45);//Affiche l'erreur
        return [99, 99]; //Retourne 99 si la case n'est pas dans le Terrain
    }

    public void Program() //Affiche le design et les instruction de la page des menus du jeu quand on lance 
    {
        ConsoleColor couleurInitiale = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("                                                                                       ⠀⠀⠀⠈⠉⠛⢷⣦⡀⠀⣀⣠⣤⠤⠄⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("                                                                                       ⠀⠀⠀⠀⠀⠀⣀⣻⣿⣿⣿⣋⣀⡀⠀⠀⢀⣠⣤⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("                                                                                       ⠀⠀⠀⣠⠾⠛⠛⢻⣿⣿⣿⠟⠛⠛⠓⠢⠀⠀⠉⢿⣿⣆⣀⣠⣤⣀⣀⠀⠀⠀");
        Console.WriteLine("                                                                                       ⠀⠀⠘⠁⠀⠀⣰⡿⠛⠿⠿⣧⡀⠀⠀⢀⣤⣤⣤⣼⣿⣿⣿⡿⠟⠋⠉⠉⠀⠀");
        Console.WriteLine("         ██╗   ██╗███████╗██████╗ ██████╗  █████╗ ██████╗ ██╗   ██╗██████╗  █████╗     ⠀⠀⠀⠀⠀⠠⠋⠀⠀⠀⠀⠘⣷⡀⠀⠀⠀⠀⠹⣿⣿⣿⠟⠻⢶⣄⠀⠀⠀⠀");
        Console.WriteLine("         ██║   ██║██╔════╝██╔══██╗██╔══██╗██╔══██╗██╔══██╗██║   ██║██╔══██╗██╔══██╗    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣧⠀⠀⠀⠀⢠⡿⠁⠀⠀⠀⠀⠈⠀⠀⠀⠀");
        Console.WriteLine("         ██║   ██║█████╗  ██████╔╝██║  ██║███████║██║  ██║██║   ██║██████╔╝███████║    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡇⠀⠀⣾⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("         ╚██╗ ██╔╝██╔══╝  ██╔══██╗██║  ██║██╔══██║██║  ██║██║   ██║██╔══██╗██╔══██║    ⠀⣤⣤⣤⣤⣤⣤⡤⠄⠀⠀⣀⡀⢸⡇⢠⣤⣁⣀⠀⠀⠠⢤⣤⣤⣤⣤⣤⣤⠀");
        Console.WriteLine("          ╚████╔╝ ███████╗██║  ██║██████╔╝██║  ██║██████╔╝╚██████╔╝██║  ██║██║  ██║    ⠀⠀⠀⠀⠀⠀⣀⣤⣶⣾⣿⣿⣷⣤⣤⣾⣿⣿⣿⣿⣷⣶⣤⣀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("           ╚═══╝  ╚══════╝╚═╝  ╚═╝╚═════╝ ╚═╝  ╚═╝╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝    ⠀⠀⠀⣠⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⣄⠀⠀⠀");
        Console.WriteLine("                                                                                       ⠀⠀⠼⠿⣿⣿⠿⠛⠉⠉⠉⠙⠛⠿⣿⣿⠿⠛⠛⠛⠛⠿⢿⣿⣿⠿⠿⠇⠀⠀");
        Console.WriteLine("                                                                                       ⠀⢶⣤⣀⣀⣠⣴⠶⠛⠋⠙⠻⣦⣄⣀⣀⣠⣤⣴⠶⠶⣦⣄⣀⣀⣠⣤⣤⡶⠀");
        Console.WriteLine("                                                                                       ⠀⠀⠈⠉⠉⠉⠀⠀⠀⠀⠀⠀⠀⠉⠉⠉⠉⠀⠀⠀⠀⠀⠉⠉⠉⠉⠀⠀⠀⠀");
        Console.WriteLine("");
        Console.WriteLine("");


        Console.WriteLine("Bienvenue dans votre jeu 🏝️ Verdadura🏝️  votre simulateur de Potager fantastique✨​!!!");
        Console.WriteLine("");
        Console.ForegroundColor = couleurInitiale;
        Console.WriteLine("Pour créer une nouvelle partie tapez N 😁​");
        Console.WriteLine("Pour charger une partie sauvegardée tapez S ​💾​");
        Console.WriteLine("Pour quitter tapez Q ❌​​");
    }

    public void InfoTerrain(Terrain terrain) //Affiche les caractéristiques de chaque terrain
    {
        bool enCours = true;
        while (enCours)
        {
            string plantesFavorites = "";
            string descriptionTerrain = "";
            Console.Clear();
            switch (terrain.Nom)
            {
                case "Plaines Paisibles​":
                    plantesFavorites = "Erdomania & Brocélia & Humalis";
                    descriptionTerrain = "Les plaines paisibles sont l'endroit rêvé pour une petite balade en famille l'été.\n\nCaractéristiques particulières:Aucune\n";
                    break;
                case "Foret Facetieuse​":
                    plantesFavorites = "Placinet & Ivoina & Zolia";
                    descriptionTerrain = "La forêt facétieuse saura assouvir votre soif de sylvothérapie (On le dit quand on fait des calins aux arbres), mais aussi de champignons.\n\nCaractéristiques particulières:Aucune\n";
                    break;
                case "Volcan Violent​":
                    plantesFavorites = "Demonia & Gorhy & Fenecia";
                    descriptionTerrain = "Le volcan violent est le jardin d'eden de tous les aventuriers qui apprécient la chaleur et aiment jouer avec le feu.\n\nCaractéristiques particulières:Aucune\n";
                    break;
                case "Desert Delicat​":
                    plantesFavorites = "Cacruz & Jaunille & Arachneides";
                    descriptionTerrain = "Le désert délicat peut permettre de faire des courses de rally, mais c'est surtout l'occasion d'observer de magnifiques cactus assoifés, il est déconseillé d'y laisser des plantes ayant besoin d'eau.\n\nCaractéristiques particulières: Ce terrain est miné, à chaque semaine, certaines cases explosent aléatoirement (tuant les plantes s'il y en a) et vous devez bécher avant de pouvoir replanter.\n";
                    break;
                case "Marecages Malins​":
                    descriptionTerrain = "Les marécages malins risquent de vous donneer bien du file à retordre, entre les nenuphars et l'eau, faites attention à ne pas vous embourber.\n\nCaractéristiques particulières:Ce terrain nécessite de la jachère, ainsi, il est plus lent et vous obligera à vous armer de patience.\n";
                    plantesFavorites = "Mutina & Nenustar & Kuintefeuille";
                    break;
            }
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine($"║                                ✦✦ INFOS TERRAIN:{terrain.Emoji}{terrain.Nom,-18} ✦✦                       ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine($" Description du terrain : {descriptionTerrain}");
            Console.WriteLine($" Température 🌡️          : 🌼​ Éveil fleuri : {terrain.Temperature[0],-10}☀️ Éclat Profond : {terrain.Temperature[1],-10}🍂 Le Repli d’Or : {terrain.Temperature[2],-10}❄️ Repos Blanc : {terrain.Temperature[3],-5}°C");
            Console.WriteLine($" Humidité 💧            : 🌼​ Éveil fleuri : {terrain.Humidite[0],-10}☀️ Éclat Profond : {terrain.Humidite[1],-10}🍂 Le Repli d’Or : {terrain.Humidite[2],-10}❄️ Repos Blanc : {terrain.Humidite[3],-5}%");
            Console.WriteLine($" Ensoleillement ☀️       : 🌼​ Éveil fleuri : {terrain.Ensoleillement[0],-10}☀️ Éclat Profond : {terrain.Ensoleillement[1],-10}🍂 Le Repli d’Or : {terrain.Ensoleillement[2],-10}❄️ Repos Blanc : {terrain.Ensoleillement[3],-5}h/j");
            Console.WriteLine($" Pluie 🌧️                : 🌼​ Éveil fleuri : {terrain.Pluie[0],-10}☀️ Éclat Profond : {terrain.Pluie[1],-10}🍂 Le Repli d’Or : {terrain.Pluie[2],-10}❄️ Repos Blanc : {terrain.Pluie[3],-5}mm");
            Console.WriteLine($" Plantes favorites 🌳   : {plantesFavorites}                                               ");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine("Pour quitter tapez Q ❌");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Q:
                    enCours = false;
                    break;
            }
        }
    }

    public void Tutoriel(string nom) //Affiche les instruction de tutoriel
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢴⠒⢢⡀⢀⡤⢤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠷⣄⡓⡋⣀⣴⠗⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⣀⠀⠀⠀⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣠⣤⣀⣤⣴⠶⠶⠛⠛⠛⠻⢿⣥⣽⣷⣤⣼⢃⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣾⠋⠁⠀⣿⠀⠀⠁⠀⣤⡶⠶⢶⣄⠀⠀⠀⠈⢻⡏⠙⢷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣼⠿⠶⠶⠾⠋⠀⠀⠀⠘⢿⣤⣤⣤⠿⠃⠀⠀⠀⠈⠛⠷⠦⠿⢷⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡶⢿⡅⠀⣠⡴⠶⠛⠛⠳⠶⠶⠶⠶⠶⠶⠾⠟⠛⠛⠳⠶⣦⣄⠀⠀⢀⣿⠷⣦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢾⡅⣸⡿⣾⠏⢀⠀⠀⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠆⠀⠀⠀⠙⢿⣦⠸⣧⣠⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣟⡛⢹⡏⠀⠈⠑⢠⣶⠟⠳⣆⣀⣀⣀⣀⢀⣴⠾⠳⣦⡀⠐⠀⠀⠹⣧⠈⢹⣧⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣷⠃⠸⣷⡉⠀⢠⡿⠁⣶⠀⠙⣉⠉⣉⡉⠙⠃⣶⡆⢸⡇⠀⠀⠀⢀⡿⠰⣿⣽⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣆⡀⠙⢷⣤⡟⠀⠀⠉⠀⠀⠙⠛⠛⠁⠀⠀⠉⠀⠈⢻⡄⢀⣠⡾⠃⢀⣼⠟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⠷⣦⣬⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⣿⣭⣩⣤⣴⠿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣹⡷⣀⠀⠀⣀⡀⠀⠀⠀⠀⠀⠀⠀⢀⡜⣷⠀⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⢀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⣿⣄⠉⠛⠛⢩⡿⠀⠀⠀⣾⠛⠛⠛⠛⠁⣼⡿⢻⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⠤⢤⠸⠃⡼⠃⠀⠀⠀⠀\n⠀⠀⢰⣋⣙⠢⢂⣠⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⡇⠀⠻⣆⠛⠛⠋⠁⠀⠀⠀⠙⠻⠶⠾⠃⣼⠏⠀⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠦⣄⠄⠠⡄⠙⢒⡄⠀⠀\n⠀⠀⠀⠈⠉⠁⣷⠀⠀⠀⠀⠀⠀⠀⢀⠀⠀⠀⠀⠀⠸⡇⢶⡄⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠋⢰⡆⢸⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠯⠄⡔⠈⠉⠉⠀⠀⠀\n⠀⠀⠀⠀⠀⢰⡇⠀⠀⢾⣋⢉⠂⢘⣈⡷⠀⠀⢀⣀⣠⣿⡀⢻⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⠃⣻⣛⣛⣿⡦⠀⠀⢀⣀⣀⠀⡠⠤⢄⠀⢸⡇⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠈⠁⠀⠀⠀⠈⠉⢳⡉⠁⠀⠀⠀⠿⠽⣶⡶⣰⡄⣿⣤⣄⣀⡀⠀⠀⠀⠀⠀⣀⣀⣀⣤⣿⣸⣾⣽⣷⡄⠀⠀⠀⠳⠥⠤⣅⠥⠴⠛⠀⣾⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠛⠛⠙⠷⠟⠀⠈⠉⠉⠛⠛⠛⠋⠉⠉⠉⠉⠀⠈⠙⠿⣿⠀⠀⠀⠀⠀⠀⠀⠀⢹⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"✨ Salutations, noble Voyageur... bienvenue dans ton royaume enchanté : {nom} ! ✨");
        Console.ResetColor();

        Console.WriteLine("🧞​ Je suis Optegar, l’âme millénaire du Potager... un esprit ancien lié à la terre et au souffle des saisons.");
        Console.WriteLine("🧹 Le vent murmure que de grandes tâches t’attendent... les Potagers de ces Terres ne se cultivent pas tout seuls !");
        Console.WriteLine("🌍 Cinq terres magiques t’accueillent, chacune aux charmes et caprices différents... Renseigne-toi bien avant d’y planter quoi que ce soit.");

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("🌸 Car pour faire naître les merveilles végétales... il faudra soin, patience et magie verte !");
        Console.ResetColor();

        Console.WriteLine();
        Console.WriteLine("🏰 Un fabuleux Magasin t’attend dans ton monde... pousse ses portes, tu y trouveras merveilles et trésors botaniques ✨");
        Console.WriteLine("🧺 Des semis d’une qualité légendaire t’y attendent, mais prends garde : chaque plante a ses caprices, et toutes ne s’épanouissent pas dans le même sol...");
        Console.WriteLine("​📖​ De plus de vieux grimoires s'y trouvent et regorgent de tous les savoirs dont tu auras besoin.");
        Console.WriteLine("💰 On raconte que le Magasin rachète les Plantes mûres à un prix... fort alléchant.");
        Console.WriteLine("Les esprits parlent de 'PnL', une magie de richesse mystérieuse qui te permettra d'amasser plein de Verdamoula 💰...");

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("🌟 Que la chance t’accompagne, Jardinier des Étoiles... que tes terres rayonnent de vie et d’abondance !");
        Console.WriteLine("🍀 Bon courage, et puisse la magie de la nature t’inspirer à chaque graine plantée !");
        Console.ResetColor();
        Console.WriteLine("\nTapez Entrée pour commencer votre aventure !");

        Console.ForegroundColor = ConsoleColor.White;
    }

    public void Chenille() //Affiche le design ASCII de chenille
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string chenille = @"
⠀⠀⣾⣿⠍⠓⢦⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⠖⠛⣿⣶⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠙⠉⠀⠀⠈⢳⠀⠀⠀⠀⠀⠀⠀⡼⠁⠀⠀⠙⠛⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠈⣇⠀⠀⠀⠀⠀⢸⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⢀⣤⠿⠒⠒⠒⠒⠒⠚⠦⠤⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⣤⠞⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠲⢄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⣠⠞⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⣴⠃⠀⠀⣴⣿⠿⣶⠀⠀⠀⠀⠀⠀⢠⣿⡟⢷⡄⠀⠀⠈⢧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⢰⠃⠀⠀⠀⣿⣿⣷⣿⠀⠀⠀⠀⠀⠀⢸⣿⣷⣿⠇⠀⠀⠀⠈⢧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⢸⠀⠀⠀⠀⠈⠛⠛⠁⠀⠀⠀⠀⠀⠀⠀⠙⠛⠋⠀⠀⠀⠀⠀⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⣾⡀⠀⠀⠀⠀⠀⠀⢀⡀⠀⠀⠀⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠘⢧⠀⠀⠀⠀⠀⠀⠀⠱⣄⡀⢀⡴⠛⠀⠀⠀⠀⠀⠀⠀⠀⣰⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠈⠳⣄⠀⠀⠀⠀⠀⠀⠀⠉⠉⠀⠀⠀⠀⠀⠀⠀⠀⢀⡴⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠈⠙⣶⢤⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⡤⠶⡿⢦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⣰⠃⠀⠀⠉⠉⠉⠉⠉⠉⠉⠉⠉⠁⠀⠀⠸⣇⣈⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⢠⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡴⠒⠲⠤⣄⠀⠀⠘⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⣠⠶⠋⢹⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢧⣀⠀⠀⠀⢹⡄⠀⡾⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⢿⣀⣀⡨⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠉⠋⠉⠀⣼⣇⣤⠴⠒⢷⠒⠲⡖⠤⣤⠖⠒⠚⢻⡙⠒⣶⠤⣤⠖⠒⠻⡍⢳⡒⢦⣀⡤⠴⣖⢲⡶⣄⡀⠀⠀⠀⠀
⠀⠀⠀⠀⠘⢦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⠞⠹⣄⢹⣧⡀⠈⢧⡀⢱⡄⠈⠙⢦⠀⠀⠱⣄⠘⡆⠈⠳⣄⠀⠙⠓⠃⠀⠈⢧⡀⠈⠉⠃⠀⠹⣦⡀⠀⠀
⠀⠀⠀⠀⠀⢸⠙⠲⢤⣀⡀⠀⠀⠀⠀⢀⣀⣠⠤⠔⠊⠁⠀⠀⠀⠉⠁⡇⠀⠀⠉⠉⠀⠀⠀⠈⢳⡀⠀⠈⠉⠁⠀⠀⠘⡆⠀⠀⠀⠀⠀⠀⢷⠀⠀⠀⠀⠀⢹⠈⠳⡀
⠀⠀⠀⠀⠀⠘⡆⠀⠀⠀⠉⠉⠉⠉⠉⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠈⡇⠀⠀⠀⠀⠀⠀⠀⢹⠀⠀⠀⠀⠀⠀⢸⡇⠀⠀⣀⠀⢸⢂⣠⠇
⠀⠀⠀⠀⠀⠀⢣⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⣷⠀⠀⠀⠀⠀⠀⠀⢸⠇⠀⣀⣀⣀⠀⡞⠀⠀⣿⡛⢹⡞⠋⠁⠀
⠀⠀⠀⠀⠀⠀⠈⢷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣀⡀⠀⠀⣠⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡇⠀⠀⢀⣀⣀⡀⢀⡟⠀⠀⢿⠁⠸⣾⣁⣀⣀⠼⠷⣼⠃⠀⠀⠀
⠀⠀⠀⠀⠀⣠⠞⠉⠙⢤⡀⠀⠀⠀⠀⠀⠀⠀⠀⣏⠀⠀⠙⣤⡴⠃⠀⠀⠀⠀⠀⣠⡤⢤⡀⢀⡜⠀⠀⠀⢿⠀⠀⢳⣾⣀⣀⣠⡼⢧⣀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠧⣄⠤⠤⠒⠋⠓⠲⠤⠤⣀⣀⣀⣀⣘⣧⣀⠀⢸⡆⠀⠀⠀⠀⠀⠀⣏⠀⠀⢿⡯⢄⣀⡠⠤⠼⢧⠀⢸⠀⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠛⠉⠛⠒⠒⠒⠒⠒⠻⡄⠀⢸⡇⠀⠀⠀⠀⠀⠈⠙⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠓⢛⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀";

        Console.WriteLine(chenille);
    }

    public void Accueil() //Affiche le design ASCII de l'accueil
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string accueil = @"
                    _,_           +                   __
                    ','                  /\          `. `.
            .                        .'  \    +      ""  |
                                    /     \         /  .'         .
                        .'\      .'       \       `""`
        +             .-'   `.   /          `.
                .     .'        \.'             \
                .-'           \               \   .-`""-.      . +
            .'.'               \               \.'       `-.
            /                    `.           .-'\           `-._
            .'                       \       .-'                   `-.
                                                                    `-.
    .-------------------'''''''''''''''              _.--      .'
                                    ___..         _.--''        .'jb
                            --''''             '            .'

    ";

        Console.WriteLine(accueil);
        Console.ForegroundColor = ConsoleColor.White;
    }


    public void Rat() //Affiche le design ASCII du rat
    {
        // Pour bien afficher tous les caractères, surtout les symboles spéciaux
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string rat = @"
         __             _,-""~^""-.
       _// )      _,-""~`         `.
     ."" ( /`""-,-""`                 ;
    / 6                             ;
   /           ,             ,-""     ;
  (,__.--.      \           /        ;
   //'   /`-.\   |          |        `._________
     _.-'_/`  )  )--...,,,___\     \-----------,)
   (((""~` _.-'.-'           __`-.   )         //
         (((""`             (((---~""`         //
                                            ((________________
                                            `----""""~~~~^^^```";

        Console.WriteLine(rat);

    }
    public void Poule() //Affiche le design ASCII de la poule
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string poule = @"
                                              _
                                   .-.  .--''` )
                                _ |  |/`   .-'`
                               ( `\      /`
                               _)   _.  -'._
                             /`  .'     .-.-;
                             `).'      /  \  \
                            (`,        \_o/_o/__
                             /           .-''`  ``'-.
                             {         /` ,___.--''`
                             {   ;     '-. \ \
           _   _             {   |'-....-`'.\_\
          / './ '.           \   \          `""`
       _  \   \  |            \   \
      ( '-.J     \_..----.._ __)   `\--..__
     .-`                    `        `\    ''--...--.
    (_,.--""`/`         .-             `\       .__ _)
            |          (                 }    .__ _)
            \_,         '.               }_  - _.'
               \_,         '.            } `'--'
                  '._.     ,_)          /
                     |    /           .'
                      \   |    _   .-'
                       \__/;--.||-'
                        _||   _||__   __
                 _ __.-` ""`)(` ""  ```._)
                (_`,-   ,-'  `''-.   '-._)
               (  (    /          '.__.'
                `""`'--'";

        Console.WriteLine(poule);
    }
    public void Fee() //Affiche le design ASCII de la fée
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string Fee = @"⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡤⠤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠈⠂⢀⠉⠢⢄⠀⠀⢠⣾⡶⡾⠁⢀⣠⣠⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠸⡋⠍⣉⠁⠒⠣⠤⣀⢉⠐⠄⡑⢦⡹⣿⣿⣴⣿⣿⣿⣿⠏⠀⠀⠀⣠⣴⣺⣅⡀⣀⠀⠀⠀⢀⣠⠀
⠀⠀⠀⠀⠀⠑⢄⠀⠈⠑⢄⠒⠂⠬⢱⡒⠬⣣⠙⢆⠸⣿⣿⣿⣿⣿⣦⠀⢀⣾⠏⠀⠀⠀⠀⠀⠰⠀⠀⢈⡻⠁
⠀⠀⠀⠀⠀⠀⠈⠳⡒⠂⠠⢬⠐⠂⠠⠥⢢⣈⠑⠤⡳⡙⢿⣿⣿⣿⡿⢀⣾⡟⠀⠀⠀⠀⠀⠀⢀⠐⢃⠀⣀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠈⠲⣈⠁⠈⠀⢒⠒⠦⠤⠩⠶⢌⣳⣸⣿⣿⣡⣴⣿⠟⠀⠀⠀⠀⠸⠆⠀⠙⠁⠈⠈⠉⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⢶⣄⡉⠁⠚⠒⢒⣲⣦⣤⣶⣿⢿⣿⣿⣿⣿⡟⠁⠀⠀⠀⠀⣦⠀⠘⠂⠐⠂⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⠻⠶⠶⢿⠿⣛⠿⣫⢟⠃⡜⣿⣿⣿⣿⠃⢠⠀⠠⠆⣀⠀⠸⠂⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡠⢒⠡⡮⡪⢋⢂⠎⣤⠁⣿⣿⣿⠃⠀⠀⠀⠀⠀⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⠣⠥⡜⡠⠑⡙⢋⣠⣧⣾⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣔⡠⠔⠓⣹⣿⣿⣿⣿⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⢀⣠⣶⣤⣠⣤⣤⣤⣤⣄⣀⠀⣠⣿⣿⣿⢿⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠴⠛⠋⠉⠉⠉⠉⠛⠛⣻⣿⣿⣿⣿⡿⠛⠁⠈⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠀⣠⣴⣿⣿⠿⠟⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⣸⣿⠟⠋⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⢰⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀";
        Console.WriteLine(Fee);
    }
    public void Pluie() //Affiche le design ASCII de la pluie
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string pluie = @"
                                            ___         
                                    ,""" + "\"\"\"\"'      `." + @"
                                   ,'        _.    ,'""""'.`._
                                  ,'       ,'              `""" + @"'.
                                 ,'    .-""`.    ,-'            `.
                                ,'    (        ,'                :
                              ,'     ,'           __,            `.
                        ,""""'     .' ;-.    ,  ,'  \             `"""".
                      ,'           `-(   `._(_,'     )_                `.
                     ,'         ,---. \ @ ;   \ @ _,'                   `.
                ,-""'         ,'      ,--'-    `;'                       `.
               ,'            ,'      (      `. ,'                          `.
               ;            ,'        \    _,','                            `.
              ,'            ;          `--'  ,'                              `.
             ,'             ;          __    (                    ,           `.
             ;              `____...  `      `.                  ,'           ,'
             ;    ...----'''' )  _.-  .       `.                ,'    ,'    ,'
_....----''' '.        _..--""_.-:.-' .'        `.             ,''.   ,' `--'
              `""     "" _.-'' .-'`-.:..___...--' `-._      ,-""'   `-'" + @"
        _.--'       _.-'    .'   .' .'               `""""""
  __.-''        _.-'     .-'   .'  /
 '          _.-' .-'  .-'        .'
        _.-'  .-'  .-' .'  .'   /
    _.-'      .-'   .-'  .'   .'
_.-'       .-'    .'   .'    /
       _.-'    .-'   .'    .'
    .-'            .'
";

        Console.WriteLine(pluie);


    }
}




