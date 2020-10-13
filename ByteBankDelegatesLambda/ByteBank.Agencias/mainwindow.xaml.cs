using ByteBank.Agencias.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ByteBank.Agencias
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ByteBankEntities _contextoBancoDeDados = new ByteBankEntities();
        private readonly ListBox lstAgencias;

        public MainWindow()
        {
            InitializeComponent();

            lstAgencias = new ListBox();
            AtualizarControles();
            AtualizarAgencias();
        }

        private void AtualizarControles()
        {
            lstAgencias.Width = 270;
            lstAgencias.Height = 290;

            Canvas.SetTop(lstAgencias, 15);
            Canvas.SetLeft(lstAgencias, 15);

            container.Children.Add(lstAgencias);

            btnEditar.Click += new RoutedEventHandler(BtnEditar_Click);

            //usa-se atribuição += para um manipulador de eventos porque ele não deve sobscrever o valor padrão
            // e sim adicionar mais um valor
            //SelectionChanged é um metodo delegate, um delegate é um metodo fortemente tipado
            //Temos que obedecer tanto o retorno quanto o tipo de seus parametros
            lstAgencias.SelectionChanged += new SelectionChangedEventHandler(lstAgencias_SelectionChange);
        }
        private void AtualizarAgencias()
        {
            lstAgencias.Items.Clear();
            var agencias = _contextoBancoDeDados.Agencias.ToList();
            foreach (var agencia in agencias)
                lstAgencias.Items.Add(agencia);
        }

        private void BtnEditar_Click (object sender, RoutedEventArgs e)
        {
            var agencia = (Agencia)lstAgencias.SelectedItem;
            var janelaEdicao = new EdicaoAgencia(agencia);
            var resultado = janelaEdicao.ShowDialog().Value;

            if(resultado)
            {

            }
            else
            {

            }
        }

        private void lstAgencias_SelectionChange(object sender, SelectionChangedEventArgs e)
        {
            var agenciaSelecionada = (Agencia)lstAgencias.SelectedItem;

            txtNumero.Text = agenciaSelecionada.Numero;
            txtNome.Text = agenciaSelecionada.Nome;
            txtTelefone.Text = agenciaSelecionada.Telefone;
            txtEndereco.Text = agenciaSelecionada.Endereco;
            txtDescricao.Text = agenciaSelecionada.Descricao;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var confirmacao = 
                MessageBox.Show(
                    "Você deseja realmente excluir este item?",
                    "Confirmação",
                    MessageBoxButton.YesNo);
            if (confirmacao == MessageBoxResult.Yes)
            {
                //Excluir
            }
            else
            {
                //Não faz nada
            }
        }
    }
}
