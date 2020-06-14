using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    class Lista<T>
    {
        private Modelos.T[] _itens;
        private int _proximaPosicao;
        public int Tamanho
        {
            get
            {
                return _proximaPosicao;
            } 
        }


        public ListaContaCorrente(int capacidadeInicial = 5 )
        {
            _itens = new Modelos.T[capacidadeInicial];
            _proximaPosicao = 0;
        }
        public void Adicionar(Modelos.T item)
        {
            VerificarCapacidade(_proximaPosicao + 1);
            _itens[_proximaPosicao] = item;
            Console.WriteLine($"Adicionado no indice {_proximaPosicao} conta {item.Agencia}/{item.Numero}");
            _proximaPosicao++;
        }

        public void EscreverLista()
        {
            for (int i = 0; i < _proximaPosicao; i++)
            {
                Modelos.T conta = _itens[i];
                Console.WriteLine($"A conta no indice{i} é a {conta.Agencia}/{conta.Numero}");
            }
        }

        public void Remover(Modelos.T item)
        {
            int indiceItem = -1;
            for (int i = 0; i < _proximaPosicao; i++)
            {
                Modelos.T contaAtual = _itens[i];
                if (contaAtual.Equals(item))
                {
                    indiceItem = i;
                    break;
                }
            }

            for (int i = indiceItem; i < _proximaPosicao-1; i++)
            {
                _itens[i] = _itens[i + 1];
            }

            _proximaPosicao--;
            _itens[_proximaPosicao] = null;
        }

        public Modelos.T GetItemNoIndice( int indice)
        {
            if(indice < 0 || indice >= _proximaPosicao)
            {
                throw new ArgumentException(nameof(indice));
            }

            return _itens[indice];
        }
        public void VerificarCapacidade(int tamanhoNecessario)
        {
            int novoTamanho = _itens.Length * 2;

            if (_itens.Length >= tamanhoNecessario)
            {
                return;
            }

            if(novoTamanho < tamanhoNecessario)
            {
                novoTamanho = tamanhoNecessario;
            }

            Modelos.T[] novoArray = new Modelos.T[novoTamanho];

            Array.Copy(_itens, novoArray, _itens.Length);

            _itens = novoArray;

        }
    }
}
