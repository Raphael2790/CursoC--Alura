using System;
using System.IO;
using System.Text;
using ByteBank.Modelos;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    { 
        static void EscritaBinaria()
        {
            string novoArquivo = "ContasCorrentes.txt";

            using (var fs = new FileStream(novoArquivo, FileMode.Create))
            using (var escritor = new BinaryWriter(fs))
            {
                escritor.Write(456);
                escritor.Write(46785);
                escritor.Write(4580.20);
                escritor.Write("Gustavo Silva");
                Console.WriteLine("Arquivo reescrito ou criado com sucesso!");
            }
        }

        static void LeituraBinaria()
        {
            string novoArquivo = "ContasCorrentes.txt";

            using (var fs = new FileStream(novoArquivo, FileMode.Open))
            using (var leitor = new BinaryReader(fs))
            {
                var agencia = leitor.ReadInt32();
                var numeroConta = leitor.ReadInt32();
                var saldo = leitor.ReadDouble();
                var titular = leitor.ReadString();

                Console.WriteLine($"{titular}:{agencia}/{numeroConta} - R${saldo}");
            }
        }
    }
}