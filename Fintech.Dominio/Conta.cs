using System;
using System.Collections.Generic;

namespace Fintech.Dominio
{
    public abstract class Conta
    {
        protected Conta(Agencia agencia, int numero, string digitoVerificador)
        {
            Agencia = agencia;
            Numero = numero;
            DigitoVerificador = digitoVerificador;
        }

        public int Numero { get; set; }
        public string DigitoVerificador { get; set; }
        public decimal Saldo { get; protected set; }
        public Agencia Agencia { get; set; }
        public Cliente Cliente { get; set; }
        public List<Movimento> Movimentos { get; set; } = new List<Movimento>();

        public virtual void EfetuarOperacao(decimal valor, Operacao operacao)
        {
            var sucesso = true;

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
                    else
                    {
                        sucesso = false;
                    }
                    break;
            }
            
            if(sucesso) Movimentos.Add(new Movimento(operacao, valor));
        }
    }
}
