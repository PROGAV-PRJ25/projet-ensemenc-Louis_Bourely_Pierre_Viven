public class Item
{
    public string Nom { get; set; }
    public int PrixAchat { get; set; }
    public char Affichage { get; set; }
    public Item(char affichage, string nom, int prixAchat)
    {
        Affichage = affichage;
        Nom = nom;
        PrixAchat = prixAchat;
    }
}