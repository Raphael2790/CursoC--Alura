using System;
using System.IO;
using System.Text;
using ByteBank.Modelos;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void UsandoStreamReader()
        {
            string enderecoArquivo = "contas.txt";

            using (var fluxoArquivo = new FileStream(enderecoArquivo, FileMode.Open))
            //Ao usar dois using encadeados não precisamos de chaves para a primeira diretiva
            using (var leitor = new StreamReader(fluxoArquivo))
            {
                while (!leitor.EndOfStream)
                {
                    string linha = leitor.ReadLine();
                    ContaCorrente contaCorrente = ConverterLinhaEmContaCorrente(linha);
                    var msg = $"Conta número: {contaCorrente.Agencia}, Agência número: {contaCorrente.Numero}, saldo R$: {contaCorrente.Saldo} e nome titular: {contaCorrente.Titular.Nome}";
                    Console.WriteLine(msg);
                }
                //variável recebe todo o conteudo do stream, não recomendado pois aloca todo o arquivo em memória
                var todoConteudo = leitor.ReadToEnd();
            }
        }

        static ContaCorrente ConverterLinhaEmContaCorrente(string linha)
        {
            string[] dadosConta = linha.Split(',');
            var agencia = dadosConta[0];
            var conta = dadosConta[1];
            var saldo = dadosConta[2].Replace('.', ',');
            var titular = dadosConta[3];

            int numeroAgencia = int.Parse(agencia);
            int numeroConta = int.Parse(conta);
            double valorSaldo = double.Parse(saldo);
            Cliente cliente = new Cliente();
            cliente.Nome = titular;

            ContaCorrente resultado = new ContaCorrente(numeroAgencia, numeroConta);
            resultado.Depositar(valorSaldo);
            resultado.Titular = cliente;

            return resultado;
        }
    }
}