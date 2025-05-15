using System.Reflection.Metadata;

public class Affichage
{
    
    
    public void Potager(Plante[,] terrain)
    {
        char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O' };


        Console.Write("  "); //espace pour aligner les chiffres
        for (int j=0; j<terrain.GetLength(1) ; j++) //création de la ligne de nombres du haut 
        {
            if (j<9)
            {
                Console.Write($"  {j+1} ");
            }
            else
            {
                if (j==9)
                {
                    Console.Write(" "); //adaptation de la taille pour les nombres à 2 chiffres
                }
                Console.Write($"{j+1}  ");
            }
        }
        Console.WriteLine();  

        Console.Write("  ");
        for (int j=0; j<terrain.GetLength(1) ; j++) //création de la délimitation de la première ligne  
        {
            Console.Write("+---");
        }
        Console.Write("+");
        Console.WriteLine(); 

        for (int i=0; i<terrain.GetLength(0); i++) //Boucle servant à afficher et remplir les cases du plateau 
        {
            Console.Write(alphabet[i]+" "); //afficher les lettres sur le coté gauche du plateau

            for (int j=0; j<terrain.GetLength(1) ; j++)
            {
                Plante(terrain[i,j]); // Appel de la procédure AffichageCase qui permet de mettre les emojis des personnages
            }
            Console.Write("|"); 
            Console.WriteLine();

            Console.Write("  ");
            for (int j=0; j<terrain.GetLength(1) ; j++) //création de la délimitation du bas de la ligne
            {
                Console.Write("+---");
            }
            Console.Write("+");
            Console.WriteLine();
        }
            Console.WriteLine();
    }


    public void Plante(Plante plante)    //couleur si malade
    {
        if(plante is SolSimple)
            {
                Console.Write($"| {plante.Affichage} ");
            }
        else
        {
            //condition malade
            Console.Write($"| {plante.Affichage} ");
        }
    }




    public void TexteEnProgressif(string texte, int vitesse)
    {
        for(int i=0; i<texte.Length;i++)
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

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Bienvenue dans le magasin ! Tapez 1 pour voir les items, 2 pour voir les Plantes et Q pour Quitter");
    }
}



                                                         
