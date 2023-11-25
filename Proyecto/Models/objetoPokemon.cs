using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proyecto.Properties;

namespace Proyecto.Models
{
    public class objetoPokemon
    {
        //info general del pokemon
        public string Id;
        public int vida;
        public string nombre;
        public string descripcion;
        public string tipo1;
        public string tipo2;

        //info de ataqueses
        public string movimiento1;
        public int mov1Poder;
        public string movimiento2;
        public int mov2Poder;
        public string movimiento3;
        public int mov3Poder;
        public string movimiento4;
        public int mov4Poder;

        //info de potenciadores
        private double eficiente;
        private double neutral;
        private double pocoEficiente;
        private double inmune;
        private double valor;
        

        private string desc;

        public objetoPokemon(string id, string nom, string desc, string tipo1, string tipo2, string m1, int pm1, string m2, int pm2, string m3, int pm3, string m4, int pm4)
        {
            //seteando valores generales
            this.nombre = nom;
            this.Id = id;
            this.descripcion = desc;
            this.tipo1 = tipo1;
            this.tipo2 = tipo2;

            //seteando valores de ataques
            this.movimiento1 = m1;
            this.movimiento2 = m2;
            this.movimiento3 = m3;
            this.movimiento4 = m4;
            this.mov1Poder = pm1;
            this.mov2Poder = pm2;
            this.mov3Poder = pm3;
            this.mov4Poder = pm4;

            //seteando potenciadores
            this.eficiente = 0.15;
            this.neutral = 1;
            this.pocoEficiente = -0.15;
            this.inmune = 0;
            this.valor = 0.0;

            //seteando vida del pokemon
            this.vida = 100;
        }

        public objetoPokemon(string id, string nom, string desc, string tipo1, string tipo2)
        {
            //seteando valores generales
            this.nombre = nom;
            this.Id = id;
            this.descripcion = desc;
            this.tipo1 = tipo1;
            this.tipo2 = tipo2;
        }

        public objetoPokemon(string desc)
        {
            this.desc = desc;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            objetoPokemon otherPokemon = (objetoPokemon)obj;
            return this.nombre.Equals(otherPokemon.nombre);
        }

        public int TakeDamage(string ataque, double power, string tipoEnemigo)
        {
            double effectiveness = GetEffectiveness(ataque, tipoEnemigo);

            double damage = power * effectiveness;
            int HP = -(int)damage;

            return HP;
        }

        /* normal, fuego, agua, planta, eléctrico,
         * hielo, lucha, veneno, tierra, volador, psíquico, 
         * bicho, roca, fantasma, dragón, hada, acero*/
        private double GetEffectiveness(string ataque, string tipoEnemigo)
        {

            switch (ataque)
            {
                case "Normal":
                    valor = TipoNormal(tipoEnemigo);
                    break;
                case "Fuego":
                    valor = TipoFuego(tipoEnemigo);
                    break;
                case "Agua":
                    valor = TipoAgua(tipoEnemigo);
                    break;
                case "Planta":
                    valor = TipoPlanta(tipoEnemigo);
                    break;
                case "Electrico":
                    valor = TipoElectrico(tipoEnemigo);
                    break;
                case "Hielo":
                    valor = TipoHielo(tipoEnemigo);
                    break;
                case "Lucha":
                    valor = TipoLucha(tipoEnemigo);
                    break;
                case "Veneno":
                    valor = TipoVeneno(tipoEnemigo);
                    break;
                case "Tierra":
                    valor = TipoTierra(tipoEnemigo);
                    break;
                case "Volador":
                    valor = TipoVolador(tipoEnemigo);
                    break;
                case "Psiquico":
                    valor = TipoPsiquico(tipoEnemigo);
                    break;
                case "Bicho":
                    valor = TipoBicho(tipoEnemigo);
                    break;
                case "Roca":
                    valor = TipoRoca(tipoEnemigo);
                    break;
                case "Fantasma":
                    valor = TipoFantasma(tipoEnemigo);
                    break;
                case "Dragon":
                    valor = TipoDragon(tipoEnemigo);
                    break;
                case "Acero":
                    valor = TipoAcero(tipoEnemigo);
                    break;
                case "Hada":
                    valor = TipoHada(tipoEnemigo);
                    break;
                default:

                    break;

            }
            return valor;

        }

