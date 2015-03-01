using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaPrograma
    {
        public static void AgregarProg(Programa pPrograma)
        {
            //Comandos a ejecutar
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("AgregarPrograma", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            //Parametros
            oComando.Parameters.AddWithValue("@NomProg", pPrograma.NomProg);
            oComando.Parameters.AddWithValue("@ProdProg", pPrograma.ProdProg);
            oComando.Parameters.AddWithValue("@TipoProg", pPrograma.TipoProg);
            oComando.Parameters.AddWithValue("@PreXSegProg", pPrograma.PreXSegProg);
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);
            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                //Determino devolucion del SP
                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("El Programa ya existe");
                else if (oAfectados == -2)
                    throw new Exception("Tipo de Programa incorrecto");
                else if (oAfectados == -3)
                    throw new Exception("Error al agregar Programa");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static void EliminarProg(Programa pPrograma)
        {
            //Comandos a ejecutar
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("EliminarPrograma", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            //Parametros
            oComando.Parameters.AddWithValue("@NomProg", pPrograma.NomProg);
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);
            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                //Determino devolucion del SP
                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("El programa tiene campanias asociadas");
                else if (oAfectados == -2)
                    throw new Exception("Error al eliminar Programa");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static Programa BuscarProg(string pNomProg)
        {
            //Comandos a ejecutar
            string oNomProg, oProdProg, oTipoProg;
            int oPreXSegProg;
            Programa p = null;
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("Exec BuscarPrograma '" + pNomProg + "'", oConexion);
            SqlDataReader oReader;
            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.HasRows)
                {
                    oReader.Read();
                    oNomProg = (string)oReader["NomProg"];
                    oProdProg = (string)oReader["ProdProg"];
                    oTipoProg = (string)oReader["TipoProg"];
                    oPreXSegProg = Convert.ToInt32(oReader["PreXSegProg"]);
                    p = new Programa(oNomProg, oProdProg, oTipoProg, oPreXSegProg);
                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error, Nombre incorrecto: " + ex);
            }
            finally
            {
                oConexion.Close();
            }
            return p;
        }

        public static void ModificarProg(Programa pPrograma)
        {
            //Comandos a ejecutar
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("ModificarPrograma", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@NomProg", pPrograma.NomProg);
            oComando.Parameters.AddWithValue("@ProdProg", pPrograma.ProdProg);
            oComando.Parameters.AddWithValue("@TipoProg", pPrograma.TipoProg);
            oComando.Parameters.AddWithValue("@PreXSegProg", pPrograma.PreXSegProg);
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);
            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                //Determino devolucion del SP
                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("El Programa no existe");
                else if (oAfectados == -2)
                    throw new Exception("Error al modificar el Programa");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static List<Programa> ListarProgramas()
        {
            string oNomProg, oProdProg, oTipoProg;
            int oPreXSegProg;
            Programa p;
            List<Programa> oListaProgramas = new List<Programa>();
            //Comandos a ejecutar
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("Exec ListarProgramas", oConexion);
            SqlDataReader oReader;
            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        oNomProg = (string)oReader["NomProg"];
                        oProdProg = (string)oReader["ProdProg"];
                        oTipoProg = (string)oReader["TipoProg"];
                        oPreXSegProg = (int)oReader["PreXSegProg"];
                        p = new Programa(oNomProg, oProdProg, oTipoProg, oPreXSegProg);
                        oListaProgramas.Add(p);
                    }
                    oReader.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
            return oListaProgramas;
        }
    }
}
