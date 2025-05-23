using System.Formats.Asn1;
using System.Reflection.Metadata;
using System.Xml;

public class Affichage
{


    public double Potager(Plante[,] terrain, string nom)
    {
        char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
        ConsoleColor couleur = Console.ForegroundColor;
        double prixAgrandir = 0;
        switch (nom)
        {
            case "Marecages Malins":
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                prixAgrandir = 200;
                break;
            case "Desert Delicat":
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                prixAgrandir = 800;
                break;
            case "Foret Facetieuse":
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                prixAgrandir = 400;
                break;
            case "Volcan Violent":
                Console.ForegroundColor = ConsoleColor.DarkRed;
                prixAgrandir = 1000;
                break;
            case "Plaines Paisibles":
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                prixAgrandir = 10;
                break;
            default:
                break;
        }


        Console.Write("  "); //espace pour aligner les chiffres
        for (int j = 0; j < terrain.GetLength(1); j++) //création de la ligne de nombres du haut 
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
        for (int j = 0; j < terrain.GetLength(1); j++) //création de la délimitation de la première ligne  
        {
            Console.Write("+---");
        }
        Console.Write("+");
        Console.WriteLine();

        for (int i = 0; i < terrain.GetLength(0); i++) //Boucle servant à afficher et remplir les cases du plateau 
        {
            Console.Write(alphabet[i] + " "); //afficher les lettres sur le coté gauche du plateau

            for (int j = 0; j < terrain.GetLength(1); j++)
            {
                Plante(terrain[i, j]); // Appel de la procédure AffichageCase qui permet de mettre les emojis des personnages
            }
            Console.Write("|");
            Console.WriteLine();

            Console.Write("  ");
            for (int j = 0; j < terrain.GetLength(1); j++) //création de la délimitation du bas de la ligne
            {
                Console.Write("+---");
            }
            Console.Write("+");
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine("--- " + nom.ToUpper() + " ---");
        Console.WriteLine();
        Console.ForegroundColor = couleur;
        return prixAgrandir;
    }


    public void Plante(Plante plante)    //couleur si malade
    {
        ConsoleColor couleur = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.White;
        if (plante is SolSimple)
        {
            Console.Write($"| {plante.Affichage} ");
        }
        else if (plante is PlanteTailler p)
        {
            //condition malade
            if (p.Taillage == false)
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
    }




    public void TexteEnProgressif(string texte, int vitesse)
    {
        for (int i = 0; i < texte.Length; i++)
        {
            Console.Write(texte[i]);
            Thread.Sleep(vitesse);
        }
        Console.WriteLine("");
    }


    public void Magasin()
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


        Console.WriteLine("\n\nBienvenue dans le magasin 🏪​! \nTapez 1 pour acheter des Semis 🌱\nTapez 2 pour vendre vos Plantes🌳\nTapez 3 pour acheter un item 🛠️\nTapez Q pour Quitter❌");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public int[] DemandeCasePotage()
    {
        Console.Write("Rentrez la case ou vous souhaitez planter : ");
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
        TexteEnProgressif("Case non valide!      ", 45);
        return [99, 99];
    }




    public void Accueil()
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


    public void InfoTerrain(Terrain terrain)
    {

    }

    public void Tutoriel(string nom)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢴⠒⢢⡀⢀⡤⢤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠷⣄⡓⡋⣀⣴⠗⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⣀⠀⠀⠀⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣠⣤⣀⣤⣴⠶⠶⠛⠛⠛⠻⢿⣥⣽⣷⣤⣼⢃⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣾⠋⠁⠀⣿⠀⠀⠁⠀⣤⡶⠶⢶⣄⠀⠀⠀⠈⢻⡏⠙⢷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣼⠿⠶⠶⠾⠋⠀⠀⠀⠘⢿⣤⣤⣤⠿⠃⠀⠀⠀⠈⠛⠷⠦⠿⢷⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡶⢿⡅⠀⣠⡴⠶⠛⠛⠳⠶⠶⠶⠶⠶⠶⠾⠟⠛⠛⠳⠶⣦⣄⠀⠀⢀⣿⠷⣦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢾⡅⣸⡿⣾⠏⢀⠀⠀⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠆⠀⠀⠀⠙⢿⣦⠸⣧⣠⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣟⡛⢹⡏⠀⠈⠑⢠⣶⠟⠳⣆⣀⣀⣀⣀⢀⣴⠾⠳⣦⡀⠐⠀⠀⠹⣧⠈⢹⣧⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣷⠃⠸⣷⡉⠀⢠⡿⠁⣶⠀⠙⣉⠉⣉⡉⠙⠃⣶⡆⢸⡇⠀⠀⠀⢀⡿⠰⣿⣽⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣆⡀⠙⢷⣤⡟⠀⠀⠉⠀⠀⠙⠛⠛⠁⠀⠀⠉⠀⠈⢻⡄⢀⣠⡾⠃⢀⣼⠟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⠷⣦⣬⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⣿⣭⣩⣤⣴⠿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣹⡷⣀⠀⠀⣀⡀⠀⠀⠀⠀⠀⠀⠀⢀⡜⣷⠀⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⢀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⣿⣄⠉⠛⠛⢩⡿⠀⠀⠀⣾⠛⠛⠛⠛⠁⣼⡿⢻⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⠤⢤⠸⠃⡼⠃⠀⠀⠀⠀\n⠀⠀⢰⣋⣙⠢⢂⣠⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⡇⠀⠻⣆⠛⠛⠋⠁⠀⠀⠀⠙⠻⠶⠾⠃⣼⠏⠀⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠦⣄⠄⠠⡄⠙⢒⡄⠀⠀\n⠀⠀⠀⠈⠉⠁⣷⠀⠀⠀⠀⠀⠀⠀⢀⠀⠀⠀⠀⠀⠸⡇⢶⡄⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠋⢰⡆⢸⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠯⠄⡔⠈⠉⠉⠀⠀⠀\n⠀⠀⠀⠀⠀⢰⡇⠀⠀⢾⣋⢉⠂⢘⣈⡷⠀⠀⢀⣀⣠⣿⡀⢻⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⠃⣻⣛⣛⣿⡦⠀⠀⢀⣀⣀⠀⡠⠤⢄⠀⢸⡇⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠈⠁⠀⠀⠀⠈⠉⢳⡉⠁⠀⠀⠀⠿⠽⣶⡶⣰⡄⣿⣤⣄⣀⡀⠀⠀⠀⠀⠀⣀⣀⣀⣤⣿⣸⣾⣽⣷⡄⠀⠀⠀⠳⠥⠤⣅⠥⠴⠛⠀⣾⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠛⠛⠙⠷⠟⠀⠈⠉⠉⠛⠛⠛⠋⠉⠉⠉⠉⠀⠈⠙⠿⣿⠀⠀⠀⠀⠀⠀⠀⠀⢹⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"✨ Salutations, noble Voyageur... bienvenue dans ton royaume enchanté : {nom} ! ✨");
        Console.ResetColor();

        Console.WriteLine("🌱 Je suis Optegar, l’âme millénaire du Potager... un esprit ancien lié à la terre et au souffle des saisons.");
        Console.WriteLine("🧹 Le vent murmure que de grandes tâches t’attendent... les Potagers de ces Terres ne se cultivent pas tout seuls !");
        Console.WriteLine("🌍 Cinq terres magiques t’accueillent, chacune aux charmes et caprices différents... Renseigne-toi bien avant d’y planter quoi que ce soit.");

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("🌸 Car pour faire naître les merveilles végétales... il faudra soin, patience et magie verte !");
        Console.ResetColor();

        Console.WriteLine();
        Console.WriteLine("🏰 Un fabuleux Magasin t’attend dans ton monde... pousse ses portes, tu y trouveras merveilles et trésors botaniques ✨");
        Console.WriteLine("🧺 Des semis d’une qualité légendaire t’y attendent, mais prends garde : chaque plante a ses caprices, et toutes ne s’épanouissent pas dans le même sol...");
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



    public void Chenille()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // Pour bien afficher les caractères spéciaux

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
    public void Rat()
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
    public void Poule()
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
}




                                                         
