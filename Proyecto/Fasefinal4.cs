﻿using Proyecto.Models;
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
        List<objetoJugador> jugadoresCiclo2 = new List<objetoJugador>();
        Controlador imagenesrnd = new Controlador();
        int cantidadbots;
        public List<string> rutasImagenesAleatorias;

        public Fasefinal4()
        {
            InitializeComponent();
        }

        public Fasefinal4(List<objetoJugador> listaGanadores)
        {
            InitializeComponent();
            this.jugadores = listaGanadores;

                mostrarGanadores();
            

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
            Seleccionpokemon equipo = new Seleccionpokemon(jugadores, cantidadbots);
            equipo.Show();
            this.Hide();
        }

        private void Fasefinal4_Load(object sender, EventArgs e)
        {
            mostrarImagenes();
            MostrarImagenesAleatorias();
            reproducirSonido();
        }

        public void mostrarGanadores()
        {
            string directorioImagenesGanadores = Path.Combine(Archivos, "Resources", "entrenadores2\\");

            pictureBox6.Image = Image.FromFile(directorioImagenesGanadores + jugadores[0].IdJugador + ".png");
            pictureBox7.Image = Image.FromFile(directorioImagenesGanadores + jugadores[1].IdJugador + ".png");

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
