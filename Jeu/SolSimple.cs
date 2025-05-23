public class SolSimple : Plante //Classe représentant les différents sols morts dans le Potager avec chacun leur spécificité
{
    public int Jachere { get; set; } = 0; //utilisé par la classe jachère pour savoir combien de semaines restantes avant de pouvoir re cultiver
    public SolSimple(string type) : base()
    {
        switch (type)
        {
            case "Friche":
                Affichage = '%';
                return;
            case "Vierge":
                Affichage = '/';
                return;
            case "Laboure":
                Affichage = '•';
                return;
            case "Jachère":
                Affichage = 'x';
                Random random = new Random();
                Jachere = random.Next(3, 7); //génère un nombre aléatoire de semaine à attendre avant de pouvoir re cultiver
                return;
            default:
                Affichage = '@';
                return;
        }
    }
}