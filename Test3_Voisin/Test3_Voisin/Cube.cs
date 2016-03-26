using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3_Voisin
{
    class Cube
    {
        Point min;
        Point max;
        List<int> coordonee;
        List<Point> contenue = new List<Point>();

        public Cube(Point min, Point max, List<int> coordonee)
        {
            this.min = min;
            this.max = max;
            this.coordonee = coordonee;
        }

        internal Point Min
        {
            get
            {
                return min;
            }

            set
            {
                min = value;
            }
        }

        internal Point Max
        {
            get
            {
                return max;
            }

            set
            {
                max = value;
            }
        }

        public List<int> Coordonee
        {
            get
            {
                return coordonee;
            }

            set
            {
                coordonee = value;
            }
        }

        internal List<Point> Contenue
        {
            get
            {
                return contenue;
            }

            set
            {
                contenue = value;
            }
        }

        public void Devient(Cube c)
        {
            this.min = c.Min;
            this.max = c.Max;
            this.coordonee[0] = c.Coordonee[0];
            this.coordonee[1] = c.Coordonee[1];
            this.coordonee[2] = c.Coordonee[2];
        }
    }
}
