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
        ListeTerrain=[new TerrainSimple("Plaines Paisibles"), new TerrainSimple([1],[1],[1],[1]), new TerrainSimple([1],[1],[1],[1]), new TerrainSimple([1],[1],[1],[1]),new TerrainSimple([1],[1],[1],[1])];
        //A coder avec les vrais valeurs !!
    }
}









//Faire hériter Sauvegarde ???
public class Sauvegarde  //A finir
{
    public string Nom {get; set;}
    //public int Difficulte{get; set;}
    public double VerdaMoula {get; set;}
    public string infoPlantes {get; set;}
    public string infoSemis {get; set;}
    public string infoItems {get; set;}
    public int Semaine {get; set;}
    public string infoTerrain  {get; set;}

    public Sauvegarde(Partie partie)
    {
        Nom=partie.Nom;
        //Difficulte=difficulte;
        VerdaMoula=partie.VerdaMoula;
        Semaine=partie.Semaine;
        int[] listePlantes=partie.ListePlantes;
        int[] listeSemis=partie.ListeSemis;
        int[] listeItems=partie.ListeItems;
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

        infoPlantes="?";
        for(int k=0;k<listePlantes.Length;k++)
        {
            infoPlantes+=listePlantes[k].ToString();
            infoPlantes+="!";
        } 
        infoPlantes+="?";

        infoSemis="?";
        for(int k=0;k<listeSemis.Length;k++)
        {
            infoSemis+=listeSemis[k].ToString();
            infoSemis+="!";
        } 
        infoSemis+="?";

        infoItems="?";
        for(int k=0;k<listeItems.Length;k++)
        {
            infoItems+=listeItems[k].ToString();
            infoItems+="!";
        } 
        infoItems+="?";
            
    }

    public Sauvegarde(string nomSauvegarde)
    {
        Nom = "@";
        VerdaMoula=0;
        Semaine=0;
        infoPlantes="@";
        infoSemis="@";
        infoItems="@";
        infoTerrain="@";
        string[] lignes = File.ReadAllLines("sauvegarde.csv");
        for (int i = 1; i < lignes.Length; i++)
        {
            string[] colonnes = lignes[i].Split(',');
            if (colonnes[0] == nomSauvegarde)
            {
                Nom=colonnes[0];
                VerdaMoula=int.Parse(colonnes[1]);
                Semaine=int.Parse(colonnes[2]);
                infoPlantes=colonnes[3];
                infoSemis=colonnes[4];
                infoItems=colonnes[5];
                infoTerrain=colonnes[6];
            }
        }
    }

    public void Sauvegarder()
    {
        string[] lignes = File.ReadAllLines("sauvegarde.csv");
        List<string> nouvellesLignes = [lignes[0]];
        for (int i = 1; i < lignes.Length; i++)
        {
            string[] colonnes = lignes[i].Split(',');
            if (colonnes[0] != Nom)
            {
                nouvellesLignes.Add(lignes[i]); 
            }
        }

        int VerdaMoula = 2;
        nouvellesLignes.Add($"{Nom},{VerdaMoula},{Semaine},{infoPlantes},{infoSemis},{infoItems},{infoTerrain}");

        File.WriteAllLines("sauvegarde.csv", nouvellesLignes);
    }

    //Creer partie
}