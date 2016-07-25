using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace TutorialAdonet._10.Entidad
{
    public class Categoria
    {
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Categoria campo requerido")]
        public string categoria { get; set; }
    }
}
