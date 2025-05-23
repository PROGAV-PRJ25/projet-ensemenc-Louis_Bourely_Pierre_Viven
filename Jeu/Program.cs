int largeurConsole = Console.WindowWidth; //récupère les dimentions de la console
int hauteurConsole = Console.WindowHeight;

Affichage Afficher = new Affichage(); //Appelle les affichages de la classe

Console.Clear();
Console.ForegroundColor = ConsoleColor.Black;

while (largeurConsole < 160 || hauteurConsole < 40) //Nécessite de mettre la console dans une taille minimale pour la fluidité du jeu
{
    largeurConsole = Console.WindowWidth;
    hauteurConsole = Console.WindowHeight;
    Console.Clear();
    if (largeurConsole < 160 || hauteurConsole < 40)
    {
        Console.WriteLine($"Pour une expérience de jeu optimale veuillez ajuster la taille de votre console pour une taille de minimum 160 x 40 \n(vous pouvez utiliser la flèche à gauche de la croix de votre console: Maximse Panel Size)");
        Console.WriteLine($"\nTapez 'ENTRÉE' quand votre écran est à la bonne taille ({largeurConsole} x {hauteurConsole} actuellement)");
        while (Console.ReadKey(true).Key != ConsoleKey.Enter)
        {
        }
    }
}


Console.ForegroundColor = ConsoleColor.White;
bool jeu = true;
while (jeu)
{
    Console.Clear();
    Afficher.Program();

    switch (Console.ReadKey(true).Key) //Permet de choisir entre créer un nouveau monde, récupérer une sauvegarde ou Quitter
    {
        case ConsoleKey.N:
            Console.Clear();
            Console.Write("Tapez le nom de votre nouveau monde : ");
            string nom = Console.ReadLine()!;
            GestionJeu partieEnCours = new GestionJeu(nom);
            partieEnCours.Jouer();
            break;
        case ConsoleKey.S:
            Console.Clear();
            Console.Write("Tapez le nom de votre sauvegarde  : ");
            string nomPartieSauvegarde = Console.ReadLine()!;
            Sauvegarde partieSauvegarde = new Sauvegarde(nomPartieSauvegarde);
            if (partieSauvegarde.infoSemis == "@") //Erreur si sauvegarde inexistante
            {
                Afficher.TexteEnProgressif("Sauvegarde non trouvée veuillez réessayer ou créer une nouvelle partie !           ", 50);
                Console.WriteLine("");
                Thread.Sleep(1500);
            }
            else
            {
                GestionJeu partieEnCoursSauvegarde = new GestionJeu(partieSauvegarde.CreerPartie());
                partieEnCoursSauvegarde.Jouer();
            }
            break;
        case ConsoleKey.Q:
            jeu = false;
            break;
        default:
            break;
    }
}



