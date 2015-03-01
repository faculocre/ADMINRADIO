using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaCampania
    {
        public static void EliminarCamp(Campania pCampania)
        {
            //Comandos a ejecutar
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("EliminarCampania", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            //Parametros
            oComando.Parameters.AddWithValue("@IdCam", pCampania.Id);
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
                    throw new Exception("La Campania no existe");
                else if (oAfectados == -2)
                    throw new Exception("Error al eliminar la Emision");
                else if (oAfectados == -3)
                    throw new Exception("Error al Eliminar la Campania Propia");
                else if (oAfectados == -4)
                    throw new Exception("Error al Eliminar la Campania Externa");
                else if (oAfectados == -5)
                    throw new Exception("Error al Eliminar la Campania");
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
    }
}
