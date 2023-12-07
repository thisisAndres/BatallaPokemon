using Proyecto;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokemons
{
    public partial class Fasefinal16 : Form
    {
        string Archivos = Configuracion.Archivos;
        List<objetoJugador> jugadores = new List<objetoJugador>();
        Controlador imagenesrnd = new Controlador();
        int cantidadbots;
        public Fasefinal16()
        {
            InitializeComponent();
        }

        public Fasefinal16(List<objetoJugador> listaGanadores)
        {
            InitializeComponent();
            // Cargar el archivo de sonido
            this.jugadores = listaGanadores;
        }

        public Fasefinal16(List<objetoJugador> listaJugadores, int cantidadbots)
        {
            InitializeComponent();
            // Cargar el archivo de sonido
            this.cantidadbots = cantidadbots;
            this.jugadores = listaJugadores;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Seleccionpokemon equipo = new Seleccionpokemon(jugadores, cantidadbots);
            equipo.Show();
            this.Hide();
        }

        private void Fasefinal16_Load(object sender, EventArgs e)
        {
            mostrarImagenes();
            mostrarImagenesAleatorias();
            reproducirSonido();
        }

        public void mostrarImagenes()
        {
            string ruta = Path.Combine(Archivos, "Resources\\");

            BackgroundImage = Image.FromFile(ruta + "fondofase.jpg");
            BackgroundImageLayout = ImageLayout.Stretch;

            pictureBox1.Image = Image.FromFile(ruta + "\\imagenes\\" + "copa.jpg");

            pictureBox33.Image = Image.FromFile(ruta + "\\imagenes\\" + "fasetexto.gif");
        }

        public void mostrarImagenesAleatorias()
        {
            List<string> rutasImagenes = imagenesrnd.ObtenerImagenesEntrenadores_16();

            if (rutasImagenes != null && rutasImagenes.Count >= 16)
            {
                pictureBox2.Image = Image.FromFile(rutasImagenes[0]);
                pictureBox3.Image = Image.FromFile(rutasImagenes[1]);
                pictureBox4.Image = Image.FromFile(rutasImagenes[2]);
                pictureBox5.Image = Image.FromFile(rutasImagenes[3]);
                pictureBox6.Image = Image.FromFile(rutasImagenes[4]);
                pictureBox7.Image = Image.FromFile(rutasImagenes[5]);
                pictureBox8.Image = Image.FromFile(rutasImagenes[6]);
                pictureBox9.Image = Image.FromFile(rutasImagenes[7]);
                pictureBox10.Image = Image.FromFile(rutasImagenes[8]);
                pictureBox11.Image = Image.FromFile(rutasImagenes[9]);
                pictureBox12.Image = Image.FromFile(rutasImagenes[10]);
                pictureBox13.Image = Image.FromFile(rutasImagenes[11]);
                pictureBox14.Image = Image.FromFile(rutasImagenes[12]);
                pictureBox15.Image = Image.FromFile(rutasImagenes[13]);
                pictureBox16.Image = Image.FromFile(rutasImagenes[14]);
                pictureBox17.Image = Image.FromFile(rutasImagenes[15]);



            }
            else
            {
               //MessageBox.Show("No hay suficientes imágenes.");
                MessageBox.Show("No hay suficientes imágenes.",
                                "Pokemon Primera Generación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<string> MostrarImagenesAleatorias()
        {
            List<string> rutasImagenes = imagenesrnd.ObtenerImagenesEntrenadores_16();

            if (rutasImagenes != null && rutasImagenes.Count >= 16)
            {
                pictureBox2.Image = Image.FromFile(rutasImagenes[0]);
                pictureBox3.Image = Image.FromFile(rutasImagenes[1]);
                pictureBox4.Image = Image.FromFile(rutasImagenes[2]);
                pictureBox5.Image = Image.FromFile(rutasImagenes[3]);
                pictureBox6.Image = Image.FromFile(rutasImagenes[4]);
                pictureBox7.Image = Image.FromFile(rutasImagenes[5]);
                pictureBox8.Image = Image.FromFile(rutasImagenes[6]);
                pictureBox9.Image = Image.FromFile(rutasImagenes[7]);
                pictureBox10.Image = Image.FromFile(rutasImagenes[8]);
                pictureBox11.Image = Image.FromFile(rutasImagenes[9]);
                pictureBox12.Image = Image.FromFile(rutasImagenes[10]);
                pictureBox13.Image = Image.FromFile(rutasImagenes[11]);
                pictureBox14.Image = Image.FromFile(rutasImagenes[12]);
                pictureBox15.Image = Image.FromFile(rutasImagenes[13]);
                pictureBox16.Image = Image.FromFile(rutasImagenes[14]);
                pictureBox17.Image = Image.FromFile(rutasImagenes[15]);



            }
            else
            {
                MessageBox.Show("No hay suficientes imágenes.");
            }

            return rutasImagenes;

        }
        public void reproducirSonido()
        {
            string rutasonido = Path.Combine(Archivos, "Resources", "sonidos", "success.wav");
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = rutasonido;
            //player.Play();
        }
    }
}
