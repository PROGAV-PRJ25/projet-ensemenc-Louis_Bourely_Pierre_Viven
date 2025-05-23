public class SolSimple : Plante
{
    public int Jachere { get; set; } = 0;
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
                Jachere = random.Next(3, 7);
                return;
            default:
                Affichage = '@';
                return;
        }
    }
}