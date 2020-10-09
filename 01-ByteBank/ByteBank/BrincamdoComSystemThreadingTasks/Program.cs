using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace BrincamdoComSystemThreadingTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listaLinhas = new List<string>();
            var linhas = File.ReadAllLines("contas.txt");
            Console.WriteLine($"O arquivo comtas possui {linhas.Length} linhas");


            foreach (var linha in linhas)
            {
                listaLinhas.Add(linha);
            }


            var lista_parte1 = listaLinhas.Take(listaLinhas.Count / 2);

            var lista_parte2 = listaLinhas.Skip(listaLinhas.Count / 2);

            Thread thread_1 = new Thread(() =>
            {
                foreach (var linha in lista_parte1)
                {
                    Console.WriteLine("Este console vem da thread 1");
                }
            });

            Thread thread_2 = new Thread(() =>
            {
                foreach (var linha in lista_parte2)
                {
                    Console.WriteLine("Este console vem da thread 2");
                }
            });

            thread_1.Start();
            while (thread_1.IsAlive)
            {
                Thread.Sleep(3000);
            }
        }
    }
}
