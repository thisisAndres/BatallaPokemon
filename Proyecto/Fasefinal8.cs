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
    public partial class Fasefinal8 : Form
    {
        string Archivos = Configuracion.Archivos;
        List<objetoJugador> jugadores = new List<objetoJugador>();
        Controlador imagenesrnd = new Controlador();
        int cantidadbots;
        bool siguienteRonda;
        bool noHayMasRondas;
        bool ronda2;
        bool ronda3;

        public Fasefinal8()
        {
            InitializeComponent();
            siguienteRonda = false;

        }

        public Fasefinal8(List<objetoJugador> listaJugadores, int cantidadbots)
        {
            InitializeComponent();
            // Cargar el archivo de sonido
            this.jugadores = listaJugadores;
            this.cantidadbots = cantidadbots;
        }

        public Fasefinal8(List<objetoJugador> listaGanadores)
        {
            InitializeComponent();
            // Cargar el archivo de sonido
            if (listaGanadores.Count == 4)
            {
                this.jugadores = listaGanadores;
                siguienteRonda = true;
                noHayMasRondas = false;
                siguienteFase();
                pictureBox2.Dispose();
                pictureBox3.Dispose();
                pictureBox4.Dispose();
                pictureBox5.Dispose();
                pictureBox6.Dispose();
                pictureBox7.Dispose();
                pictureBox8.Dispose();
                pictureBox9.Dispose();
            }
            else if (listaGanadores.Count == 2)
            {
                this.jugadores = listaGanadores;
                siguienteRonda = true;
                noHayMasRondas = false;
                siguienteFase2();
                pictureBox2.Dispose();
                pictureBox3.Dispose();
                pictureBox4.Dispose();
                pictureBox5.Dispose();
                pictureBox6.Dispose();
                pictureBox7.Dispose();
                pictureBox8.Dispose();
                pictureBox9.Dispose();
                pictureBox10.Dispose();
                pictureBox11.Dispose();
                pictureBox12.Dispose();
                pictureBox13.Dispose();
                
            }else 
            {
                this.jugadores = listaGanadores;
                siguienteRonda = false;
                noHayMasRondas = true;
                ganadorTorneo();
                pictureBox2.Dispose();
                pictureBox3.Dispose();
                pictureBox4.Dispose();
                pictureBox5.Dispose();
                pictureBox6.Dispose();
                pictureBox7.Dispose();
                pictureBox8.Dispose();
                pictureBox9.Dispose();
                pictureBox10.Dispose();
                pictureBox11.Dispose();
                pictureBox12.Dispose();
                pictureBox13.Dispose();
                pictureBox14.Dispose();
                pictureBox15.Dispose();
            }


		}
		public void siguienteFase()
		{
			string directorioImagenesGanadores = Path.Combine(Archivos, "Resources", "entrenadores2\\");

			pictureBox10.Image = Image.FromFile(directorioImagenesGanadores + jugadores[0].IdJugador + ".png");
			pictureBox11.Image = Image.FromFile(directorioImagenesGanadores + jugadores[1].IdJugador + ".png");
			pictureBox12.Image = Image.FromFile(directorioImagenesGanadores + jugadores[2].IdJugador + ".png");
			pictureBox13.Image = Image.FromFile(directorioImagenesGanadores + jugadores[3].IdJugador + ".png");

            button1.Text = "Siguiente fase";

		}

        public void siguienteFase2()
        {
            string directorioImagenesGanadores = Path.Combine(Archivos, "Resources", "entrenadores2\\");

            pictureBox14.Image = Image.FromFile(directorioImagenesGanadores + jugadores[0].IdJugador + ".png");
            pictureBox15.Image = Image.FromFile(directorioImagenesGanadores + jugadores[1].IdJugador + ".png");


            button1.Text = "Siguiente fase";

        }

        public void ganadorTorneo()
        {
            string directorioImagenesGanadores = Path.Combine(Archivos, "Resources", "entrenadores2\\");

            pictureBox16.Image = Image.FromFile(directorioImagenesGanadores + jugadores[0].IdJugador + ".png");
            MessageBox.Show("El jugador #" + jugadores[0].IdJugador + " ha ganado el torneo, felicidades!!!");
            button1.Text = "Terminar";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
			if (siguienteRonda)
			{
                Batallapokemon siguienteFase = new Batallapokemon(jugadores, false, true, false);
				siguienteFase.Show();
				this.Hide();
			}
			else if (noHayMasRondas)
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

        private void Fasefinal8_Load(object sender, EventArgs e)
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

            pictureBox17.Image = Image.FromFile(ruta + "\\imagenes\\" + "fasetexto.gif");
        }

        public void mostrarImagenesAleatorias()
        {
            List<string> rutasImagenes = imagenesrnd.ObtenerImagenesEntrenadores_8();

            if (rutasImagenes != null && rutasImagenes.Count >= 8)
            {
                
                pictureBox2.Image = Image.FromFile(rutasImagenes[0]);
                pictureBox3.Image = Image.FromFile(rutasImagenes[1]);
                pictureBox4.Image = Image.FromFile(rutasImagenes[2]);
                pictureBox5.Image = Image.FromFile(rutasImagenes[3]);
                pictureBox6.Image = Image.FromFile(rutasImagenes[4]);
                pictureBox7.Image = Image.FromFile(rutasImagenes[5]);
                pictureBox8.Image = Image.FromFile(rutasImagenes[6]);
                pictureBox9.Image = Image.FromFile(rutasImagenes[7]);
            }
            else
            {
                //MessageBox.Show("No hay suficientes imágenes.");
                MessageBox.Show("No hay suficientes imágenes.",
                                "Pokemon Primera Generación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public List<string> MostrarImagenesAleatorias()
        {
            List<string> rutasImagenes = imagenesrnd.ObtenerImagenesEntrenadores_8();

            if (rutasImagenes != null && rutasImagenes.Count >= 8)
            {

                pictureBox2.Image = Image.FromFile(rutasImagenes[0]);
                pictureBox3.Image = Image.FromFile(rutasImagenes[1]);
                pictureBox4.Image = Image.FromFile(rutasImagenes[2]);
                pictureBox5.Image = Image.FromFile(rutasImagenes[3]);
                pictureBox6.Image = Image.FromFile(rutasImagenes[4]);
                pictureBox7.Image = Image.FromFile(rutasImagenes[5]);
                pictureBox8.Image = Image.FromFile(rutasImagenes[6]);
                pictureBox9.Image = Image.FromFile(rutasImagenes[7]);
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
