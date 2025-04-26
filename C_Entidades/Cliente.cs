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
        public string NombreCompleto => $"{Nombre} {Apellido}";


        //Constructor por defecto
        public Cliente()
        {

        }

        // Constructor con todos los parámetros
        public Cliente(int id, string nombre, string apellido, string telefono, string correo)
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
