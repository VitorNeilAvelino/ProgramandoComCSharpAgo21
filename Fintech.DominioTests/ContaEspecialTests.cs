using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fintech.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Dominio.Tests
{
    [TestClass()]
    public class ContaEspecialTests
    {
        [TestMethod()]
        public void EfetuarOperacaoTest()
        {
            var conta = new ContaEspecial(new Agencia(), 0, "0", 1000);
            //decimal valor = 5;

            conta.EfetuarOperacao(50, Operacao.Deposito);
            Assert.IsTrue(conta.Saldo == 50);

            conta.EfetuarOperacao(20, Operacao.Saque);
            Assert.IsTrue(conta.Saldo == 30);

            conta.EfetuarOperacao(40, Operacao.Saque);
            Assert.IsTrue(conta.Saldo == -10);

            conta.EfetuarOperacao(990, Operacao.Saque);
            Assert.IsTrue(conta.Saldo == -1000);

            conta.EfetuarOperacao(10, Operacao.Saque);
            Assert.IsTrue(conta.Saldo == -1000);

            conta.EfetuarOperacao(1000, Operacao.Deposito);
            Assert.IsTrue(conta.Saldo == 0);

            //uint natural = -10;

            Assert.AreEqual(conta.Movimentos.Count, 5);

            var depositos = conta.Movimentos.Where(m => m.Operacao == Operacao.Deposito).Sum(m => m.Valor);
            var qtdDepositos = conta.Movimentos.Count(m => m.Operacao == Operacao.Deposito);

            var saques = conta.Movimentos.Where(m => m.Operacao == Operacao.Saque).Sum(m => m.Valor);
            var qtdSaques = conta.Movimentos.Count(m => m.Operacao == Operacao.Saque);

            //conta.Saldo = 10;

            Assert.AreEqual(conta.Saldo, depositos - saques);
            Assert.AreEqual(conta.Saldo, conta.TotalDeposito - conta.TotalSaque);
            Assert.IsTrue(qtdDepositos == 2);
            Assert.AreEqual(qtdSaques, 3);

            //conta.Saldo = 5000; //set

            //fakes - stubs
        }
    }
}