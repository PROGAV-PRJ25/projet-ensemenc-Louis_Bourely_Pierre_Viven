public class Partie
{
    public bool chenille = false;
    public string Nom { get; set; }
    public double VerdaMoula { get; set; }
    public int Semaine { get; set; }
    public int[] ListePlantes { get; set; }
    public PlanteSimple[] ListeInfoPlantes { get; set; }
    public int[] ListeSemis { get; set; }
    public int[] ListeItems { get; set; }
    public Item[] ListeInfoItems { get; set; }
    public Terrain[] ListeTerrains { get; set; }


    public Partie(string nom)
    {
        Nom = nom;
        VerdaMoula = 100;
        Semaine = 1;
        ListePlantes = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
        ListeSemis = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
        ListeItems = [0, 0, 0, 0, 0, 0, 0, 0, 0];
        ListeInfoItems = [
            new Item('R',"Raticidre", 3000,"Le Raticidre permet d'enivrer le Rat Mécréant pour le faire fuire de votre Potager."),             // [0]
            new Item('T',"TirDeFusil", 2500, "Le TirDeFusil tire un cri de Galinacée Hargneuse qui attire le Galinacé Hargneux loin de votre Potager"),            // [1]
            new Item('I',"InsecticideChenille", 1800, "L'InsecticideChenille protège votre Bulletin Météo contre la Cheeeeeniiiiiiillllle"),   // [2]
            new Item('M',"MegaItem", 2000,"Le MegaItem protège votre Plante à vie contre toutes les conditions"),              // [3]
            new Item('C',"CasqueTroué", 500,"Le CasqueTroué protège votre plante contre toutes les conditions pendant un Tour."),            // [4]
            new Item('P',"PotionMagique", 100,"La PotionMagique donne un effet aléatoir qu peut accèlérer la croissance la ralentir ou bien tuer la plante"),         // [5]
            new Item('E',"EngraisHyperactif", 1500,"L'EngraisHyperactif avance la Croissance d'une semaine"),     // [6]
            new Item('S',"SecàtoutHeure", 5000,"Le SecàtoutHeure permet de tailler les plantes"),              // [7]
            new Item('B',"Bêchhuuuuut", 20,"La Bêchhuuuuut permet de labourer une case d'un Terrain")            // [8]
        ];
        ListeInfoPlantes = [
            new PlanteSimple('a', "Arachnéide", 500, 5000, 7, "Médicinale", "Desert Delicat", [16, 26], [6, 9], [1, 5], [0, 10]),
            new PlanteSimple('b', "Brocélia", 5, 30, 3, "Comestible", "Plaines Paisibles", [18, 23], [8, 9], [3, 5], [17, 22]),
            new PlanteTailler('c', "Cacruz", 150, 600, 3, "Comestible", "Desert Delicat", [16, 26], [6, 9], [1, 5], [0, 10]),
            new PlanteSimple('d', "Demonia", 10, 40, 2, "Comestible", "Volcan Violent", [26, 33], [7, 9], [1, 3], [5, 15]),
            new PlanteSimple('e', "Erdomania", 3, 12, 2, "Comestible", "Plaines Paisibles", [14, 18], [7, 8], [4, 6], [15, 20]),
            new PlanteSimple('f', "Fenecia", 30, 240, 8, "Ornementale", "Volcan Violent", [28, 44], [8, 11], [1, 2], [5, 15]),
            new PlanteFilante('g', "Gorhy", 20, 120, 4, "Comestible", "Volcan Violent", [26, 35], [7, 9], [1, 3], [5, 15]),
            new PlanteSimple('h', "Humalis", 8, 64, 10, "Médicinale", "Plaines Paisibles", [12, 25], [6, 11], [3, 8], [10, 20]),
            new PlanteSimple('i', "Ivoina", 80, 480, 5, "Comestible", "Foret Facetieuse", [9, 18], [4, 6], [3, 4], [35, 45]),
            new PlanteFilante('j', "Jaunille", 300, 1800, 4, "Comestible", "Desert Delicat", [16, 26], [6, 9], [1, 5], [0, 10]),
            new PlanteTailler('m', "Mutina", 750, 3000, 3, "Comestible", "Marecages Malins", [20, 27], [7, 11], [5, 9], [60, 90]),
            new PlanteSimple('n', "Nénustar", 1250, 7500, 5, "Comestible", "Marecages Malins", [20, 27], [7, 11], [5, 9], [60, 90]),
            new PlanteSimple('p', "Placinet", 50, 200, 2, "Comestible", "Foret Facetieuse", [9, 18], [4, 6], [3, 4], [35, 45]),
            new PlanteTailler('k', "Kuintefeuille", 2000, 16000, 8, "Ornementale", "Marecages Malins", [20, 27], [7, 11], [5, 9], [60, 90]),
            new PlanteFilante('z', "Zolia", 100, 1000, 10, "Ornementale", "Foret Facétieuse", [18, 24], [6, 8], [1, 3], [20, 30])
        ];
        ListeTerrains = [new TerrainSimple("Plaines Paisibles"), new TerrainSimple("Foret Facetieuse"), new TerrainSimple("Volcan Violent"), new TerrainMine(), new TerrainAJachere()];
    }
}










