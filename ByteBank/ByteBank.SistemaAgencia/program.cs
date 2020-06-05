using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime datalimite = new DateTime(2020, 06, 20);
            DateTime datahoje = DateTime.Now;

            Console.WriteLine(datalimite);
            Console.WriteLine(datahoje);

            TimeSpan diasParaVencimento = datalimite - datahoje;

            string message2 = TimeSpanHumanizeExtensions.Humanize(diasParaVencimento);

            string message = FormateMessage(diasParaVencimento);

            Console.WriteLine(message);
            Console.WriteLine(message2);

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
