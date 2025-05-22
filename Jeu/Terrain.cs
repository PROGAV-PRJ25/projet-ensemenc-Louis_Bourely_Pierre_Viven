public abstract class Terrain
{
    public string Nom { get; set; }
    public double[] Temperature { get; set; }
    public double[] Humidite { get; set; }
    public double[] Pluie { get; set; }
    public double[] Ensoleillement { get; set; }

    public Plante[,] Potager { get; set; }
    public int ColonnesDispos { get; set; }

    public Terrain()
    {
        Temperature = [31];
        Humidite = [48];
        Pluie = [33];
        Ensoleillement = [81];
        Nom = "@";
        ColonnesDispos = 2;
        Potager = new Plante[10, 20];
        for (int i = 0; i < Potager.GetLength(0); i++)
        {
            for (int j = 0; j < Potager.GetLength(1); j++)
            {
                if (j < ColonnesDispos)
                {
                    Potager[i, j] = new SolSimple("Laboure");
                }
                else
                {
                    Potager[i, j] = new SolSimple("Friche");
                }
            }
        }
    }

    public static double GenererNombreAleatoire(double min, double max, int decimale)
    {
        Random random = new Random();
        double value = min + (random.NextDouble() * (max - min));
        return Math.Round(value, decimale);
    }

    public void AgrandirPotager()
    {
        ColonnesDispos += 1;
        for (int i = 0; i < Potager.GetLength(0); i++)
        {
            for (int j = 0; j < Potager.GetLength(1); j++)
            {
                if (Potager[i, j].Affichage == '%' && j < ColonnesDispos)
                {
                    Potager[i, j] = new SolSimple("Vierge");
                }
            }
        }
    }

    public double RecupererTemperature(int saison)
    {
        return Temperature[saison] * GenererNombreAleatoire(0.8, 1.2, 1);
    }
    public double RecupererPluie(int saison)
    {
        return Pluie[saison] * GenererNombreAleatoire(0.8, 1.2, 1);
    }
    public double RecupererHumidite(int saison)
    {
        return Humidite[saison];
    }
    public double RecupererEnsoleillement(int saison)
    {
        return Ensoleillement[saison];
    }


    public void Planter(Plante plante, int a, int b)
    {
        if (Potager[a, b].Affichage == '•')
        {
            Potager[a, b] = plante;
        }
        else
        {
            Console.WriteLine("Il n'est pas possible de planter à cette position");
        }

    }

    public int[] Recolter()
    {
        int[] recolte = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        for (int i = 0; i < Potager.GetLength(0); i++)
        {
            for (int j = 0; j < Potager.GetLength(1); j++)
            {
                switch (Potager[i, j].Affichage)
                {
                    case 'A':
                        recolte[0] += 1;
                        Potager[i, j] = new SolSimple("Vierge");
                        break;
                    case 'B':
                        recolte[1] += 1;
                        Potager[i, j] = new SolSimple("Vierge");
                        break;
                    case 'C':
                        recolte[2] += 1;
                        Potager[i, j] = new SolSimple("Vierge");
                        break;
                    case 'D':
                        recolte[3] += 1;
                        Potager[i, j] = new SolSimple("Vierge");
                        break;
                    case 'E':
                        recolte[4] += 1;
                        Potager[i, j] = new SolSimple("Vierge");
                        break;
                    case 'F':
                        recolte[5] += 1;
                        Potager[i, j] = new SolSimple("Vierge");
                        break;
                    case 'G':
                        recolte[6] += 1;
                        Potager[i, j] = new SolSimple("Vierge");
                        break;
                    case 'H':
                        recolte[7] += 1;
                        Potager[i, j] = new SolSimple("Vierge");
                        break;
                    case 'I':
                        recolte[8] += 1;
                        Potager[i, j] = new SolSimple("Vierge");
                        break;
                    case 'J':
                        recolte[9] += 1;
                        Potager[i, j] = new SolSimple("Vierge");
                        break;
                    case 'M':
                        recolte[10] += 1;
                        Potager[i, j] = new SolSimple("Vierge");
                        break;
                    case 'N':
                        recolte[11] += 1;
                        Potager[i, j] = new SolSimple("Vierge");
                        break;
                    case 'P':
                        recolte[12] += 1;
                        Potager[i, j] = new SolSimple("Vierge");
                        break;
                    case 'K':
                        recolte[13] += 1;
                        Potager[i, j] = new SolSimple("Vierge");
                        break;
                    case 'Z':
                        recolte[14] += 1;
                        Potager[i, j] = new SolSimple("Vierge");
                        break;
                    default:
                        break;
                }
            }
        }
        return recolte;
    }
    public void DetruirePlante(int a, int b)
    {
        Potager[a, b]= new SolSimple("Vierge");
    }

    public void Labourer(int a, int b)
    {
        if (Potager[a, b].Affichage == '/')
        {
            Potager[a, b] = new SolSimple("Laboure");
        }
        else
        {
            Console.WriteLine("Il n'est pas possible de planter à cette position");
        }
    }
    public virtual void VerifTerrain(Terrain terrain, int saison)
    {
        terrain.Temperature[4] = RecupererTemperature(saison);
        terrain.Humidite[4] = RecupererHumidite(saison);
        terrain.Pluie[4] = RecupererPluie(saison);
        terrain.Ensoleillement[4] = RecupererEnsoleillement(saison);
        for (int i = 0; i < Potager.GetLength(0); i++)
        {
            for (int j = 0; j < Potager.GetLength(1); j++)
            {
                if (Potager[i, j] is PlanteSimple plante)
                {
                    plante.SimulerCroissance(terrain, i, j);
                }
            }
        }
    }

}
public class TerrainSimple : Terrain
{
    public TerrainSimple(string nom) : base()
    {
        switch (nom)
        {
            case "Plaines Paisibles":
                Temperature = [15, 25, 21, 10, 15];
                Humidite = [20, 10, 15, 20, 20];
                Pluie = [28, 14, 42, 56, 28];
                Ensoleillement = [8, 10, 7, 5, 8];
                Nom = nom;
                break;
            case "Foret Facetieuse":
                Temperature = [12, 21, 17, 8, 12];
                Humidite = [40, 20, 30, 40, 40];
                Pluie = [28, 14, 42, 56, 28];
                Ensoleillement = [5, 8, 5, 3, 5];
                Nom = nom;
                break;
            case "Volcan Violent":
                Temperature = [37, 18, 26, 44, 37];
                Humidite = [10, 15, 15, 5, 10];
                Pluie = [35, 49, 21, 7, 35];
                Ensoleillement = [7, 5, 8, 10, 7];
                Nom = nom;
                break;
            default:
                Temperature = [31];
                Humidite = [48];
                Pluie = [33];
                Ensoleillement = [81];
                Nom = nom;
                break;
        }
    }
}



