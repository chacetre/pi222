﻿using System;
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

        public override string ToString()
        {
            return (Convert.ToString(Coordonees[0]) + " " + Convert.ToString(Coordonees[1]) + " " + Convert.ToString(Coordonees[2]) + " " + Convert.ToString(r) + " " + Convert.ToString(g) + " " + Convert.ToString(b));
        }

        public bool EstEgale(Point p)  //Création de la fonction 
        {
            if (this.Coordonees[0] == p.Coordonees[0] && this.Coordonees[1] == p.Coordonees[1] && this.Coordonees[2] == p.Coordonees[2])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
