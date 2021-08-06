using System;

namespace CSharp.Capitulo02.GeradorSenha
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Informe uma quantidade par de dígitos para a senha (entre 4 e 10): ");

            //var quantidadeDigitos = 0;

            //while (quantidadeDigitos == 0)
            //{
            //    quantidadeDigitos = ObterQuantidadeDigitos();
            //}

            int quantidadeDigitos;

            do
            {
                Console.Write("Informe uma quantidade par de dígitos para a senha (entre 4 e 10): ");
                quantidadeDigitos = ObterQuantidadeDigitos();
            } while (quantidadeDigitos == 0);

            var senha = string.Empty; //"";
            var randomico = new Random();

            for (int i = 1; i <= quantidadeDigitos; i++)
            {
                var digito = randomico.Next(10);
                senha += digito;//*.ToString()*/;
            }

            Console.WriteLine($"Senha gerada: {senha}");
            //Console.ReadKey();
            Environment.Exit(0);
        }

        private static int ObterQuantidadeDigitos()
        {
            int.TryParse(Console.ReadLine(), out int quantidadeDigitos);

            if (quantidadeDigitos is < 4 or > 10 || quantidadeDigitos % 2 != 0)
            {
                Console.WriteLine($"A quantidade de dígitos {quantidadeDigitos} é inválida de acordo com as regras. ");
                quantidadeDigitos = 0;
            }

            return quantidadeDigitos;
        }
    }
}
