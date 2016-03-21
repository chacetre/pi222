using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3_Voisin
{
    class Point
    {
        private Double x;
        private Double y;
        private Double z;
        private int r;
        private int g;
        private int b;
        private List<double> Coordonees = new List<double>(); 

        public Point(Double x, Double y, Double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.R = 1;
            this.G = 1;
            this.B = 1;
            Coordonees1.Add(x);
            Coordonees1.Add(y);
            Coordonees1.Add(z);

        }

        public double X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public double Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        public double Z
        {
            get
            {
                return z;
            }

            set
            {
                z = value;
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
