using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace TutorialAdonet._40.Helper
{
    public class Validacion<T> : IValidacion<T>, IDisposable where T : class
    {
        public string validar(T entidad)
        {
            ValidationContext context = new ValidationContext(entidad, null, null);
            IList<ValidationResult> error = new List<ValidationResult>();

            if (!Validator.TryValidateObject(entidad, context, error, true))
            {
                foreach (ValidationResult result in error)
                {
                    return result.ErrorMessage.ToString();
                }
            }
            else
            {
                return "Correcto";
            }

            return "Error en metodo validar";
        }

        public void Dispose()
        {
            Dispose();
        }
    }
}
