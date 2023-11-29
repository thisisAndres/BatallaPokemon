using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class objetoJugador
    {
        public bool isGanador;
        public bool isBot = false;
        public int IdJugador { get; set; }
        public List<string> nombrePokemones { get; set; } = new List<string>();
        public List<objetoPokemon> pokemones { get; set; } = new List<objetoPokemon>();

        public objetoJugador() { }

        public List<objetoJugador> generarListaJugadores(int cantidadJugadores)
        {
            List<objetoJugador> Jugadores = new List<objetoJugador>();

            for (int i = 1; i < cantidadJugadores+1; i++)
            {
                Jugadores.Add(new objetoJugador { IdJugador = i });
            }

            return Jugadores;
        }

        public void setBot()
        {
            this.isBot = true;
        }

        public bool getIsBot()
        {
            return this.isBot;
        }

        public void setGanador()
        {
            this.isGanador = true;
        }

        public void setPerdedor()
        {
            this.isGanador = false;
        }

        public bool getIsGanador()
        {
            return (this.isGanador);
        }


    }


}