        //Tabla de tipos
        private double TipoNormal(string tipoEnemigo)
        {

            if (tipoEnemigo == "Acero" || tipoEnemigo == "Roca")
            {
                return pocoEficiente;
            }
            else if (tipoEnemigo == "Fantasma")
            {
                return inmune;
            }
            else
            {
                return neutral;
            }
        }

        private double TipoFuego(string tipoEnemigo)
        {
            if (tipoEnemigo == "Planta" || tipoEnemigo == "Hielo" || tipoEnemigo == "Bicho" || tipoEnemigo == "Acero")
            {
                return eficiente;
            }
            else if (tipoEnemigo == "Agua" || tipoEnemigo == "Dragon" || tipoEnemigo == "Fuego" || tipoEnemigo == "Roca")
            {
                return pocoEficiente;
            }
            else
            {
                return neutral;
            }
        }

        private double TipoAgua(string tipoEnemigo)
        {
            if (tipoEnemigo == "Fuego" || tipoEnemigo == "Roca" || tipoEnemigo == "Tierra")
            {
                return eficiente;
            }
            else if (tipoEnemigo == "Agua" || tipoEnemigo == "Dragon" || tipoEnemigo == "Planta")
            {
                return pocoEficiente;
            }
            else
            {
                return neutral;
            }
        }

        private double TipoPlanta(string tipoEnemigo)
        {
            if (tipoEnemigo == "Agua" || tipoEnemigo == "Roca" || tipoEnemigo == "Tierra")
            {
                return eficiente;
            }
            else if (tipoEnemigo == "Acero" || tipoEnemigo == "Bicho" || tipoEnemigo == "Dragon" || tipoEnemigo == "Fuego" || tipoEnemigo == "Planta" || tipoEnemigo == "Veneno" || tipoEnemigo == "Volador")
            {
                return pocoEficiente;
            }
            else
            {
                return neutral;
            }
        }

        private double TipoElectrico(string tipoEnemigo)
        {
            if (tipoEnemigo == "Agua" || tipoEnemigo == "Volador")
            {
                return eficiente;
            }
            else if (tipoEnemigo == "Electrico" || tipoEnemigo == "Dragon" || tipoEnemigo == "Planta")
            {
                return pocoEficiente;
            }
            else if (tipoEnemigo == "Tierra")
            {
                return inmune;
            }
            else
            {
                return neutral;
            }
        }

        private double TipoHielo(string tipoEnemigo)
        {
            if (tipoEnemigo == "Dragon" || tipoEnemigo == "Planta" || tipoEnemigo == "Tierra" || tipoEnemigo == "Volador")
            {
                return eficiente;
            }
            else if (tipoEnemigo == "Agua" || tipoEnemigo == "Acero" || tipoEnemigo == "Fuego" || tipoEnemigo == "Hielo")
            {
                return pocoEficiente;
            }
            else
            {
                return neutral;
            }
        }

        private double TipoLucha(string tipoEnemigo)
        {
            if (tipoEnemigo == "Acero" || tipoEnemigo == "Hielo" || tipoEnemigo == "Normal" || tipoEnemigo == "Roca")
            {
                return eficiente;
            }
            else if (tipoEnemigo == "Bicho" || tipoEnemigo == "Hada" || tipoEnemigo == "Psiquico" || tipoEnemigo == "Veneno" || tipoEnemigo == "Volador")
            {
                return pocoEficiente;
            }
            else if (tipoEnemigo == "Fantasma")
            {
                return inmune;
            }
            else
            {
                return neutral;
            }
        }

        private double TipoVeneno(string tipoEnemigo)
        {
            if (tipoEnemigo == "Hada" || tipoEnemigo == "Planta")
            {
                return eficiente;
            }
            else if (tipoEnemigo == "Fantasma" || tipoEnemigo == "Roca" || tipoEnemigo == "Tierra" || tipoEnemigo == "Veneno")
            {
                return pocoEficiente;
            }
            else if (tipoEnemigo == "Acero")
            {
                return inmune;
            }
            else
            {
                return neutral;
            }
        }

