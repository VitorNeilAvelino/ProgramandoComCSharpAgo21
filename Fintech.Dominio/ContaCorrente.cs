namespace Fintech.Dominio
{
    public class ContaCorrente : Conta
    {
        public ContaCorrente(Agencia agencia, int numero, string digitoVerificador) : 
            base(agencia, numero, digitoVerificador)
        {
            //Numero = numero;
            //DigitoVerificador = digitoVerificador;
        }

        public decimal ValorPacoteServico { get; set; }
    }
}