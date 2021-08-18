namespace Fintech.Dominio
{
    public class ContaEspecial : ContaCorrente
    {
        public ContaEspecial(Agencia agencia, int numero, string digitoVerificador, decimal limite) : base(agencia, numero, digitoVerificador)
        {
            Limite = limite;
        }

        public decimal Limite { get; set; }

        public Movimento EfetuarOperacao(decimal valor, Operacao operacao)
        {
            return base.EfetuarOperacao(valor, operacao, Limite);
        }
    }
}