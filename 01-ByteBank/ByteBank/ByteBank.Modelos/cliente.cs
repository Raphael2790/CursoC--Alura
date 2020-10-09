using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Profissao { get; set; }

        public Cliente()
        {

        }

        public Cliente(string nome, string cPF, string profissao)
        {
            Nome = nome;
            CPF = cPF;
            Profissao = profissao;
        }

        public override bool Equals(object obj)
        {
            Cliente outroCliente = obj as Cliente;

            if(outroCliente == null)
            {
                return false;
            }
            return CPF == outroCliente.CPF;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"O nome do cliente é {Nome} e sua profissão é {Profissao}, a chave para ordenação é " +
                $"o CPF do cliente";
        }
    }
}
