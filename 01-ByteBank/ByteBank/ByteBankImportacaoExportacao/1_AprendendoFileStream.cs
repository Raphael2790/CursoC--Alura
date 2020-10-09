using System;
using System.IO;
using System.Text;

namespace ByteBankImportacaoExportacao
{ 
    partial class Program
    {
        static void LidandoComFileStream()
        {
            string enderecoArquivo = "contas.txt";

            //variavel recebe o arquivo e abre o mesmo         FileMode é um Enum - uma das tipagens mais forte do C#
            //Ao usar recursos de memória precisamos fazer um comando de liberação, usando usyng ou finally 
            //Ambas aplicam a execução de Dispose() para liberar memória e liberar o stream gerado
            using (var fluxoArquivo = new FileStream(enderecoArquivo, FileMode.Open))
            {
                if (fluxoArquivo == null)
                {
                    throw new ApplicationException("Arquivo não possui conteúdo");
                }
                var buffer = new byte[1024];

                int numeroBytesLidos = -1;

                while (numeroBytesLidos != 0)
                {
                    numeroBytesLidos = fluxoArquivo.Read(buffer, 0, 1024);
                    EscreverBytes(buffer, numeroBytesLidos);
                }
                Console.WriteLine(numeroBytesLidos);

            }
        }

        static void EscreverBytes(byte[] buffer, int bytesLidos)
        {
            var encodeUTF8 = Encoding.Default;

            Console.WriteLine(encodeUTF8.GetString(buffer, 0, bytesLidos));
            //foreach (var meuByte in buffer)
            //{
            //    Console.Write(meuByte);
            //    Console.Write(" ");
            //}
        }

    }
}
