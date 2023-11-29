using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Proyecto.Models;

namespace Proyecto
{
    public class Controlador
    {
        ConexionDatos db = new ConexionDatos();
        string Archivos = Configuracion.Archivos;
        private int numeroImagen;

        public List<string> ObtenerListaDeImagenes()
        {
            List<string> rutasDeImagenes = new List<string>();
            List<objetoPokemon> pokemones = db.getPokeLista();



            // Construir la ruta relativa desde la carpeta del proyecto
            string ruta = Path.Combine(Archivos, "Resources", "pokemonfrente");


            // Comprueba si el directorio existe
            if (Directory.Exists(ruta))
            {
                foreach (var id in pokemones)
                {

                    string archivos = ruta + "\\" + id.Id + ".gif";
                    rutasDeImagenes.Add(archivos);

                }
            }
            else
            {
                Console.WriteLine("El directorio de imágenes no existe.");
            }

            return rutasDeImagenes;
        }

        public List<objetoPokemon> obtenerPokeLista()
        {

            List<objetoPokemon> pokemones = db.getPokeLista();

            return pokemones;


        }

        public objetoPokemon obtenerPokemonSeleccionado(string nombrePokemon)
        {

            objetoPokemon pokemon = db.getPokemonSeleccionado(nombrePokemon);

            return pokemon;


        }

        public objetoPokemon obtenerPokemonBot(int nombrePokemon)
        {

            objetoPokemon pokemon = db.getPokemonBot(nombrePokemon);

            return pokemon;


        }

        public int ObtenerImagenesCampoBatalla()
        {
            Random rand = new Random();
            numeroImagen = rand.Next(1, 18);
            return numeroImagen;
        }
        public int ObtenerNumeroImagen()
        {
            return numeroImagen;
        }
        public List<string> ObtenerImagenesEntrenadores()
        {
            // Construir la ruta relativa desde la carpeta del proyecto
            string directorioImagenes = Path.Combine(Archivos, "Resources", "entrenadores2");

            if (Directory.Exists(directorioImagenes))
            {
                List<string> rutasImagenes = new List<string>();
                Random rand = new Random();

                HashSet<int> numerosUsados = new HashSet<int>(); // Almacena números ya utilizados

                for (int i = 1; i < 5; i++)
                {
                    int numeroImagen = i;

                    do
                    {
                        //numeroImagen = rand.Next(1, 17);
                    } while (numerosUsados.Contains(numeroImagen));

                    numerosUsados.Add(numeroImagen);

                    string ruta = Path.Combine(directorioImagenes, $"{numeroImagen}.png");
                    rutasImagenes.Add(ruta);
                }

                return rutasImagenes;
            }
            else
            {
                MessageBox.Show("El directorio de imágenes no existe.");
                return null; // o un valor por defecto, dependiendo de tus necesidades
            }
        }

        public List<string> ObtenerImagenesEntrenadores_8()
        {
            // Construir la ruta relativa desde la carpeta del proyecto
            string directorioImagenes = Path.Combine(Archivos, "Resources", "entrenadores2");

            if (Directory.Exists(directorioImagenes))
            {
                List<string> rutasImagenes = new List<string>();
                Random rand = new Random();

                HashSet<int> numerosUsados = new HashSet<int>(); // Almacena números ya utilizados

                for (int i = 1; i < 9; i++)
                {
                    int numeroImagen = i;

                    do
                    {
                        //numeroImagen = rand.Next(1, 17);
                    } while (numerosUsados.Contains(numeroImagen));

                    numerosUsados.Add(numeroImagen);

                    string ruta = Path.Combine(directorioImagenes, $"{numeroImagen}.png");
                    rutasImagenes.Add(ruta);
                }

                return rutasImagenes;
            }
            else
            {
                MessageBox.Show("El directorio de imágenes no existe.");
                return null; // o un valor por defecto, dependiendo de tus necesidades
            }
        }

        public List<string> ObtenerImagenesEntrenadores_16()
        {
            // Construir la ruta relativa desde la carpeta del proyecto
            string directorioImagenes = Path.Combine(Archivos, "Resources", "entrenadores2");

            if (Directory.Exists(directorioImagenes))
            {
                List<string> rutasImagenes = new List<string>();
                Random rand = new Random();

                HashSet<int> numerosUsados = new HashSet<int>(); // Almacena números ya utilizados

                for (int i = 1; i < 17; i++)
                {
                    int numeroImagen = i;

                    do
                    {
                        //numeroImagen = rand.Next(1, 17);
                    } while (numerosUsados.Contains(numeroImagen));

                    numerosUsados.Add(numeroImagen);

                    string ruta = Path.Combine(directorioImagenes, $"{numeroImagen}.png");
                    rutasImagenes.Add(ruta);
                }

                return rutasImagenes;
            }
            else
            {
                MessageBox.Show("El directorio de imágenes no existe.");
                return null; // o un valor por defecto, dependiendo de tus necesidades
            }

        }
    }
}
