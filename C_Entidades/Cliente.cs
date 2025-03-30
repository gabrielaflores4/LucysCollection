using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Entidades
{
    public class Cliente : Persona
    {
        //Atributos especificos para clientes
        public DateTime FechaRegistro { get; set; }

        //Constructor por defecto, con la fecha de registro automática
        public Cliente()
        {
            FechaRegistro = DateTime.Now;
        }

        // Constructor con todos los parámetros
        public Cliente(int id, string nombre, string apellido, string telefono, string correo)
            : base()
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Correo = correo;
            FechaRegistro = DateTime.Now;
        }

    }
}
