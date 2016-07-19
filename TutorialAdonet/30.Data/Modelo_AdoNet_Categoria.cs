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
    public class Modelo_AdoNet_Categoria
    {
        string conexion = ConfigurationManager.ConnectionStrings["AdoNet"].ConnectionString;

        public void RegistrarCategoria(ent.Categoria entidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    string query = "insert into Categoria (NombreCategoria) values (@nombreCategoria)";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@nombreCategoria", entidad.categoria);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ModificarCategoria(ent.Categoria entidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    string query = "update Categoria set NombreCategoria = @nombreCategoria where ID = @ID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID", entidad.ID);
                    cmd.Parameters.AddWithValue("@nombreCategoria", entidad.categoria);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void EliminarCategoria(int Id)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    string query = "delete from Categoria where ID = @ID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID", Id);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ent.Categoria> ListarCategoria()
        {
            try
            {
                List<ent.Categoria> listacategoria = new List<ent.Categoria>();
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    string query = "Select * from Categoria";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ent.Categoria obj = new ent.Categoria()
                        {
                            ID = Convert.ToInt32(dr["ID"].ToString()),
                            categoria = dr["NombreCategoria"].ToString()
                        };

                        listacategoria.Add(obj);
                    }

                    return listacategoria;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
