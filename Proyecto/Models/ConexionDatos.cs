using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Windows.Forms;

namespace Proyecto.Models
{
     class ConexionDatos
    {
        //Cadena de Conexion
        static string rutaPablo = "Server= PABLO-PC\\SQL2019; Database= bd_pokemon; User ID= PABLO-PC\\XPC; password= ROOT ; trustServerCertificate= true; Trusted_Connection=true";
        static string rutaJose = "Server=JOSEGARCIAB; Database=bd_pokemon; User ID=JOSEGARCIAB\\jluis; password=''; trustServerCertificate= true; Trusted_Connection=true";
        static string rutaAndres = "Server=PC-A; Database=bd_pokemon; User ID=sa; password=123; trustServerCertificate= true; Trusted_Connection=true";


        public SqlConnection conexion = new SqlConnection(rutaAndres);


        //Constructor
        public ConexionDatos()
        {
            this.conexion = conexion;
        }

        //Metodo para abrir la conexion
        public void abrir_bd()
        {
            try
            {
                conexion.Open();
                MessageBox.Show("La conexión a la BD " + conexion.Database + " ha sido exitosa");
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha fallado la conexión" + ex.Message);
            }
        }

        //Metodo para cerrar la conexion
        public void cerrar_bd()
        {
            conexion.Close();
        }

        

