using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaCExterna
    {
        public static void AgregarCExterna(CExterna pCExterna)
        {
            //Comandos a ejecutar
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("AgregarCampaniaExterna", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            //Parametros
            oComando.Parameters.AddWithValue("@NomCam", pCExterna.Titulo);
            oComando.Parameters.AddWithValue("@DurSpotCam", pCExterna.Duracion);
            oComando.Parameters.AddWithValue("@MenDiaCam", pCExterna.Menciones);
            oComando.Parameters.AddWithValue("@FIniCam", pCExterna.FechaI);
            oComando.Parameters.AddWithValue("@FFinCam", pCExterna.FechaF);
            oComando.Parameters.AddWithValue("@RutAn", pCExterna.unAnunciante.Rut);
            oComando.Parameters.AddWithValue("@ProdCam", pCExterna.Productora);
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
                    throw new Exception("El Anunciante no existe");
                else if (oAfectados == -2)
                    throw new Exception("Error La Fecha de Inicio debe ser menor o igual a la Fecha Final");
                else if (oAfectados == -3)
                    throw new Exception("Error al agregar Campania");
                else if (oAfectados == -4)
                    throw new Exception("Error al agregar Campania Externa");
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

        public static CExterna BuscarCampExterna(int eIdCam)
        {
            //comandos a ejecutar
            int oIdCam, oDuracion, oMenciones;
            string oTitulo, oProductora;
            long oRutAnun;
            Anunciante oAnunciante = null;
            DateTime oFechaI, oFechaF;
            CExterna e = null;

            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("Exec BuscarCampaniaExterna " + eIdCam, oConexion);
            SqlDataReader oReader;
            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.HasRows)
                {
                    oReader.Read();
                    oIdCam = (int)oReader["IdCam"];
                    oTitulo = (string)oReader["NomCam"];
                    oDuracion = (int)oReader["DurSpotCam"];
                    oMenciones = (int)oReader["MenDiaCam"];
                    oFechaI = (DateTime)oReader["FIniCam"];
                    oFechaF = (DateTime)oReader["FFinCam"];
                    oRutAnun = (long)oReader["RutAn"];
                    oProductora = (string)oReader["ProdCam"];
                    oAnunciante = PersistenciaAnunciante.BuscarAnun(oRutAnun);
                    e = new CExterna(oIdCam, oTitulo, oFechaI, oFechaF, oDuracion, oMenciones, oAnunciante, oProductora);
                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex);
            }
            finally
            {
                oConexion.Close();
            }
            return e;
        }

        public static void Modificar(CExterna pCExterna, int IdCamp)
        {
            //Comandos a ejecutar
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("ModificarCampaniaExterna", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@IdCam", IdCamp);

            oComando.Parameters.AddWithValue("@NomCam", pCExterna.Titulo);
            oComando.Parameters.AddWithValue("@DurSpotCam", pCExterna.Duracion);
            oComando.Parameters.AddWithValue("@MenDiaCam", pCExterna.Menciones);
            oComando.Parameters.AddWithValue("@FIniCam", pCExterna.FechaI);
            oComando.Parameters.AddWithValue("@FFinCam", pCExterna.FechaF);
            oComando.Parameters.AddWithValue("@RutAn", pCExterna.unAnunciante.Rut);
            oComando.Parameters.AddWithValue("@ProdCam", pCExterna.Productora);
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
                    throw new Exception("No existe el Anunciante");
                else if (oAfectados == -2)
                    throw new Exception("No existe la Campania");
                else if (oAfectados == -3)
                    throw new Exception("No es una Campania Externa");
                else if (oAfectados == -4)
                    throw new Exception("Error al Modificar Campania");
                else if (oAfectados == -5)
                    throw new Exception("Error al Modificar Campania Externa");
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

        public static List<Campania> ListarCampaniasExternas()
        {
            string oNomCam, oProductora;
            int oIdCam, oDurSpotCam, oMenDiaCam;
            long oRutAn;
            Anunciante oAnunciante = null;
            DateTime oFIniCam, oFFinCam;

            Campania c;
            List<Campania> oListaCampanias = new List<Campania>();
            //Comandos a ejecutar
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("Exec ListarCampaniasExternas", oConexion);
            SqlDataReader oReader;
            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        oIdCam = (int)oReader["IdCam"];
                        oNomCam = (string)oReader["NomCam"];
                        oDurSpotCam = (int)oReader["DurSpotCam"];
                        oMenDiaCam = (int)oReader["MenDiaCam"];
                        oFIniCam = (DateTime)oReader["FIniCam"];
                        oFFinCam = (DateTime)oReader["FFinCam"];
                        oRutAn = (long)oReader["RutAn"];
                        oProductora = (string)oReader["ProdCam"];
                        oAnunciante = PersistenciaAnunciante.BuscarAnun(oRutAn);
                        c = new CExterna(oIdCam, oNomCam, oFIniCam, oFFinCam, oDurSpotCam, oMenDiaCam, oAnunciante, oProductora);
                        oListaCampanias.Add(c);
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
            return oListaCampanias;
        }
    }
}
