using System;
using System.Collections.Generic;

namespace Neuro
{
    internal class Network
    {
        private readonly List<Sensor> input = new List<Sensor>();
        private readonly List<Neuron> network = new List<Neuron>();
        private readonly int NumberOfInputs;
        private readonly int size = 500;

        public Network(int[] values)
        {
            var rnd = new Random();
            for (var i = 0; i < size; i++) network.Add(new Neuron(i, rnd, size));
            NumberOfInputs = input.Count;
            foreach (var t in values) input.Add(new Sensor(t, rnd, size));
            for (var i = 0; i < size; i++)
            {
                var counter = 0;
                for (var j = 0; j < size; j++)
                for (var k = 0; k < 10; k++)
                    if (network[j].connections[k] == i)
                        counter++;
                for (var j = 0; j < NumberOfInputs; j++)
                for (var k = 0; k < 50; k++)
                    if (input[j].connections[k] == i)
                        counter++;
                network[i].SetInputs(counter, rnd);
            }
        }

        public void ChangeInputs(int[] ipt)
        {
            for(int i = 0;i < ipt.Length; i++)
            {
                input[i].value = ipt[i];
            }
        }

        public void Show()
        {
            foreach (var i in network)
                if (i.number > 480)
                    i.Show();
        }

        public void think()
        {
            var inputs = new List<int>();
            Console.Clear();
            for (var i = 0; i < size; i++)
            {
                inputs.Clear();
                for (var j = 0; j < size; j++)
                for (var k = 0; k < 10; k++)
                    if (network[j].connections[k] == i)
                        inputs.Add(network[j].value);
                for (var j = 0; j < NumberOfInputs; j++)
                for (var k = 0; k < 50; k++)
                    if (input[j].connections[k] == i)
                        inputs.Add(input[j].value);
                network[i].calculate(inputs);
                Console.Write(network[i].value + " ");
            }
        }
    }

    public class Sensor
    {
        public List<int> connections = new List<int>();
        public int value;

        public Sensor(int value, Random rnd, int size)
        {
            for (var i = 0; i < 500; i++) connections.Add(rnd.Next() % size);
            this.value = value;
        }
    }
}