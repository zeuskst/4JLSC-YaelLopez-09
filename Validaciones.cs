using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Identity.Client;

namespace _4JLSC_YaelLopez_09
{
    public static class Validaciones
    {
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
            else if(!float.TryParse(entrada, out numero)) return false;
            else if(numero<=0) return false;
            else return true; 



        }
        public static bool ValidarTelefono(string entrada)
        {
            if(string.IsNullOrEmpty(entrada)|| entrada.Length!=10 || !entrada.All(char.IsDigit)) return false;
            else return true;
        }

        public static bool EntradaValida(string entrada)
        {
            if(string.IsNullOrEmpty(entrada)) return false;
            else{
                string patron = @"^[a-zA-Z\s]+$";
                return Regex.IsMatch(entrada, patron);
            }
        }
    }
}
