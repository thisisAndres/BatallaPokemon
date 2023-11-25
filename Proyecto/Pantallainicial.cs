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
    public partial class Pantallainicial : Form
    {
        string Archivos = Configuracion.Archivos;
        public Pantallainicial()
        {
            InitializeComponent();

        }

        private void ingreso_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Seleccionjugadores pantallaInicio = new Seleccionjugadores();
            pantallaInicio.Show();
            SoundPlayer player = new SoundPlayer();
            //player.Stop();
            this.Hide();

        }

        private void ingreso_Load(object sender, EventArgs e)
        {


            // Construir la ruta relativa desde el directorio del ejecutable
            string ruta = Path.Combine(Archivos, "Resources", "inicio\\");


            this.BackgroundImage = Image.FromFile(ruta + "ingreso.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            pictureBox1.Image = Image.FromFile(ruta + "pokemon.png");
            pictureBox2.Image = Image.FromFile(ruta + "press_start.gif");


            reproducirSonido();
        }

        private void fondo_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void reproducirSonido() {

            string rutasonido = Path.Combine(Archivos, "Resources", "sonidos", "opening.wav");
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = rutasonido;
            //player.Play();
        }
    }
}
