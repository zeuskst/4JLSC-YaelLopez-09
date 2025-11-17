using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Identity.Client;

namespace _4JLSC_YaelLopez_09
{
    public static class Validaciones
    {
        public static void EsEnteroValido(string entrada, string Nombrecampo = "")
        {
            int valor = 0;
            if (string.IsNullOrEmpty(entrada))
                throw new CampoVacioException(Nombrecampo);
            else if (!int.TryParse(entrada, out valor))
                throw new EnteroInvalidoExcepcion(Nombrecampo, entrada);
            else if (valor <= 0)
                throw new EnteroInvalidoExcepcion($"El campo '{Nombrecampo}' debe ser mayor a cero.");



        }
        public static void EsFlotanteValido(string entrada, string Nombrecampo = "")

        {
            float numero = 0;
            if (string.IsNullOrEmpty(entrada))
                throw new FlotanteInvalidoException(Nombrecampo);
            else if (!float.TryParse(entrada, out numero))
                throw new FlotanteInvalidoException(Nombrecampo, entrada);
            else if (numero <= 0)
                throw new FlotanteInvalidoException($"El campo '{Nombrecampo}' debe ser mayor a cero.");





        }
        public static void ValidarTelefono(string entrada, string Nombrecampo = "Telefono")
        {
            if (string.IsNullOrEmpty(entrada))
                throw new CampoVacioException(Nombrecampo);

            if (entrada.Length != 10)
                throw new TelefonoInvalidoException($"El teléfono debe tener 10 dígitos, se ingresaron {entrada.Length}.");

            if (!entrada.All(char.IsDigit))
                throw new TelefonoInvalidoException("El teléfono solo debe contener números.");

        }

        public static void EntradaValida(string entrada, string Nombrecampo = "")
        {
            if (string.IsNullOrEmpty(entrada))
                throw new CampoVacioException(Nombrecampo);

            if (!entrada.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                throw new EntradaInvalidaException(Nombrecampo, entrada);

        }

        public static bool EsEnteroValido(string entrada)
        {
            int valor = 0;
            if (string.IsNullOrEmpty(entrada)) return false;
            else if (!int.TryParse(entrada, out valor)) return false;
            else if (valor <= 0) return false;
            else return true;
        }

        public static bool EsFlotanteValido(string entrada)
        {
            float numero = 0;
            if (string.IsNullOrEmpty(entrada)) return false;
            else if (!float.TryParse(entrada, out numero)) return false;
            else if (numero <= 0) return false;
            else return true;
        }

        public static bool ValidarTelefonoLegacy(string entrada)
        {
            if (string.IsNullOrEmpty(entrada) || entrada.Length != 10 || !entrada.All(char.IsDigit))
                return false;
            else
                return true;
        }

        public static bool EntradaValida(string entrada)
        {
            if (string.IsNullOrEmpty(entrada) || !entrada.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                return false;
            else
                return true;
        }
    }
}
