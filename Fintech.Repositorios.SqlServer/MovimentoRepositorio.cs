using Fintech.Dominio;
using Fintech.Dominio.Interfaces;
using System;
using System.Collections.Generic;

namespace Fintech.Repositorios.SqlServer
{
    public class MovimentoRepositorio : IMovimentoRepositorio
    {
        public void Atualizar(Movimento movimento)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Movimento movimento)
        {
            throw new NotImplementedException();
        }

        public List<Movimento> Selecionar(int numeroAgencia, int numeroConta)
        {
            throw new NotImplementedException();
        }

        public Movimento Selecionar(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}
