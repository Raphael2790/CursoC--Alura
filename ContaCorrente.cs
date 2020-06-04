using System;
using System.Text.RegularExpressions;

namespace _01_ByteBank
{
    public class ContaCorrente
    {
        public int Agencia { get; }
        public int Conta { get; }
        private double _saldo;

        public static int TotalContasCriadas { get; private set; }
        public static double TaxaOperacao { get; private set; }

        public Cliente Titular { get; set; }
        
        public ContaCorrente(int agencia, int conta)
        {
            if(agencia <= 0)
            {
                throw new ArgumentException("O campo numero da agencia deve ser maior que 0.", 
                    nameof(agencia));
            }

            if(conta <= 0)
            {
                throw new ArgumentException("O campo conta deve ser maior que 0.", nameof(conta));
            }
            Agencia = agencia;
            Conta = conta;

            TotalContasCriadas++;
            TaxaOperacao = 30 / TotalContasCriadas;
        }

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (_saldo < 0)
                {
                    return;
                }

                _saldo = value;
            }

        }

        public bool Sacar(double valor)
        {
            if(valor < 0)
            {
                throw new ArgumentException("Valor inválido para saque" , nameof(valor));
            }
            if (_saldo < valor)
            {
                throw new SaldoInsuficienteException(Saldo, valor);
            }



            _saldo -= valor;
            return true;

        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public void Tranferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para tranferência", nameof(valor));
            }

            Sacar(valor);
            contaDestino.Depositar(valor);
            
        }
    }
}
