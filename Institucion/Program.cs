using Institucion.DataAccess;
using Institucion.Misc;
using Institucion.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
            var listaProfesores = CrearLista();
            var db = new InstitucionDB();

            //db.Profesores.AddRange(listaProfesores);
            //db.SaveChanges();

            //var subconjunto = from prof in db.Profesores
            //                  where prof.Nombre.StartsWith("J")
            //                  select prof;

            //foreach (var item in subconjunto)
            //{
            //    item.CodigoInterno = "STARTS_WITH_J";
            //    Console.WriteLine(item.Nombre);
            //}

            //db.SaveChanges();

            var profesorBorrable = (from p in db.Profesores
                                   where p.Nombre == "Jeronimo"
                                   select p;



            Console.ReadLine();
        }

        private static List<Profesor> CrearLista()
        {
            Random rnd = new Random();
            var lista = new List<Profesor>();

            lista.Add(new Profesor() { Nombre = "Juan Carlos", Id = rnd.Next() });
            lista.Add(new Profesor()
            {
                Nombre = "Jeronimo",
                Catedra = "Marketing",
                Id = rnd.Next()
            });
            lista.Add(new Profesor() { Nombre = "Yohanna", Id = rnd.Next() });
            lista.Add(new Profesor() { Nombre = "Martha", Catedra = "Marketing", Id = rnd.Next() });
            lista.Add(new Profesor() { Nombre = "Jose Mauricio", Id = rnd.Next() });
            lista.Add(new Profesor() { Nombre = "Angela", Id = rnd.Next() });
            lista.Add(new Profesor() { Nombre = "Walter", Id = rnd.Next() });
            lista.Add(new Profesor() { Nombre = "Marco", Id = rnd.Next() });
            lista.Add(new Profesor() { Nombre = "Satya", Id = rnd.Next() });
            lista.Add(new Profesor() { Nombre = "Terry", Catedra = "Marketing", Id = rnd.Next() });
            lista.Add(new Profesor() { Nombre = "Alexander", Id = rnd.Next() });
            lista.Add(new Profesor() { Nombre = "Sandra", Id = rnd.Next() });

            return lista;
        }

        private static void ArchivosYDeMas()
        {
            var listProfes = new List<Profesor>();

            string[] lineas = File.ReadAllLines("./Files/Profesores.txt");

            var localId = 0;

            foreach (var linea in lineas)
            {
                listProfes.Add(new Profesor()
                {
                    Nombre = linea,
                    Id = localId++,
                });
            }

            foreach (var profe in listProfes)
            {
                Console.WriteLine(profe.Nombre);
            }

            var archivo = File.Open("profesBinarios.bin", FileMode.OpenOrCreate);

            var binFile = new BinaryWriter(archivo);

            foreach (var profe in listProfes)
            {
                var bytesNombre = Encoding.UTF8.GetBytes(profe.Nombre);


                binFile.Write(profe.Nombre);
                binFile.Write(profe.Id);

            }

            binFile.Close();
            archivo.Close();
        }

        private static void EventosYDeMas()
        {
            var profesor = new Profesor() { Id = 23, Nombre = "Mateo", Apellido = "Perez", CodigoInterno = "PROFE_SMART" };

            var transmitter = new TrasnsmisionDeDatos();
            transmitter.InformacionEnviada += Transmitter_InformacionEnviada;
            transmitter.InformacionEnviada += (obj, evtarg) =>
            {
                Console.WriteLine("WOAAAAAAAAAAAAAAAAAAAA");
            };

            transmitter.FormatearYEnviar(profesor, Formatter, "ALEXTROIO");

            transmitter.InformacionEnviada -= Transmitter_InformacionEnviada;
            transmitter.FormatearYEnviar(profesor, (s) => new string(s.Reverse().ToArray<char>()), "ALEXTROIO");
        }

        private static void Transmitter_InformacionEnviada(object sender, EventArgs e)
        {
            Console.WriteLine("TRANSMISIÓN DE INFORMACIÓN");
        }

        private static string Formatter(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);

            var base64 = Convert.ToBase64String(bytes);

            return base64;
        }

        private static string ReverseFormatter(string input)
        {
            return new string(input.Reverse().ToArray<char>());
        }

        private static void MasArrays()
        {
            List<Persona> listaPersonas = new List<Persona>();

            listaPersonas.Add(new Alumno("Aitor", "Erro") { NickName = "Karratu", });
            listaPersonas.Add(new Profesor()
            {
                Nombre = "Fernando",
                Apellido = "Calvo",
            });
            listaPersonas.Add(new Profesor()
            {
                Nombre = "Gabri",
                Apellido = "Cysnet",
            });
            listaPersonas.Add(new Alumno("Alain", "Esteso"));
            listaPersonas.Add(new Alumno("Juan", "Perez"));

            for (int i = 0; i < listaPersonas.Count; i++)
            {
                if (listaPersonas[i] is Alumno)
                {
                    var al = (Alumno)listaPersonas[i];
                    Console.WriteLine(al.NickName != null ? al.NickName : al.NombreCompleto);
                }
                else
                {
                    var per = listaPersonas[i] as Persona;
                    //Console.WriteLine(per?.NombreCompleto);
                    if (per != null)
                    {
                        Console.WriteLine(per.NombreCompleto);
                    }
                }

                foreach (var obj in listaPersonas)
                {
                    if (obj is Alumno)
                    {
                        var al = (Alumno)listaPersonas[i];
                        Console.WriteLine(al.NickName != null ? al.NickName : al.NombreCompleto);
                    }
                    else
                    {
                        var per = obj as Persona;
                        //Console.WriteLine(per?.NombreCompleto);
                        if (per != null)
                        {
                            Console.WriteLine(per.NombreCompleto);
                        }
                    }
                }

            }


            Persona[] arrayPersonas = new Persona[5];

            var tam = arrayPersonas.Length;

            arrayPersonas[0] = new Alumno("Aitor", "Erro")
            {
                NickName = "Karratu",
            };
            arrayPersonas[1] = new Profesor()
            {
                Nombre = "Fernando",
                Apellido = "Calvo",
            };
            arrayPersonas[2] = new Profesor()
            {
                Nombre = "Gabri",
                Apellido = "Cysnet",
            };
            arrayPersonas[3] = new Alumno("Alain", "Esteso");
            arrayPersonas[4] = new Alumno("Juan", "Perez");

            Console.ReadLine();
        }

        private static void Arrays()
        {
            Persona[] arrayPersonas = new Persona[5];

            var tam = arrayPersonas.Length;

            arrayPersonas[0] = new Alumno("Aitor", "Erro")
            {
                NickName = "Karratu",
            };
            arrayPersonas[1] = new Profesor()
            {
                Nombre = "Fernando",
                Apellido = "Calvo",
            };
            arrayPersonas[2] = new Profesor()
            {
                Nombre = "Gabri",
                Apellido = "Cysnet",
            };
            arrayPersonas[3] = new Alumno("Alain", "Esteso");
            arrayPersonas[4] = new Alumno("Juan", "Perez");

            for (int i = 0; i < arrayPersonas.Length; i++)
            {
                if (arrayPersonas[i] is Alumno)
                {
                    var al = (Alumno)arrayPersonas[i];
                    Console.WriteLine(al.NickName != null ? al.NickName : al.NombreCompleto);
                }
                else
                {
                    Console.WriteLine(arrayPersonas[i].NombreCompleto);
                }

            }
        }

        private static void Casteos()
        {
            var alumno = new Alumno("Aitor", "Erro");
            var profesor = new Profesor();
            Persona persona = profesor;

            //-------------
            alumno = (Alumno)persona;

            //-------------
            if (persona is Profesor)
            {
                var profe = (Profesor)persona;
                ///...
            }

            //-------------
            var tmpProfe = persona as Profesor;
            if (tmpProfe != null)
            {
                ///...
            }
        }

        private static void Rutina2()
        {
            // Short from -32.000 to +32.000
            short s = 32000;
            int i = 33000;
            float f = 2.35f;
            double d = (double)0.60050561546065156065156005761076015670156707641076501576015761457601560741560765415761576015670165741789m;


            Console.WriteLine(i);
            s = (short)i;
            Console.WriteLine(s);
            Console.WriteLine(f);
            i = (int)f;
            Console.WriteLine(i);
        }

        public void Rutina1 ()
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

            lista[1] = new Profesor()
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

            Console.WriteLine("Curso 'c' = " + c.Curso);
            Console.WriteLine("Curso 'cursoFreak' = " + cursoFreak.Curso);

            Console.WriteLine("");
            Console.WriteLine("Pulsar cualquier tecla para continar...");
            Console.ReadKey();

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
        }
    }
}
