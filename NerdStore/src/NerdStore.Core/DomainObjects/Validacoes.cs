using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NerdStore.Core.DomainObjects
{
    public class Validacoes
    {
        public static void ValidarSeIgual(object object1, object object2, string mensagem)
        {
            if (!object1.Equals(object2))
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeDiferente(object object1, object object2, string mensagem)
        {
            if(object1.Equals(object2))
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarCaracteres(string valor, int maximo, string mensagem)
        {
            var length = valor.Length;

            if(length > maximo)
                throw new DomainException(mensagem);
        }

        public static void ValidarCaracteres(string valor, int minimo, int maximo, string mensagem)
        {
            var length = valor.Trim().Length;

            if (length < maximo || length > maximo)
                throw new DomainException(mensagem);
        }

        public static void ValidarExpressao(string pattern, string valor, string mensagem)
        {
            var regex = new Regex(pattern);

            if(!regex.IsMatch(valor))
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeVazio(string valor, string mensagem)
        {
            if (valor == null || valor.Trim().Length == 0)
                throw new DomainException(mensagem);
        }

        public static void ValidarSeNulo(object object1, string mensagem)
        {
            if (object1 == null)
            {
                throw new DomainException(mensagem);
            }
        }
    }
}
