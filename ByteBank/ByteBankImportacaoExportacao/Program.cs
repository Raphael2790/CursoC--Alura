using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using ByteBank.Modelos;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var linhas = File.ReadAllLines("contas.txt");
            Console.WriteLine($"O arquivo comtas possui {linhas.Length} linhas");

            var bytes = File.ReadAllBytes("contas.txt");
            Console.WriteLine($"O arquivo contas possui {bytes.Length} bytes");

            File.WriteAllText("ArquivoFinal.txt", "Este é o arquivo final do curso básico de File Stream");

            Console.WriteLine("Arquivo criado com sucesso");

            
        }

        
    }
}
