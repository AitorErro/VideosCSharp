using Institucion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//COMMENT EN desarrolloCasa

namespace Institucion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GESTOR DE INSTITUCION");

            Persona[] lista = new Persona[3];
            lista[0] = new Alumno("Eduardo", "Garcia")
            {
                Id = 1,
                Edad = 36,
                Telefono = "3111111",
                Email = "eduardo@cysnet.com"
            };

            lista [1] = new Profesor()
            {
                Id = 2,
                Nombre = "Pello",
                Apellido = "Tarrase",
                Edad = 36,
                Telefono = "6874202",
                Catedra = "Programacion"
            };
            lista[2] = new Profesor()
            {
                Id = 3,
                Nombre = "Fran",
                Apellido = "Malo",
                Edad = 45,
                Telefono = "9874111",
                Catedra = "Naturaleza"
            };

            Console.WriteLine(Persona.ContadorPersonas);

            Console.WriteLine("Resumenes:");

            foreach (Persona p in lista)
            {
                Console.WriteLine($"Tipo: {p.GetType()}");
                Console.WriteLine(p.ConstruirResumen());

                IEnteInstituto ente = p;

                ente.ConstruirLlaveSecreta("Hola");
            }


            //STRUCTS
            Console.WriteLine("S T R U C T S");
            CursoStruct c = new CursoStruct(70);
            c.Curso = "101-B";

            var newC = new CursoStruct(55);
            newC.Curso = "564-A";

            var cursoFreak = c;
            cursoFreak.Curso = "666-G";

            Console.WriteLine("Curso 'c' = "+c.Curso);
            Console.WriteLine("Curso 'cursoFreak' = " + cursoFreak.Curso);

            //CLASSES
            Console.WriteLine("C L A S S E S");
            CursoClass c_class = new CursoClass(70);
            c_class.Curso = "101-B";

            var newC_class = new CursoStruct(55);
            newC_class.Curso = "564-A";

            var cursoFreak_class = c_class;
            cursoFreak.Curso = "666-G";

            Console.WriteLine("Curso 'c' = " + c_class.Curso);
            Console.WriteLine("Curso 'cursoFreak' = " + cursoFreak_class.Curso);

            Console.WriteLine("E N U M E R A C I O N E S");

            var alumnoEst = new Alumno("Pello", "Strauss")
            {
                Id = 2,
                Edad = 36,
                Telefono = "6874202",
                Estado = EstadosAlumno.Activo
            };

            Persona personaX = alumnoEst;

            Console.WriteLine("Estado del alumno: " + alumnoEst.Estado);

            IEnteInstituto iei = alumnoEst;

            Console.WriteLine($"Tipo {typeof(EstadosAlumno)} ");
            Console.WriteLine($"Tipo {typeof(Alumno)} ");
            Console.WriteLine($"Tipo alumnoEst: {alumnoEst.GetType()} ");
            Console.WriteLine($"Tipo personaX: {personaX.GetType()} ");
            Console.WriteLine($"Tipo iei: {iei.GetType()} ");
            Console.WriteLine($"Tipo {nameof(Alumno)} ");
            Console.WriteLine($"Tipo {sizeof(int)} ");

            Console.ReadLine();
        }
    }
}
