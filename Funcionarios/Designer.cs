using System;
using System.Collections.Generic;
using System.Text;

namespace _01_ByteBank.Funcionarios
{
    public class Designer : Funcionario
    {
        public Designer(double salario, string cpf) : base(3000, cpf)
        {

        }

        public override double GetBonificacao()
        {
            return Salario *= 0.17;
        }

        public override void AumentarSalario()
        {
            Salario *= 1.11;
        }
    }
}
