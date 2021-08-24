using Fintech.Dominio;
using Fintech.Repositorios.SqlServer;
//using Fintech.Repositorios.SistemaArquivos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Fintech.Correntista.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private MovimentoRepositorio repositorio = new (Properties.Settings.Default.CaminhoArquivoMovimento); // "Dados\\Movimento.txt"
        private MovimentoRepositorio repositorio = new (Properties.Settings.Default.StringConexao); // "Dados\\Movimento.txt"
        public List<Cliente> Clientes { get; set; } = new List<Cliente>();
        public Cliente ClienteSelecionado { get; set; }
        public Conta ContaSelecionada { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            PopularControles();
        }

        private void PopularControles()
        {
            sexoComboBox.Items.Add(Sexo.Feminino);
            sexoComboBox.Items.Add(Sexo.Masculino);
            sexoComboBox.Items.Add(Sexo.Outro);

            tipoContaComboBox.Items.Add(TipoConta.ContaCorrente);
            tipoContaComboBox.Items.Add(TipoConta.ContaEspecial);
            tipoContaComboBox.Items.Add(TipoConta.Poupanca);

            var banco1 = new Banco();
            banco1.Nome = "Banco 1";
            banco1.Numero = 915;

            bancoComboBox.Items.Add(banco1);
            bancoComboBox.Items.Add(new Banco() { Nome = "Banco 2", Numero = 923 });

            operacaoComboBox.Items.Add(Operacao.Deposito);
            operacaoComboBox.Items.Add(Operacao.Saque);

            clientesDataGrid.ItemsSource = Clientes;
        }

        private void incluirClienteButton_Click(object sender, RoutedEventArgs e)
        {
            //Cliente cliente = new Cliente();
            //var cliente = new Cliente();
            Cliente cliente = new();

            cliente.Cpf = cpfTextBox.Text;
            cliente.Nome = nomeTextBox.Text;
            cliente.DataNascimento = Convert.ToDateTime(dataNascimentoTextBox.Text);
            cliente.Sexo = (Sexo)sexoComboBox.SelectedItem;

            var endereco = new Endereco();
            endereco.Cep = cepTextBox.Text;
            endereco.Cidade = cidadeTextBox.Text;
            endereco.Logradouro = logradouroTextBox.Text;
            endereco.Numero = numeroTextBox.Text;

            cliente.EnderecoResidencial = endereco;

            Clientes.Add(cliente);

            MessageBox.Show("Cliente cadastrado com sucesso.");
            LimparControlesCliente();
            clientesDataGrid.Items.Refresh();
            pesquisaClienteTabItem.Focus();
        }

        /// <summary>
        /// Limpa os controles da aba Cadastro de Cliente.
        /// </summary>
        private void LimparControlesCliente()
        {
            cpfTextBox.Clear();
            nomeTextBox.Text = "";
            dataNascimentoTextBox.Text = string.Empty;

            sexoComboBox.SelectedIndex = -1;

            logradouroTextBox.Text = null;
            numeroTextBox.Clear();
            cidadeTextBox.Clear();
            cepTextBox.Clear();
        }

        private void SelecionarClienteButtonClick(object sender, RoutedEventArgs e)
        {
            SelecionarCliente(sender);

            clienteTextBox.Text = $"{ClienteSelecionado.Nome} - {ClienteSelecionado.Cpf}";

            contasTabItem.Focus();
        }

        private void SelecionarCliente(object sender)
        {
            var botaoClicado = (Button)sender;
            var clienteSelecionado = botaoClicado.DataContext;

            ClienteSelecionado = (Cliente)clienteSelecionado;
        }

        private void TipoContaComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tipoContaComboBox.SelectedIndex == -1) return;
            
            var tipoConta = (TipoConta)tipoContaComboBox.SelectedItem;

            if (tipoConta == TipoConta.ContaEspecial)
            {
                limiteDockPanel.Visibility = Visibility.Visible;
                limiteTextBox.Focus();
            }
            else
            {
                limiteDockPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void incluirContaButton_Click(object sender, RoutedEventArgs e)
        {
            Conta conta = null;

            var agencia = new Agencia();
            agencia.Banco = (Banco)bancoComboBox.SelectedItem;
            agencia.Numero = Convert.ToInt32(numeroAgenciaTextBox.Text);
            agencia.DigitoVerificador = Convert.ToInt32(dvAgenciaTextBox.Text);

            var numero = Convert.ToInt32(numeroContaTextBox.Text);
            var digitoVerificador = dvContaTextBox.Text;

            switch ((TipoConta)tipoContaComboBox.SelectedItem)
            {
                case TipoConta.ContaCorrente:
                    conta = new ContaCorrente(agencia, numero, digitoVerificador);
                    break;
                case TipoConta.ContaEspecial:
                    var limite = Convert.ToDecimal(limiteTextBox.Text);
                    conta = new ContaEspecial(agencia, numero, digitoVerificador, limite);
                    break;
                case TipoConta.Poupanca:
                    conta = new Poupanca(agencia, numero, digitoVerificador);
                    break;
            }

            ClienteSelecionado.Contas.Add(conta);

            MessageBox.Show("Conta adicionada com sucesso.");
            LimparControlesConta();
            clientesDataGrid.Items.Refresh();
            clientesTabItem.Focus();
            //pesquisaClienteTabItem.Focus();
        }

        private void LimparControlesConta()
        {
            clienteTextBox.Clear();
            bancoComboBox.SelectedIndex = -1;
            numeroAgenciaTextBox.Clear();
            dvAgenciaTextBox.Clear();
            numeroContaTextBox.Clear();
            dvContaTextBox.Clear();
            tipoContaComboBox.SelectedIndex = -1;
            limiteTextBox.Clear();
        }

        private void SelecionarContaButtonClick(object sender, RoutedEventArgs e)
        {
            SelecionarCliente(sender);

            contaTextBox.Text = $"{ClienteSelecionado.Nome} - {ClienteSelecionado.Cpf}";

            contaComboBox.ItemsSource = ClienteSelecionado.Contas;
            contaComboBox.Items.Refresh();
            contaComboBox.SelectedItem = ContaSelecionada;

            operacoesTabItem.Focus();
        }

        private void incluirOperacaoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var conta = (Conta)contaComboBox.SelectedItem;
                var operacao = (Operacao)operacaoComboBox.SelectedItem;
                var valor = Convert.ToDecimal(valorTextBox.Text);

                var movimento = conta.EfetuarOperacao(valor, operacao);

                repositorio.Inserir(movimento);

                AtualizarGridMovimentacao(conta);
            }
            catch (FileNotFoundException excecao)
            {
                MessageBox.Show($"O arquivo {excecao.FileName} não foi encontrado.");
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show($"O diretório {Properties.Settings.Default.CaminhoArquivoMovimento} não foi encontrado.");
            }
            catch (SaldoInsuficienteException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eita! Alguma coisa deu errado e já estamos tomando providências.");
                //Logar(ex); // log4net
            }
            //finally
            //{
            //    // É executado sempre, independente de erro ou sucesso, mesmo se houver um return no código.
            //}
        }

        private void AtualizarGridMovimentacao(Conta conta)
        {
            movimentacaoDataGrid.ItemsSource = conta.Movimentos;
            movimentacaoDataGrid.Items.Refresh();

            saldoTextBox.Text = conta.Saldo.ToString("c");
        }

        private async void contaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (contaComboBox.SelectedIndex == -1) return;

            mainSpinner.Visibility = Visibility.Visible;

            var conta = (Conta)contaComboBox.SelectedItem;

            conta.Movimentos = await repositorio.SelecionarAsync(conta.Agencia.Numero, conta.Numero);

            AtualizarGridMovimentacao(conta);

            mainSpinner.Visibility = Visibility.Hidden;
        }

        private void ContasClienteSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboClicado = (ComboBox)sender;
            ContaSelecionada = (Conta)comboClicado.SelectedItem;
        }
    }
}