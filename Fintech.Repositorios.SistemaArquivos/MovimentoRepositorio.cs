using Fintech.Dominio;
using Fintech.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Fintech.Repositorios.SistemaArquivos
{
    // IoC - inversão de controle
    // DI - injeção de dependência
    public class MovimentoRepositorio : IMovimentoRepositorio
    {
        public MovimentoRepositorio(string caminho)
        {
            Caminho = caminho;
        }

        private const string DiretorioBase = "Dados";

        public string Caminho { get; }

        public void Atualizar(Movimento movimento)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Movimento movimento)
        {
            var registro = $"{movimento.Guid};{movimento.Conta.Agencia.Numero};{movimento.Conta.Numero};" +
                $"{movimento.Data};{(int)movimento.Operacao};{movimento.Valor}";

            if (!Directory.Exists(DiretorioBase))
            {
                Directory.CreateDirectory(DiretorioBase);
            }

            File.AppendAllText(@$"{DiretorioBase}\Movimento.txt", registro + Environment.NewLine);
        }

        public List<Movimento> Selecionar(int numeroAgencia, int numeroConta)
        {
            //Thread.Sleep(4000);
            
            var movimentos = new List<Movimento>();

            if (!File.Exists(Caminho)) return movimentos;

            foreach (var linha in File.ReadAllLines(Caminho))
            {
                if (linha.Trim() == string.Empty) continue;

                var propriedades = linha.Split(';');

                var guid = new Guid(propriedades[0]);
                var propNumeroAgencia = Convert.ToInt32(propriedades[1]);
                var propNumeroConta = Convert.ToInt32(propriedades[2]);
                var data = Convert.ToDateTime(propriedades[3]);
                var operacao = (Operacao)Convert.ToInt32(propriedades[4]);
                var valor = Convert.ToDecimal(propriedades[5]);

                if (numeroAgencia == propNumeroAgencia && numeroConta == propNumeroConta)
                {
                    //var conta = new ContaCorrente();
                    var movimento = new Movimento(operacao, valor);
                    movimento.Guid = guid;
                    movimento.Data = data;

                    movimentos.Add(movimento);
                }
            }

            return movimentos;
        }

        public async Task<List<Movimento>> SelecionarAsync(int numeroAgencia, int numeroConta)
        {
            //await Task.Delay(4000);

            var movimentos = new List<Movimento>();

            if (!File.Exists(Caminho)) return movimentos;

            foreach (var linha in await File.ReadAllLinesAsync(Caminho))
            {
                if (linha.Trim() == string.Empty) continue;

                var propriedades = linha.Split(';');

                var guid = new Guid(propriedades[0]);
                var propNumeroAgencia = Convert.ToInt32(propriedades[1]);
                var propNumeroConta = Convert.ToInt32(propriedades[2]);
                var data = Convert.ToDateTime(propriedades[3]);
                var operacao = (Operacao)Convert.ToInt32(propriedades[4]);
                var valor = Convert.ToDecimal(propriedades[5]);

                if (numeroAgencia == propNumeroAgencia && numeroConta == propNumeroConta)
                {
                    //var conta = new ContaCorrente();
                    var movimento = new Movimento(operacao, valor);
                    movimento.Guid = guid;
                    movimento.Data = data;

                    movimentos.Add(movimento);
                }
            }

            return movimentos;
        }

        public Movimento Selecionar(Guid guid)
        {
            throw new NotImplementedException();
        }

        //public void Excluir(Guid guid)
        //{

        //}
    }
}