        private double TipoTierra(string tipoEnemigo)
        {
            if (tipoEnemigo == "Acero" || tipoEnemigo == "Electrico" || tipoEnemigo == "Fuego" || tipoEnemigo == "Roca" || tipoEnemigo == "Veneno")
            {
                return eficiente;
            }
            else if (tipoEnemigo == "Bicho" || tipoEnemigo == "Planta")
            {
                return pocoEficiente;
            }
            else if (tipoEnemigo == "Volador")
            {
                return inmune;
            }
            else
            {
                return neutral;
            }
        }

        private double TipoVolador(string tipoEnemigo)
        {
            if (tipoEnemigo == "Bicho" || tipoEnemigo == "Lucha" || tipoEnemigo == "Planta")
            {
                return eficiente;
            }
            else if (tipoEnemigo == "Acero" || tipoEnemigo == "Electrico" || tipoEnemigo == "Roca")
            {
                return pocoEficiente;
            }
            else
            {
                return neutral;
            }
        }

        private double TipoPsiquico(string tipoEnemigo)
        {
            if (tipoEnemigo == "Lucha" || tipoEnemigo == "Veneno")
            {
                return eficiente;
            }
            else if (tipoEnemigo == "Acero" || tipoEnemigo == "Psiquico")
            {
                return pocoEficiente;
            }
            else
            {
                return neutral;
            }
        }

        private double TipoBicho(string tipoEnemigo)
        {
            if (tipoEnemigo == "Planta" || tipoEnemigo == "Psiquico")
            {
                return eficiente;
            }
            else if (tipoEnemigo == "Acero" || tipoEnemigo == "Fantasma" || tipoEnemigo == "Fuego" || tipoEnemigo == "Hada" || tipoEnemigo == "Lucha" || tipoEnemigo == "Veneno" || tipoEnemigo == "Volador")
            {
                return pocoEficiente;
            }
            else
            {
                return neutral;
            }
        }

        private double TipoRoca(string tipoEnemigo)
        {
            if (tipoEnemigo == "Bicho" || tipoEnemigo == "Fuego" || tipoEnemigo == "Hielo" || tipoEnemigo == "Volador")
            {
                return eficiente;
            }
            else if (tipoEnemigo == "Acero" || tipoEnemigo == "Lucha" || tipoEnemigo == "Tierra")
            {
                return pocoEficiente;
            }
            else
            {
                return neutral;
            }
        }

        private double TipoFantasma(string tipoEnemigo)
        {
            if (tipoEnemigo == "Fantasma" || tipoEnemigo == "Psiquico")
            {
                return eficiente;
            }
            else
            {
                return neutral;
            }
        }

        private double TipoDragon(string tipoEnemigo)
        {
            if (tipoEnemigo == "Dragon")
            {
                return eficiente;
            }
            else if (tipoEnemigo == "Acero")
            {
                return pocoEficiente;
            }
            else if (tipoEnemigo == "Hada")
            {
                return inmune;
            }
            else
            {
                return neutral;
            }
        }

        private double TipoAcero(string tipoEnemigo)
        {
            if (tipoEnemigo == "Hada" || tipoEnemigo == "Hielo" || tipoEnemigo == "Roca")
            {
                return eficiente;
            }
            else if (tipoEnemigo == "Acero" || tipoEnemigo == "Agua" || tipoEnemigo == "Electrico" || tipoEnemigo == "Fuego")
            {
                return pocoEficiente;
            }
            else
            {
                return neutral;
            }
        }

        private double TipoHada(string tipoEnemigo)
        {
            if (tipoEnemigo == "Dragon" || tipoEnemigo == "Lucha")
            {
                return eficiente;
            }
            else if (tipoEnemigo == "Acero" || tipoEnemigo == "Fuego" || tipoEnemigo == "Veneno")
            {
                return pocoEficiente;
            }
            else
            {
                return neutral;
            }
        }

    }
}