using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using data = TutorialAdonet._30.Data;
using ent = TutorialAdonet._10.Entidad;

namespace TutorialAdonet._20.Dominio
{
    public class Personal
    {
        data.Modelo_AdoNet_Personal obj = new data.Modelo_AdoNet_Personal();

        public void RegistrarPersonal(ent.Personal entidad)
        {
            switch (entidad.Pais)
            {
                case "Per": entidad.Pais = "Perú";
                    break;
                case "Arg": entidad.Pais = "Argentina";
                    break;
                case "Col": entidad.Pais = "Colombia";
                    break;
                default: Console.WriteLine("Seleccionar país");
                    break;
            }

            obj.RegistrarPersonal(entidad);
        }

        public void ModificarPersonal(ent.Personal entidad)
        {
            if (entidad.Pais == "Per")
            {
                entidad.Pais = "Perú";
            }
            else if (entidad.Pais == "Arg")
            {
                entidad.Pais = "Argentina";
            }
            else if (entidad.Pais == "Col")
            {
                entidad.Pais = "Colombia";
            }
            else
            {
                Console.WriteLine("Seleccionar país");
            }

            obj.ModificarPersonal(entidad);
        }

        public void BorrarPersonal(int Id)
        {
            obj.BorrarPersonal(Id);
        }

        public List<ent.Personal> ListarPersonal()
        {
            return obj.ListarPersonal();
        }
    }
}
