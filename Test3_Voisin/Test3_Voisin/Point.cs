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
        private List<double> Coordonees = new List<double>(); 

        public Point(List<double> coordonnees)
        {
            this.Coordonees = coordonnees;
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

        public List<double> Coordonees1
        {
            get
            {
                return Coordonees;
            }

            set
            {
                Coordonees = value;
            }
        }

        public override string ToString()
        {
            return (Convert.ToString(x) + " " + Convert.ToString(y) + " " + Convert.ToString(z) + " " + Convert.ToString(r) + " " + Convert.ToString(g) + " " + Convert.ToString(b));
        }

        
    }
}
