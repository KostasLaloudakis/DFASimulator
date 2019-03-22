using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFASimulator1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader stream = new StreamReader(args[0], Encoding.Default);
            DFASimulation.Simulation(stream);

            stream.Close();
        }
    }
}
