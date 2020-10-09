using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;
using System.Text.RegularExpressions;
using ByteBank.SistemaAgencia.Comparadores;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            // Subescrevendo o metodo ToString da Conta corrente
            var conta = new ContaCorrente(0296, 806129);
            var contaToString = conta.ToString();
            Console.WriteLine(contaToString);

            // Declaração e inicialização de arrays
            ContaCorrente[] contas = new ContaCorrente[3];
            contas[0] = new ContaCorrente(0296, 806129);
            contas[1] = new ContaCorrente(0296, 808064);
            contas[2] = new ContaCorrente(3057, 545285);

            ContaCorrente[] contas2 = new ContaCorrente[]
            {

            };

            for (int indice = 0; indice < contas.Length; indice++)
            {
                ContaCorrente contaAtual = contas[indice];
                Console.WriteLine($"A conta no indice {indice} é {contaAtual.Numero}");
            }

            ContaCorrente contaRaphael = new ContaCorrente(0000, 1111111);

            var lista = new ListaContaCorrente();
            lista.Adicionar(contaRaphael);
            lista.Adicionar(new ContaCorrente(0296, 806129));
            lista.Adicionar(new ContaCorrente(3057, 521245));
            lista.Adicionar(new ContaCorrente(0296, 806129));
            lista.Adicionar(new ContaCorrente(3057, 521245));
            lista.Adicionar(new ContaCorrente(0296, 806129));
            lista.Adicionar(new ContaCorrente(3057, 521245)); 
            lista.Adicionar(new ContaCorrente(0296, 806129));
            lista.Adicionar(new ContaCorrente(3057, 521245));

            for (int i = 0; i < lista.Tamanho; i++)
            {
                ContaCorrente conta1 = lista.GetItemNoIndice(i);
                Console.WriteLine($"{conta1.Agencia}/{conta1.Numero}");
            }

            var lista2 = new List<string>()
            {
               "Raphael" ,
               "Monica"
            };


            List<ContaCorrente> ContaCorrente = new List<ContaCorrente>()
            {
                new ContaCorrente(1296, 806129),
                new ContaCorrente(3057,506472),
                null,
                new ContaCorrente(6052,254687),
                new ContaCorrente(1547,555858),
                null

            };

            //ContaCorrente.Sort(new ComparadorDeContaCorrente());

            IOrderedEnumerable<ContaCorrente> contasOrdenadas = ContaCorrente
                .Where(x => x != null)
                .OrderBy(x => x.Numero);

            foreach (var item in contasOrdenadas)
            {
                Console.WriteLine($"Conta corrente {item.Agencia}/{item.Numero}");
            }

            //Mostrando data atual e definindo uma data fixa
            DateTime datalimite = new DateTime(2020, 06, 20);
            DateTime datahoje = DateTime.Now;

            Console.WriteLine(datalimite);
            Console.WriteLine(datahoje);

            //usando timespan para calcular a diferença entre datas
            TimeSpan diasParaVencimento = datalimite - datahoje;

            //usando a biblioteca humanizer para formatar o retorno da diferença
            string message2 = TimeSpanHumanizeExtensions.Humanize(diasParaVencimento);

            string message = FormateMessage(diasParaVencimento);

            Console.WriteLine(message);
            Console.WriteLine(message2);

            //usando alguns metodos de string para formatar uma querystring
            string url = "page?nome=Raphael&idade=29&salario=1500";

            string arguments = url.Substring(5);

            VerficarSepararArgumentos extrator = new VerficarSepararArgumentos(url);

            Console.WriteLine(extrator.GetValor("SALARIO"));

            Console.WriteLine(arguments);

            //usando regex para procurar palavras dentro 
            string frase = "Meu nome é Raphael e meu telefone é 99640-5085";
            string padraoTel = "[0-9]{4,5}-?[0-9]{4}";

            Match match = Regex.Match(frase,padraoTel);

            Console.WriteLine(match.Value);

            Cliente cliente = new Cliente();
            cliente.CPF = "401.919.868-36";
            Cliente cliente1 = new Cliente();
            cliente1.CPF = "401.919.868-36";
            Console.WriteLine(cliente.Equals(cliente1));

        }

        public static string FormateMessage(TimeSpan timespan)
        {
            if(timespan.Days < 30)
            {
                return "Faltam " + timespan.Days + " dias para o vencimento";
            }
           
            int mesesFalatando = timespan.Days / 30;
            return "Faltam " + mesesFalatando + " meses para o vencimento";
        }
    }
}
