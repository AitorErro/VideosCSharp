using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institucion.Models
{
    public abstract class Persona: IEnteInstituto
    {
        public static int ContadorPersonas = 0;

        //definicion de propiedades
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public short Edad { get; set; }
        public string Telefono { get; set; }
        protected int Inasistencias { get; set; }
        public virtual string NombreCompleto
        {
            get
            {
                //3 formas de hacerlo
                //return Nombre + " " + Apellido;
                //return string.Format("{0} {1}", Nombre, Apellido);
                return $"{Nombre} {Apellido}";
            }
        }

        public string CodigoInterno { get; set; }

        public Persona()
        {
            //3 formas de hacerlo
            //ContadorPersonas = ContadorPersonas + 1;
            //ContadorPersonas += 1;
            ContadorPersonas++;
        }

        public abstract string ConstruirResumen();

        public string ConstruirLlaveSecreta(string nombreEnte)
        {
            var rnd = new Random();
            return rnd.Next(1, 9878956).ToString();
        }
    }
}
