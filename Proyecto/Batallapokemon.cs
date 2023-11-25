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
    public partial class Batallapokemon : Form
    {

        List<objetoJugador> jugadores = new List<objetoJugador>();
        string Archivos = Configuracion.Archivos;

        public Batallapokemon()
        {
            InitializeComponent();
            this.TransparencyKey = System.Drawing.Color.FromKnownColor(KnownColor.Control);

        }
        public Batallapokemon(List<objetoJugador> listaJugadores)
        {
            InitializeComponent();
            this.jugadores = listaJugadores;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reproducirSonido1();
            imagenGolpe();
            HabilitarBotonesRival();
            DeshabilitarBotonesJugador();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            reproducirSonido2();
            imagenGolpe();
            HabilitarBotonesRival();
            DeshabilitarBotonesJugador();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            reproducirSonido3();
            imagenGolpe();
            HabilitarBotonesRival();
            DeshabilitarBotonesJugador();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            reproducirSonido4();
            imagenGolpe();
            HabilitarBotonesRival();
            DeshabilitarBotonesJugador();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            reproducirSonido1();
            imagenGolpe_2();
            HabilitarBotonesJugador();
            DeshabilitarBotonesRival();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            reproducirSonido2();
            imagenGolpe_2();
            HabilitarBotonesJugador();
            DeshabilitarBotonesRival();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            reproducirSonido3();
            imagenGolpe_2();
            HabilitarBotonesJugador();
            DeshabilitarBotonesRival();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            reproducirSonido4();
            imagenGolpe_2();
            HabilitarBotonesJugador();
            DeshabilitarBotonesRival();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string ruta = Path.Combine(Archivos, "Resources\\fondofase.jpg");
            BackgroundImage = Image.FromFile(ruta);
            BackgroundImageLayout = ImageLayout.Stretch;

            CargarImagenesCampos();
            reproducirSonidoBatalla();
            //DeshabilitarBotonesRival();

            /*foreach (var pokemon in jugadores[0].pokemones)
            {
                MessageBox.Show(
                 "El jugador " + 1 + " ha seleccionado a:\n" +
                 "Nombre: " + pokemon.nombre + "\n\n" +
                 "Tipo: " + pokemon.tipo1 + "/" + pokemon.tipo2 + "\n" +
                 "Movimiento 1: " + pokemon.movimiento1 + "/ Poder: " + pokemon.mov1Poder + "\n" +
                 "Movimiento 2: " + pokemon.movimiento2 + "/ Poder: " + pokemon.mov2Poder + "\n" +
                 "Movimiento 3: " + pokemon.movimiento3 + "/ Poder: " + pokemon.mov3Poder + "\n" +
                 "Movimiento 4: " + pokemon.movimiento4 + "/ Poder: " + pokemon.mov4Poder
                 );
                button1.Text = pokemon.movimiento1;
                button2.Text = pokemon.movimiento2;
                button3.Text = pokemon.movimiento3;
                button4.Text = pokemon.movimiento4;
                

            }*/

            string espalda = Path.Combine(Archivos, "Resources", "pokemonEspalda\\");
            //pictureBox5.Image = Image.FromFile(espalda + jugadores[0].pokemones[0].Id + ".gif");
            PictureBox pictureBox_Espalda = new PictureBox();
            try
            {
                pictureBox_Espalda.Image = new System.Drawing.Bitmap(espalda + jugadores[0].pokemones[0].Id + ".gif");
                pictureBox_Espalda.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox_Espalda.Size = new Size(125, 125);
                flowLayoutPanel2.Controls.Add(pictureBox_Espalda);
                flowLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la imagen GIF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            button1.Text = jugadores[0].pokemones[0].movimiento1;
            button2.Text = jugadores[0].pokemones[0].movimiento2;
            button3.Text = jugadores[0].pokemones[0].movimiento3;
            button4.Text = jugadores[0].pokemones[0].movimiento4;

            string frente = Path.Combine(Archivos, "Resources", "pokemonFrente\\");
            //pictureBox6.Image = Image.FromFile(frente + jugadores[0].pokemones[1].Id + ".gif");
            PictureBox pictureBox_Frente = new PictureBox();
            try
            {
                pictureBox_Frente.Image = new System.Drawing.Bitmap(frente + jugadores[1].pokemones[0].Id + ".gif");
                pictureBox_Frente.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox_Frente.Size = new Size(110, 100);// Añadir el PictureBox al FlowLayoutPanel
                flowLayoutPanel4.Controls.Add(pictureBox_Frente);
                flowLayoutPanel4.BackColor = System.Drawing.Color.Transparent;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la imagen GIF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            button5.Text = jugadores[1].pokemones[0].movimiento1;
            button6.Text = jugadores[1].pokemones[0].movimiento2;
            button7.Text = jugadores[1].pokemones[0].movimiento3;
            button8.Text = jugadores[1].pokemones[0].movimiento4;

        }

        public void CargarImagenesCampos()
        {
            Controlador controlador = new Controlador();
            string cargarRutaImagen = controlador.ObtenerImagenesCampoBatalla();
            // MessageBox.Show(cargarRutaImagen);

            try
            {
                //pictureBox1.Image = Image.FromFile(cargarRutaImagen);
                panel1.BackgroundImage = Image.FromFile(cargarRutaImagen);
                panel1.BackgroundImageLayout = ImageLayout.Stretch;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la imagen del campo de batalla: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void reproducirSonidoBatalla()
        {

            string rutaSonido = Path.Combine(Archivos, "Resources", "sonidos", "batalla.wav");
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = rutaSonido;
            //player.PlayLooping();
            //player.Play();

        }
        public void reproducirSonido1()
        {

            string rutasonido = Path.Combine(Archivos, "Resources", "sonidos", "punch1.wav");
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = rutasonido;
            player.Play();

        }
        public void reproducirSonido2()
        {

            string rutasonido = Path.Combine(Archivos, "Resources", "sonidos", "punch2.wav");
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = rutasonido;
            player.Play();
        }
        public void reproducirSonido3()
        {

            string rutasonido = Path.Combine(Archivos, "Resources", "sonidos", "punch3.wav");
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = rutasonido;
            player.Play();
        }
        public void reproducirSonido4()
        {

            string rutasonido = Path.Combine(Archivos, "Resources", "sonidos", "punch4.wav");
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = rutasonido;
            player.Play();
        }

        public void imagenGolpe()
        {
            string rutaImagen = Path.Combine(Archivos, "Resources", "Imagenes\\golpe2.gif");
            PictureBox pictureBox_Golpe = new PictureBox();
            try
            {
                if (File.Exists(rutaImagen))
                {
                    pictureBox_Golpe.Image = new System.Drawing.Bitmap(rutaImagen);
                    pictureBox_Golpe.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox_Golpe.Size = new Size(160, 160);

                    flowLayoutPanel5.Invoke(new Action(() => flowLayoutPanel5.Controls.Add(pictureBox_Golpe)));
                    flowLayoutPanel5.Invoke(new Action(() => flowLayoutPanel5.BackColor = System.Drawing.Color.Transparent));

                    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                    timer.Interval = 1000; // 1000 milisegundos (1 segundo)

                    // Manejador de eventos del temporizador
                    timer.Tick += (sender, e) =>
                    {
                        // Ocultar la imagen después de un segundo
                        pictureBox_Golpe.Visible = false;

                        // Detener y liberar el temporizador
                        timer.Stop();
                        timer.Dispose();
                    };

                    // Iniciar el temporizador
                    timer.Start();
                }
                else
                {
                    MessageBox.Show("El archivo de imagen no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la imagen GIF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void imagenGolpe_2()
        {
            string rutaImagen = Path.Combine(Archivos, "Resources", "Imagenes\\golpe4.gif");
            PictureBox pictureBox_Golpe = new PictureBox();
            try
            {
                if (File.Exists(rutaImagen))
                {
                    pictureBox_Golpe.Image = new System.Drawing.Bitmap(rutaImagen);
                    pictureBox_Golpe.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox_Golpe.Size = new Size(160, 160);

                    flowLayoutPanel5.Invoke(new Action(() => flowLayoutPanel5.Controls.Add(pictureBox_Golpe)));
                    flowLayoutPanel5.Invoke(new Action(() => flowLayoutPanel5.BackColor = System.Drawing.Color.Transparent));

                    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                    timer.Interval = 1000; // 1000 milisegundos (1 segundo)

                    // Manejador de eventos del temporizador
                    timer.Tick += (sender, e) =>
                    {
                        // Ocultar la imagen después de un segundo
                        pictureBox_Golpe.Visible = false;

                        // Detener y liberar el temporizador
                        timer.Stop();
                        timer.Dispose();
                    };

                    // Iniciar el temporizador
                    timer.Start();
                }
                else
                {
                    MessageBox.Show("El archivo de imagen no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la imagen GIF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeshabilitarBotonesJugador()
        {
            // Deshabilita los primeros 4 botones (button1, button2, button3, button4)
            for (int i = 1; i <= 4; i++)
            {
                Button boton = Controls["button" + i] as Button;
                if (boton != null)
                {
                    boton.Enabled = false;
                }
            }
        }
        private void DeshabilitarBotonesRival()
        {
            // Deshabilita los primeros 4 botones (button1, button2, button3, button4)
            for (int i = 5; i <= 8; i++)
            {
                Button boton = Controls["button" + i] as Button;
                if (boton != null)
                {
                    boton.Enabled = false;
                }
            }
        }
        private void HabilitarBotonesJugador()
        {
            // Deshabilita los primeros 4 botones (button1, button2, button3, button4)
            for (int i = 1; i <= 4; i++)
            {
                Button boton = Controls["button" + i] as Button;
                if (boton != null)
                {
                    boton.Enabled = true;
                }
            }
        }
        private void HabilitarBotonesRival()
        {
            // Deshabilita los primeros 4 botones (button1, button2, button3, button4)
            for (int i = 5; i <= 8; i++)
            {
                Button boton = Controls["button" + i] as Button;
                if (boton != null)
                {
                    boton.Enabled = true;
                }
            }
        }

    }
}
