using _01_ByteBank.Funcionarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_ByteBank.Sistema
{
    public class SistemaInterno
    {
        public bool Logar(IAutenticavel funcionario , string senha)
        {
            bool usuarioAutenticado = funcionario.Autenticar(senha);

            if(usuarioAutenticado)
            {
                Console.WriteLine("Bem-vindo");
                return true;
            }
            else
            {
                Console.WriteLine("Senha Inválida");
                return false;
            }
        }
        public bool Logar(GerenteDeContas funcionario, string senha)
        {
            bool usuarioAutenticado = funcionario.Autenticar(senha);

            if (usuarioAutenticado)
            {
                Console.WriteLine("Bem-vindo");
                return true;
            }
            else
            {
                Console.WriteLine("Senha Inválida");
                return false;
            }
        }
    }


}
