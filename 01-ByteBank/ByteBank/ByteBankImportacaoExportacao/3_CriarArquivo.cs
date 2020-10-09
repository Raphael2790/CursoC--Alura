using System;
using System.IO;
using System.Text;
using ByteBank.Modelos;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void CriarArquivo()
        {
            string caminhoNovoArquivo = "contasExportadas.csv";

            using (var fluxoDoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            {
                string novaContaString = "456,78945,4785.50,Gustavo Santos";
                var encodingUTF8 = Encoding.UTF8;
                var stringBytes = encodingUTF8.GetBytes(novaContaString);

                fluxoDoArquivo.Write(stringBytes, 0, stringBytes.Length);
                Console.WriteLine("Arquivo criado e escrito com sucesso!");
            }
        }

        static void CriarArquivoComWriter()
        {
            string nomeArquivo = "contasExportadas.csv";
                                                                    // FileMode.Create - cria ou modifica o arquivo , FileMode.CreateNew - verifica se existe o arquivo para criá-lo
            using (var fluxoDeArquivo = new FileStream(nomeArquivo, FileMode.Create))
            using (var escritor = new StreamWriter(fluxoDeArquivo) )
            {
                escritor.Write("456,78945,4785.50,Gustavo Santos");
                Console.WriteLine("Arquivo criado ou modificado com sucesso");
            }
        }

        //Usar o flush para a escrita de um arquivo faz o buffer de dados ser escrito assim que acionado o flush invés
        //escrever o arquivo somente ao final do buffer
        static void UsandoFlushParaEscreverArquivoSemGerarBUffer()
        {
            string novoArquivo = "teste.txt";

            using (var fluxoDeArquivo = new FileStream(novoArquivo, FileMode.Create))
            using (var escritor = new StreamWriter(fluxoDeArquivo))
            {
                for (int i = 0; i < 1000; i++)
                {
                    escritor.WriteLine($"Linha {i} escrita");
                    escritor.Flush();
                    Console.WriteLine("Aperte enter para escrever a próxima linha");
                    Console.ReadLine();
                }
            }
        }
    }
}