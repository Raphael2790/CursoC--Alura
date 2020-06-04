using System;
using System.Collections.Generic;
using System.Text;

namespace _01_ByteBank.Funcionarios
{
    public abstract class Funcionario
    {
        public string Nome { get; set; }
        public string CPF { get; private set; }
        public double Salario { get; protected set; }

        public static int TotalFuncionarios { get; private set; }

        public abstract double GetBonificacao();

        public Funcionario(double salario,string cpf)
        {
            CPF = cpf;
            Salario = salario;
            TotalFuncionarios++;
        }

        public abstract void AumentarSalario();

    }
}
