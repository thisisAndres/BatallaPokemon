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
        bool segundaRonda;
        bool siguienteRonda;
        bool noHayMasRondas;
        public Fasefinal16()
        {
            InitializeComponent();
        }

        public Fasefinal16(List<objetoJugador> listaGanadores)
        {
            InitializeComponent();
            // Cargar el archivo de sonido

            if (listaGanadores.Count == 8)
            {
                this.jugadores = listaGanadores;
                siguienteRonda = true;
                noHayMasRondas = false;
                segundaFase();

            }
            else if(listaGanadores.Count == 4)
            {
                this.jugadores = listaGanadores;
                siguienteRonda = true;
                noHayMasRondas = false;
                terceraFase();
            }
            else if (listaGanadores.Count == 2)
            {
                this.jugadores = listaGanadores;
                siguienteRonda = true;
                noHayMasRondas = false;
                cuartaFase();
            }
            else
            {
                this.jugadores = listaGanadores;
                siguienteRonda = false;
                noHayMasRondas = true;
                ganadorTorneo();
            }

		}
		public void segundaFase()
		{
			string directorioImagenesGanadores = Path.Combine(Archivos, "Resources", "entrenadores2\\");

			pictureBox19.Image = Image.FromFile(directorioImagenesGanadores + jugadores[0].IdJugador + ".png");
			pictureBox20.Image = Image.FromFile(directorioImagenesGanadores + jugadores[1].IdJugador + ".png");
			pictureBox21.Image = Image.FromFile(directorioImagenesGanadores + jugadores[2].IdJugador + ".png");
			pictureBox22.Image = Image.FromFile(directorioImagenesGanadores + jugadores[3].IdJugador + ".png");
			pictureBox23.Image = Image.FromFile(directorioImagenesGanadores + jugadores[4].IdJugador + ".png");
			pictureBox24.Image = Image.FromFile(directorioImagenesGanadores + jugadores[5].IdJugador + ".png");
			pictureBox25.Image = Image.FromFile(directorioImagenesGanadores + jugadores[6].IdJugador + ".png");
			pictureBox26.Image = Image.FromFile(directorioImagenesGanadores + jugadores[7].IdJugador + ".png");
			button1.Text = "Siguiente fase";

		}
		public void terceraFase()
		{
			string directorioImagenesGanadores = Path.Combine(Archivos, "Resources", "entrenadores2\\");

			pictureBox27.Image = Image.FromFile(directorioImagenesGanadores + jugadores[0].IdJugador + ".png");
			pictureBox28.Image = Image.FromFile(directorioImagenesGanadores + jugadores[1].IdJugador + ".png");
			pictureBox29.Image = Image.FromFile(directorioImagenesGanadores + jugadores[2].IdJugador + ".png");
			pictureBox30.Image = Image.FromFile(directorioImagenesGanadores + jugadores[3].IdJugador + ".png");
			button1.Text = "Siguiente fase";
		}

		public void cuartaFase()
		{
			string directorioImagenesGanadores = Path.Combine(Archivos, "Resources", "entrenadores2\\");

			pictureBox31.Image = Image.FromFile(directorioImagenesGanadores + jugadores[0].IdJugador + ".png");
			pictureBox32.Image = Image.FromFile(directorioImagenesGanadores + jugadores[1].IdJugador + ".png");
			button1.Text = "Siguiente fase";
		}

		public void ganadorTorneo()
		{
			string directorioImagenesGanadores = Path.Combine(Archivos, "Resources", "entrenadores2\\");

			pictureBox18.Image = Image.FromFile(directorioImagenesGanadores + jugadores[0].IdJugador + ".png");
            MessageBox.Show("El jugador #"+ jugadores[0].IdJugador + " ha ganado el torneo, felicidades!!!");

            button1.Text = "Terminar";

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
			if (siguienteRonda)
			{
				Batallapokemon siguienteFase = new Batallapokemon(jugadores, false, false, true);
				siguienteFase.Show();
				this.Hide();
			}else if (noHayMasRondas)
            {
                this.Close();
            }
            else
            {
                // Mantén el código original si la condición no se cumple
                Seleccionpokemon equipo = new Seleccionpokemon(jugadores, cantidadbots);
                equipo.Show();
                this.Hide();
            }

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
