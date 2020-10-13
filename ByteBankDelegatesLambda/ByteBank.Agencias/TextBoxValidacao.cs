using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ByteBank.Agencias
{
    public delegate void ValidationEventHandler(object sender, ValidacaoEventArgs e);
    public class TextBoxValidacao : TextBox
    {
        private ValidationEventHandler _validation;
        public event ValidationEventHandler Validation 
        {
            add
            {
                _validation += value;
                onValidacao();
            }
            remove
            {
                _validation -= value;
            }
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            onValidacao();
        }

        protected virtual void onValidacao()
        {
            if (_validation != null)
            {
                var listaValidacao = _validation.GetInvocationList();
                var eventArgs = new ValidacaoEventArgs(Text);
                var ehValido = true;

                foreach (ValidationEventHandler validacao in listaValidacao)
                {
                    validacao(this, eventArgs);
                    if (!eventArgs.ehValido)
                    {
                        ehValido = false;
                        break;
                    }

                }

                Background = ehValido
                    ? new SolidColorBrush(Colors.White)
                    : new SolidColorBrush(Colors.OrangeRed);
            }
        }
    }
}
