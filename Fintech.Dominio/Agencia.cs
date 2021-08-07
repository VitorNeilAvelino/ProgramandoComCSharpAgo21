namespace Fintech.Dominio
{
    public class Agencia
    {
        public int Numero { get; set; }
        public int DigitoVerificador { get; set; }
        public Banco Banco { get; set; }
    }
}