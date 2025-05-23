public class Partie  //Classe qui permet de stocker toutes les informations essentielles au déroulement du jeu
{
    public bool chenille = false; //Condition pour afficher le bulletin météo
    public string Nom { get; set; } //nom de la partie
    public double VerdaMoula { get; set; } //Argent du joueur
    public int Semaine { get; set; } //Semaine de jeu qui sert aussi à calculer la saison
    public int[] ListePlantes { get; set; } //Stocke le nombre de plantes récoltées
    public PlanteSimple[] ListeInfoPlantes { get; set; } //Stocke les informations relatives aux plantes pour les afficher et sert à en créer de nouvelle avec .Clone()
    public int[] ListeSemis { get; set; } //Stocke le nombre de semis disponibles
    public int[] ListeItems { get; set; } //Stocke le nombre d'items disponibles
    public Item[] ListeInfoItems { get; set; } //Stocke les informations des items pour les afficher
    public Terrain[] ListeTerrains { get; set; } //Stocke tous les terrains (en tableau car il reste dans un ordre précis et ne sont jamais supprimés ou ajoutés)


    public Partie(string nom) //Instancie une nouvelle partie avec les paramètres de bases (à changer si ajout de difficultés)
    {
        Nom = nom;
        VerdaMoula = 100;
        Semaine = 1;
        ListePlantes = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
        ListeSemis = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
        ListeItems = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
        ListeInfoItems = [
            new Item('R',"Raticidre", 3000,"Le Raticidre permet d'enivrer le Rat Mécréant pour le faire fuire de votre Potager."),             // [0]
            new Item('T',"TirDeFusil", 2500, "Le TirDeFusil tire un cri de Galinacée Hargneuse qui attire le Galinacé Hargneux loin de votre Potager"),            // [1]
            new Item('I',"InsecticideChenille", 1800, "L'InsecticideChenille protège votre Bulletin Météo contre la Cheeeeeniiiiiiillllle"),   // [2]
            new Item('M',"MegaItem", 2000,"Le MegaItem protège votre Plante à vie contre toutes les conditions"),              // [3]
            new Item('C',"CasqueTroué", 500,"Le CasqueTroué protège votre plante contre toutes les conditions pendant un Tour."),            // [4]
            new Item('P',"PotionMagique", 100,"La PotionMagique donne un effet aléatoir qu peut accèlérer la croissance la ralentir ou bien tuer la plante"),         // [5]
            new Item('E',"EngraisHyperactif", 1500,"L'EngraisHyperactif avance la Croissance d'une semaine"),     // [6]
            new Item('S',"SecàtoutHeure", 5000,"Le SecàtoutHeure permet de tailler les plantes"),              // [7]
            new Item('B',"Bêchhuuuuut", 20,"La Bêchhuuuuut permet de labourer une case d'un Terrain"),
            new Item('U',"UltraBêchhuuuuut",500,"L'UltraBêchhuuuuut permet de Labourer tous le potager d'un seul coup.")
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
