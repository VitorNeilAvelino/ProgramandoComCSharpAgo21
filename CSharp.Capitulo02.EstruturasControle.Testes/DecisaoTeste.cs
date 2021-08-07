using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Capitulo02.EstruturasControle.Testes
{
    [TestClass]
    public class DecisaoTeste
    {
        [TestMethod]
        public void AvaliacaoFinalReprovadoTeste()
        {
            var notaFinal = 2.9;
            var resultadoFinal = string.Empty;

            if (notaFinal < 3)
            {
                resultadoFinal = "Reprovado";
            }
            else if (notaFinal is >= 3 and < 5)
            {
                resultadoFinal = "Recuperação";
            }
            else
            {
                resultadoFinal = "Aprovado";
            }

            Assert.AreEqual(resultadoFinal, "Reprovado");
        }

        [TestMethod]
        public void AvaliacaoFinalRecuperacao3Teste()
        {
            var notaFinal = 3.0;
            var resultadoFinal = string.Empty;

            switch (notaFinal)
            {
                //case -1.0:
                //    resultadoFinal = "Meu Deus";
                //    break;
                case < 3.0:
                    resultadoFinal = "Reprovado";
                    break;
                case >= 3.0 and < 5.0:
                    resultadoFinal = "Recuperação";
                    break;
                default:
                    resultadoFinal = "Aprovado";
                    break;
            }

            Assert.AreEqual(resultadoFinal, "Recuperação");
        }

        [TestMethod]
        public void AvaliacaoFinalRecuperacao49Teste()
        {
            var notaFinal = 4.9;
            var resultadoFinal = string.Empty;

            resultadoFinal = notaFinal switch
            {
                < 3 => "Reprovado",
                >= 3 and < 5 => "Recuperação",
                _ => "Aprovado"
            };

            Assert.AreEqual(resultadoFinal, "Recuperação");
        }

        [TestMethod]
        [DataRow(2.9, "Reprovado")]
        [DataRow(3.0, "Recuperação")]
        [DataRow(4.9, "Recuperação")]
        [DataRow(5, "Aprovado")]
        public void AvaliacaoFinalTeste(double notaFinal, string resultadoEsperado)
        {
            var resultadoFinal = notaFinal switch
            {
                < 3 => "Reprovado",
                >= 3 and < 5 => "Recuperação",
                _ => "Aprovado"
            };

            Assert.AreEqual(resultadoFinal, resultadoEsperado);
        }
    }
}
