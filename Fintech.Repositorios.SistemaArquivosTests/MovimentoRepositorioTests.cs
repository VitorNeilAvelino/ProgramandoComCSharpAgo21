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
        MovimentoRepositorio repositorio = new MovimentoRepositorio(@"Dados\Movimento.txt");

        [TestMethod()]
        public void InserirTest()
        {
            var conta = new ContaCorrente(new Agencia { Numero = 1 }, 2, "0");
            var movimento = new Movimento(Operacao.Deposito, 5.5m, conta);

            repositorio.Inserir(movimento);
        }

        [TestMethod()]
        public void SelecionarTest()
        {
            var movimentos = repositorio.Selecionar(1, 2);

            foreach (var movimento in movimentos)
            {
                Console.WriteLine($"{movimento.Guid} - {movimento.Data} - {movimento.Operacao} - {movimento.Valor:c}");
            }
        }

        [TestMethod]
        public void OrderByTeste()
        {
            var movimentos = repositorio.Selecionar(1, 2)
                .OrderBy(m => m.Data)                
                .ThenBy(m => m.Operacao)
                .ThenByDescending(m => m.Valor);
            //Func<>

            var primeiro = movimentos.First(m => m.Operacao == Operacao.Deposito);
            //var outroPrimeiro = movimentos.Where(m => m.Operacao == Operacao.Deposito).First();

            Console.WriteLine($"{primeiro.Data}-{primeiro.Valor}");
        }

        [TestMethod]
        public void CountTeste()
        {
            var qtdMovimentos = repositorio.Selecionar(1, 2).Count(m => m.Operacao == Operacao.Deposito);

            Assert.AreEqual(qtdMovimentos, 3);
        }

        [TestMethod]
        public void LikeTeste()
        {
            var movimentos = repositorio.Selecionar(1, 2)
                .Where(m => m.Data.ToString().Contains("19/08/2021"));

            //var contemV = "Vítor".Contains("V");

            foreach (var movimento in movimentos)
            {
                Console.WriteLine(movimento.Data.ToString("dd/MM/yyyy HH:mm:ss"));
            }
        }

        [TestMethod]
        public void MinTeste()
        {
            var menorDeposito = repositorio.Selecionar(1, 2)
                .Where(m => m.Operacao == Operacao.Deposito)
                .Min(m => m.Valor);

            Assert.IsTrue(menorDeposito == 5.5m);
        }

        [TestMethod]
        public void SkipTakeTeste()
        {
            var movimentos = repositorio.Selecionar(1, 2)
                .Skip(10)
                .Take(5);

            foreach (var movimento in movimentos)
            {
                Console.WriteLine($"{movimento.Data}-{movimento.Valor}");
            }
        }

        [TestMethod]
        public void GroupByTeste()
        {
            var agrupamento = repositorio.Selecionar(1, 2)
                .GroupBy(m => m.Operacao)
                .Select(g => new { OperacaoGrupo = g.Key, Total = g.Sum(m => m.Valor) });

            foreach (var item in agrupamento)
            {
                Console.WriteLine($"{item.OperacaoGrupo}: {item.Total}");
            }
        }
    }
}