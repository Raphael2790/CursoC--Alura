using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TrabalhandoComColeções
{
    class Program
    {
        static void Main(string[] args)
        {
            ReturnALinkedList();

            Console.WriteLine();

            ReturnAStackExample();

            Console.WriteLine();

            ReturnAQueueExample();

            Console.WriteLine();

            SortedItensExample();

            Console.WriteLine();

            MultiArrayExample();

            Console.WriteLine();

            JaggedArrayExample();

            Console.WriteLine();

            LinqConsultingExample();

            Console.WriteLine();

            // COVARIÂNCIA - a declaração e a atribuição são iniciados com valores equivalentes
            IEnumerable<object> enumObj = new List<string>();
            // Também são covariantes , uma vez atrbuido um array de strings o tipo do objeto é de strings
            // Porém é uma má prática de conversão ou covariancia de tipo, pois ainda podemos acessar diretamente os indicespara atribuições
            object[] objetcs = new string[4];
        }

        private static void LinqConsultingExample()
        {
            string[] seq1 = { "janeiro", "fevereiro", "março" };
            string[] seq2 = { "fevereiro", "MARÇO", "abril" };

            List<Mes> mesesAno = new List<Mes> {
                new Mes("Janeiro", 31),
                new Mes("Fevereiro",28),
                new Mes("Março", 31),
                new Mes("Abril" , 30),
                new Mes("Maio", 31),
                new Mes("Junho", 30),
                new Mes("Julho" ,31),
                new Mes("Agosto" ,31),
                new Mes("Setembro", 30),
                new Mes("Outubro" ,31),
                new Mes("Novembro" ,30),
                new Mes("Dezembro" ,31)
            };

            mesesAno.Sort();
            foreach (var mes in mesesAno)
            {
                if (mes.Dias == 31)
                    Console.WriteLine(mes.Nome.ToUpper());
            }

            Console.WriteLine();
            //Usando linq para atingir o mesmo resultado
            //Ainda levando em consideração que é uma má pratica modificar itens originais, sempre crie uma cópia
            IEnumerable<string> meses = mesesAno
                                .Where(x => x.Dias == 31)
                                .OrderBy(x => x.Nome)
                                .Select(x => x.Nome.ToUpper());

            foreach (var mes in meses)
            {
                Console.WriteLine(mes);
            }
            Console.WriteLine();

            var consulta = mesesAno.Take(3);// recebe os 3 primeiros itens da coleção
            var consulta2 = mesesAno.Skip(3);// recebe todos os meses do ano pulando os 3 primeiros
            var consulta3 = mesesAno.Skip(6).Take(3);// recebe os meses do ano pulando 6 e pegando 3 na sequencia
            var consulta4 = mesesAno.TakeWhile(x => !x.Nome.StartsWith("S")); //recebe todos os meses do ano em sequencia até o primeiro com nome começando com S
            var consulta5 = mesesAno.SkipWhile(x => !x.Nome.StartsWith("S"));
            var consulta6 = seq1.Union(seq2);//une dois conjuntos 
            //une dois conjuntos ignorando letras maiusculas
            var consulta7 = seq1.Union(seq2, StringComparer.InvariantCultureIgnoreCase);
            foreach (var item in consulta7)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            //recebe a intersecção entre dois conjuntos ignorando letras maiusculas
            var consulta8 = seq1.Intersect(seq2, StringComparer.InvariantCultureIgnoreCase);
            foreach (var item in consulta8)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            //recebe a diferença dos elementos contido no conjunto 1 para o 2
            var consulta9 = seq1.Except(seq2);
            foreach (var item in consulta9)
            {
                Console.WriteLine(item);
            }
            //faz a junção entre dois conjuntos, porém não aceita comparador como o metodo Union
            var consulta10 = seq1.Concat(seq2);
        }

        private static void JaggedArrayExample()
        {
            // Exemplo de array denteado, geralmente utilizado quando precisamos criar arrays de arrays
            string[][] jaggedArray = new string[3][];

            jaggedArray[0] = new string[] { "Fred", "Wilma", "Pedrita" };
            jaggedArray[1] = new string[] { "Homer", "Marge", "Lisa", "Bart", "Maggie" };
            jaggedArray[2] = new string[] { "Florinda", "Kiko" };

            foreach (var familia in jaggedArray)
            {
                Console.WriteLine(string.Join(',', familia));
            }
        }

        private static void MultiArrayExample()
        {
            //Declaração já implementando o array
            string[,] multidimensionalArray = new string[3, 3]
            {
                {"Alemanha", "Espanha", "Itália" },
                { "Argentina",  "Holanda",  "França"},
                { "Holanda" ,  "Alemanha" ,  " Alemanha"}
            };

            //iniação de intância de um array multidimensional
            string[,] multiArray = new string[4, 3];

            multiArray[0, 0] = "Alemanha";
            multiArray[1, 0] = "Argentina";
            multiArray[2, 0] = "Holanda";
            multiArray[3, 0] = "Brasil";

            multiArray[0, 1] = "Espanha";
            multiArray[1, 1] = "Holanda";
            multiArray[2, 1] = "Alemanha";
            multiArray[3, 1] = "Uruguai";

            multiArray[0, 2] = "Itália";
            multiArray[1, 2] = "França";
            multiArray[2, 2] = "Alemanha";
            multiArray[3, 2] = "Portugal";

            for (int copa = 0; copa < 3; copa++)
            {
                int ano = 2014 - copa * 4;
                Console.Write(ano.ToString().PadRight(12));
            }
            Console.WriteLine();
            // A função GetUpperBound pega o indice maximo do dimensão da matriz começamdo por 0 também
            for (int posicao = 0; posicao <= multiArray.GetUpperBound(0); posicao++)
            {
                for (int copa = 0; copa <= multiArray.GetUpperBound(1); copa++)
                {
                    Console.Write(multiArray[posicao, copa].PadRight(12));
                }
                Console.WriteLine();
            }
        }

        private static void SortedItensExample()
        {
            //Uma lista ordenada tem como base um dicionário, porém ela é ordenada de acordo com sua chave
            //Um dicionário é organizado por hash
            //Uma lista ordenada é menos indexada e mais custosa, pois na sua inserção ou remoção temos que iterar sobre todos elementos
            //Quando usar: quando já temos uma lista totalmente populada e não faremos constantes remoções e implementações
            IDictionary<string, Cliente> sortedClientList = new SortedList<string, Cliente>();
            Cliente cliente1 = new Cliente("Raphael", "64538292917", "Programador");
            Cliente cliente2 = new Cliente("Monica", "23678965412", "Perfumista");
            sortedClientList.Add(cliente1.CPF, cliente1);
            sortedClientList.Add(cliente2.CPF, cliente2);
            foreach (var item in sortedClientList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            //Um dicionario ordenado funciona semelhante a uma lista ordenada, porém é de mais rápida indexação
            //Pois trabalha com redistruição binária de elementos
            //Quando usar: Quando precisamos remover e inserir elementos em uma lista com frequência
            //Cenário ideal seria quando precisamos implementar a mesma aos poucos e precisamos de agilidade nas buscas
            IDictionary<string, Cliente> sortedClientDictionary = new SortedDictionary<string, Cliente>(new ComparadorTextos());
            sortedClientDictionary.Add(cliente1.CPF, cliente1);
            sortedClientDictionary.Add(cliente2.CPF, cliente2);
            foreach (var item in sortedClientList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //SortedSet são hashs ordenados porém não implementam chaves para ordenação e sim ordenam pelo próprio valor
            //Sua indexação é feita por arvore binária
            //Pode receber como parametro um comparador para evitar valores duplicados
            //Sets permitem comparações entre si, usando a teoria dos conjuntos para verificar intersecções, uniões, elementos em comum
            //Ou ainda elementos incomuns
            ISet<string> sortedSet = new SortedSet<string>(new ComparadorTextos())
            {
                "Raphael Silvestre",
                "Monica Silva",
                "Aline Silva",
                "Junior Oliveira",
                "RAPHAEL SILVESTRE"
            };

            sortedSet.Add("Vanessa Silvestre");
            foreach (var item in sortedSet)
            {
                Console.WriteLine(item);
            }

            ISet<string> sortedSet2 = new HashSet<string>();

            Console.WriteLine(sortedSet.SetEquals(sortedSet2));
        }

        private static void ReturnAQueueExample()
        {
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

        private static void ReturnAStackExample()
        {
            //Exemplo de Stack
            Navegador navegador = new Navegador();
            navegador.navegarPara("vazia");
            navegador.navegarPara("www.google.com");
            navegador.navegarPara("www.alura.com.br");
            navegador.navegarPara("www.caelum.com.br");
            navegador.Anterior();
            navegador.Anterior();
            navegador.Proximo();
            navegador.Proximo();
        }

        private static void ReturnALinkedList()
        {
            //Quando usar uma lista ligada? Quando necessário remover mais vezes elementos no meio de um lista
            //Listas ligadas não possuem indice, buscas, remoções são feitas pelo próprio elemento
            // Inserções são feitas com base em algum elemento
            LinkedList<string> daysOfWeek = new LinkedList<string>();

            var d1 = daysOfWeek.AddFirst("domingo");
            var d7 = daysOfWeek.AddLast("sábado");
            var d2 = daysOfWeek.AddAfter(d1, "segunda");

            // Não podemos usar for em listas ligadas por falta de um indice
            foreach (var day in daysOfWeek)
            {
                Console.WriteLine(day);
            }
        }

        public class Mes : IComparable
        {

            public string Nome { get; private set; }
            public int Dias { get; private set; }
            public Mes(string nome, int dias)
            {
                Nome = nome;
                Dias = dias;
            }

            public override string ToString()
            {
                return $"{Nome} - {Dias}";
            }

            public int CompareTo(object obj)
            {
                Mes outroMes = obj as Mes;
                return this.Nome.CompareTo(outroMes.Nome);
            }
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
