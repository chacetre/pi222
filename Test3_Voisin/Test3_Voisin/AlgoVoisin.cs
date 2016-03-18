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
            //int minpt = 0;
            //int minobj = 0; 
            Double select = 0.5;
            Point pinit = groupe[0];
            voisin.Add(pinit);
            int counter = 0;

            foreach (Point p in groupe)
            {
                Double a = (pinit.X - p.X);
                Double b = (pinit.Y - p.Y);
                Double c = (pinit.Z - p.Z);
                Double dist = Math.Sqrt(a * a + b * b + c * c);

                if (dist <= select)
                {
                    voisin.Add(p);
                    Console.WriteLine(p.ToString());
                    counter++;
                    //groupe.Remove(p);
                }
            }
            System.Console.WriteLine("il y a {0} points", counter);

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
