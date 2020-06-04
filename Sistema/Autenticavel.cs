using _01_ByteBank.Funcionarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_ByteBank.Sistema
{
    public interface  IAutenticavel
    {
         bool Autenticar(string senha);
    }

    
}
