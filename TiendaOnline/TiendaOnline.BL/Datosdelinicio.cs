using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaOnline.BL
{
    public class DatosdeInicio : CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {
            var usuario1 = new Usuario();
            usuario1.Id = 1;
            usuario1.Nombre = "Kesia";
            usuario1.Contrasena = Encriptar.CodificarContrasena("123");
            contexto.Usuarios.Add(usuario1);

            var usuario2 = new Usuario();
            usuario2.Id = 2;
            usuario2.Nombre = "Gricelda";
            usuario2.Contrasena = Encriptar.CodificarContrasena("123");
            contexto.Usuarios.Add(usuario2);

            var usuario3 = new Usuario();
            usuario3.Id = 3;
            usuario3.Nombre = "Alma";
            usuario3.Contrasena = Encriptar.CodificarContrasena("123");
            contexto.Usuarios.Add(usuario3);

            var usuario4 = new Usuario();
            usuario4.Id = 4;
            usuario4.Nombre = "Gabriela";
            usuario4.Contrasena = Encriptar.CodificarContrasena("123");
            contexto.Usuarios.Add(usuario4);

            base.Seed(contexto);
        }
    }
}