public class TerrainMine : Terrain
{
    public TerrainMine() : base()
    {
        Temperature = [30, 30, 18, 18, 30];
        Humidite = [0, 0, 0, 0, 0];
        Pluie = [0, 0, 14, 28, 0];
        Ensoleillement = [14, 14, 8, 8, 14];
        Nom = "Desert Delicat";
    }
    public override void VerifTerrain(Terrain terrain, int saison)
    {
        base.VerifTerrain(terrain, saison);
        for (int i = 0; i < Potager.GetLength(0); i++)
        {
            for (int j = 0; j < Potager.GetLength(1); j++)
            {
                Random rng = new Random();
                int chance = rng.Next(0, 256);
                if (chance == 13)
                {
                    Potager[i, j] = new SolSimple("Friche");
                    DetruirePlante(i, j);
                }
            }
        }
    }
}
public class TerrainAJachere : Terrain
{
    public int[,] Jachere;

    public TerrainAJachere() : base()
    {
        Temperature = [25, 18, 18, 25, 25];
        Humidite = [65, 95, 95, 65, 65];
        Pluie = [56, 42, 70, 84, 56];
        Ensoleillement = [8, 10, 7, 5, 8];
        Nom = "Marecages Malins";
        Jachere = new int[Potager.GetLength(0), Potager.GetLength(1)];
        for (int i = 0; i < Potager.GetLength(0); i++)
        {
            for (int j = 0; j < Potager.GetLength(1); j++)
            {
                Jachere[i, j] = 0;
            }
        }
    }
    public override void VerifTerrain(Terrain terrain, int saison)
    {
        base.VerifTerrain(terrain, saison);
        for (int i = 0; i < Potager.GetLength(0); i++)
        {
            for (int j = 0; j < Potager.GetLength(1); j++)
            {
                if (Potager[i, j].Affichage == '/')
                {
                    Potager[i, j] = new SolSimple("Jachère");
                    Jachere[i, j] = 5;
                }
                if (Jachere[i, j] == 1)
                {
                    Potager[i, j] = new SolSimple("Laboure");
                }
                else if (Jachere[i, j] > 0)
                {
                    Jachere[i, j]--;
                }
            }
        }
    }
}

