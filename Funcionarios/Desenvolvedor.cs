using System;
using System.Collections.Generic;
using System.Text;

namespace _01_ByteBank.Funcionarios
{
    class Desenvolvedor : Funcionario
    {
        public Desenvolvedor(double salario, string cpf) : base(3000, cpf)
        {

        }

        public override void AumentarSalario()
        {
            Salario *= 1.1;
        }

        public override double GetBonificacao()
        {
            return Salario *= 0.2;
        }
    }
}
