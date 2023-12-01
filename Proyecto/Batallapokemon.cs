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

        private void Form2_Load(object sender, EventArgs e)
        {
            cargarImagenBackground();
            CargarImagenesCampos();
            reproducirSonidoBatalla();
            llamarPokemonesCampo();
            CargarPokemonesEnEspera();
            mostrarJugadores();
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

            //for (int i = 0; i < 6; i++) {
            //    jugadores[jugadorActual1].pokemones[i].vida = 100;
            //}

            foreach (var jugador in jugadores)
            {
                foreach (var pokemon in jugador.pokemones)
                {
                    pokemon.vida = 100;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
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

                jugadores[jugadorActual2].pokemones[pokemonActual2].restarVida(Convert.ToDouble(jugadores[jugadorActual1].pokemones[pokemonActual1].mov1Poder),
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

                jugadores[jugadorActual2].pokemones[pokemonActual2].restarVida(Convert.ToDouble(jugadores[jugadorActual1].pokemones[pokemonActual1].mov2Poder),
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

                jugadores[jugadorActual2].pokemones[pokemonActual2].restarVida(Convert.ToDouble(jugadores[jugadorActual1].pokemones[pokemonActual1].mov3Poder),
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
                jugadores[jugadorActual2].pokemones[pokemonActual2].restarVida(Convert.ToDouble(jugadores[jugadorActual1].pokemones[pokemonActual1].mov4Poder),
                                                                                               jugadores[jugadorActual1].pokemones[pokemonActual1].tipo1,
                                                                                               jugadores[jugadorActual2].pokemones[pokemonActual2].tipo1, ObtenerNumeroImagen());
                logicaMovimientoJ1();

            }

        }


        /*public void logicaAmbosSonBots()
         {
             if (jugadores[jugadorActual1].isBot && jugadores[jugadorActual2].isBot)
             {
                 Random rnd = new Random();

                 int nRandom = rnd.Next(1, 3);

                 if (nRandom == 1)
                 {
                     jugadores[jugadorActual1].setPerdedor();
                     jugadores[jugadorActual2].setGanador();

                     MessageBox.Show("Gano el jugador: " + jugadores[jugadorActual2].IdJugador);
                 }
                 else
                 {
                     jugadores[jugadorActual1].setGanador();
                     jugadores[jugadorActual2].setPerdedor();

                     MessageBox.Show("Gano el jugador: " + jugadores[jugadorActual1].IdJugador);
                 }

             }
         }*/
        public (int ganadorId, int perdedorId, string combate) logicaAmbosSonBots()
        {
            int ganadorId = 0;
            int perdedorId = 0;
            string combate = $"Jugador {jugadores[jugadorActual1].IdJugador} VS Jugador {jugadores[jugadorActual2].IdJugador}";

            if (jugadores[jugadorActual1].isBot && jugadores[jugadorActual2].isBot)
            {
                Random rnd = new Random();

                int nRandom = rnd.Next(1, 3);

                if (nRandom == 1)
                {
                    jugadores[jugadorActual1].setPerdedor();
                    jugadores[jugadorActual2].setGanador();

                    ganadorId = jugadores[jugadorActual2].IdJugador;
                    perdedorId = jugadores[jugadorActual1].IdJugador;

                    MessageBox.Show("Gano el jugador: " + ganadorId);
                }
                else
                {
                    jugadores[jugadorActual1].setGanador();
                    jugadores[jugadorActual2].setPerdedor();

                    ganadorId = jugadores[jugadorActual1].IdJugador;
                    perdedorId = jugadores[jugadorActual2].IdJugador;

                    MessageBox.Show("Gano el jugador: " + ganadorId);
                }
                
                insertar_bitacora.InsertarEnBitacoraPeleas(ganadorId, perdedorId, combate);
            }

            return (ganadorId, perdedorId, combate);
        }


        /*public void logicaMovimientoJ1()
        {
            HabilitarBotonesRival();
            DeshabilitarBotonesJugador();

            progressBar2.Value = jugadores[jugadorActual2].pokemones[pokemonActual2].getVidaRestante();
            label4.Text = Convert.ToString(progressBar2.Value) + "/100";

            if (progressBar2.Value == 0)
            {

                actualizarPokemonJ2();
                j1PokemonesElim++;
            }

            if (j1PokemonesElim == 4)
            {

                MessageBox.Show("jugador " + jugadores[jugadorActual1].IdJugador + " ha ganado el combate pokemon!!!!");
                //jugadores.RemoveAt(jugadorActual2);
                //Se setea el bot en este caso como perdedor y el jugador como ganador
                jugadores[jugadorActual2].setPerdedor();
                jugadores[jugadorActual1].setGanador();

                jugadorActual1 = jugadorActual1 + 2;
                jugadorActual2 = jugadorActual2 + 2;

                restaurarEquipo();
                llamarPokemonesCampo();
                CargarPokemonesEnEspera();
                mostrarJugadores();
                MessageBox.Show("Inicio siguiente combate");

                logicaAmbosSonBots();
            }
        }*/
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

                MessageBox.Show("jugador " + jugadores[jugadorActual2].IdJugador + " ha ganado el combate pokemon!!!!");
                //jugadores.RemoveAt(jugadorActual2);
                //Se setea el bot en este caso como perdedor y el jugador como ganador
                jugadores[jugadorActual1].setPerdedor();
                jugadores[jugadorActual2].setGanador();

                perdedorId = jugadores[jugadorActual1].IdJugador;
                ganadorId = jugadores[jugadorActual2].IdJugador;
                
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

        /*public void logicaMovimientoJ2()
        {
            reproducirSonido2();
            imagenGolpe();
            HabilitarBotonesJugador();
            DeshabilitarBotonesRival();
            progressBar1.Value = jugadores[jugadorActual1].pokemones[pokemonActual1].getVidaRestante();
            label3.Text = Convert.ToString(progressBar1.Value) + "/100";

            if (progressBar1.Value == 0)
            {

                actualizarPokemonJ1();
            }

            if (pokemonActual1 == 4)
            {

                MessageBox.Show("jugador " + jugadores[jugadorActual2].IdJugador + " ha ganado el combate pokemon!!!!");
                //jugadores.RemoveAt(jugadorActual2);
                //Se setea el bot en este caso como perdedor y el jugador como ganador
                jugadores[jugadorActual1].setPerdedor();
                jugadores[jugadorActual2].setGanador();

                jugadorActual1 = jugadorActual1 + 2;
                jugadorActual2 = jugadorActual2 + 2;

                restaurarEquipo();
                llamarPokemonesCampo();
                CargarPokemonesEnEspera();
                mostrarJugadores();
                MessageBox.Show("Inicio siguiente combate");

                logicaAmbosSonBots();
            }

        }*/
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

        /*public void logicaMovimientoBot()
        {
            // jugadores[jugadorActual2].pokemones[pokemonActual2].restarVida(
            //     Convert.ToDouble(jugadores[jugadorActual1].pokemones[pokemonActual1].mov4Poder),
            //     jugadores[jugadorActual1].pokemones[pokemonActual1].tipo1,
            //     jugadores[jugadorActual2].pokemones[pokemonActual2].tipo1, ObtenerNumeroImagen());

            progressBar2.Value = jugadores[jugadorActual2].pokemones[pokemonActual2].getVidaRestante();
            label4.Text = Convert.ToString(progressBar2.Value) + "/100";


            if (progressBar2.Value == 0)
            {
                //int eliminarPokemon = 0;
                //MessageBox.Show(Convert.ToString(jugadores[jugadorActual2].pokemones.Count()));
                //jugadores[jugadorActual2].pokemones.RemoveAt(eliminarPokemon);
                //MessageBox.Show(Convert.ToString(jugadores[jugadorActual2].pokemones.Count()));
                //eliminarPokemon++;
                pokemonActual2++;
                actualizarPokemonbot();
                if (pokemonActual2 == 4)
                {

                    MessageBox.Show("jugador " + jugadores[jugadorActual2].IdJugador + " ha ganado el combate pokemon!!!!");
                    //jugadores.RemoveAt(jugadorActual2);
                    //Se setea el bot en este caso como perdedor y el jugador como ganador
                    jugadores[jugadorActual2].setPerdedor();
                    jugadores[jugadorActual1].setGanador();

                    jugadorActual1 = jugadorActual1 + 2;
                    jugadorActual2 = jugadorActual2 + 2;

                    restaurarEquipo();
                    llamarPokemonesCampo();
                    CargarPokemonesEnEspera();
                    mostrarJugadores();
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

        }*/
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
                j1PokemonesElimidados++;

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

        private void button5_Click(object sender, EventArgs e)
        {


            jugadores[jugadorActual1].pokemones[pokemonActual1].restarVida(Convert.ToDouble(jugadores[jugadorActual2].pokemones[pokemonActual2].mov4Poder),
                                                                                           jugadores[jugadorActual2].pokemones[pokemonActual2].tipo1,
                                                                                           jugadores[jugadorActual1].pokemones[pokemonActual1].tipo1, ObtenerNumeroImagen());
            logicaMovimientoJ2();
            //reproducirSonido1();
            //imagenGolpe_2();
            //HabilitarBotonesJugador();
            // DeshabilitarBotonesRival();

            //progressBar1.Value = jugadores[jugadorActual1].pokemones[pokemonActual1].getVidaRestante();

            //movimiento del bot si lo hay
            //movimientoBot(jugadorActual1, jugadorActual2);


        }

        private void button6_Click(object sender, EventArgs e)
        {


            jugadores[jugadorActual1].pokemones[pokemonActual1].restarVida(Convert.ToDouble(jugadores[jugadorActual2].pokemones[pokemonActual2].mov4Poder),
                                                                                           jugadores[jugadorActual2].pokemones[pokemonActual2].tipo1,
                                                                                           jugadores[jugadorActual1].pokemones[pokemonActual1].tipo1, ObtenerNumeroImagen());
            logicaMovimientoJ2();
            //progressBar1.Value = jugadores[jugadorActual1].pokemones[pokemonActual1].getVidaRestante();

            //movimiento del bot si lo hay
            //movimientoBot(jugadorActual1, jugadorActual2);

        }
        private void button7_Click(object sender, EventArgs e)
        {

            jugadores[jugadorActual1].pokemones[pokemonActual1].restarVida(Convert.ToDouble(jugadores[jugadorActual2].pokemones[pokemonActual2].mov4Poder),
                                                                                           jugadores[jugadorActual2].pokemones[pokemonActual2].tipo1,
                                                                                           jugadores[jugadorActual1].pokemones[pokemonActual1].tipo1, ObtenerNumeroImagen());
            logicaMovimientoJ2();
            //progressBar1.Value = jugadores[jugadorActual1].pokemones[pokemonActual1].getVidaRestante();

            //movimiento del bot si lo hay
            //movimientoBot(jugadorActual1, jugadorActual2);

        }
        private void button8_Click(object sender, EventArgs e)
        {


            jugadores[jugadorActual1].pokemones[pokemonActual1].restarVida(Convert.ToDouble(jugadores[jugadorActual2].pokemones[pokemonActual2].mov4Poder),
                                                                                           jugadores[jugadorActual2].pokemones[pokemonActual2].tipo1,
                                                                                           jugadores[jugadorActual1].pokemones[pokemonActual1].tipo1, ObtenerNumeroImagen());
            logicaMovimientoJ2();
            //progressBar1.Value = jugadores[jugadorActual1].pokemones[pokemonActual1].getVidaRestante();

            //movimiento del bot si lo hay
            //movimientoBot(jugadorActual1, jugadorActual2);

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
            /*
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
            }*/
        }
        public void actualizarPokemonbot()
        {
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
                button5.Text = jugadores[jugadorActual2].pokemones[pokemonActual2].movimiento1;
                button6.Text = jugadores[jugadorActual2].pokemones[pokemonActual2].movimiento2;
                button7.Text = jugadores[jugadorActual2].pokemones[pokemonActual2].movimiento3;
                button8.Text = jugadores[jugadorActual2].pokemones[pokemonActual2].movimiento4;

                //Actualizacion de la vida del nuevo pokemon!
                progressBar2.Value = 100;
                label4.Text = Convert.ToString(progressBar2.Value) + "/100";


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la imagen GIF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void actualizarPokemonJ1()
        {
            pokemonActual1++;
            try
            {
                flowLayoutPanel2.Controls.Clear();
                PictureBox pictureBox_Espalda = new PictureBox();
                pictureBox_Espalda.Image = new System.Drawing.Bitmap(espalda + jugadores[jugadorActual1].pokemones[pokemonActual1].Id + ".gif");
                pictureBox_Espalda.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox_Espalda.Size = new Size(125, 125);
                flowLayoutPanel2.Controls.Add(pictureBox_Espalda);
                flowLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
                button1.Text = jugadores[jugadorActual1].pokemones[pokemonActual1].movimiento1;
                button2.Text = jugadores[jugadorActual1].pokemones[pokemonActual1].movimiento2;
                button3.Text = jugadores[jugadorActual1].pokemones[pokemonActual1].movimiento3;
                button4.Text = jugadores[jugadorActual1].pokemones[pokemonActual1].movimiento4;



                //Actualizacion de la vida del nuevo pokemon!
                progressBar1.Value = jugadores[jugadorActual1].pokemones[pokemonActual1].vida;
                label3.Text = Convert.ToString(progressBar1.Value) + "/100";


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la imagen GIF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void actualizarPokemonJ2()
        {
            pokemonActual2++;
            try
            {
                flowLayoutPanel4.Controls.Clear();
                PictureBox pictureBox_Frente = new PictureBox();
                pictureBox_Frente.Image = new System.Drawing.Bitmap(frente + jugadores[jugadorActual2].pokemones[pokemonActual2].Id + ".gif");
                pictureBox_Frente.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox_Frente.Size = new Size(110, 100);// Añadir el PictureBox al FlowLayoutPanel
                flowLayoutPanel4.Controls.Add(pictureBox_Frente);
                flowLayoutPanel4.BackColor = System.Drawing.Color.Transparent;
                button5.Text = jugadores[jugadorActual2].pokemones[pokemonActual2].movimiento1 + "//" + jugadores[jugadorActual2].pokemones[pokemonActual2].mov1Poder;
                button6.Text = jugadores[jugadorActual2].pokemones[pokemonActual2].movimiento2 + "//" + jugadores[jugadorActual2].pokemones[pokemonActual2].mov2Poder;
                button7.Text = jugadores[jugadorActual2].pokemones[pokemonActual2].movimiento3 + "//" + jugadores[jugadorActual2].pokemones[pokemonActual2].mov3Poder;
                button8.Text = jugadores[jugadorActual2].pokemones[pokemonActual2].movimiento4 + "//" + jugadores[jugadorActual2].pokemones[pokemonActual2].mov4Poder;



                //Actualizacion de la vida del nuevo pokemon!
                progressBar2.Value = jugadores[jugadorActual2].pokemones[pokemonActual2].vida;
                label4.Text = Convert.ToString(progressBar2.Value) + "/100";


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la imagen GIF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void llamarPokemonesCampo()
        {

            //pictureBox5.Image = Image.FromFile(espalda + jugadores[0].pokemones[0].Id + ".gif
            pokemonActual1 = 0;
            pokemonActual2 = 0;
            try
            {

                flowLayoutPanel2.Controls.Clear();
                flowLayoutPanel1.Controls.Clear();
                PictureBox pictureBox_Espalda = new PictureBox();
                pictureBox_Espalda.Image = new System.Drawing.Bitmap(espalda + jugadores[jugadorActual1].pokemones[pokemonActual1].Id + ".gif");
                pictureBox_Espalda.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox_Espalda.Size = new Size(125, 125);
                flowLayoutPanel2.Controls.Add(pictureBox_Espalda);
                flowLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
                button1.Text = jugadores[jugadorActual1].pokemones[pokemonActual1].movimiento1;
                button2.Text = jugadores[jugadorActual1].pokemones[pokemonActual1].movimiento2;
                button3.Text = jugadores[jugadorActual1].pokemones[pokemonActual1].movimiento3;
                button4.Text = jugadores[jugadorActual1].pokemones[pokemonActual1].movimiento4;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la imagen GIF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //pictureBox6.Image = Image.FromFile(frente + jugadores[0].pokemones[1].Id + ".gif
            try
            {
                flowLayoutPanel3.Controls.Clear();
                flowLayoutPanel4.Controls.Clear();
                PictureBox pictureBox_Frente = new PictureBox();
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
        //*********************************************************


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
        //*********************************************************



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
            Fasefinal4 faseFinalForm = new Fasefinal4(jugadores, cantidadbots);

            progressBar1.Value = jugadores[jugadorActual1].pokemones[0].vida;
            progressBar2.Value = jugadores[jugadorActual2].pokemones[0].vida;
            label1.Text = "Jugador" + Convert.ToString(jugadores[jugadorActual1].IdJugador);
            label2.Text = "Jugador" + Convert.ToString(jugadores[jugadorActual2].IdJugador);

            // Obtener las rutas de imágenes aleatorias
            List<string> rutasImagenes = faseFinalForm.MostrarImagenesAleatorias();

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
