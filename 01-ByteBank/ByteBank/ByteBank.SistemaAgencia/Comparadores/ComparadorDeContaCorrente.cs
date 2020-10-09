using ByteBank.Modelos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia.Comparadores
{
    class ComparadorDeContaCorrente : IComparer<ContaCorrente>
    {
        public int Compare(ContaCorrente x, ContaCorrente y)
        {
            if (x == y)
            {
                return 0;
            }

            return y.Numero.CompareTo(x.Numero);
        }
    }
}
