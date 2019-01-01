using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi1.Datos;
using System.Data;

namespace WebApi1.Models
{
    public class NegocioAlumno : IAlumno
    {
        CDatos cdatos;
        Alumno alumno;
        public NegocioAlumno() {
            cdatos = new CDatos();

        }

        public Alumno Get(int id)
        {
            cdatos.Query("SELECT * FROM alumnos WHERE registro=" + id , "idalumno");

           DataRow fila= cdatos.GetDatos("idalumno").Rows[0];

            alumno = new Alumno();

            alumno.Registro = fila.Field<int>(0);
            alumno.Dni = fila.Field<String>(1);
            alumno.Nombre = fila.Field<String>(2);
            alumno.Apellido1 = fila.Field<String>(3);
            alumno.Apellido2 = fila.Field<String>(4);

            return alumno;

        }

        public int Add(Alumno alumno)
        {
            Console.WriteLine(alumno.Nombre);
            String sql = "INSERT INTO alumnos(dni, nombre, apellido1, apellido2) VALUES('" +
                alumno.Dni + "','" + alumno.Nombre + "','" + alumno.Apellido1 + "','" + alumno.Apellido2 + "')";

            Console.WriteLine(sql);
            return cdatos.EjecutaComando(sql);
        }


        public int Remove(int id)
        {
            return cdatos.EjecutaComando("DELETE FROM alumnos WHERE registro=" + id);
        }

        public int Update(Alumno alumno)
        {
            Console.WriteLine(alumno.Nombre);
            String sql = "UPDATE alumnos set dni='" +
                alumno.Dni + "', nombre='" + alumno.Nombre + "', apellido1='" + alumno.Apellido1 + "', apellido2='" + alumno.Apellido2 +
                "' WHERE registro=" + alumno.Registro;
            
            Console.WriteLine(sql);
            return cdatos.EjecutaComando(sql);

        }

        public IEnumerable<Alumno> Getall()
        {
            throw new NotImplementedException();
        }
    }
}