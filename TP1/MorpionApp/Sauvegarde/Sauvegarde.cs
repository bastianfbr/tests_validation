using MorpionApp.Jeux.Communs;

using System.Text.Json;

namespace MorpionApp.Sauvegarde
{
    public class SauvegardeJeu
    {
        private readonly EtatJeu etatJeu;
        private readonly string typeJeu;
        private readonly bool estJoueurIA;

        public SauvegardeJeu(EtatJeu etatJeu, string typeJeu, bool estJoueurIA)
        {
            this.etatJeu = etatJeu;
            this.typeJeu = typeJeu;
            this.estJoueurIA = estJoueurIA;
        }

        public void Sauvegarder()
        {
            var grilleList = GrilleToList(etatJeu.Grille);
            var sauvegarde = new
            {
                grille = grilleList,
                typeJeu,
                estJoueurIA
            };
            var json = JsonSerializer.Serialize(sauvegarde);
            File.WriteAllText("sauvegarde.json", json);
        }
        

        public static (EtatJeu etatJeu, string typeJeu, bool estJoueurIA) Charger()
        {
            var json = File.ReadAllText("sauvegarde.json"); 
            System.Console.WriteLine(json);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var sauvegarde = JsonSerializer.Deserialize<SauvegardeDonnees>(json, options);

            if (sauvegarde == null)
            {
                throw new InvalidOperationException("La désérialisation de la sauvegarde a échoué.");
            }

            var etatJeu = ListToGrille(sauvegarde.Grille);
            return (etatJeu, sauvegarde.TypeJeu, sauvegarde.EstJoueurIA);
        }


        
        private static List<string> GrilleToList(char[,] grille)
        {
            var list = new List<string>();
            for (int i = 0; i < grille.GetLength(0); i++)
            {
                var row = "";
                for (int j = 0; j < grille.GetLength(1); j++)
                {
                    row += grille[i, j];
                }
                list.Add(row);
            }
            return list;
        }

        private static EtatJeu ListToGrille(List<string> list)
        {
            if (list == null || list.Count == 0)
            {
                throw new ArgumentException("La liste fournie est vide ou null.");
            }

            int lignes = list.Count;
            int colonnes = list[0].Length;
            var etatJeu = new EtatJeu(lignes, colonnes);

            for (int i = 0; i < lignes; i++)
            {
                for (int j = 0; j < colonnes; j++)
                {
                    if (list[i].Length >= j)
                    {
                        etatJeu.Grille[i, j] = list[i][j];
                    }
                    else
                    {
                        etatJeu.Grille[i, j] = ' ';
                    }
                }
            }

            return etatJeu;
        }




    }
}
