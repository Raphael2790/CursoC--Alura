using System;
using System.Collections.Generic;
using System.Linq;

namespace TrabalhandoComColeções
{
    internal class Navegador
    {
        private string _actual;
        //Uma stack traduzindo simplesmente é uma pilha, entrando na regras de pilhas como forma de organização
        //Em uma pilha sempre é removido o elemento do topo LIFO ( Last In First Out)
        private Stack<string> _historicoAnterior = new Stack<string>();
        private Stack<string> _historicoPosterior = new Stack<string>();
        public Navegador()
        {
            System.Console.WriteLine("Página atual:" + _actual);
        }

        //Dada que uma pilha só podemos interagircom o topo, unicos métodos para colocar e remover são
        //Pop(Remover) e Push(Inserir)
        internal void navegarPara(string url)
        {
            _historicoAnterior.Push(_actual);
            _actual = url;
            Console.WriteLine(_actual);
        }

        internal void Anterior()
        {
            if (_historicoAnterior.Any())
            {
                _historicoPosterior.Push(_actual);
                _actual = _historicoAnterior.Pop();
                Console.WriteLine(_actual);
            }
        }

        internal void Proximo()
        {
            if (_historicoPosterior.Any())
            {
                _historicoAnterior.Push(_actual);
                _actual = _historicoPosterior.Pop();
                Console.WriteLine(_actual);
            }
        }
    }
}