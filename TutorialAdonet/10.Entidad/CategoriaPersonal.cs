using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace TutorialAdonet._10.Entidad
{
    public class CategoriaPersonal
    {
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Nombre campo obligatorio")]
        [StringLength(10, MinimumLength = 0, ErrorMessage = "Nombre Muchas letras")]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Apellido obligatorio")]
        public string ApePaterno { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Apellido Materno campo obligatorio")]
        public string ApeMaterno { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "País campo obligatorio")]
        public string Pais { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Fecha campo obligatorio")]
        public DateTime Fecha { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Salario campo obligatorio")]
        [Range(0, 500, ErrorMessage = "Fuera del rango de salario gana mucho")]
        public decimal Salario { get; set; }

        public int IDCategoria { get; set; }


        public string NombreCompleto { get { return string.Format("{0} {1} {2}", Nombre, ApePaterno, ApeMaterno); } }
        public string SalarioFormato { get { return string.Format("{0:C}", Salario.ToString()); } }

        public int IDCate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Categoria campo requerido")]
        public string categoria { get; set; }
    }
}
