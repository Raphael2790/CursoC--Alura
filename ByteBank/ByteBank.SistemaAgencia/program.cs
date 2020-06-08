using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;
using System.Text.RegularExpressions;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            // Subescrevendo o metodo ToString da Conta corrente
            ContaCorrente conta = new ContaCorrente(0296, 806129);
            string contaToString = conta.ToString();
            Console.WriteLine(contaToString);

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
