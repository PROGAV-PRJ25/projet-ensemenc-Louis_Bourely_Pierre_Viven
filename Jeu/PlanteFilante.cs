public class PlanteFilante : PlanteSimple
{
    public bool Extension { get; set; }

    public PlanteFilante(char affichage, string nom, double prixAchat, double prixVente, double croissance, bool extension = false) : base(affichage, nom, prixAchat, prixVente, croissance)
    {
        Affichage = affichage;
        Nom = nom;
        PrixAchat = prixAchat;
        PrixVente = prixVente;
        Croissance = croissance;
        Extension = extension;
    }

    public void Etendre(int i, int j)
    {
        // if ((i != 0) && (Terrain.Potager[i - 1, j].Affichage == "•"))
        // {
        //     Terrain.Planter(new PlanteFilante(), i - 1, j);
        // }
        // else if ((j != Terrain.Potager.GetLength(1)) && (Terrain.Potager[i, j + 1].Affichage == "•"))
        // {
        //     Terrain.Planter(new PlanteFilante(), i, j + 1);
        // }
        // else if ((i != Terrain.Potager.GetLength(0)) && (Terrain.Potager[i + 1, j].Affichage == "•"))
        // {
        //     Terrain.Planter(new PlanteFilante(), i + 1, j);
        // }
        // else if ((j != 0) && (Terrain.Potager[i, j - 1].Affichage == "•"))
        // {
        //     Terrain.Planter(new PlanteFilante(), i, j - 1);
        // }
        // else { }
    }
    public void VerifEtat(int i, int j)
    {
        Random random = new Random();
        int aleatoire = random.Next(0, 3);
        // if ((Extension == false) && (Croissance == ) && (aleatoire == 1))
        {
            Etendre(i, j);
        }


    }
}