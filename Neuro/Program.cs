using System;

namespace Neuro
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] ipt = {1, 0};
            var network = new Network(ipt);
            for (var i = 0; i < 100; i++) network.think();
            Console.ReadLine();
            ipt[0] = 0;
            ipt[1] = 1;
            network.ChangeInputs(ipt);
            for (var i = 0; i < 100; i++) network.think();
            Console.ReadLine();
            ipt[1] = 0;
            ipt[1] = 1;
            network.ChangeInputs(ipt);
            for (var i = 0; i < 100; i++) network.think();
            Console.ReadLine();
            ipt[0] = 0;
            ipt[1] = 1;
            network.ChangeInputs(ipt);
            for (var i = 0; i < 100; i++) network.think();
            Console.ReadLine();
        }
    }
}