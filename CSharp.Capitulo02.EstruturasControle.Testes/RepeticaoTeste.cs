using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CSharp.Capitulo02.EstruturasControle.Testes
{
    [TestClass]
    public class RepeticaoTeste
    {
        [TestMethod]
        public void TabuadaTeste()
        {
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Console.WriteLine($"{i} * {j} = {i * j}");                
                }
                Console.WriteLine(new string('-', 50));
            }
        }

        [TestMethod]
        public void EstruturaForTeste()
        {
            var i = 1;

            for (Console.WriteLine("Iniciou"); i <= 3; Console.WriteLine(++i/*++*/))
            {
                //i++;
            }

            /*
             for(1. Inicialização; 2. Condição; 4. Pós-execução)
             {
                3. Execução
            }
             */
        }

        [TestMethod]
        public void ForApenasComCondicaoTeste()
        {
            var i = 1;

            for (; i++ <= 3;)
            {
                Console.WriteLine(i);
            }
        }
    }
}
