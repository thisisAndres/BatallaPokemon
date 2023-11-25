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

namespace Proyecto
{
    public partial class Fasefinal4 : Form
    {
        string Archivos = Configuracion.Archivos;
        List<objetoJugador> jugadores = new List<objetoJugador>();
        Controlador imagenesrnd = new Controlador();
        int cantidadbots;
        public Fasefinal4()
        {
            InitializeComponent();
        }

        public Fasefinal4(List<objetoJugador> listaJugadores, int cantidadbots)
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

        private void Fasefinal4_Load(object sender, EventArgs e)
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

            pictureBox9.Image = Image.FromFile(ruta + "\\imagenes\\" + "fasetexto.gif");
        }

        public void mostrarImagenesAleatorias()
        {
            List<string> rutasImagenes = imagenesrnd.ObtenerImagenesEntrenadores();

            if (rutasImagenes != null && rutasImagenes.Count >= 4)
            {
                pictureBox2.Image = Image.FromFile(rutasImagenes[0]);
                pictureBox3.Image = Image.FromFile(rutasImagenes[1]);
                pictureBox5.Image = Image.FromFile(rutasImagenes[2]);
                pictureBox6.Image = Image.FromFile(rutasImagenes[3]);
            }
            else
            {
                MessageBox.Show("No hay suficientes imágenes.");
            }
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
