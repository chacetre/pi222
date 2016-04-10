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
            string line;
            int i = 0;

            System.IO.StreamReader file = new System.IO.StreamReader("./../../../C_061.txt");
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

            System.Console.ReadKey();

        }

        public void RechercheMaxMin()
        {
            Random r = new Random();
            int rPoint = r.Next(1, 100);
            Point pInit = groupe[rPoint];

            miniX = pInit.Coordonees[0];
            miniY = pInit.Coordonees[1];
            miniZ = pInit.Coordonees[2];

            maxX = pInit.Coordonees[0];
            maxY = pInit.Coordonees[1];
            maxZ = pInit.Coordonees[2];

            foreach (Point p in groupe)
            {
                miniX = Math.Min(miniX, p.Coordonees[0]);
                miniY = Math.Min(miniY, p.Coordonees[1]);
                miniZ = Math.Min(miniZ, p.Coordonees[2]);

                maxX = Math.Max(maxX, p.Coordonees[0]);
                maxY = Math.Max(maxY, p.Coordonees[1]);
                maxZ = Math.Max(maxZ, p.Coordonees[2]);
            }
            Console.WriteLine(miniX + "; " + miniY + "; " + miniZ);
            Console.WriteLine(maxX + "; " + maxY + "; " + maxZ);
            //Console.ReadKey();
        }

        public void GenererCube()
        {
            double p = 5;
            int coordI = 0;
            int coordJ = 0;
            int coordK = 0;
            int nbCube = 0;

            for (double i = miniX; i < maxX; i += p)
            {
                for (double j = miniY; j < maxY; j += p)
                {
                    for (double k = miniZ; k < maxZ; k += p)
                    {
                        Point miniTemp = new Point(i, j, k);
                        Point maxTemp = new Point(i + (coordK * p) + p, j + (coordK * p) + p, k + (coordK * p) + p);

                        List<int> coordoCube = new List<int>();
                        coordoCube.Add(coordI);
                        coordoCube.Add(coordJ);
                        coordoCube.Add(coordK);

                        Cube cubeTemp = new Cube(miniTemp, maxTemp, coordoCube);
                        cubeGeant.Add(cubeTemp);
                        
                        nbCube++;
                        coordK++;
                    }
                    coordK = 0;
                    coordJ++;
                }
                coordJ = 0;
                coordI++;
            }
            Console.WriteLine("il y a {0} cubes", nbCube);
        }

        public void PlacerPoint()
        {
            int count = 0;
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
                                p.CoordCluster = c.Coordonee;
                                c.Contenue.Add(p);
                                count++;
                                Console.WriteLine(count);
                                Console.WriteLine("dans cube !");
                                break;
                            }
                        }
                    }
                }
            }

        }

        public void TrieVoisinCube() // recherche des voisins avec la methode du cube
        {
            LireFichier(); // on enregistre les donnees
            // --- Creation des cubes ---
            RechercheMaxMin(); //
            GenererCube();
            //--- Classement des points dans les cubes
            PlacerPoint();

            int i = 1;
            while (groupe != null)
            {
                Random r = new Random();
                int rPoint = r.Next(1, groupe.Count); // index du point
                Point pInit = groupe[0]; // point initial
                pInit.R = 255;
                pInit.G = 0;
                pInit.B = 0;

                List<Cube> cubevoisin = ChercherCubeVoisin(pInit);

                voisin.Add(pInit);
                groupe.RemoveAt(0);

                RechercherVoisin2(pInit, cubevoisin, 0);

                string titreFichier = "listeVoisin" + Convert.ToString(i);
                EcrireFichier(voisin, titreFichier);
                //EcrireFichier(obj, "listeObjet");
                voisin.Clear();
                i++;
            }

        }

        public void RechercherVoisin2(Point pInit, List<Cube> listCubeVoisin, int count)
        {
            double pas = 0.01;

            List<int> val = new List<int>();
            List<int> valGr = new List<int>();
            int ind = 0;
            for (int i = 0; i < voisin.Count(); i++)
            {
                pInit = voisin[i];
                foreach (Cube c in listCubeVoisin)
                {
                    if(c.Contenue.Contains(pInit) == true)
                    {
                        ind = c.Contenue.IndexOf(pInit);
                        c.Contenue.RemoveAt(ind);
                    }
                    foreach (Point p in c.Contenue)
                    {
                        double distance = DistanceE(p, pInit);
                        if (distance < pas)
                        {
                            voisin.Add(p);
                            valGr.Add(groupe.IndexOf(p));
                            val.Add(c.Contenue.IndexOf(p));
                           Console.Write(".");
                        }
                    }

                    //Console.WriteLine("tour "+ i);
                    val.Reverse();
                    valGr.Reverse();
                    foreach (int x in val)
                    {
                        c.Contenue.RemoveAt(x);
                    }
                    foreach (int g in valGr)
                    {
                        groupe.RemoveAt(g);
                }
                    val.Clear();
                    valGr.Clear();
                }
            }
            Console.WriteLine("il y a {0} voisin", voisin.Count());
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
            System.IO.StreamWriter fichierPourEcrire = new System.IO.StreamWriter("./../../../FichierPoint/"+titre);

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
            List<int> init = p.CoordCluster;
            foreach (Cube c in cubeGeant)
            {
                if (c.Coordonee[0] == init[0] || c.Coordonee[0] == init[0] -1 || c.Coordonee[0] == init[0]+1)
                {
                    if (c.Coordonee[1] == init[1] || c.Coordonee[1] == init[1] - 1 || c.Coordonee[1] == init[1] + 1)
                    {
                        if (c.Coordonee[2] == init[2] || c.Coordonee[2] == init[2] - 1 || c.Coordonee[2] == init[2] + 1)
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
