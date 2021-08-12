using System;

namespace Fintech.Dominio
{
    public abstract class Conta
    {
        public int Numero { get; set; }
        public int DigitoVerificador { get; set; }
        public decimal Saldo { get; set; }
        public Agencia Agencia { get; set; }
        public Cliente Cliente { get; set; }

        public virtual void EfetuarOperacao(decimal valor, Operacao operacao)
        {
            switch (operacao)
            {
                case Operacao.Deposito:
                    Saldo += valor;
                    break;
                case Operacao.Saque:
                    if (Saldo >= valor)
                    {
                        Saldo -= valor;
                    }
                    break;
            }
        }
    }
}
