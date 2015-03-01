using System;
using System.Collections.Generic;
using System.Text;
using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    public class PersistenciaEmision
    {
        public static void AgregarEmision(Emision pEmision)
        {
            //Comandos a ejecutar
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("AgregarEmision", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            //Parametros
            oComando.Parameters.AddWithValue("@IdCam", pEmision.UnaCampania.Id);
            oComando.Parameters.AddWithValue("@NomProg", pEmision.UnPrograma.NomProg);
            oComando.Parameters.AddWithValue("@FEmision", pEmision.FEmision);
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
                    throw new Exception("La campania no existe");
                else if (oAfectados == -2)
                    throw new Exception("El programa no existe");
                else if (oAfectados == -3)
                    throw new Exception("La fecha de la mencion no esta dentro del rango de la campania");
                else if (oAfectados == -4)
                    throw new Exception("Se exede la Cantidad de Emisiones diarias Permitida");
                else if (oAfectados == -5)
                    throw new Exception("Error al agregar la Emisión");
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

        public static List<Emision> ListarEmisiones(Campania pCampania)
        {
            string oNomProg;
            int oIdCam;
            DateTime oFEmision;

            Emision oEmision = null;

            Campania Camp;
            Programa Prog;
            List<Emision> oListaEmisiones = new List<Emision>();
            //Comandos a ejecutar
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("Exec ListarEmisiones " + pCampania.Id, oConexion); 
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
                        oNomProg = (string)oReader["NomProg"];
                        oFEmision = (DateTime)oReader["FEmision"];
                        Camp = PersistenciaCPropia.BuscarCampPropia(oIdCam);
                        if (Camp == null)
                        {
                            Camp = PersistenciaCExterna.BuscarCampExterna(oIdCam);
                        }
                        Prog = PersistenciaPrograma.BuscarProg(oNomProg);
                        oEmision = new Emision(oFEmision, Camp, Prog);
                        oListaEmisiones.Add(oEmision);
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
            return oListaEmisiones;
        }
    }
}
