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
using System.Windows.Shapes;

namespace ByteBank.Agencias
{
    /// <summary>
    /// Lógica interna para EdicaoAgencia.xaml
    /// </summary>
    public partial class EdicaoAgencia : Window
    {
        private readonly Agencia _agencia;
        public EdicaoAgencia(Agencia agencia)
        {
            InitializeComponent();
            _agencia = agencia ?? throw new ArgumentNullException(nameof(agencia));
            AtualizarCamposTexto();
            AtualizarControles();
        }

        private void AtualizarCamposTexto()
        {
            txtNumero.Text = _agencia.Numero;
            txtNome.Text = _agencia.Nome.Trim();
            txtTelefone.Text = _agencia.Telefone;
            txtEndereco.Text = _agencia.Endereco.Trim();
            txtDescricao.Text = _agencia.Descricao.Trim();
        }

        private void AtualizarControles()
        {
            //declaração de metodo anonimo atribuido a uma variável usando expressão lamba
            RoutedEventHandler okResultDialog = (o, e) => DialogResult = true;
            RoutedEventHandler cancelResultDialog = (o, e) =>  DialogResult = false;
            RoutedEventHandler fechar = (o, e) => Close();
            //var okEventHandler = (RoutedEventHandler)BtnOk_Click + Fechar;
            var cancelarEventHandler = cancelResultDialog + fechar;

            var OKEventHandler = (RoutedEventHandler)Delegate.Combine(okResultDialog, fechar);

            //Os eventos são atribuidos ao botão click e desencadeados em sequencia, uma vez que disparado o primeiro evento
            BtnOk.Click += OKEventHandler;

            BtnCancelar.Click += cancelarEventHandler;

            txtNumero.Validation += ValidarCampoTexto;
            txtNumero.Validation += ValidarDigitos;

            txtNumero.Validation += ValidarCampoTexto;
            txtDescricao.Validation += ValidarCampoTexto;
            txtNome.Validation += ValidarCampoTexto;
            txtTelefone.Validation += ValidarCampoTexto;
            txtEndereco.Validation += ValidarCampoTexto;

            //então na loja do botões o fechamento seria desencadeado na sequencia
            //BtnOk.Click += new RoutedEventHandler(Fechar);
            //BtnCancelar.Click += new RoutedEventHandler(Fechar);

        }

        private void ValidarDigitos(object sender, ValidacaoEventArgs e)
        {
            //a propriedade sender de um evento refere-se a quem disparou o evento
            //var txt = sender as TextBox;

            //Func recebem os tipos de parametros e um tipo de retorno recebendo delegates
            //Func<char, bool> verificaDigitos = caracter => { return Char.IsDigit(caracter); };

            var ehValido = e.Texto.All(Char.IsDigit);
            e.ehValido = ehValido;
        }

        private void ValidarCampoTexto(object sender, ValidacaoEventArgs e)
        {
           var ehvalido = !String.IsNullOrEmpty(e.Texto);
            e.ehValido = ehvalido;
        }
    }
}
