using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3_Voisin
{
    class Point
    {
      
        private int r;
        private int g;
        private int b;
        private List<double> coordonees = new List<double>();
        List<int> coordCluster = new List<int>();

        public Point(List<double> coordonnees)
        {
            this.coordonees = coordonnees;
            this.R = 1;
            this.G = 1;
            this.B = 1;
            this.CoordCluster.Add(0); this.CoordCluster.Add(0); this.CoordCluster.Add(0);

        }

        public Point(double x , double y , double z)
        {
            List<double> coordTemp = new List<double>();
            coordTemp.Add(x);
            coordTemp.Add(y);
            coordTemp.Add(z);

            this.coordonees = coordTemp;
            this.R = 1;
            this.G = 1;
            this.B = 1;

        }


        public int R
        {
            get
            {
                return r;
            }

            set
            {
                r = value;
            }
        }

        public int G
        {
            get
            {
                return g;
            }

            set
            {
                g = value;
            }
        }

        public int B
        {
            get
            {
                return b;
            }

            set
            {
                b = value;
            }
        }

        public List<double> Coordonees
        {
            get
            {
                return coordonees;
            }

            set
            {
                coordonees = value;
            }
        }

        public List<int> CoordCluster
        {
            get
            {
                return coordCluster;
            }

            set
            {
                coordCluster = value;
            }
        }

        public override string ToString()
        {
            return (Convert.ToString(Coordonees[0]) + " " + Convert.ToString(Coordonees[1]) + " " + Convert.ToString(Coordonees[2]) + " " + Convert.ToString(r) + " " + Convert.ToString(g) + " " + Convert.ToString(b));
        }
       
    }
}
