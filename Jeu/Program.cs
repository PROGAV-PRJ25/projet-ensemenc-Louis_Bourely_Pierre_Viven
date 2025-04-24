int largeurConsole = Console.WindowWidth;
int hauteurConsole = Console.WindowHeight;

while(largeurConsole <160 || hauteurConsole<40)
{
    largeurConsole = Console.WindowWidth;
    hauteurConsole = Console.WindowHeight;
    Console.Clear();
    if(largeurConsole <160 || hauteurConsole<40)
    {
        Console.WriteLine($"Taille de votre console : {largeurConsole} x {hauteurConsole}");
        Console.WriteLine($"Pour une expérience de jeu optimale veuillez ajuster la taille de votre console pour une taille de minimum 160 x 40");
        Console.WriteLine($"\nTapez 'ENTRÉE' quand votre écran est à la bonne taille.");
        while(Console.ReadKey().Key!=ConsoleKey.Enter)
        {
        }
    }
}


//Affichage blabla menu
bool jeu=true;
while(jeu)
{
    Console.WriteLine("Pour créer une nouvelle partie tapez N");
    Console.WriteLine("Pour charger une partie tapez C");
    Console.WriteLine("Pour quitter tapez Q");

    switch(Console.ReadKey().Key)
    {
        case ConsoleKey.N:
        Console.Write("Tapez le nom de votre nouveau monde : ");
            string nom=Console.ReadLine()!;
            GestionJeu partieEnCours = new GestionJeu(nom);
            partieEnCours.Jouer();
            break;
        case ConsoleKey.C:
            string partieSauvegarde=Console.ReadLine()!;
            //chercher la sauvegarde
            break;
        case ConsoleKey.Q:
            Console.WriteLine("q");
            jeu=false;
            break;
        default :
            break;

    }

}