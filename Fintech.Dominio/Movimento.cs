using System;

namespace Fintech.Dominio
{
    public class Movimento
    {
        public Movimento(Operacao operacao, decimal valor)
        {
            Operacao = operacao;
            Valor = valor;
        }

        public Movimento(Operacao operacao, decimal valor, Conta conta)
        {
            Operacao = operacao;
            Valor = valor;
            Conta = conta;
        }

        public Guid Guid { get; set; } = Guid.NewGuid();
        public DateTime Data { get; set; } = DateTime.Now;
        public Operacao Operacao { get; set; }
        public decimal Valor { get; set; }
        public Conta Conta { get; set; }
    }
}