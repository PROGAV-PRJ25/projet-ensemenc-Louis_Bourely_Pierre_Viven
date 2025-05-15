using System.Runtime.CompilerServices;

public class GestionJeu
{
    Partie Partie {get; set;}
    Affichage Afficher{get;}

    public GestionJeu(Partie partie)
    {
        Partie=partie;
        Afficher=new Affichage();
    }
    public GestionJeu(string nom)
    {
        Partie=new Partie(nom);
        Afficher=new Affichage();
        Tutoriel();
    }


    public void Tutoriel()
    {
        //code blabla affichage des règles ascii ?
    }

    public void Jouer()
    {
        bool enCours =true;
        while(enCours)
        {
            switch(Accueil(Partie))
            {
                case 1:
                    SimulationSemaine(Partie);
                    break;
                case 2:
                    //Sauvegarder(Partie);
                    SimulationSemaine(Partie);
                    break;
                case 3:
                    //Sauvegarder(Partie);
                    enCours=false;
                    break;
                case 4:
                    enCours=false;
                    break;
                case 5:
                    Console.WriteLine("ERREUR @@@");
                    break;
                default:
                    break;
            }
        }
    }

    public int Accueil(Partie partie)
    {
        bool semaineEnCours = true;
        while(semaineEnCours)
        {
            
            Console.Clear();
            Console.WriteLine($"Bienvenue dans votre monde Verdadura! {partie.Nom}");
            Console.WriteLine($"C'est la semaine {partie.Semaine}");
            Console.WriteLine("Que voulez vous faire ? T pour test Q pour quitter numéro 1 à 5 pour aller sur un terrain");
            Console.WriteLine($"Vos infos => VerdaMoula:{Partie.VerdaMoula} Semaine:{Partie.Semaine}");
            Console.WriteLine($"Vous avez => {Partie.ListePlantes[0]}Plante1,  {Partie.ListePlantes[1]}Plante2,...");
            Console.WriteLine($"Vous avez => {Partie.ListeSemis[0]}Semis1,  {Partie.ListeSemis[1]}Semis2,...");
            Console.WriteLine($"Vous avez => {Partie.ListeItems[0]}Item1,  {Partie.ListeItems[1]}Item2,...");
            switch(Console.ReadKey().Key)
            {
                case ConsoleKey.T:
                    return 1;
                case ConsoleKey.Q:
                    return 4;
                case ConsoleKey.D1:
                    VisualisationTerrain(1);
                    break;
                case ConsoleKey.D2:
                    VisualisationTerrain(2);
                    break;
                case ConsoleKey.D3:
                    VisualisationTerrain(3);
                    break;
                case ConsoleKey.D4:
                    VisualisationTerrain(4);
                    break;
                case ConsoleKey.D5:
                    VisualisationTerrain(5);
                    break;
                case ConsoleKey.M:
                    Magasin();
                    break;
                default :
                    break;
            }
        }
        //Affichage résumé
        //va dans magasin ou dans un terrain ou meteo ou semaine suivante ou aide
        return 5;
    }

    public void VisualisationTerrain(int terrain)
    {
        bool enCours = true;
        while(enCours)
        {
            Console.Clear();
            Afficher.Potager(Partie.ListeTerrain[terrain-1].Potager);
            Console.WriteLine($"Terrain {terrain} Q pour quitter, P pour Planter");

            switch(Console.ReadKey().Key)
            {
                case ConsoleKey.Q:
                    enCours=false;
                    break;
                case ConsoleKey.P:
                    Planter(Partie.ListeTerrain[terrain-1]);
                    break;
                default :
                    break;

            }
        }
    }

    public void Planter(Terrain terrain)
    {
        bool enCours = true;
        while(enCours)
        {
            Console.Clear();
            Console.WriteLine($"Vous avez => {Partie.ListePlantes[0]}Plante1,  {Partie.ListePlantes[1]}Plante2,...");
            Console.WriteLine($"Terrain {terrain} Q pour quitter, Initial de la plante pour plante");

            switch(Console.ReadKey().Key)
            {
                case ConsoleKey.Q:
                    enCours=false;
                    break;
                case ConsoleKey.T:
                    Partie.ListePlantes[0]++;
                    break;
                case ConsoleKey.A:
                    if(Partie.ListePlantes[0]==0)
                    {
                        //Afficher non
                    }
                    else
                    {

                        PlanteSimple nouvellePlante = new PlanteSimple('a', "Arachnéide", 500, 5000, 7);
                        Console.Write("Tapez les coordonnées : ");
                        int x = Convert.ToInt32(Console.ReadLine()!);
                        Console.WriteLine("");
                        Console.Write("Tapez les coordonnées : ");
                        int y = Convert.ToInt32(Console.ReadLine()!);
                        terrain.Planter(nouvellePlante,x,y);
                        Partie.ListePlantes[0]--;
                    }
                    
                    break;
                default :
                    break;

            }
        }
    }

