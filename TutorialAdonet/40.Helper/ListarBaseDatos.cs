using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ent = TutorialAdonet._10.Entidad;

namespace TutorialAdonet._40.Helper
{
    public class ListarBaseDatos : IListarBaseDatos
    {
        public List<ent.Personal> traetodo()
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

        public void Dispose()
        {
            Dispose();
        }
    }
}