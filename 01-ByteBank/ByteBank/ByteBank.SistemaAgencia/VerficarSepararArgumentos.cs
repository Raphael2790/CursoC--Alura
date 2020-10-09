using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    class VerficarSepararArgumentos
    {
        public string URL { get; }
        private readonly string _arguments;
        public VerficarSepararArgumentos(string url)
        {
            bool isValidString = String.IsNullOrEmpty(url);

            if (isValidString)
            {
                throw new ArgumentException("O argumento da url não pode ser vazio ou nulo.", nameof(url));
            }

            int indiceInterrogacao = url.IndexOf('?');
            _arguments = url.Substring(indiceInterrogacao + 1);

            URL = url;
        }
        public string GetValor(string nomeParametro)
        {
            string parametroUpper = nomeParametro.ToUpper();
            string argumentsUpper = _arguments.ToUpper();

            string termo = parametroUpper + "=";
            int indiceParametro = argumentsUpper.IndexOf(termo);
            string resultado = _arguments.Substring(indiceParametro + termo.Length);
            int indiceEComercial = resultado.IndexOf('&');
             

            if(indiceEComercial == -1)
            {
                return resultado;
            }
            return resultado.Remove(indiceEComercial); ;
        }
    }
}
