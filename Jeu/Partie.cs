public class Partie
{
    public string Nom {get; set;}
    public int Difficulte{get; set;}
    public double VerdaMoula {get; set;}
    public int[] ListePlantes {get; set;}
    public int[] ListeSemis {get; set;}
    public int[] ListeItems {get; set;}
    //public Terrain[] ListeTerrain {get; set;}
    public int Semaine {get; set;}

    public Partie(string nom, int difficulte)
    {
        Nom=nom;
        Difficulte=difficulte;
        Semaine=1;
        ListePlantes =[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0];
        ListeSemis =[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0];
        ListeItems=[0,0,0,0,0,0,0,0];
        //ListeTerrain=[new Plaines(),new Plaines(),new Plaines(),new Plaines(),new Plaines()];
    }
}










public class Sauvegarde
{
    public string Nom {get; set;}
    public int Difficulte{get; set;}
    public double VerdaMoula {get; set;}
    public int[] ListePlantes {get; set;}
    public int[] ListeSemis {get; set;}
    public int[] ListeItems {get; set;}
    public int Semaine {get; set;}
    public string infoTerrain  {get; set;}

    public Sauvegarde(string nom, int difficulte, double moula, int[] listePlante, int[] listeSemis, int[] listeTtems, int semaine, Terrain[] listeTerrain)
    {
        Nom=nom;
        Difficulte=difficulte;
        VerdaMoula=moula;
        ListePlantes=listePlante;
        ListeSemis=listeSemis;
        ListeItems=listeTtems;
        Semaine=semaine;

        infoTerrain="/";
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
            infoTerrain+="/";
        }
    }
}