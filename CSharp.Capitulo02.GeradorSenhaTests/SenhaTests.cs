using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharp.Capitulo02.GeradorSenha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Capitulo02.GeradorSenha.Tests
{
    [TestClass]
    public class SenhaTests
    {
        [TestMethod]
        public void GerarSenhaTest()
        {
            Senha password = new Senha();

            //password.Tamanho = 4;
            string novaSenha = password.GerarSenha();

            Assert.IsTrue(novaSenha.Length == 4);
        }
    }
}