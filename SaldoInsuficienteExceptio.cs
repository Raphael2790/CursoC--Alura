﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _01_ByteBank
{
    public class SaldoInsuficienteException : Exception
    {
        public double Saldo { get; }
        public double ValorSaque { get; }
        public SaldoInsuficienteException()
        {

        }

        public SaldoInsuficienteException(double saldo, double valorSaque) 
            : this("Tentativa de saque do valor de "+ valorSaque + " em uma conta com saldo de " + saldo)
        {
            Saldo = saldo;
            ValorSaque = valorSaque;
        }
        public SaldoInsuficienteException(string message) : base(message)
        {

        }
    }
}
