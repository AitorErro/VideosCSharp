using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institucion.Models
{
    public class CursoClass
    {
        const string NOM_DEF_CURSO = "NO ASIGNADO";
        private string curso;

        public string Curso
        {
            get { return curso; }
            set { curso = value; }
        }

        public readonly short max_capacidad;

        public CursoClass(short max_cap)
        {
            max_capacidad = max_cap;
            curso = NOM_DEF_CURSO;
        }

    }
}
