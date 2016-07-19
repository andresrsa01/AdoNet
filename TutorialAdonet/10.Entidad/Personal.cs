using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TutorialAdonet._10.Entidad
{
    public class Personal
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string ApePaterno { get; set; }
        public string ApeMaterno { get; set; }
        public string Pais { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Salario { get; set; }
        public int IDCategoria { get; set; }


        public string NombreCompleto { get { return string.Format("{0} {1} {2}", Nombre, ApePaterno, ApeMaterno); } }
        public string SalarioFormato { get { return string.Format("{0:C}", Salario.ToString()); } }
    }
}
