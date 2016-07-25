using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TutorialAdonet._40.Helper
{
    public interface IValidacion<T> where T : class
    {
        string validar(T entidad);

    }
}
