using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fintech.Repositorios.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}