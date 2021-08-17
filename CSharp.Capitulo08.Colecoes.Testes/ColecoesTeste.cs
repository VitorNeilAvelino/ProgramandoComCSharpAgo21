using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Capitulo08.Colecoes.Testes
{
    [TestClassAttribute]
    public class ColecoesTeste
    {
        [TestMethod]
        public void ListTeste()
        {
            var inteiros = new List<int>(1000) { 1, 8, 33, 16, -78 };
            inteiros.Add(24);
            inteiros[0] = -3;
            //inteiros[100] = 14;

            var maisInteiros = new List<int> { 16, 38, -7, 8, 33 };

            inteiros.AddRange(maisInteiros);

            inteiros.Insert(2, 42);

            inteiros.Remove(42);
            inteiros.Remove(8);
            var removeu = inteiros.Remove(-1);

            inteiros.RemoveAll(i => i == 8);

            inteiros.RemoveAt(5);

            inteiros.Sort();

            var primeiro = inteiros[0];
            primeiro = inteiros.First();

            foreach (var inteiro in inteiros)
            {
                Console.WriteLine($"{inteiros.IndexOf(inteiro)}: {inteiro}");
            }
        }
    }
}
