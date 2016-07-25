using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ent = TutorialAdonet._10.Entidad;

namespace TutorialAdonet._40.Helper
{
    public interface IListarBaseDatos
    {
        List<ent.Personal> traetodo();
    }
}
