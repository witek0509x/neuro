using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Neuro
{
    class Neuron
    {
        public List<int> connections = new List<int>();
        List<float> weights = new List<float>();
        List<int> inputs = new List<int>();
        public int value = 0;
        public int number;
        public Neuron(int number, Random rnd, int size)
        {
            this.number = number;
            for(int i = 0; i < 10; i++)
            {
                connections.Add(rnd.Next() % size);
                value = rnd.Next() % 2;
            }
        }
        public void SetInputs(int size, Random rnd)
        {
            for (int i = 0; i < size; i++)
            {
                inputs.Add(0);
                float tmp = rnd.Next(-100,100);
                weights.Add(tmp / 100);
            }
        }
        public void calculate(List<int> Inputs)
        {
            inputs = Inputs;
            float sum = 0;
            for (int i = 0; i < inputs.Count(); i++) sum += inputs[i] * weights[i];
            sum = sum / inputs.Count();
            if (sum < 0) value = 0;
            else value = 1;
            Learn();
        }
        private void Learn()
        {
            for (int i = 0; i < inputs.Count(); i++)
            {
                if (inputs[i] < 0 & value == 0)
                {
                    if(weights[i] < 0.9) weights[i] += 0.001F;
                }
                else if (inputs[i] > 0 & value == 0) 
                {
                    if (weights[i] > 0.1) weights[i] -= 0.001F;
                }
                else if (inputs[i] < 0 & value == 1) 
                {
                    if (weights[i] > 0.1) weights[i] -= 0.001F;
                }
                else 
                {
                    if (weights[i] < 0) weights[i] += 0.001F;
                }
            }
        }
        public void Show()
        {
            Console.Write(number + " ");
            for (int i = 0; i < inputs.Count(); i++)
            {
                Console.Write(weights[i] + " ");
            }
            Console.WriteLine(";");
        }
    }
}