using _01_ByteBank.Sistema;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_ByteBank.Funcionarios
{
    public class GerenteDeContas : FuncionarioAutenticavel
    {
        public GerenteDeContas(double salario, string cpf) : base(4000, cpf)
        {

        }

        public override void AumentarSalario()
        {
            Salario *= 1.05;
        }

        public override double GetBonificacao()
        {
            return Salario *= 0.25;
        }
    }
}
