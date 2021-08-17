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

        [TestMethod]
        public void DictionaryTeste()
        {
            var feriados = new Dictionary<DateTime, string>();

            feriados.Add(Convert.ToDateTime("25/12/2021"), "Natal");
            feriados.Add(new DateTime(2021, 01, 01), "Ano Novo");
            feriados.Add(new DateTime(2021, 4, 21), "Tiradentes");
            //feriados.Add(new DateTime(2021, 4, 21), "Proclamação da República");

            var natal = feriados[new DateTime(2021, 12, 25)];

            foreach (var feriado in feriados.OrderBy(f => f.Key))
            {
                Console.WriteLine($"{feriado.Key.ToShortDateString()}: {feriado.Value}");
            }

            Console.WriteLine(feriados.ContainsKey(new DateTime(2021, 01, 01)));
            Console.WriteLine(feriados.ContainsValue("Natal"));
        }
    }
}
