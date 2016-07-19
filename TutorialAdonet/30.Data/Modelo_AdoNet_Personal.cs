using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ent = TutorialAdonet._10.Entidad;

namespace TutorialAdonet._30.Data
{
    public class Modelo_AdoNet_Personal
    {
        string conexion = ConfigurationManager.ConnectionStrings["AdoNet"].ConnectionString;

        public void RegistrarPersonal(ent.Personal entidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "RegistrarPeronal";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("Nombre", entidad.Nombre);
                    cmd.Parameters.AddWithValue("ApePaterno", entidad.ApePaterno);
                    cmd.Parameters.AddWithValue("ApeMaterno", entidad.ApeMaterno);
                    cmd.Parameters.AddWithValue("Pais", entidad.Pais);
                    cmd.Parameters.AddWithValue("Fecha", entidad.Fecha);
                    cmd.Parameters.AddWithValue("Salario", entidad.Salario);
                    cmd.Parameters.AddWithValue("IDCategoria", entidad.IDCategoria);

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ModificarPersonal(ent.Personal entidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "ModificarPeronal";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("ID", entidad.ID);
                    cmd.Parameters.AddWithValue("Nombre", entidad.Nombre);
                    cmd.Parameters.AddWithValue("ApePaterno", entidad.ApePaterno);
                    cmd.Parameters.AddWithValue("ApeMaterno", entidad.ApeMaterno);
                    cmd.Parameters.AddWithValue("Pais", entidad.Pais);
                    cmd.Parameters.AddWithValue("Fecha", entidad.Fecha);
                    cmd.Parameters.AddWithValue("Salario", entidad.Salario);
                    cmd.Parameters.AddWithValue("IDCategoria", entidad.IDCategoria);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void BorrarPersonal(int id)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "BorrarPersonal";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("ID", id);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ent.Personal> ListarPersonal()
        {
            List<ent.Personal> listaentidad = new List<ent.Personal>();
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = ConfigurationManager.ConnectionStrings["AdoNet"].ConnectionString;
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("ListarTodoPersonal", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {

                        ent.Personal entidad = new ent.Personal()
                        {
                            ID = Convert.ToInt32(dr["ID"].ToString()),
                            Nombre = dr["Nombre"].ToString(),
                            ApePaterno = dr["ApePaterno"].ToString(),
                            ApeMaterno = dr["ApeMaterno"].ToString(),
                            Pais = dr["Pais"].ToString(),
                            Fecha = Convert.ToDateTime(dr["Fecha"]),
                            Salario = Convert.ToDecimal(dr["Salario"].ToString()),
                            IDCategoria = Convert.ToInt32(dr["IDCategoria"].ToString())

                        };

                        listaentidad.Add(entidad);
                    }

                    dr.Close();
                }

                return listaentidad;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
