using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi1.Models;
namespace WebApi1.Controllers
{
    public class AlumnoController : ApiController
    {

        NegocioAlumno negalumno;
        public AlumnoController() {

            negalumno = new NegocioAlumno();
        }

        [HttpGet]
        public Alumno GetAlumno(int id) {

            Alumno alumno = negalumno.Get(id );
            return alumno;
        }

        [HttpPost]
        public int Add(Alumno alumno)
        {
            Console.WriteLine(alumno.ToString());
            return negalumno.Add(alumno);
        }

        [HttpDelete]
        public int Delete(int id)
        {
            return negalumno.Remove(id);
        }

        [HttpPut]
        public int Update(Alumno alumno)
        {
            return negalumno.Update(alumno);
        }
    }
}
