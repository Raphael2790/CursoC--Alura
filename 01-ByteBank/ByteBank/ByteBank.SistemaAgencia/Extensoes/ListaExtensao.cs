using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    public static class ListaExtensao
    {
        public static void AdicionarVarios<T>(this List<T> listaInteiros,params T[] itens)
        {
            foreach (var item in itens)
            {
                listaInteiros.Add(item);
            }
        }
    }
}
