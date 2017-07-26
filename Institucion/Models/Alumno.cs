using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institucion.Models
{



    class Alumno: Persona
    {
        public EstadosAlumno Estado { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }

        public string ListaInasistencias()
        {
            return Inasistencias.ToString();
        }

        public Alumno(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
        }

        public override string ConstruirResumen()
        {
            return $"{NombreCompleto},{NickName},{Telefono}";
        }

        public override string NombreCompleto
        {
            get
            {
                return base.NombreCompleto.ToUpper();
                //return "INFORMACION BLOQUEADA";
            }
        }
    }
}