    public void Magasin()
    {
        bool enCours = true;
        while(enCours)
        {
            
            Console.Clear();
            Afficher.Magasin();
            switch(Console.ReadKey().Key)
            {
                case ConsoleKey.Q:
                    enCours=false;
                    break;
                case ConsoleKey.D1:
                    MagasinSemis();
                    break;
                case ConsoleKey.D2:
                    VisualisationTerrain(1);
                    break;
                case ConsoleKey.D3:
                    VisualisationTerrain(1);
                    break;
                default :
                    break;
            }
        }
    }

    public void MagasinSemis()
    {
        bool enCours = true;
        while(enCours)
        {
            Console.WriteLine($"Verdamoula : {Partie.VerdaMoula}");
            Console.WriteLine($"Vous avez => {Partie.ListeSemis[0]}Semis1,  {Partie.ListeSemis[1]}Semis2,...");
            Console.WriteLine("mets l'initial pour acheter j'espère ta la thunasse");
            Console.Clear();
            Afficher.Magasin();
            switch(Console.ReadKey().Key)
            {
                case ConsoleKey.Q:
                    enCours=false;
                    break;
                case ConsoleKey.A:
                    if(Partie.VerdaMoula>=500)
                    {
                        Partie.VerdaMoula-=500;
                        Partie.ListeSemis[0]++;
                    }
                    break;
                case ConsoleKey.B:
                    if(Partie.VerdaMoula>=5)
                    {
                        Partie.VerdaMoula-=5;
                        Partie.ListeSemis[1]++;
                    }
                    break;
                case ConsoleKey.C:
                    if(Partie.VerdaMoula>=150)
                    {
                        Partie.VerdaMoula-=150;
                        Partie.ListeSemis[2]++;
                    }
                    break;
                case ConsoleKey.D:
                    if(Partie.VerdaMoula>=10)
                    {
                        Partie.VerdaMoula-=10;
                        Partie.ListeSemis[3]++;
                    }
                    break;
                case ConsoleKey.E:
                    if(Partie.VerdaMoula>=3)
                    {
                        Partie.VerdaMoula-=3;
                        Partie.ListeSemis[4]++;
                    }
                    break;
                case ConsoleKey.F:
                    if(Partie.VerdaMoula>=30)
                    {
                        Partie.VerdaMoula-=30;
                        Partie.ListeSemis[5]++;
                    }
                    break;
                case ConsoleKey.G:
                    if(Partie.VerdaMoula>=20)
                    {
                        Partie.VerdaMoula-=20;
                        Partie.ListeSemis[6]++;
                    }
                    break;
                case ConsoleKey.H:
                    if(Partie.VerdaMoula>=8)
                    {
                        Partie.VerdaMoula-=8;
                        Partie.ListeSemis[7]++;
                    }
                    break;
                case ConsoleKey.I:
                    if(Partie.VerdaMoula>=80)
                    {
                        Partie.VerdaMoula-=80;
                        Partie.ListeSemis[8]++;
                    }
                    break;
                case ConsoleKey.J:
                    if(Partie.VerdaMoula>=300)
                    {
                        Partie.VerdaMoula-=300;
                        Partie.ListeSemis[9]++;
                    }
                    break;
                case ConsoleKey.M:
                    if(Partie.VerdaMoula>=750)
                    {
                        Partie.VerdaMoula-=750;
                        Partie.ListeSemis[10]++;
                    }
                    break;
                case ConsoleKey.N:
                    if(Partie.VerdaMoula>=1250)
                    {
                        Partie.VerdaMoula-=1250;
                        Partie.ListeSemis[11]++;
                    }
                    break;
                case ConsoleKey.P:
                    if(Partie.VerdaMoula>=50)
                    {
                        Partie.VerdaMoula-=50;
                        Partie.ListeSemis[12]++;
                    }
                    break;
                case ConsoleKey.K:
                    if(Partie.VerdaMoula>=2000)
                    {
                        Partie.VerdaMoula-=2000;
                        Partie.ListeSemis[13]++;
                    }
                    break;
                case ConsoleKey.Z:
                    if(Partie.VerdaMoula>=100)
                    {
                        Partie.VerdaMoula-=100;
                        Partie.ListeSemis[14]++;
                    }
                    break;
                default:
                    break;
            }
        }
    }

