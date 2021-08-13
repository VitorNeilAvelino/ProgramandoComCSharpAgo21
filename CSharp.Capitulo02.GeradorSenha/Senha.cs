using System;

namespace CSharp.Capitulo02.GeradorSenha
{
    public class Senha
    {
        //public Senha()
        //{
        //    Valor = GerarSenha();
        //}

        public Senha(int tamanho = TamanhoMinimo)
        {
            tamanho = tamanho < TamanhoMinimo ? TamanhoMinimo : tamanho;
            tamanho = tamanho > TamanhoMaximo ? TamanhoMaximo : tamanho;
            
            Tamanho = tamanho;
            
            Valor = GerarSenha();
        }

        public const int TamanhoMinimo = 4;
        public const int TamanhoMaximo = 10;
        public int Tamanho { get; set; } = TamanhoMinimo;
        public string Valor { get; set; }

        private string GerarSenha()
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