public class Sauvegarde  //A finir
{
    public string Nom { get; set; }
    public double VerdaMoula { get; set; }
    public string infoPlantes { get; set; }
    public string infoSemis { get; set; }
    public string infoItems { get; set; }
    public int Semaine { get; set; }
    public string infoTerrains { get; set; }

    public Sauvegarde(Partie partie)
    {
        Nom = partie.Nom;
        VerdaMoula = partie.VerdaMoula;
        Semaine = partie.Semaine;
        int[] listePlantes = partie.ListePlantes;
        int[] listeSemis = partie.ListeSemis;
        int[] listeItems = partie.ListeItems;
        Terrain[] listeTerrain = partie.ListeTerrains;

        infoTerrains = "?";
        for (int k = 0; k < listeTerrain.Length; k++)
        {
            for (int i = 0; i < listeTerrain[k].Potager.GetLength(0); i++)
            {
                for (int j = 0; j < listeTerrain[k].Potager.GetLength(1); j++)
                {
                    if (listeTerrain[k].Potager[i, j] is PlanteSimple plante)
                    {
                        infoTerrains += plante.Croissance.ToString();
                    }
                    infoTerrains += listeTerrain[k].Potager[i, j].Affichage;
                    //coder maladie
                    infoTerrains += "!";
                }
            }
            infoTerrains += "?";
        }

        infoPlantes = "";
        for (int k = 0; k < listePlantes.Length; k++)
        {
            infoPlantes += listePlantes[k].ToString();
            infoPlantes += "!";
        }


        infoSemis = "";
        for (int k = 0; k < listeSemis.Length; k++)
        {
            infoSemis += listeSemis[k].ToString();
            infoSemis += "!";
        }


        infoItems = "";
        for (int k = 0; k < listeItems.Length; k++)
        {
            infoItems += listeItems[k].ToString();
            infoItems += "!";
        }


    }

