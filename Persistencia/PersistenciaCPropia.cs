using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaCPropia
    {
        public static void AgregarCPropia(CPropia pCPropia)
        {
            //Comandos a ejecutar
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("AgregarCampaniaPropia", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            //Parametros
            oComando.Parameters.AddWithValue("@NomCam", pCPropia.Titulo);
            oComando.Parameters.AddWithValue("@DurSpotCam", pCPropia.Duracion);
            oComando.Parameters.AddWithValue("@MenDiaCam", pCPropia.Menciones);
            oComando.Parameters.AddWithValue("@FIniCam", pCPropia.FechaI);
            oComando.Parameters.AddWithValue("@FFinCam", pCPropia.FechaF);
            oComando.Parameters.AddWithValue("@RutAn", pCPropia.unAnunciante.Rut);
            oComando.Parameters.AddWithValue("@CostoCam", pCPropia.Costo);
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
                    throw new Exception("Error al agregar Campania Propia");
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

        public static CPropia BuscarCampPropia(int pIdCam)
        {
            //comandos a ejecutar
            int oIdCam, oDuracion, oMenciones;
            double oCosto;
            string oTitulo;
            long oRutAnun;
            Anunciante oAnunciante = null;
            DateTime oFechaI, oFechaF;
            CPropia p = null;
            
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("Exec BuscarCampaniaPropia " + pIdCam, oConexion);
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
                    oCosto = Convert.ToDouble(oReader["CostoCam"]);
                    oAnunciante = PersistenciaAnunciante.BuscarAnun(oRutAnun);
                    p = new CPropia(oIdCam, oTitulo, oFechaI, oFechaF, oDuracion, oMenciones, oAnunciante, oCosto);
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
            return p;
        }

        public static void Modificar(CPropia pCPropia, int IdCamp)
        {
            //Comandos a ejecutar
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("ModificarCampaniaPropia", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@IdCam", IdCamp);
            oComando.Parameters.AddWithValue("@NomCam", pCPropia.Titulo);
            oComando.Parameters.AddWithValue("@DurSpotCam", pCPropia.Duracion);
            oComando.Parameters.AddWithValue("@MenDiaCam", pCPropia.Menciones);
            oComando.Parameters.AddWithValue("@FIniCam", pCPropia.FechaI);
            oComando.Parameters.AddWithValue("@FFinCam", pCPropia.FechaF);
            oComando.Parameters.AddWithValue("@RutAn", pCPropia.unAnunciante.Rut);
            oComando.Parameters.AddWithValue("@CostoCam", pCPropia.Costo);
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
                    throw new Exception("No existe la Campania");
                else if (oAfectados == -2)
                    throw new Exception("No existe la Campania Propia");
                else if (oAfectados == -3)
                    throw new Exception("No existe el Anunciante");
                else if (oAfectados == -4)
                    throw new Exception("Error al Modificar Campania");
                else if (oAfectados == -5)
                    throw new Exception("Error al Modificar Campania Propia");
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

        public static List<Campania> ListarCampaniasPropias()
        {
            string oNomCam;
            int oIdCam, oDurSpotCam, oMenDiaCam;
            long oRutAn;
            double oCosto;
            Anunciante oAnunciante = null;
            DateTime oFIniCam, oFFinCam;

            Campania c;
            List<Campania> oListaCampanias = new List<Campania>();
            //Comandos a ejecutar
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("Exec ListarCampaniasPropias", oConexion);
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
                        oCosto = Convert.ToDouble(oReader["CostoCam"]);
                        oAnunciante = PersistenciaAnunciante.BuscarAnun(oRutAn);
                        c = new CPropia(oIdCam, oNomCam, oFIniCam, oFFinCam, oDurSpotCam, oMenDiaCam, oAnunciante, oCosto);
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
