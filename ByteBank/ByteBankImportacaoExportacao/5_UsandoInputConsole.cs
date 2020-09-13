using System;
using System.IO;
using System.Text;
using ByteBank.Modelos;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void CapturandoInputGravandoArquivo()
        {
            using (var fluxoConsole = Console.OpenStandardInput())
            using (var fs = new FileStream("EscritaDaConsole.txt", FileMode.Create))
            {
                var buffer = new byte[1024];

                while(true)
                {
                    var bytesLidos = fluxoConsole.Read(buffer, 0, 1024);

                    Console.WriteLine($"Bites lidos {bytesLidos}");

                    fs.Write(buffer, 0, bytesLidos);
                    fs.Flush();
                }


            }
        }
    }
}