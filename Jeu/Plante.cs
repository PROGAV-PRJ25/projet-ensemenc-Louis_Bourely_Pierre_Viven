public abstract class Plante //Classe abstract de Plante qui est défini uniquement par un affichage unique
{
    public char Affichage { get; set; }


    public Plante()
    {
        Affichage = '@';
    }
}