﻿using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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
        List<objetoJugador> jugadoresCiclo2 = new List<objetoJugador>();
        Controlador imagenesrnd = new Controlador();
        int cantidadbots;
        public List<string> rutasImagenesAleatorias;
        bool segundaRonda;
        bool primerRonda = true;

        public Fasefinal4()
        {
            InitializeComponent();
        }

        public Fasefinal4(List<objetoJugador> listaGanadores)
        {
            InitializeComponent();
            this.jugadores = listaGanadores;


            if (listaGanadores.Count < 2)
            {
                ganadorTorneo();
                pictureBox2.Dispose();
                pictureBox3.Dispose();
                pictureBox4.Dispose();
                pictureBox5.Dispose();
                pictureBox6.Dispose();
                pictureBox7.Dispose();
            }
            else
            {
                segundaFase();
                pictureBox2.Dispose();
                pictureBox3.Dispose();
                pictureBox4.Dispose();
                pictureBox5.Dispose();
            }
        }
        public void segundaFase()
        {
            string directorioImagenesGanadores = Path.Combine(Archivos, "Resources", "entrenadores2\\");

            pictureBox6.Image = Image.FromFile(directorioImagenesGanadores + jugadores[0].IdJugador + ".png");
            pictureBox7.Image = Image.FromFile(directorioImagenesGanadores + jugadores[1].IdJugador + ".png");
            button1.Text = "Siguiente fase";
            primerRonda = false;
            segundaRonda = true;
        }
        public void ganadorTorneo()
        {
            string directorioImagenesGanadores = Path.Combine(Archivos, "Resources", "entrenadores2\\");

            pictureBox8.Image = Image.FromFile(directorioImagenesGanadores + jugadores[0].IdJugador + ".png");
            MessageBox.Show("El jugador #" + jugadores[0].IdJugador + " ha ganado el torneo, felicidades!!!");
            button1.Text = "Terminar";
            primerRonda = false;
            segundaRonda = false;

        }
        public Fasefinal4(List<objetoJugador> listaJugadores, int cantidadbots)
        {
            InitializeComponent();
            // Cargar el archivo de sonido
            this.cantidadbots = cantidadbots;
            this.jugadores = listaJugadores;
        }
        public List<string> RutasImagenesAleatorias
        {
            get { return rutasImagenesAleatorias; }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (primerRonda)
            {
                // Mantén el código original si la condición no se cumple
                Seleccionpokemon equipo = new Seleccionpokemon(jugadores, cantidadbots);
                equipo.Show();
                this.Hide();

            }
            else if (segundaRonda)
            {
                Batallapokemon siguienteFase = new Batallapokemon(jugadores, true, false, false);
                siguienteFase.Show();
                this.Hide();
            }
            else
            {

                this.Close();

            }

        }

        private void Fasefinal4_Load(object sender, EventArgs e)
        {
            mostrarImagenes();
            MostrarImagenesAleatorias();
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

        public List<string> MostrarImagenesAleatorias()
        {
            rutasImagenesAleatorias = imagenesrnd.ObtenerImagenesEntrenadores();

            if (rutasImagenesAleatorias != null && rutasImagenesAleatorias.Count >= 4)
            {
                pictureBox2.Image = Image.FromFile(rutasImagenesAleatorias[0]);
                pictureBox3.Image = Image.FromFile(rutasImagenesAleatorias[1]);
                pictureBox4.Image = Image.FromFile(rutasImagenesAleatorias[2]);
                pictureBox5.Image = Image.FromFile(rutasImagenesAleatorias[3]);


                return rutasImagenesAleatorias;
            }
            else
            {
                //MessageBox.Show("No hay suficientes imágenes.");
                MessageBox.Show("No hay suficientes imágenes.",
                                "Pokemon Primera Generación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return null;
            }

        }

        public void reproducirSonido()
        {
            string rutasonido = Path.Combine(Archivos, "Resources", "sonidos", "success.wav");
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = rutasonido;
            //player.Play(); hola
        }
    }
}
