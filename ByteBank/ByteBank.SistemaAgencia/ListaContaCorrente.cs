using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    class ListaContaCorrente
    {
        private ContaCorrente[] _itens;
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
            _itens = new ContaCorrente[capacidadeInicial];
            _proximaPosicao = 0;
        }
        public void Adicionar(ContaCorrente item)
        {
            VerificarCapacidade(_proximaPosicao + 1);
            _itens[_proximaPosicao] = item;
            Console.WriteLine($"Adicionado no indice {_proximaPosicao} conta {item.Agencia}/{item.Numero}");
            _proximaPosicao++;
        }

        public void AdicionarVarias( params ContaCorrente[] itens)
        {
            foreach ( ContaCorrente item in itens)
            {
                Adicionar(item);
            }
        }

        public void EscreverLista()
        {
            for (int i = 0; i < _proximaPosicao; i++)
            {
                ContaCorrente conta = _itens[i];
                Console.WriteLine($"A conta no indice{i} é a {conta.Agencia}/{conta.Numero}");
            }
        }

        public void Remover(ContaCorrente item)
        {
            int indiceItem = -1;
            for (int i = 0; i < _proximaPosicao; i++)
            {
                ContaCorrente contaAtual = _itens[i];
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

        public ContaCorrente GetItemNoIndice( int indice)
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

            ContaCorrente[] novoArray = new ContaCorrente[novoTamanho];

            Array.Copy(_itens, novoArray, _itens.Length);

            _itens = novoArray;

        }
    }
}
