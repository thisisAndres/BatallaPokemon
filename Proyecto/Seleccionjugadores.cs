using Pokemons;
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
    public partial class Seleccionjugadores : Form
    {

        public List<objetoJugador> Jugadores = new List<objetoJugador>();
        public objetoJugador objJugador = new objetoJugador();
        string Archivos = Configuracion.Archivos;
        private int CantidadJugadores = 1;
        private int torneo4 = 4;
        private int torneo8 = 8;
        private int torneo16 = 16;
        public Seleccionjugadores()
        {
            InitializeComponent();

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PantallaInicio_Load(object sender, EventArgs e)
        {
            // Construir la ruta relativa desde el directorio del ejecutable
            string ruta = Path.Combine(Archivos, "Resources", "inicio\\");
            panel1.BackgroundImage = Image.FromFile(ruta + "p_ini.jpg");
            label1.Text = Convert.ToString(CantidadJugadores);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int CantidadJugadoresBots;
            if (radioButton1.Checked)
            {
                //CantidadJugadores = 4;
                Jugadores = objJugador.generarListaJugadores(torneo4);
                //mostrarSelectPokemones();

                CantidadJugadoresBots = torneo4 - CantidadJugadores;
                mostrarfasefinal(torneo4, CantidadJugadoresBots);

            }
            else if (radioButton2.Checked)
            {
                //CantidadJugadores = 8;
                Jugadores = objJugador.generarListaJugadores(torneo8);
                //mostrarSelectPokemones();

                CantidadJugadoresBots = torneo8 - CantidadJugadores;
                mostrarfasefinal(torneo8, CantidadJugadoresBots);
            }
            else if (radioButton3.Checked)
            {
                //CantidadJugadores = 16;
                Jugadores = objJugador.generarListaJugadores(torneo16);
                //mostrarSelectPokemones();

                CantidadJugadoresBots = torneo16 - CantidadJugadores;
                mostrarfasefinal(torneo16, CantidadJugadoresBots);

            }
            else
            {
                //MessageBox.Show("No has seleccionado ninguna opción");
                MessageBox.Show("No has seleccionado ninguna opción",
                                "Pokemon Primera Generación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        /* private void mostrarSelectPokemones()
         {
             Form1 selecPokemones = new Form1(Jugadores);
             this.Hide();
             selecPokemones.Show();
         }*/

        public void mostrarfasefinal(int tipoTorneo, int cantidadbots)
        {
            if (tipoTorneo == 4)
            {
                Fasefinal4 ff4 = new Fasefinal4(Jugadores, cantidadbots);
                ff4.Show();
                this.Hide();
            }
            else if (tipoTorneo == 8)
            {

                Fasefinal8 ff8 = new Fasefinal8(Jugadores, cantidadbots);
                ff8.Show();
                this.Hide();
            }
            else if (tipoTorneo == 16)
            {
                Fasefinal16 ff16 = new Fasefinal16(Jugadores, cantidadbots);
                ff16.Show();
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            int maxPlayers = 0;

            if (radioButton1.Checked)
            {
                maxPlayers = 4;
            }
            else if (radioButton2.Checked)
            {
                maxPlayers = 8;
            }
            else if (radioButton3.Checked)
            {
                maxPlayers = 16;
            }

            if (CantidadJugadores < maxPlayers)
            {
                CantidadJugadores++;
                label1.Text = Convert.ToString(CantidadJugadores);
            }
            else
            {
                //MessageBox.Show("Se ha alcanzado el máximo de jugadores permitidos para esta opción.");
                MessageBox.Show("Se ha alcanzado el máximo de jugadores permitidos para esta opción.",
                                "Pokemon Primera Generación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            reproducirSonido();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (CantidadJugadores > 1)
            {
                CantidadJugadores--;
                label1.Text = Convert.ToString(CantidadJugadores);
            }
            else
            {
                //MessageBox.Show("La cantidad mínima de jugadores es 1");
            }

            reproducirSonido();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            

            if (radioButton1.Checked)
            {
                CantidadJugadores = 1;
                label1.Text = Convert.ToString("1");
            }
            reproducirSonido();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton2.Checked)
            {
                CantidadJugadores = 1;
                label1.Text = Convert.ToString("1");
            }
            reproducirSonido();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton3.Checked)
            {
                CantidadJugadores = 1;
                label1.Text = Convert.ToString("1");
            }
            reproducirSonido();
        }

        public void reproducirSonido()
        {
            string rutasonido = Path.Combine(Archivos, "Resources", "sonidos", "check_pokemon.wav");
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = rutasonido;
            //player.Play();

        }
    }
}
