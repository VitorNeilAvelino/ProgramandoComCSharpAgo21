using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Fintech.Dominio;

namespace Fintech.Repositorios.SqlServer.Tests
{
    [TestClass()]
    public class MovimentoRepositorioTests
    {
        private readonly MovimentoRepositorio repositorio = new("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Fintech;Integrated Security=True");

        [TestMethod()]
        public void InserirTest()
        {
            var conta = new ContaCorrente(new Agencia { Numero = 1 }, 2, "0");
            var movimento = new Movimento(Operacao.Deposito, 5.5m, conta);

            repositorio.Inserir(movimento);
        }

        [TestMethod]
        public void SelecionarTest()
        {
            var movimentos = repositorio.SelecionarAsync(0, 2).Result;

            Assert.IsTrue(movimentos.Count > 0);
        }

        [TestMethod()]
        public void AtualizarTest()
        {
            var movimento = new Movimento(Operacao.Saque, 100m);
            movimento.Id = 1;
            movimento.Data = DateTime.Now;

            repositorio.Atualizar(movimento);

            var movimentos = repositorio.SelecionarAsync(0, 456).Result;

            foreach (var m in movimentos)
            {
                Console.WriteLine($"{m.Id} - {m.Data} - {m.Operacao} - {m.Valor}");
            }
        }

        [TestMethod()]
        public void ExcluirTest()
        {
            repositorio.Excluir(1);

            var movimentos = repositorio.SelecionarAsync(0, 456).Result;

            foreach (var m in movimentos)
            {
                Console.WriteLine($"{m.Id} - {m.Data} - {m.Operacao} - {m.Valor}");
            }
        }
    }
}