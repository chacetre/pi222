using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3_Voisin
{
    class AlgoVoisin
    {

        /* Coucou, alors j'ai créer le cube et essayer de faire une recherche de voisin avec. Mais j'ai pas pu la teste
        je pense qu'il y a quelque probleme et j'ai pas tout compris comment tu avais fait ta recherche de voisin mais
        j'ai quand meme copier tu as fait pour pas tout casse j'ai creer une nouvelle fonction */

        private List<Point> groupe = new List<Point>();
        private List<Point> voisin = new List<Point>();
        private List<Point> obj = new List<Point>(); // Ajout de la liste obj 
        List<Cube> cubeGeant = new List<Cube>(); // liste des cubes du cubeGeant

        // Pour definir le cube Geant 
        double miniX;
        double miniY;
        double miniZ;

        double maxX;
        double maxY;
        double maxZ;
        // ------------------------------

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

        public void RechercheMaxMin()
        {
            Random r = new Random();
            int rPoint = r.Next(1, 100);
            Point pInit = groupe[rPoint];

            double miniX = pInit.Coordonees[0];
            double miniY = pInit.Coordonees[1];
            double miniZ = pInit.Coordonees[2];

            double maxX = pInit.Coordonees[0];
            double maxY = pInit.Coordonees[1];
            double maxZ = pInit.Coordonees[2];

            foreach (Point p in groupe)
            {
                miniX = Math.Min(miniX, p.Coordonees[0]);
                miniY = Math.Min(miniY, p.Coordonees[1]);
                miniZ = Math.Min(miniZ, p.Coordonees[2]);

                maxX = Math.Min(maxX, p.Coordonees[0]);
                maxY = Math.Min(maxY, p.Coordonees[1]);
                maxZ = Math.Min(maxZ, p.Coordonees[2]);
            }

            Console.ReadKey();
        }

        public void GenererCube()
        {
            double p = 0.1;
            int coordI = 0;
            int coordJ = 0;
            int coordK = 0;

            for (double i = miniX; i < maxX; i += p)
            {
                for (double j = miniY; i < maxY; j += p)
                {
                    for (double k = miniZ; i < maxZ; k += p)
                    {
                        Point miniTemp = new Point(i, j, k);
                        Point maxTemp = new Point(i + p, j + p, k + p);

                        List<int> coordoCube = new List<int>();
                        coordoCube.Add(coordI);
                        coordoCube.Add(coordJ);
                        coordoCube.Add(coordK);

                        Cube cubeTemp = new Cube(miniTemp, maxTemp, coordoCube);
                        cubeGeant.Add(cubeTemp);

                        coordK++;
                    }
                    coordJ++;
                }
                coordI++;
            }

        }

        public void PlacerPoint()
        {
            foreach (Point p in groupe)
            {
                foreach (Cube c in cubeGeant)
                {
                    if (c.Min.Coordonees[0] < p.Coordonees[0] && p.Coordonees[0] < c.Max.Coordonees[0])
                    {
                        if (c.Min.Coordonees[1] < p.Coordonees[1] && p.Coordonees[1] < c.Max.Coordonees[1])
                        {
                            if (c.Min.Coordonees[2] < p.Coordonees[2] && p.Coordonees[2] < c.Max.Coordonees[2])
                            {
                                p.Cluster = c;
                                c.Contenue.Add(p);
                            }
                        }
                    }
                }
            }
        }

        public void TrieVoisinCube() // recherche des voisins avec la methode du cube
        {
            

            LireFichier(); // on enregistre les donnee
            // --- Creation des cubes ---
            RechercheMaxMin(); //
            GenererCube();
            //--- Classement des points dans les cubes
            PlacerPoint();

            while (groupe != null)
            {
                Random r = new Random();
                int rPoint = r.Next(1, 10000); // index du point
                Point pInit = groupe[rPoint]; // point initial
                pInit.R = 255;
                pInit.G = 0;
                pInit.B = 0;
                List<Cube> cubevoisin = ChercherCubeVoisin(pInit);
                int i = 1;           

                string titreFichier = "listeVoisin" + Convert.ToString(i);

                
                voisin.Add(pInit);
                groupe.RemoveAt(rPoint);

                RechercherVoisin2(pInit, cubevoisin, 0);

                EcrireFichier(voisin, titreFichier);
                //EcrireFichier(obj, "listeObjet");

                voisin.Clear();
                i++;

            }

        }

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
            for (int i = 0; i < voisin.Count(); i++)  //trouver un moyen d'enlever
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

        public void RechercherVoisin2(Point pInit, List<Cube> listCubeVoisin, int count)
        {
            double pas = 0.01;
            List<int> val = new List<int>();
            for (int i = 0; i < voisin.Count(); i++)  //trouver un moyen d'enlever
            {
                pInit = voisin[i];
                foreach (Cube c in listCubeVoisin)
                {
                    foreach (Point p in c.Contenue)
                    {
                        double distance = DistanceE(p, pInit);
                        if (distance < pas)
                        {
                            voisin.Add(p);
                            val.Add(c.Contenue.IndexOf(p));
                            Console.WriteLine("ajouter !");
                        }
                    }

                    Console.WriteLine("tour " + i);
                    val.Reverse();
                    foreach (int x in val)
                    {
                        c.Contenue.RemoveAt(x);
                    }
                    val.Clear();
                }
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

        public List<Cube> ChercherCubeVoisin(Point p)
        {
            List<Cube> listTemp = new List<Cube>();
            Cube init = p.Cluster;

            foreach (Cube c in cubeGeant)
            {
                if (c.Coordonee[0] == init.Coordonee[0] || c.Coordonee[0] == init.Coordonee[0] - 1 || c.Coordonee[0] == init.Coordonee[0] + 1)
                {
                    if (c.Coordonee[1] == init.Coordonee[1] || c.Coordonee[1] == init.Coordonee[1] - 1 || c.Coordonee[1] == init.Coordonee[1] + 1)
                    {
                        if (c.Coordonee[2] == init.Coordonee[2] || c.Coordonee[2] == init.Coordonee[2] - 1 || c.Coordonee[2] == init.Coordonee[2] + 1)
                        {
                            listTemp.Add(c);
                        }
                    }
                }
            }

            return listTemp;

        }
    }
}
