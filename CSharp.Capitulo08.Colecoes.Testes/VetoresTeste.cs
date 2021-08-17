using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace CSharp.Capitulo08.Colecoes.Testes
{
    [TestClass]
    public class VetoresTeste
    {
        [TestMethod]
        public void InicializacaoTeste()
        {
            int[] inteiros = new int[5];
            inteiros[0] = 14;
            inteiros[1] = 1;
            //inteiros[5] = -3;

            Assert.AreEqual(inteiros[2], 0);
            Assert.AreEqual(inteiros[3], default(int));

            var decimais = new decimal[] { 0.4m, 0.9m, 4, 7.8m };

            string[] nomes = { "Vítor", "Avelino" };

            var chars = new[] { 'a', 'b', 'c' };

            foreach (var @decimal in decimais)
            {
                Console.WriteLine(@decimal);
            }

            Console.WriteLine($"Tamanho do vetor: {decimais.Length}");
        }

        [TestMethod]
        public void RedimensionamentoTeste()
        {
            var decimais = new[] { 0.5m, 7, 8.9m };

            Array.Resize(ref decimais, 4);

            decimais[3] = 1.5m;
        }

        [TestMethod]
        public void OrdenacaoTeste()
        {
            var decimais = new[] { 0.5m, 7, -8.9m };

            Array.Sort(decimais);

            Assert.AreEqual(decimais[0], -8.9m);
        }

        private decimal Media(decimal x, decimal y)
        {
            return (x + y) / 2;
        }

        private decimal Media(params decimal[] decimais)
        {
            var soma = 0m;
            
            foreach (var @decimal in decimais)
            {
                soma += @decimal;
            }

            return soma / decimais.Length;
        }

        [TestMethod]
        public void ParamsTeste()
        {
            var decimais = new[] { 0.5m, 7, -8.9m };

            Console.WriteLine(Media(1, 2.8m));
            Console.WriteLine(Media(decimais));
            //Console.WriteLine(new[] { 0.5m, 7, -8.9m });
            Console.WriteLine(Media(0.5m, 21.9m, 7.3m, 1.5m));
            Console.WriteLine(decimais.Average());
        }

        [TestMethod]
        public void TodaStringEhUmVetorTeste()
        {
            var nome = "Vítor";
            nome += " Avelino";

            //StringBuilder

            Assert.AreEqual(nome[0], 'V');

            foreach (char @char in nome)
            {
                Console.Write(@char);
            }
        }
    }
}