        public List<objetoPokemon> getPokeLista()
        {
            try
            {
                conexion.Open();

                SqlCommand command = new SqlCommand("getInfoPokemon", conexion);
                using (SqlDataReader reader  = command.ExecuteReader())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    List<objetoPokemon> pokeLista = new List<objetoPokemon>();

                    while (reader.Read())
                    {
                        string id = Convert.ToString(reader["ID"]);
                        string nom = Convert.ToString(reader["NOMBRE"]);
                        string desc = Convert.ToString(reader["DESCRIPCION"]);
                        string tipo1 = Convert.ToString(reader["TIPO1"]);
                        string tipo2 = Convert.ToString(reader["TIPO2"]);
                        string movimiento1 = Convert.ToString(reader["MOVIMIENTO1"]);
                        int poder1 = Convert.ToInt32(reader["MOV_1_PODER"]);
                        string movimiento2 = Convert.ToString(reader["MOVIMIENTO2"]);
                        int poder2 = Convert.ToInt32(reader["MOV_2_PODER"]);
                        string movimiento3 = Convert.ToString(reader["MOVIMIENTO3"]);
                        int poder3 = Convert.ToInt32(reader["MOV_3_PODER"]);
                        string movimiento4 = Convert.ToString(reader["MOVIMIENTO4"]);
                        int poder4 = Convert.ToInt32(reader["MOV_4_PODER"]);


                        objetoPokemon pokemon = new objetoPokemon(id, nom, desc, tipo1, tipo2, movimiento1, poder1, movimiento2, poder2, movimiento3, poder3, movimiento4, poder4);

                        pokeLista.Add(pokemon);
                        //int result = Convert.ToInt32(reader["ID"]);
                        //pokeIDs.Add(result);
                    }

                    conexion.Close();
                    return pokeLista;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha fallado la conexión getPokeLista \n" + ex.Message, 
                                "Pokemon Primera Generación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
        public objetoPokemon getPokemonBot(int pokemonRandom)
        {
            objetoPokemon pokemon = null;
            try
            {
                conexion.Open();

                SqlCommand command = new SqlCommand("getInfoPokemonBot", conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@pokemonID", pokemonRandom);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        //info general
                        string id = Convert.ToString(reader["ID"]);
                        string nom = Convert.ToString(reader["NOMBRE"]);
                        string desc = Convert.ToString(reader["DESCRIPCION"]);
                        string tipo1 = Convert.ToString(reader["TIPO1"]);
                        string tipo2 = Convert.ToString(reader["TIPO2"]);

                        //info atakes
                        string m1 = Convert.ToString(reader["MOVIMIENTO1"]);
                        string m2 = Convert.ToString(reader["MOVIMIENTO2"]);
                        string m3 = Convert.ToString(reader["MOVIMIENTO3"]);
                        string m4 = Convert.ToString(reader["MOVIMIENTO4"]);
                        int pm1 = Convert.ToInt32(reader["MOV_1_PODER"]);
                        int pm2 = Convert.ToInt32(reader["MOV_2_PODER"]);
                        int pm3 = Convert.ToInt32(reader["MOV_3_PODER"]);
                        int pm4 = Convert.ToInt32(reader["MOV_4_PODER"]);

                        pokemon = new objetoPokemon(id, nom, desc, tipo1, tipo2, m1, pm1, m2, pm2, m3, pm3, m4, pm4);
                    }
                    else
                    {
                        MessageBox.Show("No se encontro el pokemon",
                                        "Pokemon Primera Generación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                conexion.Close();
                //return null; // Si no se encuentra ningún Pokémon con ese nombre

            }
            catch (Exception ex)
            {
                conexion.Close();

                MessageBox.Show("Ha fallado la conexión getPokemonSeleccionado \n" + ex.Message,
                                "Pokemon Primera Generación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return pokemon;
        }

        public objetoPokemon getPokemonSeleccionado(string pokemonSeleccionado)
        {
            objetoPokemon pokemon = null;
            try
            {
                conexion.Open();

                SqlCommand command = new SqlCommand("getInfoPokemonSeleccionado", conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@pokemonNombre", pokemonSeleccionado);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        //info general
                        string id = Convert.ToString(reader["ID"]);
                        string nom = Convert.ToString(reader["NOMBRE"]);
                        string desc = Convert.ToString(reader["DESCRIPCION"]);
                        string tipo1 = Convert.ToString(reader["TIPO1"]);
                        string tipo2 = Convert.ToString(reader["TIPO2"]);

                        //info atakes
                        string m1 = Convert.ToString(reader["MOVIMIENTO1"]);
                        string m2 = Convert.ToString(reader["MOVIMIENTO2"]);
                        string m3 = Convert.ToString(reader["MOVIMIENTO3"]);
                        string m4 = Convert.ToString(reader["MOVIMIENTO4"]);
                        int pm1 = Convert.ToInt32(reader["MOV_1_PODER"]);
                        int pm2 = Convert.ToInt32(reader["MOV_2_PODER"]);
                        int pm3 = Convert.ToInt32(reader["MOV_3_PODER"]);
                        int pm4 = Convert.ToInt32(reader["MOV_4_PODER"]);

                        pokemon = new objetoPokemon(id, nom, desc, tipo1, tipo2, m1, pm1, m2, pm2, m3, pm3, m4, pm4);
                    }
                    else
                    {
                        MessageBox.Show("No se encontro el pokemon",
                                        "Pokemon Primera Generación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                conexion.Close();
                //return null; // Si no se encuentra ningún Pokémon con ese nombre

            }
            catch (Exception ex)
            {
                conexion.Close();

                MessageBox.Show("Ha fallado la conexión getInfoPokemonSeleccionado \n" + ex.Message,
                                "Pokemon Primera Generación", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return pokemon;
        }

        public List<objetoPokemon> InfoPokemon()
        {
            try
            {
                conexion.Open();

                SqlCommand command = new SqlCommand("getInfoPokemon", conexion);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    List<objetoPokemon> pokeLista = new List<objetoPokemon>();

                    
                    while (reader.Read())
                    {
                        string id = Convert.ToString(reader["ID"]);
                        string nom = Convert.ToString(reader["NOMBRE"]);
                        string desc = Convert.ToString(reader["DESCRIPCION"]);
                        string tipo1 = Convert.ToString(reader["TIPO1"]);
                        string tipo2 = Convert.ToString(reader["TIPO2"]);

                        objetoPokemon pokemon = new objetoPokemon(id, nom, desc, tipo1, tipo2);
                        MessageBox.Show(desc);
                    }
                    
                    conexion.Close();
                    return pokeLista;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha fallado la conexión InfoPokemon \n" + ex.Message,
                                "Pokemon Primera Generación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public void InsertarEnBitacoraPeleas(int ganadorId, int perdedorId, string combate)
        {
            try
            {
                    conexion.Open();

                    // Crear el comando SQL para el insert
                    string query = "INSERT INTO bitacora_peleas (FECHA, COMBATE, GANADOR, PERDEDOR) VALUES (GETDATE(), @combate, @ganadorId, @perdedorId)";

                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        // Agregar los parámetros
                        command.Parameters.AddWithValue("@combate", combate);
                        command.Parameters.AddWithValue("@ganadorId", ganadorId);
                        command.Parameters.AddWithValue("@perdedorId", perdedorId);

                        // Ejecutar el comando
                        command.ExecuteNonQuery();
                    }

                    conexion.Close();
                


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar en la tabla bitacora_peleas: " + ex.Message,
                                "Pokemon Primera Generación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        internal void InfoPokemon(object text)
        {
            throw new NotImplementedException();
        }
    }

    
}
