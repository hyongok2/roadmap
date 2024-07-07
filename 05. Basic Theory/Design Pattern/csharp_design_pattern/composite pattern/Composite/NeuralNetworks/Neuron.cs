using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks
{
    public class Neuron : IEnumerable<Neuron>
    {
        public float Value;
        public List<Neuron> In { get; set; } = new List<Neuron>();
        public List<Neuron> Out { get; set; } = new List<Neuron>();

        public IEnumerator<Neuron> GetEnumerator()
        {
            yield return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return this;
        }
    }
}
