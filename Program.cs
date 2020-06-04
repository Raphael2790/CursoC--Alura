using _01_ByteBank.Funcionarios;
using _01_ByteBank.Sistema;
using System;

namespace _01_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            GerenteDeContas Raphael = new GerenteDeContas(2000, "401.919.868-36");
            Diretor Monica = new Diretor(5000, "401.254.521-45");
            Monica.AumentarSalario();
            Raphael.AumentarSalario();
            

            ContaCorrente contaRaphael = new ContaCorrente(0296,806129);
            ContaCorrente contaMonica = new ContaCorrente(0296, 864249);

            contaRaphael.Titular = new Cliente();
            contaRaphael.Titular.Nome = "Raphael";
            contaRaphael.Titular.CPF = "401.919.868-36";
            contaRaphael.Titular.Profissao = "Desenvolvedor Junior";

            contaRaphael.Saldo = 10000;

            Console.WriteLine(Raphael.Salario);
            Console.WriteLine(Monica.Salario);
            
            CalcularBonificacao();

            UsarSistema();

            try
            {
                contaRaphael.Tranferir(20000, contaMonica);
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine("Aconteceu o erro " + e.Message);
            }
            catch(OperacaoFinanceiraException e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
                Console.WriteLine("INNEREXCEPTION:");
                Console.WriteLine(e.InnerException.Message);
                Console.WriteLine(e.InnerException.StackTrace);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void CalcularBonificacao()
        {
            GerenciarBonificacao gerenciarBonificacao = new GerenciarBonificacao();
            Funcionario Raphael = new Auxiliar(2000, "401.919.868-36");
            Funcionario Monica = new Diretor(5000, "401.254.521-45");

            gerenciarBonificacao.Registrar(Raphael);
            gerenciarBonificacao.Registrar(Monica);
            Console.WriteLine("Estas serão as bonificações pagas para os funcionários até o momento:"+ gerenciarBonificacao.GetBonificacao()); 
        }
        public static void UsarSistema()
        {
            SistemaInterno sistema = new SistemaInterno();
            GerenteDeContas Raphael = new GerenteDeContas(2000, "401.919.868-36");
            Diretor Monica = new Diretor(5000, "401.254.521-45");
            ParceiroComercial Miguel = new ParceiroComercial();
            Monica.Senha = "1234";
            Raphael.Senha = "12345";
            Miguel.Senha = "123457";
            sistema.Logar(Monica, "1234");
            sistema.Logar(Raphael, "abc");
            sistema.Logar(Miguel, "123457");
        }
        public static int Dividir(int numero, int divisor)
        {   
            try
            {

                return numero / divisor;
            }
            catch(DivideByZeroException)
            {
                Console.WriteLine("A divisão por "+ numero +" e "+ divisor + " não foi possivel" );
                throw;
            }
        }

        static void Metodo()
        {
            TestaDivisao(0);
        }
        static void TestaDivisao(int divisor)
        {
            Dividir(10, divisor);
        }
    }

}