    public Sauvegarde(string nomSauvegarde)
    {
        Nom = "@";
        VerdaMoula = 0;
        Semaine = 0;
        infoPlantes = "@";
        infoSemis = "@";
        infoItems = "@";
        infoTerrains = "@";
        string[] lignes = File.ReadAllLines("sauvegarde.csv");
        for (int i = 1; i < lignes.Length; i++)
        {
            string[] colonnes = lignes[i].Split(',');
            if (colonnes[0] == nomSauvegarde)
            {
                Nom = colonnes[0];
                VerdaMoula = int.Parse(colonnes[1]);
                Semaine = int.Parse(colonnes[2]);
                infoPlantes = colonnes[3];
                infoSemis = colonnes[4];
                infoItems = colonnes[5];
                infoTerrains = colonnes[6];
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


        nouvellesLignes.Add($"{Nom},{VerdaMoula},{Semaine},{infoPlantes},{infoSemis},{infoItems},{infoTerrains}");

        File.WriteAllLines("sauvegarde.csv", nouvellesLignes);
    }

    public Partie CreerPartie()
    {
        string nombre = "";

        int[] listePlantes = new int[15];
        int nbPlante = 0;

        for (int k = 0; k < infoPlantes.Length; k++)
        {
            if (infoPlantes[k] == '!')
            {
                listePlantes[nbPlante] = Convert.ToInt32(nombre);
                nbPlante++;
                nombre = "";
            }
            else
            {
                nombre += infoPlantes[k];
            }
        }



        int[] listeSemis = new int[15];
        int nbSemis = 0;

        for (int k = 0; k < infoSemis.Length; k++)
        {
            if (infoSemis[k] == '!')
            {
                listeSemis[nbSemis] = Convert.ToInt32(nombre);
                nbSemis++;
                nombre = "";
            }
            else
            {
                nombre += infoSemis[k];
            }
        }



        int[] listeItems = new int[9];
        int nbItems = 0;

        for (int k = 0; k < infoItems.Length; k++)
        {
            if (infoItems[k] == '!')
            {
                listeItems[nbItems] = Convert.ToInt32(nombre);
                nbItems++;
                nombre = "";
            }
            else
            {
                nombre += infoItems[k];
            }
        }



        Terrain[] listeTerrains = [new TerrainSimple("Plaines Paisibles"), new TerrainSimple("Foret Facetieuse"), new TerrainSimple("Volcan Violent"), new TerrainMine(), new TerrainAJachere()];
        int nbTerrain = -1;
        int i = 0;
        int j = 0;
        for (int k = 0; k < infoTerrains.Length; k++)
        {
            if (infoTerrains[k] == '?')
            {
                nbTerrain++;
                i = 0;
            }
            else if (infoTerrains[k] == '!')
            {
                if (j != 19)
                {
                    j++;
                }
                else
                {
                    i++;
                    j = 0;
                }
            }
            else
            {
                switch (char.ToLower(infoTerrains[k]))
                {
                    case '/':
                        Console.WriteLine(i + "&" + j);
                        listeTerrains[nbTerrain].Potager[i, j] = new SolSimple("Vierge");
                        break;
                    case '%':
                        listeTerrains[nbTerrain].Potager[i, j] = new SolSimple("Friche");
                        break;
                    case 'x':
                        listeTerrains[nbTerrain].Potager[i, j] = new SolSimple("Jachère");
                        break;
                    case '•':
                        listeTerrains[nbTerrain].Potager[i, j] = new SolSimple("Laboure");
                        break;
                    case 'a':
                        listeTerrains[nbTerrain].Potager[i, j] = new PlanteSimple('a', "Arachnéide", 500, 5000, Convert.ToInt32(nombre), "Médicinale", "Desert Delicat", [16, 26], [6, 9], [1, 5], [0, 10]);
                        nombre = "";
                        break;
                    case 'b':
                        listeTerrains[nbTerrain].Potager[i, j] = new PlanteSimple('b', "Brocélia", 5, 30, Convert.ToInt32(nombre), "Comestible", "Plaines Paisibles", [18, 23], [8, 9], [3, 5], [17, 22]);
                        nombre = "";
                        break;
                    case 'c':
                        listeTerrains[nbTerrain].Potager[i, j] = new PlanteTailler('c', "Cacruz", 150, 600, Convert.ToInt32(nombre), "Comestible", "Desert Delicat", [16, 26], [6, 9], [1, 5], [0, 10]);
                        nombre = "";
                        break;
                    case 'd':
                        listeTerrains[nbTerrain].Potager[i, j] = new PlanteSimple('d', "Demonia", 10, 40, Convert.ToInt32(nombre), "Comestible", "Volcan Violent", [26, 33], [7, 9], [1, 3], [5, 15]);
                        nombre = "";
                        break;
                    case 'e':
                        listeTerrains[nbTerrain].Potager[i, j] = new PlanteSimple('e', "Erdomania", 3, 12, Convert.ToInt32(nombre), "Comestible", "Plaines Paisibles", [14, 18], [7, 8], [4, 6], [15, 20]);
                        nombre = "";
                        break;
                    case 'f':
                        listeTerrains[nbTerrain].Potager[i, j] = new PlanteSimple('f', "Fenecia", 30, 240, Convert.ToInt32(nombre), "Ornementale", "Volcan Violent", [28, 44], [8, 11], [1, 2], [5, 15]);
                        nombre = "";
                        break;
                    case 'g':
                        listeTerrains[nbTerrain].Potager[i, j] = new PlanteFilante('g', "Gorhy", 20, 120, Convert.ToInt32(nombre), "Comestible", "Volcan Violent", [26, 35], [7, 9], [1, 3], [5, 15]);
                        nombre = "";
                        break;
                    case 'h':
                        listeTerrains[nbTerrain].Potager[i, j] = new PlanteSimple('h', "Humalis", 8, 64, Convert.ToInt32(nombre), "Médicinale", "Plaines Paisibles", [12, 25], [6, 11], [3, 8], [10, 20]);
                        nombre = "";
                        break;
                    case 'i':
                        listeTerrains[nbTerrain].Potager[i, j] = new PlanteSimple('i', "Ivoina", 80, 480, Convert.ToInt32(nombre), "Comestible", "Foret Facetieuse", [9, 18], [4, 6], [3, 4], [35, 45]);
                        nombre = "";
                        break;
                    case 'j':
                        listeTerrains[nbTerrain].Potager[i, j] = new PlanteFilante('j', "Jaunille", 300, 1800, Convert.ToInt32(nombre), "Comestible", "Desert Delicat", [16, 26], [6, 9], [1, 5], [0, 10]);
                        nombre = "";
                        break;
                    case 'm':
                        listeTerrains[nbTerrain].Potager[i, j] = new PlanteTailler('m', "Mutina", 750, 3000, Convert.ToInt32(nombre), "Comestible", "Marecages Malins", [20, 27], [7, 11], [5, 9], [60, 90]);
                        nombre = "";
                        break;
                    case 'n':
                        listeTerrains[nbTerrain].Potager[i, j] = new PlanteSimple('a', "Arachnéide", 500, 5000, Convert.ToInt32(nombre), "Médicinale", "Desert Delicat", [16, 26], [6, 9], [1, 5], [0, 10]);
                        nombre = "";
                        break;
                    case 'p':
                        listeTerrains[nbTerrain].Potager[i, j] = new PlanteSimple('n', "Nénustar", 1250, 7500, Convert.ToInt32(nombre), "Comestible", "Marecages Malins", [20, 27], [7, 11], [5, 9], [60, 90]);
                        nombre = "";
                        break;
                    case 'k':
                        listeTerrains[nbTerrain].Potager[i, j] = new PlanteTailler('k', "Kuintefeuille", 2000, 16000, Convert.ToInt32(nombre), "Ornementale", "Marecages Malins", [20, 27], [7, 11], [5, 9], [60, 90]);
                        nombre = "";
                        break;
                    case 'z':
                        listeTerrains[nbTerrain].Potager[i, j] = new PlanteFilante('z', "Zolia", 100, 1000, Convert.ToInt32(nombre), "Ornementale", "Foret Facétieuse", [18, 24], [6, 8], [1, 3], [20, 30]);
                        nombre = "";
                        break;
                    default:
                        nombre += infoTerrains[k];
                        break;
                }
            }

        }
        Partie sauvegarde = new Partie(Nom);
        sauvegarde.VerdaMoula = VerdaMoula;
        sauvegarde.Semaine = Semaine;
        sauvegarde.ListeItems = listeItems;
        sauvegarde.ListePlantes = listePlantes;
        sauvegarde.ListeSemis = listeSemis;
        sauvegarde.ListeTerrains = listeTerrains;
        return sauvegarde;

    }
}