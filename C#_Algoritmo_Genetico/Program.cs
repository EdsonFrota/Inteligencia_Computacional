using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmo_Genetico
{
    class Program
    {
        static void Main(string[] args)
        {
            A_G run = new A_G();
            run.constroi();
            run.info();
            Console.ReadLine();
        }
        
    }
}
