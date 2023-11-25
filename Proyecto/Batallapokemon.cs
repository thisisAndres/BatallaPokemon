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
        int cantidadbots;

        //Jugadores actuales
        int jugadorActual1 = 0;
        int jugadorActual2 = 1;

        //Pokemones actuales
        int pokemonActual1 = 0;
        int pokemonActual2 = 1;

        public Batallapokemon()
        {
            InitializeComponent();
            this.TransparencyKey = System.Drawing.Color.FromKnownColor(KnownColor.Control);

        }
        public Batallapokemon(List<objetoJugador> listaJugadores, int cantidadbots)
        {
            InitializeComponent();
            this.jugadores = listaJugadores;
            this.cantidadbots = cantidadbots;
        }

        public async void movimientoBot(int siguienteJugador, int jugadorActual)
        {


            if (jugadores[siguienteJugador].getIsBot())
            {
                await Task.Delay(1000);

                Random rnd = new Random();
                int numeroAleatorio = rnd.Next(1, 5);

                if (jugadores[siguienteJugador].IdJugador % 2 == 0)
                {
                    reproducirSonido2();
                    imagenGolpe_2();
                    HabilitarBotonesJugador();
                    DeshabilitarBotonesRival();
                    switch (numeroAleatorio)
                    {
                        case 1:
                            jugadores[jugadorActual].pokemones[pokemonActual2].restarVida(jugadores[siguienteJugador].pokemones[pokemonActual1].mov1Poder);
                            progressBar1.Value = jugadores[jugadorActual].pokemones[pokemonActual2].getVidaRestante();
                            break;
                        case 2:
                            jugadores[jugadorActual].pokemones[pokemonActual2].restarVida(jugadores[siguienteJugador].pokemones[pokemonActual1].mov2Poder);
                            progressBar1.Value = jugadores[jugadorActual].pokemones[pokemonActual2].getVidaRestante();
                            break;
                        case 3:
                            jugadores[jugadorActual].pokemones[pokemonActual2].restarVida(jugadores[siguienteJugador].pokemones[pokemonActual1].mov3Poder);
                            progressBar1.Value = jugadores[jugadorActual].pokemones[pokemonActual2].getVidaRestante();
                            break;
                        case 4:
                            jugadores[jugadorActual].pokemones[pokemonActual2].restarVida(jugadores[siguienteJugador].pokemones[pokemonActual1].mov4Poder);
                            progressBar1.Value = jugadores[jugadorActual].pokemones[pokemonActual2].getVidaRestante();
                            break;
                    }
                }
                else
                {
                    reproducirSonido1();
                    imagenGolpe();
                    HabilitarBotonesRival();
                    DeshabilitarBotonesJugador();

                    switch (numeroAleatorio)
                    {
                        case 1:
                            jugadores[jugadorActual].pokemones[pokemonActual2].restarVida(jugadores[siguienteJugador].pokemones[pokemonActual1].mov1Poder);
                            progressBar2.Value = jugadores[jugadorActual].pokemones[pokemonActual2].getVidaRestante();
                            break;
                        case 2:
                            jugadores[jugadorActual].pokemones[pokemonActual2].restarVida(jugadores[siguienteJugador].pokemones[pokemonActual1].mov2Poder);
                            progressBar2.Value = jugadores[jugadorActual].pokemones[pokemonActual2].getVidaRestante();
                            break;
                        case 3:
                            jugadores[jugadorActual].pokemones[pokemonActual2].restarVida(jugadores[siguienteJugador].pokemones[pokemonActual1].mov3Poder);
                            progressBar2.Value = jugadores[jugadorActual].pokemones[pokemonActual2].getVidaRestante();
                            break;
                        case 4:
                            jugadores[jugadorActual].pokemones[pokemonActual2].restarVida(jugadores[siguienteJugador].pokemones[pokemonActual1].mov4Poder);
                            progressBar2.Value = jugadores[jugadorActual].pokemones[pokemonActual2].getVidaRestante();
                            break;
                    }
                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //efectos
            reproducirSonido1();
            imagenGolpe();
            HabilitarBotonesRival();
            DeshabilitarBotonesJugador();

            //restando vida al oponente
            jugadores[jugadorActual2].pokemones[pokemonActual2].restarVida(jugadores[jugadorActual1].pokemones[pokemonActual1].mov1Poder);
            progressBar2.Value = jugadores[jugadorActual2].pokemones[pokemonActual2].getVidaRestante();

            //movimiento del bot si lo hay
            movimientoBot(jugadorActual2, jugadorActual1);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //efectos
            reproducirSonido2();
            imagenGolpe();
            HabilitarBotonesRival();
            DeshabilitarBotonesJugador();

            //restando vida al oponente
            jugadores[jugadorActual2].pokemones[pokemonActual2].restarVida(jugadores[jugadorActual1].pokemones[pokemonActual1].mov2Poder);
            progressBar2.Value = jugadores[jugadorActual2].pokemones[pokemonActual2].getVidaRestante();

            //movimiento del bot si lo hay
            movimientoBot(jugadorActual2, jugadorActual1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //efectos
            reproducirSonido3();
            imagenGolpe();
            HabilitarBotonesRival();
            DeshabilitarBotonesJugador();

            //restando vida al oponente
            jugadores[jugadorActual2].pokemones[pokemonActual2].restarVida(jugadores[jugadorActual1].pokemones[pokemonActual1].mov3Poder);
            progressBar2.Value = jugadores[jugadorActual2].pokemones[pokemonActual2].getVidaRestante();

            //movimiento del bot si lo hay
            movimientoBot(jugadorActual2, jugadorActual1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //efectos
            reproducirSonido4();
            imagenGolpe();
            HabilitarBotonesRival();
            DeshabilitarBotonesJugador();

            //restando vida al oponente
            jugadores[jugadorActual2].pokemones[pokemonActual2].restarVida(jugadores[jugadorActual1].pokemones[pokemonActual1].mov4Poder);
            progressBar2.Value = jugadores[jugadorActual2].pokemones[pokemonActual2].getVidaRestante();

            //movimiento del bot si lo hay
            movimientoBot(jugadorActual2, jugadorActual1);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            reproducirSonido1();
            imagenGolpe_2();
            HabilitarBotonesJugador();
            DeshabilitarBotonesRival();
            jugadores[jugadorActual1].pokemones[pokemonActual1].restarVida(jugadores[jugadorActual2].pokemones[pokemonActual2].mov1Poder);
            progressBar1.Value = jugadores[jugadorActual1].pokemones[pokemonActual1].getVidaRestante();

            //movimiento del bot si lo hay
            movimientoBot(jugadorActual1, jugadorActual2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            reproducirSonido2();
            imagenGolpe_2();
            HabilitarBotonesJugador();
            DeshabilitarBotonesRival();
            jugadores[jugadorActual1].pokemones[pokemonActual1].restarVida(jugadores[jugadorActual2].pokemones[pokemonActual2].mov2Poder);
            progressBar1.Value = jugadores[jugadorActual1].pokemones[pokemonActual1].getVidaRestante();

            //movimiento del bot si lo hay
            movimientoBot(jugadorActual1, jugadorActual2);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            reproducirSonido3();
            imagenGolpe_2();
            HabilitarBotonesJugador();
            DeshabilitarBotonesRival();
            jugadores[jugadorActual1].pokemones[pokemonActual1].restarVida(jugadores[jugadorActual2].pokemones[pokemonActual2].mov3Poder);
            progressBar1.Value = jugadores[jugadorActual1].pokemones[pokemonActual1].getVidaRestante();

            //movimiento del bot si lo hay
            movimientoBot(jugadorActual1, jugadorActual2);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            reproducirSonido4();
            imagenGolpe_2();
            HabilitarBotonesJugador();
            DeshabilitarBotonesRival();
            jugadores[jugadorActual1].pokemones[pokemonActual1].restarVida(jugadores[jugadorActual2].pokemones[pokemonActual2].mov4Poder);
            progressBar1.Value = jugadores[jugadorActual1].pokemones[pokemonActual1].getVidaRestante();

            //movimiento del bot si lo hay
            movimientoBot(jugadorActual1, jugadorActual2);

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
            cargarImagenBackground();
            CargarImagenesCampos();
            reproducirSonidoBatalla();
            llamarPokemonesCampo();
            CargarPokemonesEnEspera();
            mostrarJugadores();
        }
        public void CargarPokemonesEnEspera()
        {
            string pokemonesJugador1 = Path.Combine(Archivos, "Resources", "pokemonFrente\\");
            string pokemonesJugador2 = Path.Combine(Archivos, "Resources", "pokemonFrente\\");

            try
            {
                for (int i = 1; i < 6; i++)
                {
                    PictureBox pictureBox_pokemonesJugador1 = new PictureBox();
                    string rutaImagen = pokemonesJugador1 + jugadores[jugadorActual1].pokemones[i].Id + ".gif";

                    if (File.Exists(rutaImagen))
                    {
                        pictureBox_pokemonesJugador1.Image = new System.Drawing.Bitmap(rutaImagen);
                        pictureBox_pokemonesJugador1.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox_pokemonesJugador1.Size = new Size(70, 70);

                        flowLayoutPanel1.Controls.Add(pictureBox_pokemonesJugador1);
                    }
                    else
                    {
                        MessageBox.Show($"Error: La imagen {rutaImagen} no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las imágenes del jugador 1: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                for (int i = 1; i < 6; i++)
                {
                    PictureBox pictureBox_pokemonesJugador2 = new PictureBox();
                    string rutaImagen_2 = pokemonesJugador2 + jugadores[jugadorActual2].pokemones[i].Id + ".gif";

                    if (File.Exists(rutaImagen_2))
                    {
                        pictureBox_pokemonesJugador2.Image = new System.Drawing.Bitmap(rutaImagen_2);
                        pictureBox_pokemonesJugador2.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox_pokemonesJugador2.Size = new Size(70, 70);

                        flowLayoutPanel3.Controls.Add(pictureBox_pokemonesJugador2);
                    }
                    else
                    {
                        MessageBox.Show($"Error: La imagen {rutaImagen_2} no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las imágenes del jugador 2: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void cambiarPokemon()
        {

        }
        public void llamarPokemonesCampo()
        {

            string espalda = Path.Combine(Archivos, "Resources", "pokemonEspalda\\");
            //pictureBox5.Image = Image.FromFile(espalda + jugadores[0].pokemones[0].Id + ".gif");
            PictureBox pictureBox_Espalda = new PictureBox();
            try
            {
                pictureBox_Espalda.Image = new System.Drawing.Bitmap(espalda + jugadores[jugadorActual1].pokemones[pokemonActual1].Id + ".gif");
                pictureBox_Espalda.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox_Espalda.Size = new Size(125, 125);
                flowLayoutPanel2.Controls.Add(pictureBox_Espalda);
                flowLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la imagen GIF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            button1.Text = jugadores[jugadorActual1].pokemones[pokemonActual1].movimiento1;
            button2.Text = jugadores[jugadorActual1].pokemones[pokemonActual1].movimiento2;
            button3.Text = jugadores[jugadorActual1].pokemones[pokemonActual1].movimiento3;
            button4.Text = jugadores[jugadorActual1].pokemones[pokemonActual1].movimiento4;

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

            button5.Text = jugadores[jugadorActual2].pokemones[pokemonActual2].movimiento1;
            button6.Text = jugadores[jugadorActual2].pokemones[pokemonActual2].movimiento2;
            button7.Text = jugadores[jugadorActual2].pokemones[pokemonActual2].movimiento3;
            button8.Text = jugadores[jugadorActual2].pokemones[pokemonActual2].movimiento4;
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
        public void cargarImagenBackground()
        {

            string ruta = Path.Combine(Archivos, "Resources\\fondofase.jpg");
            BackgroundImage = Image.FromFile(ruta);
            BackgroundImageLayout = ImageLayout.Stretch;
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
        public void mostrarJugadores()
        {
            Fasefinal4 faseFinalForm = new Fasefinal4(jugadores, cantidadbots);

            progressBar1.Value = jugadores[jugadorActual1].pokemones[0].vida;
            progressBar2.Value = jugadores[jugadorActual2].pokemones[0].vida;
            label1.Text = "Jugador" + Convert.ToString(jugadores[jugadorActual1].IdJugador);
            label2.Text = "Jugador" + Convert.ToString(jugadores[jugadorActual2].IdJugador);

            // Obtener las rutas de imágenes aleatorias
            List<string> rutasImagenes = faseFinalForm.MostrarImagenesAleatorias();

            if (rutasImagenes != null && rutasImagenes.Count >= 2)
            {
                string rutaImagenJugador1 = rutasImagenes[jugadores[jugadorActual1].IdJugador];
                string rutaImagenJugador2 = rutasImagenes[jugadores[jugadorActual2].IdJugador];

                // Asignar las imágenes a los PictureBox correspondientes en Batallapokemon
                pictureBox3.Image = Image.FromFile(rutaImagenJugador1);
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox3.BackColor = System.Drawing.Color.Transparent;

                pictureBox4.Image = Image.FromFile(rutaImagenJugador2);
                pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox4.BackColor = System.Drawing.Color.Transparent;
            }

        }


    }
}
