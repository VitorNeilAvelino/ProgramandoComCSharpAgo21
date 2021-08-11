using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Capitulo02.GeradorSenha
{
     public class Senha
    {
        public const int TamanhoMinimo = 4;
        public const int TamanhoMaximo = 10;
        public int Tamanho { get; set; } = TamanhoMinimo;
        public string Valor { get; set; }

        public  string GerarSenha()
        {
            var senha = string.Empty; //"";
            var randomico = new Random();

            for (int i = 1; i <= Tamanho; i++)
            {
                var digito = randomico.Next(10);
                senha += digito;//*.ToString()*/;
            }

            return senha;
        }
    }
}
