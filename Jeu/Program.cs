int largeurConsole = Console.WindowWidth;
int hauteurConsole = Console.WindowHeight;

while(largeurConsole <160 || hauteurConsole<40)
{
    largeurConsole = Console.WindowWidth;
    hauteurConsole = Console.WindowHeight;
    Console.Clear();
    Console.WriteLine($"Taille de votre console : {largeurConsole} x {hauteurConsole}");
    Console.WriteLine($"Pour une expérience de jeu optimale veuillez ajuster la taille de votre console pour une taille de minimum 160 x 40");
    Console.WriteLine($"\nTapez 'ENTRÉE' quand vous êtes prêt.");
    while(Console.ReadKey().Key!=ConsoleKey.Enter)
    {
    }
}
for(int i= 1; i<161;i++)
{
    Console.Write("a");
}