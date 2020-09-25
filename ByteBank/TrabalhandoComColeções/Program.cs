using System;
using System.Collections.Generic;

namespace TrabalhandoComColeções
{
    class Program
    {
        static void Main(string[] args)
        {
            //Quando usar uma lista ligada? Quando necessário remover mais vezes elementos no meio de um lista
            //Listas ligadas não possuem indice, buscas, remoções são feitas pelo próprio elemento
            // Inserções são feitas com base em algum elemento
            LinkedList<string> daysOfWeek = new LinkedList<string>();

            var d1 = daysOfWeek.AddFirst("domingo");
            var d7 = daysOfWeek.AddLast("sábado");
            var d2 = daysOfWeek.AddAfter(d1, "segunda");

            // Não podemos usar for em listas ligadas por falta de um indice
            foreach(var day in daysOfWeek)
            {
                Console.WriteLine(day);
            }

            Navegador navegador = new Navegador();
            navegador.navegarPara("vazia");
            navegador.navegarPara("www.google.com");
            navegador.navegarPara("www.alura.com.br");
            navegador.navegarPara("www.caelum.com.br");
            navegador.Anterior();
            navegador.Anterior();
            navegador.Proximo();
            navegador.Proximo();

            Pedagio pedagio = new Pedagio();
            pedagio.Enfileirar("van");
            pedagio.Enfileirar("trator");
            pedagio.Enfileirar("ônibus viagem");
            pedagio.Enfileirar("carro familiar");
            pedagio.Desenfileirar();
            pedagio.Desenfileirar();
            pedagio.Desenfileirar();
            pedagio.Desenfileirar();
            pedagio.Desenfileirar();
        }

        //Resumindo existem vários tipos de listas em C#, algumas são:
        //IList - tipo de lista que permite valores duplicados e possue ordem de indexação
        //ISet - tipo de lista que não permite valores duplicado e não possue ordem
        //Dictionary - tipo de lista que indexa os elementos por um tipo de chave primária
        //List - listas comuns
        //HashSet - Listas com maior indexação, porém mais custosas em memória e buscas com tempo fixo
        //Queue - Filas seguem a estrutura de algoritmos FIFO 
        //Stack - Filas que seguem a estrutura de saida e entrada LIFO
        //Linked List - Listas que são indexadas pelo elementos próximos a ele mesmo
    }
}
