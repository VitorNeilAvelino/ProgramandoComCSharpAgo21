using System;
using System.Collections.Generic;

namespace Fintech.Dominio.Interfaces
{
    public interface IMovimentoRepositorio
    {
        void Inserir(Movimento movimento);
        void Atualizar(Movimento movimento);
        List<Movimento> Selecionar(int numeroAgencia, int numeroConta);
        Movimento Selecionar(Guid guid);
        void Excluir(Guid guid)
        {
            throw new InvalidOperationException();
        }
    }
}