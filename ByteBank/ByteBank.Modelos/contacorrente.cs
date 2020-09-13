using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    /// <summary>
    /// Está classe é responsavél pela criar Contas no ByteBank
    /// </summary>
    public class ContaCorrente : IComparable
    {
        private static int TaxaOperacao;

        public static int TotalDeContasCriadas { get; private set; }

        public Cliente Titular { get; set; }

        public int ContadorSaquesNaoPermitidos { get; private set; }
        public int ContadorTransferenciasNaoPermitidas { get; private set; }

        public int Numero { get; }
        public int Agencia { get; }

        private double _saldo = 100;
        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }

        /// <summary>
        /// Este metodo é o construtor das Contas Corrente
        /// </summary>
        /// <exception cref="ArgumentException">Exceção para o valor <paramref name="agencia"/> e <paramref name="numero"/> deve ser maior que 0</exception>
        /// <param name="agencia">Responsavel por implementar a propriedade <see cref="Agencia"/></param>
        /// <param name="numero">Responsável por implementar a propriedade <see cref="Numero"/></param>
        public ContaCorrente(int agencia, int numero)
        {
            if (numero <= 0)
            {
                throw new ArgumentException("O argumento agencia deve ser maior que 0.", nameof(agencia));
            }

            if (numero <= 0)
            {
                throw new ArgumentException("O argumento numero deve ser maior que 0.", nameof(numero));
            }

            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }

        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para o saque.", nameof(valor));
            }

            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }

            _saldo -= valor;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para a transferência.", nameof(valor));
            }

            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new OperacaoFinanceiraException("Operação não realizada.", ex);
            }

            contaDestino.Depositar(valor);
        }

        public override string ToString()
        {
            return $"Sua agencia {Agencia}, sua conta {Numero} e seu saldo é {Saldo}";
        }
        public override bool Equals(object obj)
        {
            var outraConta = obj as ContaCorrente;

            if(outraConta == null)
            {
                return false;
            }

            return outraConta.Numero == Numero && outraConta.Agencia == Agencia;
        }

        public int CompareTo(object obj)
        {
            var outraConta = obj as ContaCorrente;

            if(outraConta == null)
            {
                return -1;
            }

            if(Numero > outraConta.Numero)
            {
                return -1;
            }
            if(Numero == outraConta.Numero)
            {
                return 0;
            }

            return 1;
        }

        public override int GetHashCode()
        {
            int hashCode = -1221596495;
            hashCode = hashCode * -1521134295 + EqualityComparer<Cliente>.Default.GetHashCode(Titular);
            return hashCode;
        }
    }

}
