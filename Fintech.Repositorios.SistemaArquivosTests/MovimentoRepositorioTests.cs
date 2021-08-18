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
            var movimento = new Movimento(Operacao.Deposito, 22.28m, conta);
            
            var repositorio = new MovimentoRepositorio();
            repositorio.Inserir(movimento);
        }
    }
}