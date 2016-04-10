using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3_Voisin
{
    class Program
    {
        static void Main(string[] args)
        {
            AlgoVoisin Algo = new AlgoVoisin();
            Algo.TrieVoisinCube();

            Console.ReadKey();
        }
    }
}
