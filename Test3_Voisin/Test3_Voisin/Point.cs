using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3_Voisin
{
    class Point
    {
        List<double> coordonees;
        private int r;
        private int g;
        private int b;

        public Point(List<double> coordonees)
        {
            this.coordonees = coordonees;
            this.r = 1;
            this.g = 1;
            this.b = 1;
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

        public override string ToString()
        {
            return (Convert.ToString(Coordonees[0]) + " " + Convert.ToString(Coordonees[1]) + " " + Convert.ToString(Coordonees[2]) + " " + Convert.ToString(R) + " " + Convert.ToString(G) + " " + Convert.ToString(B));
        }
    }
}
