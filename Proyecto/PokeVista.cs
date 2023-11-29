using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto
{
    public partial class PokeVista : UserControl
    {

        public event EventHandler CheckBoxStateChanged;
        public CheckBox CheckBoxSeleccion { get { return checkBox1; } }
        public PictureBox ImagenControl { get { return imagen; } }
        public int IdPokemon { get; private set; }
        string Archivos = Configuracion.Archivos;
        string desc;
        string movimiento1;
        int mov1Poder;
        string movimiento2;
        int mov2Poder;
        string movimiento3;
        int mov3Poder;
        string movimiento4;
        int mov4Poder;
        private System.Windows.Forms.ToolTip toolTip1;

        public PokeVista(string nombre, Image imagen, string tipo1, string tipo2, string desc, string m1, int p1, string m2, int p2, string m3, int p3, string m4, int p4)
        {
            InitializeComponent();
            this.nombre.Text = nombre;

            this.imagen.Image = imagen;
            this.tipo1.Image = tipos(tipo1);
            this.tipo2.Image = tipos(tipo2);
            this.desc = desc;
            this.movimiento1 = m1;
            this.mov1Poder = p1;
            this.movimiento2 = m2;
            this.mov2Poder = p2;
            this.movimiento3 = m3;
            this.mov3Poder = p3;
            this.movimiento4 = m4;
            this.mov4Poder = p4;

            toolTip1 = new System.Windows.Forms.ToolTip();

            // Suscribirse al evento MouseHover de la imagen


            // Configurar el mensaje que deseas mostrar


        }

        public Image tipos(string tipo)
        {

            Image img = null;
            //string ruta= "Resources\\tipos\\";


            // Construir la ruta relativa desde el directorio del ejecutable
            string ruta = Path.Combine(Archivos, "Resources", "tipos\\");


            switch (tipo)
            {
                case "Normal":
                    img = Image.FromFile(ruta + "normal.png");
                    break;
                case "Fuego":
                    img = Image.FromFile(ruta + "Fuego.png");
                    break;
                case "Agua":
                    img = Image.FromFile(ruta + "Agua.png");
                    break;
                case "Planta":
                    img = Image.FromFile(ruta + "Planta.png");
                    break;
                case "Eléctrico":
                    img = Image.FromFile(ruta + "Eléctrico.png");
                    break;
                case "Hielo":
                    img = Image.FromFile(ruta + "Hielo.png");
                    break;
                case "Lucha":
                    img = Image.FromFile(ruta + "Lucha.png");
                    break;
                case "Veneno":
                    img = Image.FromFile(ruta + "Veneno.png");
                    break;
                case "Tierra":
                    img = Image.FromFile(ruta + "Tierra.png");
                    break;
                case "Volador":
                    img = Image.FromFile(ruta + "Volador.png");
                    break;
                case "Psíquico":
                    img = Image.FromFile(ruta + "Psíquico.png");
                    break;
                case "Bicho":
                    img = Image.FromFile(ruta + "Bicho.png");
                    break;
                case "Roca":
                    img = Image.FromFile(ruta + "Roca.png");
                    break;
                case "Fantasma":
                    img = Image.FromFile(ruta + "Fantasma.png");
                    break;
                case "Dragón":
                    img = Image.FromFile(ruta + "Dragón.png");
                    break;
                case "Acero":
                    img = Image.FromFile(ruta + "Acero.png");
                    break;
                case "Hada":
                    img = Image.FromFile(ruta + "Hada.png");
                    break;
                default:

                    break;

            }
            return img;
        }

        public PokeVista(Image imagen2)
        {
            InitializeComponent();
            this.nombre.Text = "";
            this.imagen.Image = imagen2;
            this.tipo1.Text = "";
            this.tipo2.Text = "";
        }

        private void CheckBoxSeleccion_CheckedChanged(object sender, EventArgs e)
        {
            // Notifica al formulario padre cuando cambia el estado del CheckBox
            CheckBoxStateChanged?.Invoke(this, EventArgs.Empty);
        }

        /*public bool EstaSeleccionado()
        {
            // Devuelve el estado del CheckBox
            return ((CheckBox)Controls[0]).Checked;
        }*/


        private void PokeVista_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // Agregar la imagen al flowLayoutPanel2 de Form1
                ((Seleccionpokemon)this.ParentForm).AgregarImagenSeleccionada(this.imagen.Image);
                ((Seleccionpokemon)this.ParentForm).agregarPokemon(this.nombre.Text);
            }
            else
            {
                // Remover la imagen del flowLayoutPanel2 de Form1 si se desmarca
                ((Seleccionpokemon)this.ParentForm).RemoverImagenSeleccionada(this.imagen.Image);
                ((Seleccionpokemon)this.ParentForm).eliminarPokemon(this.nombre.Text);
            }

            reproducirSonido();
        }

        public void reproducirSonido()
        {

            string rutasonido = Path.Combine(Archivos, "Resources", "sonidos", "check_pokemon.wav");
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = rutasonido;
            player.Play();
        }

      

        private void imagen_MouseHover_1(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(imagen, desc + "\n"+
                                        movimiento1 + ": " + mov1Poder + "\n"+
                                        movimiento2 + ": " + mov2Poder + "\n"+
                                        movimiento3 + ": " + mov3Poder + "\n"+
                                        movimiento4 + ": " + mov4Poder + "\n" );
        }
    }
}
