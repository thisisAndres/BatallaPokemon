using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class Configuracion
    {
        public static string Archivos { get; private set; }
      

        static Configuracion()
        {
            // Inicializar la propiedad estática en el constructor estático
            Archivos = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            
        }
    }



}
