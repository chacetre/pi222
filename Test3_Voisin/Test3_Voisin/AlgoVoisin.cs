﻿using System;
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
                    Point p = new Point(Convert.ToDouble(words[0]), Convert.ToDouble(words[1]), Convert.ToDouble(words[2]));
                    groupe.Add(p);
                    i++;
                }
            }


            file.Close();

            System.Console.WriteLine("Fichier lu");

            System.Console.ReadLine();

        }


        public void Trie_voisin()
        {
            LireFichier();

            Random r = new Random();
            int rPoint = r.Next(1, 100); // nb entre 1 et 99
            int count = 0;

            Point pInit = groupe[rPoint];

            RechercherVoisin(pInit, groupe, count);

            // faire ca tant qu'il y a des point dans groupe 
            // il faut donc faire un remove de la liste

        }

        public void RechercherVoisin(Point pInit, List<Point> listPoint, int count)
        {
            double pas = 0.5;
            count++;
            foreach (Point p in listPoint)
            {
                double distance = DistanceE(p, pInit);
                if ( count < 3 )
                {
                if (distance < pas)
                {
                    voisin.Add(p);
                    Console.WriteLine("ajouter !");
                        RechercherVoisin(p, listPoint , count);
                    }
                }
                
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

        public void EcrireFichier()
        {
            System.IO.StreamWriter fichierPourEcrire = new System.IO.StreamWriter("testAlgo.txt");
            foreach (Point g in voisin)
            {
                String s = g.ToString();
                s.Replace(',', '.');
                fichierPourEcrire.WriteLine(s);

            }
            fichierPourEcrire.Close();
            Console.WriteLine("Bien reçu");
        }
    }
}
