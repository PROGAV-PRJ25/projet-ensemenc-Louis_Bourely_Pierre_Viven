public class Partie
{
    public string Nom {get; set;}
    //public int Difficulte{get; set;}
    public double VerdaMoula {get; set;}
    public int[] ListePlantes {get; set;}
    public int[] ListeSemis {get; set;}
    public int[] ListeItems {get; set;}
    public Terrain[] ListeTerrain {get; set;}
    public int Semaine {get; set;}

    public Partie(string nom)      //ajouter difficulte
    {
        Nom=nom;
        //Difficulte=difficulte;
        VerdaMoula=100; //A change selon difficulte
        Semaine=1;
        ListePlantes =[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0];
        ListeSemis =[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0];
        ListeItems=[0,0,0,0,0,0,0,0];
        ListeTerrain=[new TerrainSimple([1],[1],[1],[1]), new TerrainSimple([1],[1],[1],[1]), new TerrainSimple([1],[1],[1],[1]), new TerrainSimple([1],[1],[1],[1]),new TerrainSimple([1],[1],[1],[1])];
        //A coder avec les vrais valeurs !!
    }
}









//Faire hériter Sauvegarde ???
public class Sauvegarde  //A finir
{
    public string Nom {get; set;}
    //public int Difficulte{get; set;}
    public double VerdaMoula {get; set;}
    public int[] ListePlantes {get; set;}
    public int[] ListeSemis {get; set;}
    public int[] ListeItems {get; set;}
    public int Semaine {get; set;}
    public string infoTerrain  {get; set;}

    public Sauvegarde(Partie partie)
    {
        Nom=partie.Nom;
        //Difficulte=difficulte;
        VerdaMoula=partie.VerdaMoula;
        ListePlantes=partie.ListePlantes;
        ListeSemis=partie.ListeSemis;
        ListeItems=partie.ListeItems;
        Semaine=partie.Semaine;
        Terrain[] listeTerrain=partie.ListeTerrain;

        infoTerrain="?";
        for(int k=0;k<listeTerrain.Length;k++)
        {
            for(int i=0;i<listeTerrain[k].Potager.GetLength(0);i++)
            {
                for(int j=0; j<listeTerrain[k].Potager.GetLength(1);j++)
                {
                    infoTerrain+=listeTerrain[k].Potager[i,j].Affichage;
                    if(listeTerrain[k].Potager[i,j] is PlanteSimple plante)
                    {
                        infoTerrain+=plante.Croissance.ToString();
                    }
                    //coder maladie
                    infoTerrain+="!";
                }
            }
            infoTerrain+="?";
        }       
    }

    public void Sauvegarder()
    {
    }
    //sauvegarde a partir du fichier

    //creer Partie

    //Ecrire dans sauvegarde.csv

    //Sauvegarde initial
}