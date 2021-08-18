using System;

namespace Fintech.Dominio
{
    public class Movimento
    {
        public Movimento(Operacao operacao, decimal valor, Conta conta)
        {
            Operacao = operacao;
            Valor = valor;
            Conta = conta;
        }

        public DateTime Data { get; set; } = DateTime.Now;
        public Operacao Operacao { get; set; }
        public decimal Valor { get; set; }
        public Conta Conta { get; set; }
    }
}