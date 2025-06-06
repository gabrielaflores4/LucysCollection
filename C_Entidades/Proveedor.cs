﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Entidades
{
    public class Proveedor
    {
        //Atributos del Proveedor
        public int IdProveedor { get; set; }
        public string NombreProv { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }


        // Constructor por defecto
        public Proveedor(){}

        // Constructor personalizado
        public Proveedor(int id, string nombreProv, string direccion, string telefono, string correo)
        {
            IdProveedor = id;
            NombreProv = nombreProv;
            Direccion = direccion;
            Telefono = telefono;
            Correo = correo;
        }
    }
}
