using _01_ByteBank.Sistema;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_ByteBank.Funcionarios
{
    public class Diretor : FuncionarioAutenticavel
    {
        public override double GetBonificacao()
        {
            return Salario*= 0.5;
        }

        public Diretor(double salario, string cpf) : base(5000,cpf)
        {

        }

        public override void AumentarSalario()
        {
            Salario *= 1.15;
        }
    }
}
