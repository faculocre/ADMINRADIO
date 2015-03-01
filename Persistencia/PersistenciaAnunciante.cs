using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaAnunciante
    {
        public static void AgregarAnun(Anunciante pAnunciante)
        {
            //Comandos a ejecutar
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("AgregarAnunciante", oConexion);
            SqlCommand oComandoTel = new SqlCommand("AgregarTelAnunciante", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComandoTel.CommandType = CommandType.StoredProcedure;
            //Parametros
            oComando.Parameters.AddWithValue("@RutAn", pAnunciante.Rut);
            oComando.Parameters.AddWithValue("@NomAn", pAnunciante.Nombre);
            oComando.Parameters.AddWithValue("@DirAn", pAnunciante.Direccion);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            SqlParameter oRetornoTel = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oRetornoTel.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                //Determino devolucion del SP
                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("El Anunciante ya existe");
                else if (oAfectados == -2)
                    throw new Exception("Error al agregar Anunciante");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            try
            {
                foreach (string t in pAnunciante.Telefono)
                {                   
                    oComandoTel.Parameters.Clear();
                    oComandoTel.Parameters.Add(oRetornoTel);
                    oComandoTel.Parameters.AddWithValue("@RutAn", pAnunciante.Rut);
                    oComandoTel.Parameters.AddWithValue("@TelAn", t);
                    oComandoTel.ExecuteNonQuery();
                    int oAfectados = (int)oComandoTel.Parameters["@Retorno"].Value;
                    if (oAfectados == -1)
                        throw new Exception("No Existe el Anunciante");
                    else if (oAfectados == -2)
                        throw new Exception("Telefono Duplicado");
                    else if (oAfectados == -3)
                        throw new Exception("Error al agregar el Telefono");
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
        }

        public static void EliminarAnun(Anunciante pAnunciante)
        {
            //Comandos a ejecutar
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("EliminarAnunciante", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            //Parametros
            oComando.Parameters.AddWithValue("@RutAn", pAnunciante.Rut);
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
                    throw new Exception("Error al intentar eliminar la Emision");
                else if (oAfectados == -3)
                    throw new Exception("Error al intentar eliminar la Campania Propia");
                else if (oAfectados == -4)
                    throw new Exception("Error al intentar eliminar la Campania Externa");
                else if (oAfectados == -5)
                    throw new Exception("Error al intentar eliminar la Campania");
                else if (oAfectados == -6)
                    throw new Exception("Error al intentar eliminar el Telefono del Anunciante");
                else if (oAfectados == -7)
                    throw new Exception("Error al intentar eliminar el Anunciante");
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

        public static Anunciante BuscarAnun(long aRutAn)
        {
            //comandos a ejecutar
            long oRutAn;
            string oNomAn, oDirAn, oTelAn;
            List<string> oListaTelAn = new List<string>();
            Anunciante a = null;
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("Exec BuscarAnunciante " + aRutAn, oConexion);
            SqlCommand oComandoTel = new SqlCommand("Exec ListarTelAnunciante " + aRutAn, oConexion);
            SqlDataReader oReader;
            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.HasRows)
                {
                    oReader.Read();
                    oRutAn = (long)oReader["RutAn"];
                    oNomAn = (string)oReader["NomAn"];
                    //Como la direccion en la BD puede ser null para evitar problemas leo dentro de un Try y
                    //si me da error , fuerzo en valor a: oDirAn = "No hay Datos".
                    try
                    {
                        oDirAn = (string)oReader["DirAn"];
                    }
                    catch
                    {
                        oDirAn = "No hay Datos";
                    }
                    a = new Anunciante(oRutAn, oNomAn, oDirAn, oListaTelAn);
                }
                oReader.Close();

                if (a != null)
                {
                    oReader = oComandoTel.ExecuteReader();
                    if (oReader.HasRows)
                    {
                        while (oReader.Read())
                        {
                            oTelAn = Convert.ToString(oReader["TelAn"]);
                            oListaTelAn.Add(oTelAn);
                        }
                    }
                    oReader.Close();

                    a.Telefono = oListaTelAn;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error, Rut incorrecto: " + ex);
            }
            finally
            {
                oConexion.Close();
            }
            return a;
        }

        public static void ModificarAnun(Anunciante pAnunciante)
        {
            //comandos a ejecutar
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("ModificarAnunciante", oConexion);
            SqlCommand oComandoATel = new SqlCommand("AgregarTelAnunciante", oConexion);
            SqlCommand oComandoETel = new SqlCommand("EliminarTelAnunciante", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComandoATel.CommandType = CommandType.StoredProcedure;
            oComandoETel.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@RutAn", pAnunciante.Rut);
            oComando.Parameters.AddWithValue("@NomAn", pAnunciante.Nombre);
            oComando.Parameters.AddWithValue("@DirAn", pAnunciante.Direccion);
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            SqlParameter oRetornoATel = new SqlParameter("@Retorno", SqlDbType.Int);
            SqlParameter oRetornoETel = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oRetornoATel.Direction = ParameterDirection.ReturnValue;
            oRetornoETel.Direction = ParameterDirection.ReturnValue;
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
                    throw new Exception("Error al modificar el Anunciante");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            try
            {
                //Elimino la lista de telefonos del anunciante de la BD
                oComandoETel.Parameters.Clear();
                oComandoETel.Parameters.Add(oRetornoETel);
                oComandoETel.Parameters.AddWithValue("@RutAn", pAnunciante.Rut);
                oComandoETel.ExecuteNonQuery();
                int oAfectados = (int)oComandoETel.Parameters["@Retorno"].Value;
                    if (oAfectados == -1)
                        throw new Exception("No Existe el Anunciante");
                    else if (oAfectados == -2)
                        throw new Exception("Error al Eliminar Telefonos");
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            try
            {
                //Recorro el Listbox y agrego todos los telefonos al anunciante
                foreach (string t in pAnunciante.Telefono)
                {
                    oComandoATel.Parameters.Clear();
                    oComandoATel.Parameters.Add(oRetornoATel);
                    oComandoATel.Parameters.AddWithValue("@RutAn", pAnunciante.Rut);
                    oComandoATel.Parameters.AddWithValue("@TelAn", t);
                    oComandoATel.ExecuteNonQuery();
                    int oAfectados = (int)oComandoATel.Parameters["@Retorno"].Value;
                    if (oAfectados == -1)
                        throw new Exception("No Existe el Anunciante");
                    else if (oAfectados == -2)
                        throw new Exception("Telefono Duplicado");
                    else if (oAfectados == -3)
                        throw new Exception("Error al agregar el Telefono");
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
        }

        public static List<Anunciante> ListarAnunciantes()
        {
            long oRutAn;
            string oNomAn, oDirAn;
            List<string> oListaTelAn = new List<string>();//Creo una lista vacia de telefonos solo para poder crear luego el objeto anunciante
                                                          //pero en realidad no necesito mostrar este dato solo el nombre del Anunciante
            Anunciante a;
            List<Anunciante> oListaAnunciantes = new List<Anunciante>();

            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("Exec ListarAnunciantes", oConexion);
            SqlDataReader oReader;
            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        oRutAn = (long)oReader["RutAn"];
                        oNomAn = (string)oReader["NomAn"];
                        //Como la direccion en la BD puede ser null para evitar proplemas leo dentro de un Try y
                        //si me da error , fuerzo en valor a: oDirAn = "No hay Datos".
                        try
                        {
                            oDirAn = (string)oReader["DirAn"];
                        }
                        catch
                        {
                            oDirAn = "No hay Datos";
                        }
                        a = new Anunciante(oRutAn, oNomAn, oDirAn, oListaTelAn);
                        oListaAnunciantes.Add(a);
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
            return oListaAnunciantes;
        }
    }
}
