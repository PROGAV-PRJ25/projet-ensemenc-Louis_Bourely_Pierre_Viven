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
    }
    
    

    public int[] Recolter()
    {
        int[] recolte = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        string caseNew = "Vierge";
        if (Nom == "Marecages Malins")
        {
            caseNew = "Jachère";
        }
        for (int i = 0; i < Potager.GetLength(0); i++)
        {
            for (int j = 0; j < Potager.GetLength(1); j++)
            {
                switch (Potager[i, j].Affichage)
                {
                    case 'A':
                        recolte[0] += 1;
                        Potager[i, j] = new SolSimple(caseNew);
                        break;
                    case 'B':
                        recolte[1] += 1;
                        Potager[i, j] = new SolSimple(caseNew);
                        break;
                    case 'C':
                        recolte[2] += 1;
                        Potager[i, j] = new SolSimple(caseNew);
                        break;
                    case 'D':
                        recolte[3] += 1;
                        Potager[i, j] = new SolSimple(caseNew);
                        break;
                    case 'E':
                        recolte[4] += 1;
                        Potager[i, j] = new SolSimple(caseNew);
                        break;
                    case 'F':
                        recolte[5] += 1;
                        Potager[i, j] = new SolSimple(caseNew);
                        break;
                    case 'G':
                        recolte[6] += 1;
                        Potager[i, j] = new SolSimple(caseNew);
                        break;
                    case 'H':
                        recolte[7] += 1;
                        Potager[i, j] = new SolSimple(caseNew);
                        break;
                    case 'I':
                        recolte[8] += 1;
                        Potager[i, j] = new SolSimple(caseNew);
                        break;
                    case 'J':
                        recolte[9] += 1;
                        Potager[i, j] = new SolSimple(caseNew);
                        break;
                    case 'M':
                        recolte[10] += 1;
                        Potager[i, j] = new SolSimple(caseNew);
                        break;
                    case 'N':
                        recolte[11] += 1;
                        Potager[i, j] = new SolSimple(caseNew);
                        break;
                    case 'P':
                        recolte[12] += 1;
                        Potager[i, j] = new SolSimple(caseNew);
                        break;
                    case 'K':
                        recolte[13] += 1;
                        Potager[i, j] = new SolSimple(caseNew);
                        break;
                    case 'Z':
                        recolte[14] += 1;
                        Potager[i, j] = new SolSimple(caseNew);
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
    }
    public virtual void VerifTerrain(Terrain terrain, int saison)
    {
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
        terrain.Temperature[4] = Math.Round(RecupererTemperature(saison),1);
        terrain.Humidite[4] = Math.Round(RecupererHumidite(saison),1);
        terrain.Pluie[4] = Math.Round(RecupererPluie(saison),1);
        terrain.Ensoleillement[4] = Math.Round(RecupererEnsoleillement(saison),1);
    }

}