    public void MagasinPlantes()
    {
        bool enCours = true;
        while(enCours)
        {
            Console.WriteLine($"Verdamoula : {Partie.VerdaMoula}");
            Console.WriteLine($"Vous avez => {Partie.ListePlantes[0]}Semis1,  {Partie.ListePlantes[1]}Semis2,...");
            Console.WriteLine("mets l'initial pour vendre et être à l'aise financierement");
            Console.Clear();
            Afficher.Magasin();
            switch(Console.ReadKey().Key)
            {
                case ConsoleKey.Q:
                    enCours=false;
                    break;
                case ConsoleKey.A:
                    if(Partie.ListePlantes[0]>=1)
                    {
                        Partie.VerdaMoula+=5000;
                        Partie.ListePlantes[0]--;
                    }
                    break;
                case ConsoleKey.B:
                    if(Partie.ListePlantes[1]>=1)
                    {
                        Partie.VerdaMoula+=30;
                        Partie.ListePlantes[1]--;
                    }
                    break;
                case ConsoleKey.C:
                    if(Partie.ListePlantes[2]>=1)
                    {
                        Partie.VerdaMoula+=600;
                        Partie.ListePlantes[2]--;
                    }
                    break;
                case ConsoleKey.D:
                    if(Partie.ListePlantes[3]>=1)
                    {
                        Partie.VerdaMoula+=40;
                        Partie.ListePlantes[3]--;
                    }
                    break;
                case ConsoleKey.E:
                    if(Partie.ListePlantes[4]>=1)
                    {
                        Partie.VerdaMoula+=12;
                        Partie.ListePlantes[4]--;
                    }
                    break;
                case ConsoleKey.F:
                    if(Partie.ListePlantes[5]>=1)
                    {
                        Partie.VerdaMoula+=240;
                        Partie.ListePlantes[5]--;
                    }
                    break;
                case ConsoleKey.G:
                    if(Partie.ListePlantes[6]>=1)
                    {
                        Partie.VerdaMoula+=120;
                        Partie.ListePlantes[6]--;
                    }
                    break;
                case ConsoleKey.H:
                    if(Partie.ListePlantes[7]>=1)
                    {
                        Partie.VerdaMoula+=64;
                        Partie.ListePlantes[7]--;
                    }
                    break;
                case ConsoleKey.I:
                    if(Partie.ListePlantes[8]>=1)
                    {
                        Partie.VerdaMoula+=480;
                        Partie.ListePlantes[8]--;
                    }
                    break;
                case ConsoleKey.J:
                    if(Partie.ListePlantes[9]>=1)
                    {
                        Partie.VerdaMoula+=1800;
                        Partie.ListePlantes[9]--;
                    }
                    break;
                case ConsoleKey.M:
                    if(Partie.ListePlantes[10]>=1)
                    {
                        Partie.VerdaMoula+=3000;
                        Partie.ListePlantes[10]--;
                    }
                    break;
                case ConsoleKey.N:
                    if(Partie.ListePlantes[11]>=1)
                    {
                        Partie.VerdaMoula+=7500;
                        Partie.ListePlantes[11]--;
                    }
                    break;
                case ConsoleKey.P:
                    if(Partie.ListePlantes[12]>=1)
                    {
                        Partie.VerdaMoula+=200;
                        Partie.ListePlantes[12]--;
                    }
                    break;
                case ConsoleKey.K:
                    if(Partie.ListePlantes[13]>=1)
                    {
                        Partie.VerdaMoula+=16000;
                        Partie.ListePlantes[13]--;
                    }
                    break;
                case ConsoleKey.Z:
                    if(Partie.ListePlantes[14]>=1)
                    {
                        Partie.VerdaMoula+=1000;
                        Partie.ListePlantes[14]--;
                    }
                    break;
                default:
                    break;
            }
        }
    }



    public void SimulationSemaine(Partie partie)
    {
        Console.Clear();
        Afficher.TexteEnProgressif("Simulation semaine!!!!",100);
        Thread.Sleep(800);
        for(int k=0;k<Partie.ListeTerrain.Length;k++)
        {
            //Partie.ListeTerrain[k].VerifTerrain(Partie.ListeTerrain[k],Partie.Semaine);
        }
        partie.Semaine++; 

        /* Random random = new Random();
        int urgences = random.Next(1, 51);
        switch(urgences)
        {
            case 10:
                Rat();
                break;
            case 11:
                Galinace();
                break;
            default:
                break;
        } */
    }


    public void Rat()
    {}

    
    
    public void Galinace()
    {}

}