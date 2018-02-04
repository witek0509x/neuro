using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neuro
{
    class Program
    {
        static void Main(string[] args)
        {
            Network network = new Network();
            List<int> inputs = new List<int>();
            inputs.Add(1);
            inputs.Add(0);
            inputs.Add(1);
            inputs.Add(0);
            inputs.Add(1);
            inputs.Add(0);
            inputs.Add(1);
            inputs.Add(0);
            inputs.Add(1);
            inputs.Add(0);
            network.think(inputs);
            Console.ReadLine();
        }
    }
}
