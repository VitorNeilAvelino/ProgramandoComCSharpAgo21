namespace Fintech.Dominio
{
    public class Poupanca : Conta
    {
        public Poupanca(Agencia agencia, int numero, string digitoVerificador) : base(agencia, numero, digitoVerificador)
        {
        }

        public decimal TaxaRendimento { get; set; }
    }
}