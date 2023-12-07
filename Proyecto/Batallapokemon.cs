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
    public partial class Batallapokemon : Form
    {

        List<objetoJugador> jugadores = new List<objetoJugador>();
        string Archivos = Configuracion.Archivos;
        int cantidadbots;
        string frente = Path.Combine(Configuracion.Archivos, "Resources", "pokemonFrente\\");
        string espalda = Path.Combine(Configuracion.Archivos, "Resources", "pokemonEspalda\\");
        Controlador controlador = new Controlador();
        ConexionDatos insertar_bitacora = new ConexionDatos();
        private string rutaDeLaImagen;
        int arenaAleatoria;
        //Jugadores actuales
        int jugadorActual1 = 0;
        int jugadorActual2 = 1;
        private string arena = "";
        //Pokemones actuales
        int pokemonActual1 = 0;
        int pokemonActual2 = 0;
        //numero de eliminaciones
        int j1PokemonesElimidados = 0;
        int j2PokemonesElimidados = 0;

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

        //Carga inicial del form
        private void Form2_Load(object sender, EventArgs e)
        {
            cargarImagenBackground();
            CargarImagenesCampos();
            reproducirSonidoBatalla();
            llamarPokemonesCampo();
            CargarPokemonesEnEspera();
            mostrarJugadores();
        }
        //botones de ataques
        private void button1_Click(object sender, EventArgs e)
        {
            //efectos
            reproducirSonido1();
            imagenGolpe();

            if (jugadores[jugadorActual2].isBot)
            {
                jugadores[jugadorActual2].pokemones[pokemonActual2].restarVida(
                              Convert.ToDouble(jugadores[jugadorActual1].pokemones[pokemonActual1].mov1Poder),
                              jugadores[jugadorActual1].pokemones[pokemonActual1].tipo1,
                              jugadores[jugadorActual2].pokemones[pokemonActual2].tipo1, ObtenerNumeroImagen());
                logicaMovimientoBot();

            }
            else
            {

				jugadores[jugadorActual2].pokemones[pokemonActual2].restarVida(
							 Convert.ToDouble(jugadores[jugadorActual1].pokemones[pokemonActual1].mov1Poder),
							 jugadores[jugadorActual1].pokemones[pokemonActual1].tipo1,
							 jugadores[jugadorActual2].pokemones[pokemonActual2].tipo1, ObtenerNumeroImagen());
				logicaMovimientoJ1();
            }


        }
        private void button2_Click(object sender, EventArgs e)
        {
            //efectos
            reproducirSonido1();
            imagenGolpe();

            if (jugadores[jugadorActual2].isBot)
            {
                jugadores[jugadorActual2].pokemones[pokemonActual2].restarVida(
                          Convert.ToDouble(jugadores[jugadorActual1].pokemones[pokemonActual1].mov2Poder),
                          jugadores[jugadorActual1].pokemones[pokemonActual1].tipo1,
                          jugadores[jugadorActual2].pokemones[pokemonActual2].tipo1, ObtenerNumeroImagen());
                logicaMovimientoBot();

            }
            else
            {

                jugadores[jugadorActual2].pokemones[pokemonActual2].restarVida(
                        Convert.ToDouble(jugadores[jugadorActual1].pokemones[pokemonActual1].mov2Poder),
                        jugadores[jugadorActual1].pokemones[pokemonActual1].tipo1,
                        jugadores[jugadorActual2].pokemones[pokemonActual2].tipo1, ObtenerNumeroImagen());
                logicaMovimientoJ1();
            }


        }
        private void button3_Click(object sender, EventArgs e)
        {
            //efectos
            reproducirSonido1();
            imagenGolpe();

            if (jugadores[jugadorActual2].isBot)
            {
                jugadores[jugadorActual2].pokemones[pokemonActual2].restarVida(
                          Convert.ToDouble(jugadores[jugadorActual1].pokemones[pokemonActual1].mov3Poder),
                          jugadores[jugadorActual1].pokemones[pokemonActual1].tipo1,
                          jugadores[jugadorActual2].pokemones[pokemonActual2].tipo1, ObtenerNumeroImagen());
                logicaMovimientoBot();

            }
            else
            {

                jugadores[jugadorActual2].pokemones[pokemonActual2].restarVida(
                        Convert.ToDouble(jugadores[jugadorActual1].pokemones[pokemonActual1].mov3Poder),
                        jugadores[jugadorActual1].pokemones[pokemonActual1].tipo1,
                        jugadores[jugadorActual2].pokemones[pokemonActual2].tipo1, ObtenerNumeroImagen());
                logicaMovimientoJ1();
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            //efectos
            reproducirSonido1();
            imagenGolpe();

            if (jugadores[jugadorActual2].isBot)
            {
                jugadores[jugadorActual2].pokemones[pokemonActual2].restarVida(
                          Convert.ToDouble(jugadores[jugadorActual1].pokemones[pokemonActual1].mov4Poder),
                          jugadores[jugadorActual1].pokemones[pokemonActual1].tipo1,
                          jugadores[jugadorActual2].pokemones[pokemonActual2].tipo1, ObtenerNumeroImagen());
                logicaMovimientoBot();

            }
            else
            {
                //aqui deberia ir la logica si es otro jugador el enemigo
                jugadores[jugadorActual2].pokemones[pokemonActual2].restarVida(
					      Convert.ToDouble(jugadores[jugadorActual1].pokemones[pokemonActual1].mov4Poder),
						  jugadores[jugadorActual1].pokemones[pokemonActual1].tipo1,
						  jugadores[jugadorActual2].pokemones[pokemonActual2].tipo1, ObtenerNumeroImagen()); 
                logicaMovimientoJ1();

            }

        }
		private void button5_Click(object sender, EventArgs e)
		{


			jugadores[jugadorActual1].pokemones[pokemonActual1].restarVida(Convert.ToDouble(jugadores[jugadorActual2].pokemones[pokemonActual2].mov1Poder),
																						   jugadores[jugadorActual2].pokemones[pokemonActual2].tipo1,
																						   jugadores[jugadorActual1].pokemones[pokemonActual1].tipo1, ObtenerNumeroImagen());
			logicaMovimientoJ2();



		}
		private void button6_Click(object sender, EventArgs e)
		{


			jugadores[jugadorActual1].pokemones[pokemonActual1].restarVida(Convert.ToDouble(jugadores[jugadorActual2].pokemones[pokemonActual2].mov2Poder),
																						   jugadores[jugadorActual2].pokemones[pokemonActual2].tipo1,
																						   jugadores[jugadorActual1].pokemones[pokemonActual1].tipo1, ObtenerNumeroImagen());
			logicaMovimientoJ2();


		}
		private void button7_Click(object sender, EventArgs e)
		{

			jugadores[jugadorActual1].pokemones[pokemonActual1].restarVida(Convert.ToDouble(jugadores[jugadorActual2].pokemones[pokemonActual2].mov3Poder),
																						   jugadores[jugadorActual2].pokemones[pokemonActual2].tipo1,
																						   jugadores[jugadorActual1].pokemones[pokemonActual1].tipo1, ObtenerNumeroImagen());
			logicaMovimientoJ2();

		}
		private void button8_Click(object sender, EventArgs e)
		{


			jugadores[jugadorActual1].pokemones[pokemonActual1].restarVida(Convert.ToDouble(jugadores[jugadorActual2].pokemones[pokemonActual2].mov4Poder),
																						   jugadores[jugadorActual2].pokemones[pokemonActual2].tipo1,
																						   jugadores[jugadorActual1].pokemones[pokemonActual1].tipo1, ObtenerNumeroImagen());
			logicaMovimientoJ2();


		}
        //Logica de ataques
		public (int ganadorId, int perdedorId, string combate) logicaAmbosSonBots()
        {
            int ganadorId = 0;
            int perdedorId = 0;
            //MessageBox.Show(jugadorActual1.ToString() + "//" + jugadorActual2.ToString());
            string combate = $"Jugador {jugadores[jugadorActual1].IdJugador} VS Jugador {jugadores[jugadorActual2].IdJugador}";

            if (jugadores[jugadorActual1].isBot && jugadores[jugadorActual2].isBot)
            {
                Random rnd = new Random();

                int nRandom = rnd.Next(1, 3);

                if (nRandom == 1)
                {
                    jugadores[jugadorActual1].setGanador();
                    jugadores[jugadorActual2].setPerdedor();

					ganadorId = jugadores[jugadorActual1].IdJugador;
                    perdedorId = jugadores[jugadorActual2].IdJugador;

                    MessageBox.Show("Gano el jugador: " + ganadorId);
                }
                else
                {
                    jugadores[jugadorActual1].setPerdedor();
                    jugadores[jugadorActual2].setGanador();

					ganadorId = jugadores[jugadorActual2].IdJugador;
                    perdedorId = jugadores[jugadorActual1].IdJugador;

                    MessageBox.Show("Gano el jugador: " + ganadorId);
                }
                
                insertar_bitacora.InsertarEnBitacoraPeleas(ganadorId, perdedorId, combate);




                MessageBox.Show(jugadorActual2 + " // " + (jugadores.Count - 1));

                if (jugadorActual2 != jugadores.Count - 1)
                {
                    jugadorActual1 = jugadorActual1 + 2;
                    jugadorActual2 = jugadorActual2 + 2;

                    restaurarEquipo();
                    logicaAmbosSonBots();
                }
                else
                {
                    if (jugadores.Count == 4)
                    {
  
                        eliminarPerdedores();
                        siguinteFase(4);
                    }
                    else if (jugadores.Count == 8)
                    {

                        eliminarPerdedores();
                        siguinteFase(8);

                    }
                    else
                    {
                        eliminarPerdedores();
                        siguinteFase(16);
                       

                    }
                }

            }


            return (ganadorId, perdedorId, combate);
        }

        public void eliminarPerdedores()
        {
            for (int i = jugadores.Count - 1; i >= 0; i--)
            {
                if (!jugadores[i].getIsGanador())
                {
                    jugadores.RemoveAt(i);
                }
            }
        }

        public void siguinteFase(int tipoFase)
        {

            MessageBox.Show("Iniciando siguiente fase del torneo de " + tipoFase + " jugadores");

            if (tipoFase == 4)
            {
                Fasefinal4 faseFinal4 = new Fasefinal4(jugadores);
                this.Hide();
                faseFinal4.Show();
            }
            else if (tipoFase == 8)
            {
                Fasefinal8 faseFinal8 = new Fasefinal8(jugadores);
                this.Hide();
                faseFinal8.Show();
            }
            else
            {
                Fasefinal16 faseFinal16 = new Fasefinal16(jugadores);
                this.Hide();
                faseFinal16.Show();
            }

        }

        public (int ganadorId, int perdedorId, string combate) logicaMovimientoJ1()
        {
            HabilitarBotonesRival();
            DeshabilitarBotonesJugador();
            int ganadorId = 0;
            int perdedorId = 0;
            string combate = $"Jugador {jugadores[jugadorActual1].IdJugador} VS Jugador {jugadores[jugadorActual2].IdJugador}";

            progressBar2.Value = jugadores[jugadorActual2].pokemones[pokemonActual2].getVidaRestante();
            label4.Text = Convert.ToString(progressBar2.Value) + "/100";

            if (progressBar2.Value == 0)
            {
                actualizarPokemonJ2();
                j2PokemonesElimidados++;
            }

                if (j2PokemonesElimidados == 4)
                {

                    MessageBox.Show("jugador " + jugadores[jugadorActual1].IdJugador + " ha ganado el combate pokemon!!!!");
                    //jugadores.RemoveAt(jugadorActual2);
                    //Se setea el bot en este caso como perdedor y el jugador como ganador
                    jugadores[jugadorActual1].setGanador();
				    jugadores[jugadorActual2].setPerdedor();

				    ganadorId = jugadores[jugadorActual1].IdJugador;
                    perdedorId = jugadores[jugadorActual2].IdJugador;
                
                    jugadorActual1 += 2;
                    jugadorActual2 += 2;

                    restaurarEquipo();
                    llamarPokemonesCampo();
                    CargarPokemonesEnEspera();
                    mostrarJugadores();
                    
                    controlador.insertarGanadorBitacora(ganadorId, perdedorId, combate);
				

                    MessageBox.Show("Inicio siguiente combate");

                    if (jugadores[jugadorActual1].getIsBot() && jugadores[jugadorActual2].getIsBot())
                    {
                        logicaAmbosSonBots();
                    }


                }

            return (ganadorId, perdedorId, combate);
        }
        public (int ganadorId, int perdedorId, string combate) logicaMovimientoJ2()
        {
            reproducirSonido2();
            imagenGolpe();
            HabilitarBotonesJugador();
            DeshabilitarBotonesRival();
            int ganadorId = 0;
            int perdedorId = 0;
            string combate = $"Jugador {jugadores[jugadorActual1].IdJugador} VS Jugador {jugadores[jugadorActual2].IdJugador}";

            progressBar1.Value = jugadores[jugadorActual1].pokemones[pokemonActual1].getVidaRestante();
            label3.Text = Convert.ToString(progressBar1.Value) + "/100";

            if (progressBar1.Value == 0)
            {
                actualizarPokemonJ1();
                j1PokemonesElimidados++;
            }

            if (j1PokemonesElimidados == 4)
            {

                MessageBox.Show("jugador " + jugadores[jugadorActual1].IdJugador + " ha ganado el combate pokemon!!!!");
                //jugadores.RemoveAt(jugadorActual2);
                //Se setea el bot en este caso como perdedor y el jugador como ganador
                jugadores[jugadorActual2].setPerdedor();
                jugadores[jugadorActual1].setGanador();

                perdedorId = jugadores[jugadorActual2].IdJugador;
                ganadorId = jugadores[jugadorActual1].IdJugador;

                jugadorActual1 = jugadorActual1 + 2;
                jugadorActual2 = jugadorActual2 + 2;

                restaurarEquipo();
                llamarPokemonesCampo();
                CargarPokemonesEnEspera();
                mostrarJugadores();

                insertar_bitacora.InsertarEnBitacoraPeleas(ganadorId, perdedorId, combate);

                MessageBox.Show("Inicio siguiente combate");

                logicaAmbosSonBots();
            }
            return (ganadorId, perdedorId, combate);
        }
        public (int ganadorId, int perdedorId, string combate) logicaMovimientoBot()
        {
            int ganadorId = 0;
            int perdedorId = 0;
            string combate = $"Jugador {jugadores[jugadorActual1].IdJugador} VS Jugador {jugadores[jugadorActual2].IdJugador}";

            progressBar2.Value = jugadores[jugadorActual2].pokemones[pokemonActual2].getVidaRestante();
            label4.Text = Convert.ToString(progressBar2.Value) + "/100";


            if (progressBar2.Value == 0)
            {
                
                actualizarPokemonbot();
                j2PokemonesElimidados++;

                if (j2PokemonesElimidados == 4)
                {

                    MessageBox.Show("jugador " + jugadores[jugadorActual1].IdJugador + " ha ganado el combate pokemon!!!!");
                    //jugadores.RemoveAt(jugadorActual2);
                    //Se setea el bot en este caso como perdedor y el jugador como ganador
                    jugadores[jugadorActual2].setPerdedor();
                    jugadores[jugadorActual1].setGanador();



                    perdedorId = jugadores[jugadorActual2].IdJugador;
                    ganadorId = jugadores[jugadorActual1].IdJugador;

                    jugadorActual1 += 2;
                    jugadorActual2 += 2;

                    restaurarEquipo();
                    llamarPokemonesCampo();
                    CargarPokemonesEnEspera();
                    mostrarJugadores();

					controlador.insertarGanadorBitacora(ganadorId, perdedorId, combate);


                    MessageBox.Show("Inicio segundo combate");
                }
                else
                {
                    movimientoBot(jugadorActual1, jugadorActual2);
                }
            }
            else
            {
                movimientoBot(jugadorActual1, jugadorActual2);
            }


            
            logicaAmbosSonBots();

            return (ganadorId, perdedorId, combate);
        }
		public async void movimientoBot(int jugadorActual1, int jugadorActual2)
		{

			if (jugadores[jugadorActual2].getIsBot())
			{
				await Task.Delay(1000);

				Random rnd = new Random();
				int numeroAleatorio = rnd.Next(1, 5);

				if (jugadores[jugadorActual2].IdJugador % 2 == 0)
				{
					reproducirSonido2();
					imagenGolpe_2();
					HabilitarBotonesJugador();
					DeshabilitarBotonesRival();

					switch (numeroAleatorio)
					{
						case 1:
							jugadores[jugadorActual1].pokemones[pokemonActual1].restarVida(Convert.ToDouble(jugadores[jugadorActual2].pokemones[pokemonActual1].mov1Poder),
																										   jugadores[jugadorActual2].pokemones[pokemonActual1].tipo1,
																										   jugadores[jugadorActual1].pokemones[pokemonActual1].tipo1, ObtenerNumeroImagen());
							break;
						case 2:
							jugadores[jugadorActual1].pokemones[pokemonActual1].restarVida(Convert.ToDouble(jugadores[jugadorActual2].pokemones[pokemonActual1].mov2Poder),
																										   jugadores[jugadorActual2].pokemones[pokemonActual1].tipo1,
																										   jugadores[jugadorActual1].pokemones[pokemonActual1].tipo1, ObtenerNumeroImagen());
							break;
						case 3:
							jugadores[jugadorActual1].pokemones[pokemonActual1].restarVida(Convert.ToDouble(jugadores[jugadorActual2].pokemones[pokemonActual1].mov3Poder),
																										   jugadores[jugadorActual2].pokemones[pokemonActual1].tipo1,
																										   jugadores[jugadorActual1].pokemones[pokemonActual1].tipo1, ObtenerNumeroImagen());
							break;
						case 4:
							jugadores[jugadorActual1].pokemones[pokemonActual1].restarVida(Convert.ToDouble(jugadores[jugadorActual2].pokemones[pokemonActual1].mov4Poder),
																										   jugadores[jugadorActual2].pokemones[pokemonActual1].tipo1,
																										   jugadores[jugadorActual1].pokemones[pokemonActual1].tipo1, ObtenerNumeroImagen());
							break;
					}
					progressBar1.Value = jugadores[jugadorActual1].pokemones[pokemonActual1].getVidaRestante();
					label3.Text = Convert.ToString(progressBar1.Value) + "/100";


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
							jugadores[jugadorActual1].pokemones[pokemonActual1].restarVida(Convert.ToDouble(jugadores[jugadorActual2].pokemones[pokemonActual2].mov1Poder),
																							  jugadores[jugadorActual2].pokemones[pokemonActual2].tipo1,
																							  jugadores[jugadorActual1].pokemones[pokemonActual1].tipo1, ObtenerNumeroImagen());
							progressBar1.Value = jugadores[jugadorActual1].pokemones[pokemonActual1].getVidaRestante();
							break;
						case 2:
							jugadores[jugadorActual1].pokemones[pokemonActual1].restarVida(Convert.ToDouble(jugadores[jugadorActual2].pokemones[pokemonActual2].mov2Poder),
																						  jugadores[jugadorActual2].pokemones[pokemonActual2].tipo1,
																						  jugadores[jugadorActual1].pokemones[pokemonActual1].tipo1, ObtenerNumeroImagen());
							progressBar1.Value = jugadores[jugadorActual1].pokemones[pokemonActual1].getVidaRestante();
							break;
						case 3:
							jugadores[jugadorActual1].pokemones[pokemonActual1].restarVida(Convert.ToDouble(jugadores[jugadorActual2].pokemones[pokemonActual2].mov3Poder),
																						  jugadores[jugadorActual2].pokemones[pokemonActual2].tipo1,
																						  jugadores[jugadorActual1].pokemones[pokemonActual1].tipo1, ObtenerNumeroImagen());
							progressBar1.Value = jugadores[jugadorActual1].pokemones[pokemonActual1].getVidaRestante();
							break;
						case 4:
							jugadores[jugadorActual1].pokemones[pokemonActual1].restarVida(Convert.ToDouble(jugadores[jugadorActual2].pokemones[pokemonActual2].mov4Poder),
																						  jugadores[jugadorActual2].pokemones[pokemonActual2].tipo1,
																						  jugadores[jugadorActual1].pokemones[pokemonActual1].tipo1, ObtenerNumeroImagen());
							progressBar1.Value = jugadores[jugadorActual1].pokemones[pokemonActual1].getVidaRestante();
							break;
					}
				}

			}

			if (progressBar1.Value <= 0)
			{
				actualizarPokemonJ1();
			}
			if (progressBar2.Value <= 0)
			{
				actualizarPokemonJ2();
			}

		}
		private string tipoArena(int numArena)
		{

			switch (numArena)
			{
				case 12:
					arena = "Normal";
					break;
				case 11:
					arena = "Fuego";
					break;
				case 4:
					arena = "Agua";
					break;
				case 2:
					arena = "Planta";
					break;
				case 13:
					arena = "Electrico";
					break;
				case 14:
					arena = "Hielo";
					break;
				case 5:
					arena = "Lucha";
					break;
				case 10:
					arena = "Veneno";
					break;
				case 15:
					arena = "Tierra";
					break;
				case 7:
					arena = "Volador";
					break;
				case 16:
					arena = "Psiquico";
					break;
				case 17:
					arena = "Bicho";
					break;
				case 6:
					arena = "Roca";
					break;
				case 9:
					arena = "Fantasma";
					break;
				case 3:
					arena = "Dragon";
					break;
				case 8:
					arena = "Acero";
					break;
				case 1:
					arena = "Hada";
					break;
				default:

					break;

			}
			return arena;

		}
		private void restaurarEquipo()
		{
			foreach (var jugador in jugadores)
			{
				foreach (var pokemon in jugador.pokemones)
				{
					pokemon.vida = 100;
				}
			}

		}
        //Cambio de pokemones
        private void PokemonEnEspera_Click1(object sender, EventArgs e)
        {
            PictureBox pictureBoxEnEspera = sender as PictureBox;

            // Obtener el índice del PictureBox en el panel de Pokémon en espera
            int indicePictureBoxEspera = flowLayoutPanel1.Controls.IndexOf(pictureBoxEnEspera);

            // Obtener el nombre del Pokémon en el campo de batalla
            string nombrePokemonCampo = flowLayoutPanel2.Controls[0].Name;

            int indicePokemonEspera = 0;
            int indicePokemonCampo = 0;

            string pathEspera = Path.Combine(Archivos, "Resources", "pokemonFrente\\");
            string pathBatalla = Path.Combine(Archivos, "Resources", "pokemonEspalda\\");

            // Encontrar los índices de los Pokémon en base a los nombres
            foreach (var pokemon in jugadores[jugadorActual1].pokemones)
            {
                if (pokemon.nombre == pictureBoxEnEspera.Name)
                {
                    break;
                }
                indicePokemonEspera++;
            }

            foreach (var pokemon in jugadores[jugadorActual1].pokemones)
            {
                if (pokemon.nombre == nombrePokemonCampo)
                {
                    break;
                }
                indicePokemonCampo++;
            }

            flowLayoutPanel1.Controls.RemoveAt(indicePictureBoxEspera);

           

            // Construir las rutas de las imágenes basadas en los índices
            string rutaImagenEsperaAbatalla = Path.Combine(pathBatalla, $"{jugadores[jugadorActual1].pokemones[indicePokemonEspera].Id}.gif");
            string rutaImagenBatallaAespera = Path.Combine(pathEspera, $"{jugadores[jugadorActual1].pokemones[indicePokemonCampo].Id}.gif");

            // Eliminar todos los Pokémon del campo de batalla antes de agregar uno nuevo
            flowLayoutPanel2.Controls.Clear();

            //Se setean las propiedades del PictureBox
            PictureBox pictureBox_Espalda = new PictureBox();
            pictureBox_Espalda.Name = jugadores[jugadorActual1].pokemones[indicePokemonEspera].nombre;
            pictureBox_Espalda.Image = new System.Drawing.Bitmap(rutaImagenEsperaAbatalla);
            pictureBox_Espalda.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_Espalda.Size = new Size(125, 125);

            //Se agrega la imagen del pokemon que antes estaba en espera al campo de batalla
            flowLayoutPanel2.Controls.Add(pictureBox_Espalda);
            flowLayoutPanel2.BackColor = System.Drawing.Color.Transparent;

			//Se le agregan los nombres 
			button1.Text = jugadores[jugadorActual1].pokemones[indicePokemonEspera].movimiento1 + "//" + jugadores[jugadorActual1].pokemones[pokemonActual1].mov1Poder;
			button2.Text = jugadores[jugadorActual1].pokemones[indicePokemonEspera].movimiento2 + "//" + jugadores[jugadorActual1].pokemones[pokemonActual1].mov2Poder;
			button3.Text = jugadores[jugadorActual1].pokemones[indicePokemonEspera].movimiento3 + "//" + jugadores[jugadorActual1].pokemones[pokemonActual1].mov3Poder;
			button4.Text = jugadores[jugadorActual1].pokemones[indicePokemonEspera].movimiento4 + "//" + jugadores[jugadorActual1].pokemones[pokemonActual1].mov4Poder;
		
            progressBar1.Value = jugadores[jugadorActual1].pokemones[indicePokemonEspera].vida;
            label3.Text = Convert.ToString(progressBar1.Value) + "/100";

            pokemonActual1 = indicePokemonEspera;

            PictureBox PictureBoxbatallaAespera = sender as PictureBox;
            PictureBoxbatallaAespera.Image = new System.Drawing.Bitmap(rutaImagenBatallaAespera);
            PictureBoxbatallaAespera.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBoxbatallaAespera.Size = new Size(70, 70);
            PictureBoxbatallaAespera.Name = jugadores[jugadorActual1].pokemones[indicePokemonCampo].nombre;

            flowLayoutPanel1.Controls.Add(PictureBoxbatallaAespera);
        }
        private void RivalPokemonEnEspera_Click(object sender, EventArgs e)
        {
            PictureBox pictureBoxEnEspera = sender as PictureBox;

            // Obtener el índice del PictureBox en el panel de Pokémon en espera
            int indicePictureBoxEspera = flowLayoutPanel3.Controls.IndexOf(pictureBoxEnEspera);

            // Obtener el nombre del Pokémon en el campo de batalla
            string nombrePokemonCampo = flowLayoutPanel4.Controls[0].Name;

            int indicePokemonEspera = 0;
            int indicePokemonCampo = 0;

            string pathEspera = Path.Combine(Archivos, "Resources", "pokemonFrente\\");
            string pathBatalla = Path.Combine(Archivos, "Resources", "pokemonEspalda\\");

            // Encontrar los índices de los Pokémon en base a los nombres
            foreach (var pokemon in jugadores[jugadorActual2].pokemones)
            {
                if (pokemon.nombre == pictureBoxEnEspera.Name)
                {
                    break;
                }
                indicePokemonEspera++;
            }

            foreach (var pokemon in jugadores[jugadorActual2].pokemones)
            {
                if (pokemon.nombre == nombrePokemonCampo)
                {
                    break;
                }
                indicePokemonCampo++;
            }

            if (jugadores[jugadorActual2].pokemones[indicePokemonEspera].vida != 0)
            {
                flowLayoutPanel3.Controls.RemoveAt(indicePictureBoxEspera);

                // Construir las rutas de las imágenes basadas en los índices
                string rutaImagenEsperaAbatalla = Path.Combine(pathEspera, $"{jugadores[jugadorActual2].pokemones[indicePokemonCampo].Id}.gif");
                string rutaImagenBatallaAespera = Path.Combine(pathEspera, $"{jugadores[jugadorActual2].pokemones[indicePokemonEspera].Id}.gif");

                // Eliminar todos los Pokémon del campo de batalla antes de agregar uno nuevo
                flowLayoutPanel4.Controls.Clear();

                // Se setean las propiedades del PictureBox
                PictureBox pictureBox_Frente = new PictureBox();
                pictureBox_Frente.Name = jugadores[jugadorActual2].pokemones[indicePokemonEspera].nombre;
                pictureBox_Frente.Image = new System.Drawing.Bitmap(rutaImagenBatallaAespera);
                pictureBox_Frente.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox_Frente.Size = new Size(125, 125);

                // Se agrega la imagen del pokemon que antes estaba en espera al campo de batalla
                flowLayoutPanel4.Controls.Add(pictureBox_Frente);
                flowLayoutPanel4.BackColor = System.Drawing.Color.Transparent;

                // Se le agregan los nombres de los ataques
    
				button5.Text = jugadores[jugadorActual2].pokemones[indicePokemonEspera].movimiento1 + "//" + jugadores[jugadorActual2].pokemones[indicePokemonEspera].mov1Poder;
				button6.Text = jugadores[jugadorActual2].pokemones[indicePokemonEspera].movimiento2 + "//" + jugadores[jugadorActual2].pokemones[indicePokemonEspera].mov2Poder;
				button7.Text = jugadores[jugadorActual2].pokemones[indicePokemonEspera].movimiento3 + "//" + jugadores[jugadorActual2].pokemones[indicePokemonEspera].mov3Poder;
				button8.Text = jugadores[jugadorActual2].pokemones[indicePokemonEspera].movimiento4 + "//" + jugadores[jugadorActual2].pokemones[indicePokemonEspera].mov4Poder;

				progressBar2.Value = jugadores[jugadorActual2].pokemones[indicePokemonEspera].vida;
                label4.Text = $"{progressBar2.Value}/100";

                pokemonActual2 = indicePokemonEspera;


                PictureBox PictureBoxbatallaAespera = sender as PictureBox;
                PictureBoxbatallaAespera.Image = new System.Drawing.Bitmap(rutaImagenEsperaAbatalla);
                PictureBoxbatallaAespera.SizeMode = PictureBoxSizeMode.Zoom;
                PictureBoxbatallaAespera.Size = new Size(70, 70);
                PictureBoxbatallaAespera.Name = jugadores[jugadorActual2].pokemones[indicePokemonCampo].nombre;

                flowLayoutPanel3.Controls.Add(PictureBoxbatallaAespera);
            }
            else
            {
                MessageBox.Show(jugadores[jugadorActual2].pokemones[indicePokemonEspera].nombre + ": Estoy cansado jefe");
            }

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
                    PictureBox pictureBox_pokemonesJugador2 = new PictureBox();
                    //Asignando el evento a los picturebox
                    pictureBox_pokemonesJugador1.Click += PokemonEnEspera_Click1;
                    pictureBox_pokemonesJugador2.Click += RivalPokemonEnEspera_Click;

                    //Asignando nombre a cada uno de los picture box
                    pictureBox_pokemonesJugador1.Name = jugadores[jugadorActual1].pokemones[i].nombre;

                    pictureBox_pokemonesJugador2.Name = jugadores[jugadorActual2].pokemones[i].nombre;

                    //Generando rutas de imagen
                    string rutaImagen = pokemonesJugador1 + jugadores[jugadorActual1].pokemones[i].Id + ".gif";
                    string rutaImagen2 = pokemonesJugador2 + jugadores[jugadorActual2].pokemones[i].Id + ".gif";


                    if (File.Exists(rutaImagen) && File.Exists(rutaImagen2))
                    {
                        pictureBox_pokemonesJugador1.Image = new System.Drawing.Bitmap(rutaImagen);
                        pictureBox_pokemonesJugador1.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox_pokemonesJugador1.Size = new Size(70, 70);

                        pictureBox_pokemonesJugador2.Image = new System.Drawing.Bitmap(rutaImagen2);
                        pictureBox_pokemonesJugador2.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox_pokemonesJugador2.Size = new Size(70, 70);
                        flowLayoutPanel1.Controls.Add(pictureBox_pokemonesJugador1);
                        flowLayoutPanel3.Controls.Add(pictureBox_pokemonesJugador2);
                    }
                    else
                    {
                        MessageBox.Show($"Error: La imagen {rutaImagen} no existe o puede ser la imagen {rutaImagen2} ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las imágenes del jugador 1: {ex.Message} o del jugador 2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //Actualizacion de pokemones
        public void actualizarPokemonbot()
        {
			int indicePokemon = jugadores[jugadorActual2].pokemones.FindIndex(pokemon => pokemon.vida == 100);

			// Si no se encuentra un Pokémon con 100 de vida, obtener el de mayor vida
			if (indicePokemon == -1)
			{
				var pokemonMayorVida = jugadores[jugadorActual2].pokemones.OrderByDescending(pokemon => pokemon.vida).FirstOrDefault();

				if (pokemonMayorVida != null)
				{
					// Obtener el índice del Pokémon con mayor vida
					indicePokemon = jugadores[jugadorActual2].pokemones.IndexOf(pokemonMayorVida);
				}
			}

			if (indicePokemon != -1) // Si se encuentra un Pokémon con 100 de vida
			{
				try
				{
                    pokemonActual2++;
					flowLayoutPanel4.Controls.Clear();
					PictureBox pictureBox_Frente = new PictureBox();
					pictureBox_Frente.Image = Image.FromFile(frente + jugadores[jugadorActual2].pokemones[pokemonActual2].Id + ".gif");
					pictureBox_Frente.SizeMode = PictureBoxSizeMode.StretchImage;
					pictureBox_Frente.Size = new Size(110, 100);
                    pictureBox_Frente.Name = jugadores[jugadorActual2].pokemones[indicePokemon].nombre;
					flowLayoutPanel4.Controls.Add(pictureBox_Frente);
					flowLayoutPanel4.BackColor = System.Drawing.Color.Transparent;
					button5.Text = jugadores[jugadorActual2].pokemones[indicePokemon].movimiento1 + "//" + jugadores[jugadorActual2].pokemones[pokemonActual2].mov1Poder;
					button6.Text = jugadores[jugadorActual2].pokemones[indicePokemon].movimiento2 + "//" + jugadores[jugadorActual2].pokemones[pokemonActual2].mov2Poder;
					button7.Text = jugadores[jugadorActual2].pokemones[indicePokemon].movimiento3 + "//" + jugadores[jugadorActual2].pokemones[pokemonActual2].mov3Poder;
					button8.Text = jugadores[jugadorActual2].pokemones[indicePokemon].movimiento4 + "//" + jugadores[jugadorActual2].pokemones[pokemonActual2].mov4Poder;
					pokemonActual2 = indicePokemon;
					// Actualizar la vida del nuevo Pokémon
					progressBar2.Value = jugadores[jugadorActual2].pokemones[indicePokemon].vida;
					label4.Text = $"{progressBar2.Value}/100";

					flowLayoutPanel3.Controls.RemoveAt(0);

				}
				catch (Exception ex)
				{
					MessageBox.Show($"Error al cargar la imagen GIF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show("No se encontró un Pokémon con 100 de vida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}


            /*
			pokemonActual2++;
            try
            {

                flowLayoutPanel4.Controls.Clear();
                PictureBox pictureBox_Frente = new PictureBox();
                pictureBox_Frente.Image = Image.FromFile(frente + jugadores[jugadorActual2].pokemones[pokemonActual2].Id + ".gif");
                pictureBox_Frente.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox_Frente.Size = new Size(110, 100);
                flowLayoutPanel4.Controls.Add(pictureBox_Frente);
                flowLayoutPanel4.BackColor = System.Drawing.Color.Transparent;
                button5.Text = jugadores[jugadorActual2].pokemones[pokemonActual2].movimiento1 + "//" + jugadores[jugadorActual2].pokemones[pokemonActual2].mov1Poder;
				button6.Text = jugadores[jugadorActual2].pokemones[pokemonActual2].movimiento2 + "//" + jugadores[jugadorActual2].pokemones[pokemonActual2].mov2Poder;
				button7.Text = jugadores[jugadorActual2].pokemones[pokemonActual2].movimiento3 + "//" + jugadores[jugadorActual2].pokemones[pokemonActual2].mov3Poder;
				button8.Text = jugadores[jugadorActual2].pokemones[pokemonActual2].movimiento4 + "//" + jugadores[jugadorActual2].pokemones[pokemonActual2].mov4Poder;

				//Actualizacion de la vida del nuevo pokemon!
				progressBar2.Value = 100;
                label4.Text = Convert.ToString(progressBar2.Value) + "/100";


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la imagen GIF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
        }
        public void actualizarPokemonJ1()
        {

            // Buscar el primer Pokémon con 100 de vida
            int indicePokemon = jugadores[jugadorActual1].pokemones.FindIndex(pokemon => pokemon.vida == 100);

            // Si no se encuentra un Pokémon con 100 de vida, obtener el de mayor vida
            if (indicePokemon == -1)
            {
                var pokemonMayorVida = jugadores[jugadorActual1].pokemones.OrderByDescending(pokemon => pokemon.vida).FirstOrDefault();

                if (pokemonMayorVida != null)
                {
                    // Obtener el índice del Pokémon con mayor vida
                    indicePokemon = jugadores[jugadorActual1].pokemones.IndexOf(pokemonMayorVida);
                }
            }

            if (indicePokemon != -1) // Si se encuentra un Pokémon con 100 de vida
            {
                try
                {
                    flowLayoutPanel2.Controls.Clear();
                    PictureBox pictureBox_Espalda = new PictureBox();
                    pictureBox_Espalda.Image = new System.Drawing.Bitmap(espalda + jugadores[jugadorActual1].pokemones[indicePokemon].Id + ".gif");
                    pictureBox_Espalda.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox_Espalda.Size = new Size(125, 125);
                    pictureBox_Espalda.Name = jugadores[jugadorActual1].pokemones[indicePokemon].nombre;
                    flowLayoutPanel2.Controls.Add(pictureBox_Espalda);
                    flowLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
                    button1.Text = jugadores[jugadorActual1].pokemones[indicePokemon].movimiento1 + "//" + jugadores[jugadorActual1].pokemones[indicePokemon].mov1Poder;
                    button2.Text = jugadores[jugadorActual1].pokemones[indicePokemon].movimiento2 + "//" + jugadores[jugadorActual1].pokemones[indicePokemon].mov2Poder;
					button3.Text = jugadores[jugadorActual1].pokemones[indicePokemon].movimiento3 + "//" + jugadores[jugadorActual1].pokemones[indicePokemon].mov3Poder;
                    button4.Text = jugadores[jugadorActual1].pokemones[indicePokemon].movimiento4 + "//" + jugadores[jugadorActual1].pokemones[indicePokemon].mov4Poder;

                    pokemonActual1 = indicePokemon;
                    // Actualizar la vida del nuevo Pokémon
                    progressBar1.Value = jugadores[jugadorActual1].pokemones[indicePokemon].vida;
                    label3.Text = $"{progressBar1.Value}/100";

                    flowLayoutPanel1.Controls.RemoveAt(0);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar la imagen GIF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No se encontró un Pokémon con 100 de vida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void actualizarPokemonJ2()
        {

            // Buscar el primer Pokémon con 100 de vida
            int indicePokemon = jugadores[jugadorActual2].pokemones.FindIndex(pokemon => pokemon.vida == 100);

            // Si no se encuentra un Pokémon con 100 de vida, obtener el de mayor vida
            if (indicePokemon == -1)
            {
                var pokemonMayorVida = jugadores[jugadorActual2].pokemones.OrderByDescending(pokemon => pokemon.vida).FirstOrDefault();

                if (pokemonMayorVida != null)
                {
                    // Obtener el índice del Pokémon con mayor vida
                    indicePokemon = jugadores[jugadorActual2].pokemones.IndexOf(pokemonMayorVida);
                }
            }

            if (indicePokemon != -1) // Si se encuentra un Pokémon con 100 de vida
            {
                try
                {
                    //Borramos el picturebox del pokemon en batalla
                    flowLayoutPanel4.Controls.Clear();
                    
                    //Se crea un nuevo picture box con los atributos del siguiente pokemon
                    PictureBox pictureBox_Frente = new PictureBox();
                    pictureBox_Frente.Image = new System.Drawing.Bitmap(frente + jugadores[jugadorActual2].pokemones[indicePokemon].Id + ".gif");
                    pictureBox_Frente.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox_Frente.Size = new Size(110, 100);
                    pictureBox_Frente.Name = jugadores[jugadorActual2].pokemones[indicePokemon].nombre;

                    //Se agrega el picturebox con el pokemon siguiente
                    flowLayoutPanel4.Controls.Add(pictureBox_Frente);
                    flowLayoutPanel4.BackColor = System.Drawing.Color.Transparent;

                    //Se setean los valores del siguiente pokemon
                    button1.Text = jugadores[jugadorActual2].pokemones[indicePokemon].movimiento1;
                    button2.Text = jugadores[jugadorActual2].pokemones[indicePokemon].movimiento2;
                    button3.Text = jugadores[jugadorActual2].pokemones[indicePokemon].movimiento3;
                    button4.Text = jugadores[jugadorActual2].pokemones[indicePokemon].movimiento4;

                    //Se actualiza el index del pokemon
                    pokemonActual2 = indicePokemon;

                    // Actualizar la vida del nuevo Pokémon
                    progressBar2.Value = jugadores[jugadorActual2].pokemones[indicePokemon].vida;
                    label4.Text = $"{progressBar1.Value}/100";

                    flowLayoutPanel3.Controls.RemoveAt(0);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar la imagen GIF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No se encontró un Pokémon con 100 de vida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //metodos para la precarga del form
        public void llamarPokemonesCampo()
        {

            pokemonActual1 = 0;
            pokemonActual2 = 0;
            try
            {

                flowLayoutPanel2.Controls.Clear();
                flowLayoutPanel1.Controls.Clear();

                PictureBox pictureBox_Espalda = new PictureBox();
                //Asignar nombre a picturebox en campo
                pictureBox_Espalda.Name = jugadores[jugadorActual1].pokemones[pokemonActual1].nombre;

                pictureBox_Espalda.Image = new System.Drawing.Bitmap(espalda + jugadores[jugadorActual1].pokemones[pokemonActual1].Id + ".gif");
                pictureBox_Espalda.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox_Espalda.Size = new Size(125, 125);
                flowLayoutPanel2.Controls.Add(pictureBox_Espalda);
                flowLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
                button1.Text = jugadores[jugadorActual1].pokemones[pokemonActual1].movimiento1 + "//" + jugadores[jugadorActual1].pokemones[pokemonActual1].mov1Poder;
                button2.Text = jugadores[jugadorActual1].pokemones[pokemonActual1].movimiento2 + "//" + jugadores[jugadorActual1].pokemones[pokemonActual1].mov2Poder;
				button3.Text = jugadores[jugadorActual1].pokemones[pokemonActual1].movimiento3 + "//" + jugadores[jugadorActual1].pokemones[pokemonActual1].mov3Poder;
                button4.Text = jugadores[jugadorActual1].pokemones[pokemonActual1].movimiento4 + "//" + jugadores[jugadorActual1].pokemones[pokemonActual1].mov4Poder;
			}
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la imagen GIF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            try
            {
                flowLayoutPanel3.Controls.Clear();
                flowLayoutPanel4.Controls.Clear();
                PictureBox pictureBox_Frente = new PictureBox();

                pictureBox_Frente.Name = jugadores[jugadorActual2].pokemones[pokemonActual2].nombre;
                pictureBox_Frente.Image = new System.Drawing.Bitmap(frente + jugadores[jugadorActual2].pokemones[pokemonActual2].Id + ".gif");
                pictureBox_Frente.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox_Frente.Size = new Size(110, 100);// Añadir el PictureBox al FlowLayoutPanel
                flowLayoutPanel4.Controls.Add(pictureBox_Frente);
                flowLayoutPanel4.BackColor = System.Drawing.Color.Transparent;
                button5.Text = jugadores[jugadorActual2].pokemones[pokemonActual2].movimiento1 + "//" + jugadores[jugadorActual2].pokemones[pokemonActual2].mov1Poder;
                button6.Text = jugadores[jugadorActual2].pokemones[pokemonActual2].movimiento2 + "//" + jugadores[jugadorActual2].pokemones[pokemonActual2].mov2Poder;
                button7.Text = jugadores[jugadorActual2].pokemones[pokemonActual2].movimiento3 + "//" + jugadores[jugadorActual2].pokemones[pokemonActual2].mov3Poder;
                button8.Text = jugadores[jugadorActual2].pokemones[pokemonActual2].movimiento4 + "//" + jugadores[jugadorActual2].pokemones[pokemonActual2].mov4Poder;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la imagen GIF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void CargarImagenesCampos()
        {
            // Construir la ruta relativa desde la carpeta del proyecto

            arenaAleatoria = controlador.ObtenerImagenesCampoBatalla();
            string directorioImagenes = Path.Combine(Archivos, "Resources", "campos");
            string ruta = directorioImagenes + "\\" + arenaAleatoria.ToString() + ".jpg";
            label5.Text = "Arena de tipo: " + tipoArena(arenaAleatoria);
            //MessageBox.Show(Convert.ToString(arenaAleatoria));
            try
            {
                if (Directory.Exists(directorioImagenes))
                {

                    panel1.BackgroundImage = Image.FromFile(ruta);
                    panel1.BackgroundImageLayout = ImageLayout.Stretch;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la imagen del campo de batalla: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public int ObtenerNumeroImagen()
        {
            return this.arenaAleatoria;
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
        //se puede simplificar estos metodos de sonido en uno solo
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
        //igual para estos 2 metodos se puede unificar
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
        //igual que estos metodos de habilitar o desabilitar botones
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
        //**********************************************************
        public void mostrarJugadores()
        {
            List<string> rutasImagenes;
            if (jugadores.Count == 4)
            {
                Fasefinal4 faseFinal4 = new Fasefinal4(jugadores, cantidadbots);
                // Obtener las rutas de imágenes aleatorias
                rutasImagenes = faseFinal4.MostrarImagenesAleatorias();
            }
            else if (jugadores.Count == 8)
            {
                Fasefinal8 faseFinal8 = new Fasefinal8(jugadores, cantidadbots);
                rutasImagenes = faseFinal8.MostrarImagenesAleatorias();
            }
            else
            {
                Fasefinal16 faseFinal16 = new Fasefinal16(jugadores, cantidadbots);
                rutasImagenes = faseFinal16.MostrarImagenesAleatorias();
            }

            progressBar1.Value = jugadores[jugadorActual1].pokemones[pokemonActual1].vida;
            progressBar2.Value = jugadores[jugadorActual2].pokemones[pokemonActual2].vida;
            label1.Text = "Jugador" + Convert.ToString(jugadores[jugadorActual1].IdJugador);
            label2.Text = "Jugador" + Convert.ToString(jugadores[jugadorActual2].IdJugador);



            if (rutasImagenes != null && rutasImagenes.Count >= 2)
            {
                string rutaImagenJugador1 = rutasImagenes[jugadores[jugadorActual1].IdJugador - 1];
                string rutaImagenJugador2 = rutasImagenes[jugadores[jugadorActual2].IdJugador - 1];

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
