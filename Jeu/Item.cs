public class Item
{
    public string Nom { get; set; }
    public int PrixAchat { get; set; }
    public char Affichage { get; set; }
    public string Description { get; set; }
    public Item(char affichage, string nom, int prixAchat, string description)
    {
        Affichage = affichage;
        Nom = nom;
        PrixAchat = prixAchat;
        Description = description;
    }
}