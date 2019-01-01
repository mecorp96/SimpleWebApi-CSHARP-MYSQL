using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebApi1.Models
{
    interface IAlumno
    {
        IEnumerable<Alumno> Getall();
        Alumno Get(int id);
        int Add(Alumno alumno);
        int Remove(int id);
        int Update(Alumno alumno);

    }
}
