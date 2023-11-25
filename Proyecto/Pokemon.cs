using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    internal class Pokemon
    {
        private string nombre;
        private string descripcion; 
        private string tipo;
        private string imagen;
        private List<string> movimientos;


        public Pokemon(string nombre, string descripcion, string tipo, string imagen, List<string> movimientos)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.tipo = tipo;
            this.imagen = imagen;
            this.movimientos = movimientos;

        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public string Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }
        public List<string> Movimientos
        {
            get { return movimientos; }
            set { movimientos = value; }
        }



    }
}
