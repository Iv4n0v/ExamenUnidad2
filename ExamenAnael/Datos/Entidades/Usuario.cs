﻿namespace Datos.Entidades
{
    public class Usuario
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }
        public string Clave { get; set; }
        public bool EstaActivo { get; set; }

        public Usuario(string codigo, string nombre, string rol, string clave, bool estaActivo)
        {
            Codigo = codigo;
            Nombre = nombre;
            Rol = rol;
            Clave = clave;
            EstaActivo = estaActivo;
        }

        public Usuario()
        {
        }
    }
}
