﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _01_ByteBank.Funcionarios
{
    public class Auxiliar : Funcionario
    {
        public Auxiliar (double salario, string cpf) : base(2000,cpf)
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
