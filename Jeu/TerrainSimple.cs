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