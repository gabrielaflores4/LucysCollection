using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Entidades
{
    public class Usuario : Persona
    {
        //Atributos de Usuario
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }


        // Constructor por defecto
        public Usuario(){}

        // Constructor con parámetros (Llama al constructor de la clase heredada)
        public Usuario(int idUsuario, string nombre, string apellido, string rol)
            : base(idUsuario, nombre, apellido, "", "") // Pasamos id, nombre, apellido y dejamos vacíos teléfono y correo
        {
            IdUsuario = idUsuario;
            Nombre = nombre;
            Apellido = apellido;
            Rol = rol;
        }

        public Usuario(int id, string nombre, string apellido, string telefono, string correo, string rol)
        {
            IdUsuario = id;
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Correo = correo;
            Rol = rol;
        }
    }
}
