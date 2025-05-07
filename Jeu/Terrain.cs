public abstract class Terrain
{
    public double[] Temperature { get; set; }
    public double[] Humidite { get; set; }
    public double[] Pluie { get; set; }
    public double[] Ensoleillement { get; set; }

    public Plante[,] Potager { get; set; }
    public int ColonnesDispos { get; set; }

    public Terrain(double[] temperature, double[] humidite, double[] pluie, double[] ensoleillement)
    {
        Temperature = temperature;
        Humidite = humidite;
        Pluie = pluie;
        Ensoleillement = ensoleillement;

        ColonnesDispos = 10;
        Potager = new Plante[10, 20];
        for (int i = 0; i < Potager.GetLength(0); i++)
        {
            for (int j = 0; j < Potager.GetLength(1); j++)
            {
                if (j < ColonnesDispos)
                {
                    Potager[i, j] = new SolSimple("Vierge");
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

    public void AgrandirPotager(int nombreColonne)
    {
        ColonnesDispos += nombreColonne;
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

    public double RecupererTemprature(int saison)
    {
        return Temperature[saison] * GenererNombreAleatoire(0.8, 1.2, 1);
    }


    public double RecupererPluie(int saison)
    {
        return Pluie[saison] * GenererNombreAleatoire(0.8, 1.2, 1);
    }


    public void Planter(Plante plante, int a, int b)
    {
        if (Potager[a, b].Affichage == '•')
        {
            Potager[a, b] = plante;
        }
        else
        {
            Console.WriteLine("Il n'est pas possible de planter à cette condition");
        }

    }

    public int[] Recolter()
    {
        int[] recolte = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
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
                    case 'Q':
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
        Potager[a, b].Affichage = '/';
    }

}



public class TerrainSimple : Terrain
{
    public TerrainSimple(double[] temperature, double[] humidite, double[] pluie, double[] ensoleillement) : base(temperature, humidite, pluie, ensoleillement)
    {

    }

}
public class TerrainMiné : TerrainSimple
{
    public TerrainMiné(double[] temperature, double[] humidite, double[] pluie, double[] ensoleillement) : base(temperature, humidite, pluie, ensoleillement)
    {

    }
    public void VerifTerrain()
    {
        for (int i = 0; i < Potager.GetLength(0); i++)
        {
            for (int j = 0; j < Potager.GetLength(1); j++)
            {
                Random rng = new Random();
                int chance = rng.Next(0, 256);
                if (chance == 13)
                {
                    Potager[i, j] = new SolSimple("Friche");
                }
            }
        }
    }
}
public class TerrainAJachère : TerrainSimple
{
    public int?[,] Jachere;

    public TerrainAJachère(double[] temperature, double[] humidite, double[] pluie, double[] ensoleillement) : base(temperature, humidite, pluie, ensoleillement)
    {
        DemarrerJachère();
    }
    public void DemarrerJachère()
    {
        for (int i = 0; i < Potager.GetLength(0); i++)
        {
            for (int j = 0; j < Potager.GetLength(1); j++)
            {
                Jachere[i, j] = 0;
            }
        }
    }
    public void VerifTerrain()
    {

        for (int i = 0; i < Potager.GetLength(0); i++)
        {
            for (int j = 0; j < Potager.GetLength(1); j++)
            {
                if (Potager[i, j].Affichage == '/')
                {
                    Potager[i, j] = new SolSimple("Jachère");
                    Jachere[i, j] = 5;
                }
                if (Jachere[i, j] == 0)
                {
                    Potager[i, j] = new SolSimple("Laboure");
                }
                if (Jachere[i, j] != 5)
                {
                    Jachere[i, j]--;
                }
            }
        }
    }
}

