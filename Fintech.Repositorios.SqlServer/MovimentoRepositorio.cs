﻿using Dapper;
using Fintech.Dominio;
using Fintech.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Fintech.Repositorios.SqlServer
{
    public class MovimentoRepositorio : IMovimentoRepositorio
    {
        private readonly string stringConexao;

        public MovimentoRepositorio(string stringConexao)
        {
            this.stringConexao = stringConexao;
        }

        public void Atualizar(Movimento movimento)
        {
            var instrucao = @$"Update Movimento
                                         set Data = @Data, 
                                              Valor = @Valor, 
                                              Operacao = @Operacao
                                         where Id = @Id";

            using var conexao = new SqlConnection(stringConexao);
            conexao.Execute(instrucao, movimento);
        }        

        public void Excluir(int id)
        {
            var instrucao = @$"Delete Movimento where Id = @Id";

            using var conexao = new SqlConnection(stringConexao);
            conexao.Execute(instrucao, new { Id = id });
        }

        public void Inserir(Movimento movimento)
        {
            var instrucao = @$"Insert Movimento(IdConta, Data, Valor, Operacao)
                                            values({movimento.Conta.Numero}, @Data, @Valor, @Operacao)";

            using (var conexao = new SqlConnection(stringConexao)) // descarte seguro de memória.
            {
                conexao.Execute(instrucao, movimento);
            }
        }

        public List<Movimento> Selecionar(int numeroAgencia, int numeroConta)
        {
            var instrucao = @"Select Id, Data, Operacao, Valor from Movimento
                                        where IdConta=@numeroConta";

            using (var conexao = new SqlConnection(stringConexao))
            {
                return conexao.Query<Movimento>(instrucao, new { numeroConta }).AsList();
            }
        }

        public async Task<List<Movimento>> SelecionarAsync(int numeroAgencia, int numeroConta)
        {
            var instrucao = @"Select Id, Data, Operacao, Valor from Movimento
                                        where IdConta=@numeroConta";

            using (var conexao = new SqlConnection(stringConexao))
            {
                var movimentos = await conexao.QueryAsync<Movimento>(instrucao, new { numeroConta });
                //return movimentos.ToList();
                return movimentos.AsList();
            }
        }

        public Movimento Selecionar(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}