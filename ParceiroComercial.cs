using _01_ByteBank.Sistema;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_ByteBank
{
    class ParceiroComercial: IAutenticavel
    {
        public string Senha { get; set; }
        public bool Autenticar(string senha)
        {
            return Senha == senha;
        }
    }
}
