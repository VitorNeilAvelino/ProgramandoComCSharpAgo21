using System;

namespace CSharp.Capitulo01.ValeTransporte
{
    class Program
    {
        static void Main(string[] args)
        {
            Inicio:

            Console.Write("Informe o nome do funcionário: ");
            var nome = Console.ReadLine();

            Console.Write("Informe o salário do funcionário: ");
            var salario = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Informe o gasto com transporte: ");
            var gastoTransporte = Convert.ToDecimal(Console.ReadLine());

            var descontoMaximo = salario * 0.06m; //6 / 100;

            var descontoVT = gastoTransporte > descontoMaximo ? descontoMaximo : gastoTransporte;

            var resultado = $"\nFuncionário: {nome}" +
                $"\nSalário: {salario:c}" +
                $"\nDesconto VT: {descontoVT:c}";

            Console.WriteLine(resultado);

            Console.WriteLine("\nPressione Enter para novo cálculo ou Esc para sair.");

            var comando = Console.ReadKey();

            if (comando.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }

            Console.Clear();

            goto Inicio;
        }
    }
}
