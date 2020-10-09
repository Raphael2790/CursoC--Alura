using System;
using System.Collections.Generic;
using System.Linq;

namespace TrabalhandoComColeções
{
    internal class Pedagio
    {
        private Queue<string> _filaPedagio = new Queue<string>();
        public Pedagio()
        {
        }

        internal void Enfileirar(string carro)
        {
            _filaPedagio.Enqueue(carro);
            Console.WriteLine($"Entrando na fila : {carro}");
            ListarFila(_filaPedagio);
        }

        internal void ListarFila(Queue<string> fila)
        {
            Console.WriteLine("FILA");
            foreach (var v in fila)
            {
                Console.WriteLine(v);
            }
        }

        internal void Desenfileirar()
        {
            try
            {
                var carroSaindo = _filaPedagio.Dequeue();
                Console.WriteLine($"Saindo da fila agora: {carroSaindo}");
                ListarFila(_filaPedagio);
                var proximoCarro = _filaPedagio.Peek();
                Console.WriteLine($"O próximo veiculo a ser atendido é : {proximoCarro}");
            }
            catch(Exception)
            {
                Console.WriteLine("Não há mais carros na fila!");
            }

            
        }
    }
}