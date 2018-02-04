using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
namespace Neuro
{
    class Network
    {
        List<Neuron> network = new List<Neuron>();
        int size = 500;
        public Network()
        {
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                network.Add(new Neuron(i, rnd, size));
            }
            for(int i = 0; i < size; i++)
            {
                int counter = 0;
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        if (network[j].connections[k] == i) counter++;
                    }
                    if (j < 10) counter++;
                }
                network[i].SetInputs(counter, rnd);
            }
        }
        public void Show()
        {
            foreach(var i in network)
            {
                i.Show();
            }
        }
        public void think(List<int> into)
        {
            List<int> inputs = new List<int>();
            while(true)
            {
                for (int i = 0; i < size; i++)
                {
                    inputs.Clear();
                    if (i < 10) inputs.Add(into[i]);
                    for (int j = 0; j < size; j++)
                    {
                        for (int k = 0; k < 10; k++)
                        {
                            if (network[j].connections[k] == i) inputs.Add(network[j].value);
                        }
                    }
                    network[i].calculate(inputs);
                    Console.Write(network[i].value + " ");
                    
                }
                Thread.Sleep(100);
                Console.Clear();
            }  
        }
    }
}