using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ent = TutorialAdonet._10.Entidad;
using data = TutorialAdonet._30.Data;

namespace TutorialAdonet._20.Dominio
{
    public class Categoria
    {
        data.Modelo_AdoNet_Categoria obj = new data.Modelo_AdoNet_Categoria();

        public void RegistrarCategoria(ent.Categoria entidad)
        {
            obj.RegistrarCategoria(entidad);
        }

        public void ModificarCategoria(ent.Categoria entidad)
        {
            obj.ModificarCategoria(entidad);
        }

        public void EliminarCategoria(int Id)
        {
            obj.EliminarCategoria(Id);
        }

        public List<ent.Categoria> ListarCategoria()
        {
            return obj.ListarCategoria();
        }
    }
}
