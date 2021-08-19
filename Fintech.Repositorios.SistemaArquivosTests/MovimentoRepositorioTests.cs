using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fintech.Repositorios.SistemaArquivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fintech.Dominio;

namespace Fintech.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class MovimentoRepositorioTests
    {
        [TestMethod()]
        public void InserirTest()
        {
            var conta = new ContaCorrente(new Agencia { Numero = 1 }, 2, "0");
            var movimento = new Movimento(Operacao.Deposito, 5.5m, conta);

            var repositorio = new MovimentoRepositorio(@"Dados\Movimento.txt");
            repositorio.Inserir(movimento);
        }

        [TestMethod()]
        public void SelecionarTest()
        {
            var repositorio = new MovimentoRepositorio(@"Dados\Movimento.txt");
            var movimentos = repositorio.Selecionar(1, 2);

            foreach (var movimento in movimentos)
            {
                Console.WriteLine($"{movimento.Guid} - {movimento.Data} - {movimento.Operacao} - {movimento.Valor:c}");
            }
        }
    }
}