using Microsoft.Data.SqlClient;
using Proyecto.Models;
using System.Media;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Seleccionpokemon : Form
    {
        List<objetoJugador> jugadores = new List<objetoJugador>();
        Controlador controlador = new Controlador();
        internal static Image Image;
        private int indiceJugadorActual = 0;
        string Archivos = Configuracion.Archivos;
        int cantidadbots = 0;
        public Seleccionjugadores Seleccionjugadores = new Seleccionjugadores();

        public Seleccionpokemon()
        {
            InitializeComponent();
            // Cargar el archivo de sonido

        }

        public Seleccionpokemon(List<objetoJugador> listaJugadores, int cantidadbots)
        {
            InitializeComponent();
            // Cargar el archivo de sonido
            this.jugadores = listaJugadores;
            this.cantidadbots = cantidadbots;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string ruta = Path.Combine(Archivos, "Resources\\");


            panel1.BackgroundImage = Image.FromFile(ruta + "pokedex.png");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;

            pictureBox1.Image = Image.FromFile(ruta + "pokemon.png");

            button1.BackgroundImage = Image.FromFile(ruta + "pokedexboton.png");


            CargarDatos();
            mostrarJugador();
        }

        public void CargarDatos()
        {

            flowLayoutPanel1.Controls.Clear();

            // Obtén la lista de rutas de imágenes
            List<string> rutasDeImagenes = controlador.ObtenerListaDeImagenes();

            if (rutasDeImagenes.Count == 151)
            {
                for (int i = 0; i < 151; i++)
                {
                    string rutaImagen = rutasDeImagenes[i];
                    objetoPokemon pokemon = controlador.obtenerPokeLista()[i];

                    flowLayoutPanel1.Controls.Add(new PokeVista(
                        $"{pokemon.nombre}",
                        Image.FromFile(rutaImagen),
                        $"{pokemon.tipo1}",
                        $"{pokemon.tipo2}"
                        ));
                }

            }
            else
            {
                MessageBox.Show("No se encontraron suficientes rutas de imágenes.");
            }


        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (jugadores.Count == indiceJugadorActual)
            {
                Batallapokemon VistaCampoBatalla = new Batallapokemon(jugadores, cantidadbots);
                VistaCampoBatalla.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("No todos los jugadores han seleccionado su equipo!!");
            }

        }




        public void agregarPokemon(string nombre)
        {
            if (jugadores[indiceJugadorActual].pokemones.Count != 6)
            {
                jugadores[indiceJugadorActual].pokemones.Add(controlador.obtenerPokemonSeleccionado(nombre));

            }
        }
        public void agregarPokemonBot()
        {
            Random random = new Random();

            if (jugadores[indiceJugadorActual].pokemones.Count != 6)
            {
                for (int i = 0; i < 7; i++)
                {
                    int pokemonAleatorio = random.Next(1, 152);
                    jugadores[indiceJugadorActual].pokemones.Add(controlador.obtenerPokemonBot(pokemonAleatorio));
                    jugadores[indiceJugadorActual].setBot();
                }

            }
        }
        public void eliminarPokemon(string nombre)
        {
            if (jugadores.Count != indiceJugadorActual)
            {
                objetoPokemon pokemonAEliminar = controlador.obtenerPokemonSeleccionado(nombre);// Crear un objeto Pokemon con el nombre especificado

                if (jugadores[indiceJugadorActual].pokemones.Contains(pokemonAEliminar))
                {
                    jugadores[indiceJugadorActual].pokemones.Remove(pokemonAEliminar);
                }

            }
        }


        public void AgregarImagenSeleccionada(Image imagen)
        {


            if (jugadores[indiceJugadorActual].pokemones.Count != 6)
            {
                //flowLayoutPanel2.Controls.Add(new PokeVista(imagen));
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = imagen;
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Ajustar el tamaño de la imagen si es necesario
                flowLayoutPanel2.Controls.Add(pictureBox);
            }
            else
            {
                MessageBox.Show("LLego al limite de pokemones");
            }

        }

        public void RemoverImagenSeleccionada(Image imagen)
        {
            // Implementa la lógica para quitar la imagen si el CheckBox se desmarca
            foreach (Control control in flowLayoutPanel2.Controls)
            {
                if (control is PictureBox pictureBox && pictureBox.Image == imagen)
                {
                    flowLayoutPanel2.Controls.Remove(pictureBox);
                    pictureBox.Dispose(); // Liberar recursos asociados al control eliminado
                    break; // No es necesario continuar buscando una vez que se encuentra y elimina la imagen
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            var pokeVistas = this.Controls.OfType<PokeVista>();
            int nPokemonesSeleccionados = flowLayoutPanel2.Controls.Count;
            int cantidad = jugadores.Count;
            if (nPokemonesSeleccionados == 6)
            {
                flowLayoutPanel2.Controls.Clear();

                if (jugadores[indiceJugadorActual].pokemones.Count > 0 && jugadores[indiceJugadorActual].pokemones[0] != null)
                {

                    foreach (var pokemon in jugadores[indiceJugadorActual].pokemones)
                    {
                        /*  MessageBox.Show(
                           "El jugador " + indiceJugadorActual + " ha seleccionado a:\n" +
                           "Nombre: " + pokemon.nombre + "\n\n" +
                           "Tipo: " + pokemon.tipo1 + "/" + pokemon.tipo2 + "\n" +
                           "Movimiento 1: " + pokemon.movimiento1 + "/ Poder: " + pokemon.mov1Poder + "\n" +
                           "Movimiento 2: " + pokemon.movimiento2 + "/ Poder: " + pokemon.mov2Poder + "\n" +
                           "Movimiento 3: " + pokemon.movimiento3 + "/ Poder: " + pokemon.mov3Poder + "\n" +
                           "Movimiento 4: " + pokemon.movimiento4 + "/ Poder: " + pokemon.mov4Poder
                           );*/
                    }
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ningún Pokémon.");
                }

                // Aumentar el indice al nuevo jugador
                indiceJugadorActual++;

                // Iterar a través de los controles en el FlowLayoutPanel1
                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    // Verificar si el control es un PokeVista (suponiendo que PokeVista es la clase que contiene los CheckBoxes)
                    if (control is PokeVista pokeVista)
                    {
                        // Desmarcar el CheckBox dentro de cada PokeVista
                        pokeVista.CheckBoxSeleccion.Checked = false;
                    }
                }


                if (indiceJugadorActual != cantidad - cantidadbots)
                {
                    mostrarJugador();
                    cantidad--;
                }
                else
                {
                    MessageBox.Show("Ya todos los jugadores han seleccionado su equipo\n\n A POKEJUGAR!!");
                    button2.Enabled = false;
                    PokeVista pokeVista = null;
                    while (jugadores.Count != indiceJugadorActual)
                    {


                        agregarPokemonBot();
                        indiceJugadorActual++;
                    }

                }


                /*if (jugadores.Count != indiceJugadorActual)
                {
                    mostrarJugador();

                }
                else
                {
                    MessageBox.Show("Ya todos los jugadores han seleccionado su equipo\n\n A POKEJUGAR!!");
                    button2.Enabled = false;
                }*/

            }
            else
            {
                MessageBox.Show("Tu equipo no esta completo!! \n" + Convert.ToString(nPokemonesSeleccionados));
            }




        }
        public void mostrarJugador()
        {
            string idJugador = Convert.ToString(jugadores[indiceJugadorActual].IdJugador);
            label2.Text = idJugador;
        }
    }
}