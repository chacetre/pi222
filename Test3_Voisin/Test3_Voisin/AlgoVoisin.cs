using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3_Voisin
{
    class AlgoVoisin
    {
        private List<Point> groupe = new List<Point>();
        private List<Point> voisin = new List<Point>();
        private List<Point> obj = new List<Point>(); // Ajout de la liste obj 

        public void LireFichier()
        {
            //int counter = 0;
            string line;
            int i = 0;
            
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\Marjorie\Desktop\PI²\object simple ex\C_002.txt");
            while ((line = file.ReadLine()) != null)
            {
                if (i <= 10)
                {
                    line = line.Replace('.', ',');
                    string[] trop = line.Split(' ');
                    i++;
                    Console.WriteLine(trop);
                }

                else
                {
                    line = line.Replace('.', ',');
                    string[] words = line.Split('\t', ' ');
                    List<double> coord = new List<double>();
                    coord.Add(Convert.ToDouble(words[0]));
                    coord.Add(Convert.ToDouble(words[1]));
                    coord.Add(Convert.ToDouble(words[2]));
                    Point p = new Point(coord);
                    groupe.Add(p);
                    i++;
                }
            }


            file.Close();

            System.Console.WriteLine("Fichier lu");

            System.Console.ReadLine();

        }

        // test modif

        public void Trie_voisin()
        {
            LireFichier();


            Random r = new Random();
            int i = 1;
            while (groupe != null)
            {
            int rPoint = r.Next(1, 100); // nb entre 1 et 99
                                             //int count = 0;

                string titreFichier = "listeVoisin" + Convert.ToString(i);

            Point pInit = groupe[rPoint];
                pInit.R = 255;
                pInit.G = 0;
                pInit.B = 0;
                voisin.Add(pInit);
                groupe.RemoveAt(rPoint);

                RechercherVoisin(pInit, groupe, 0);

                EcrireFichier(voisin, titreFichier);
                //EcrireFichier(obj, "listeObjet");

                voisin.Clear();
                i++;

            }
            // faire ca tant qu'il y a des point dans groupe 
            // il faut donc faire un remove de la liste

        }

        public void RechercherVoisin(Point pInit, List<Point> listPoint, int count)
        {
            double pas = 0.01;
            List<int> val = new List<int>();
            for (int i = 0; i < voisin.Count(); i++)  //trouver un moyen d'enle
            {
                pInit = voisin[i];
            foreach (Point p in listPoint)
            {
                double distance = DistanceE(p, pInit);
                if (distance < pas)
                {
                    voisin.Add(p);
                        val.Add(listPoint.IndexOf(p));
                    Console.WriteLine("ajouter !");
                    }
                }
                Console.WriteLine("tour " + i);
                val.Reverse();
                foreach (int x in val)
                {
                    listPoint.RemoveAt(x);
                }
                val.Clear();
                    }

                }
                
        

        public void CreationObjet(List<Point> list, List<Point> objet) //Ajout de la fonction 
        {
            int conteur = 0;
            objet.Add(list[0]);
            int taille = objet.Count();
            foreach (Point p in list)
            {
                for (int i = 0; i < taille; i++)
                {
                    if (p.EstEgale(objet[i]) == false)
                    {
                        conteur = conteur + 1;
                    }
            }
                if (conteur == taille)
                {
                    objet.Add(p);
                    Console.WriteLine("obj ok");

                    taille++;
                }
                conteur = 0;
            }
        }

        public double DistanceE(Point p1, Point p2)
        {
            double distance = 0.0;

            for (int i = 0; i < 3; i++)
            {
                distance += Math.Pow((p1.Coordonees[i] - p2.Coordonees[i]), 2.0);
            }

            distance = Math.Sqrt(distance);
            return distance;
        }

        public void EcrireFichier(List<Point> aEcrire, String nomFichier) // Modification de la fonction Ecrire Fichier 
        {
            string titre = nomFichier + ".txt";
            System.IO.StreamWriter fichierPourEcrire = new System.IO.StreamWriter(titre);
            foreach (Point g in aEcrire)
            {
                String s = g.ToString();
                s.Replace(',', '.');
                fichierPourEcrire.WriteLine(s);

            }
            fichierPourEcrire.Close();
            Console.WriteLine("Bien reçu");
            Console.WriteLine(titre); 
        }
    }
}
