int largeurConsole = Console.WindowWidth;
int hauteurConsole = Console.WindowHeight;

Affichage Afficher =new Affichage();

Console.Clear();

while(largeurConsole <160 || hauteurConsole<40)
{
    largeurConsole = Console.WindowWidth;
    hauteurConsole = Console.WindowHeight;
    Console.Clear();
    if(largeurConsole <160 || hauteurConsole<40)
    {
        Console.WriteLine($"Pour une expérience de jeu optimale veuillez ajuster la taille de votre console pour une taille de minimum 160 x 40 \n(vous pouvez utiliser la flèche à gauche de la croix de votre console: Maximse Panel Size)");
        Console.WriteLine($"\nTapez 'ENTRÉE' quand votre écran est à la bonne taille ({largeurConsole} x {hauteurConsole} actuellement)");
        while(Console.ReadKey().Key!=ConsoleKey.Enter)
        {
        }
    }
}


//Affichage blabla menu
bool jeu=true;
while(jeu)
{
    Console.Clear();
    Console.WriteLine("Pour créer une nouvelle partie appuyez sur 'N' ");
    Console.WriteLine("Pour charger une partie sauvegardée appuyez sur 'S' ");
    Console.WriteLine("Pour quitter tapez Q ");

    switch(Console.ReadKey().Key)
    {
        case ConsoleKey.N:
            Console.Clear();
            Console.Write("Tapez le nom de votre nouveau monde : ");
            string nom=Console.ReadLine()!;
            GestionJeu partieEnCours = new GestionJeu(nom);
            partieEnCours.Jouer();
            break;
        case ConsoleKey.S:
            Console.Clear();
            Console.Write("Tapez le nom de votre sauvegarde  : ");
            string nomPartieSauvegarde=Console.ReadLine()!;
            Sauvegarde partieSauvegarde = new Sauvegarde(nomPartieSauvegarde);
            if(partieSauvegarde.infoSemis=="@")
            {
                Afficher.TexteEnProgressif("Sauvegarde non trouvée veuillez réessayer ou créer une nouvelle partie !          ",20);        
            }
            else
            {
                GestionJeu partieEnCoursSauvegarde = new GestionJeu(partieSauvegarde.CreerPartie());
                partieEnCoursSauvegarde.Jouer();
            }
            break;
        case ConsoleKey.Q:
            jeu=false;
            break;
        default :
            break;
    }
}



