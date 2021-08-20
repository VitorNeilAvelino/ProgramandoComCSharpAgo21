using System;
using System.Collections.Generic;
using System.Linq;

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
        public decimal Saldo
        {
            get { return TotalDeposito - TotalSaque; }
            private set { }
        }
        public Agencia Agencia { get; set; }
        public Cliente Cliente { get; set; }
        public List<Movimento> Movimentos { get; set; } = new List<Movimento>();
        public decimal TotalDeposito
        {
            get
            {
                return Movimentos.Where(m => m.Operacao == Operacao.Deposito).Sum(m => m.Valor);
            }
        }
        public decimal TotalSaque => Movimentos.Where(m => m.Operacao == Operacao.Saque).Sum(m => m.Valor);
        //{
        //    get
        //    {
        //        return Movimentos.Where(m => m.Operacao == Operacao.Saque).Sum(m => m.Valor);
        //    }
        //}

        public Movimento EfetuarOperacao(decimal valor, Operacao operacao, decimal limite = 0)
        {
            //var sucesso = true;
            //var movimento = new Movimento();
            Movimento movimento = null;

            switch (operacao)
            {
                case Operacao.Deposito:
                    Saldo += valor;
                    break;
                case Operacao.Saque:
                    if (Saldo + limite >= valor)
                    {
                        Saldo -= valor;
                    }
                    else
                    {
                        throw new SaldoInsuficienteException();
                    }
                    break;
            }

            //if (sucesso)
            //{
                movimento = new Movimento(operacao, valor, this);
                Movimentos.Add(movimento);
            //}

            return movimento;
        }
    }
}
