using _01_ByteBank.Funcionarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_ByteBank
{
    public class GerenciarBonificacao
    {
        private double _totalBonificacao;

        public void Registrar(Funcionario funcionario )
        {
            _totalBonificacao += funcionario.GetBonificacao();
        }

        public double GetBonificacao()
        {
            return _totalBonificacao;
        }


    }
}
