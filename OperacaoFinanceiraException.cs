using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace _01_ByteBank
{
    public class OperacaoFinanceiraException : Exception 
    {
        public OperacaoFinanceiraException()
        {

        }
        public OperacaoFinanceiraException(string mensagem) : base(mensagem)
        {

        }
        public OperacaoFinanceiraException(string mensagem, Exception exception) : base(mensagem, exception)
        {

        }
    }
}
