using System;
using System.ComponentModel.DataAnnotations;


namespace _4JLSC_YaelLopez_09
{
    public class validacionExcepcion: Exception
    {
        public validacionExcepcion(string mensaje): base( mensaje )
        {

        }
        public validacionExcepcion(string mensaje, Exception inner): base( mensaje, inner )
        {
        }
    }
    public class EnteroInvalidoExcepcion:validacionExcepcion
    {
        public EnteroInvalidoExcepcion():base("\"El valor ingresado no es un número entero válido o es menor o igual a cero.\"") { }
        public EnteroInvalidoExcepcion(string mensaje): base(mensaje) { }

        public EnteroInvalidoExcepcion(string campo,string valor) : base($"El campo '{campo}' con valor '{valor}' no es un entero válido.") {}
        
    }

    public class FlotanteInvalidoException : Exception
    {
        public FlotanteInvalidoException()
            : base("El valor ingresado no es un número decimal válido o es menor o igual a cero.") { }

        public FlotanteInvalidoException(string mensaje) : base(mensaje) { }

        public FlotanteInvalidoException(string campo, string valor)
            : base($"El campo '{campo}' con valor '{valor}' no es un número decimal válido.") { }
    }
    public class TelefonoInvalidoException : Exception
    {
        public TelefonoInvalidoException()
            : base("El teléfono debe contener exactamente 10 dígitos numéricos.") { }

        public TelefonoInvalidoException(string mensaje) : base(mensaje) { }

        public TelefonoInvalidoException(string campo, string valor)
            : base($"El campo '{campo}' con valor '{valor}' no es un teléfono válido. Debe contener exactamente 10 dígitos numéricos.") { }


    }
    public class EntradaInvalidaException : Exception
    {
        public EntradaInvalidaException()
            : base("La entrada debe contener solo letras y espacios.") { }

        public EntradaInvalidaException(string mensaje) : base(mensaje) { }

        public EntradaInvalidaException(string campo, string valor)
            : base($"El campo '{campo}' con valor '{valor}' contiene caracteres no permitidos. Solo se permiten letras y espacios.") { }
    }

    public class CampoVacioException : Exception
    {
        public CampoVacioException()
            : base("El campo no puede estar vacío.") { }

        public CampoVacioException(string campo)
            : base($"El campo '{campo}' es obligatorio y no puede estar vacío.") { }
    }

}
