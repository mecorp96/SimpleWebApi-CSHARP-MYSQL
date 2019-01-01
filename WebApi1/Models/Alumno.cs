using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApi1.Models
{
    [DataContract]
    public class Alumno
    {
        [DataMember]
        private int _registro;
        [DataMember]
        private string _dni;
        [DataMember]
        private string _nombre;
        [DataMember]
        private string _apellido1;
        [DataMember]
        private string _apellido2;
        public Alumno() { }

        public int Registro {
            set { _registro = value; }
            get { return _registro; }
        }

        public string Dni
        {
            set { _dni = value; }
            get { return _dni; }
        }

        public string Nombre
        {
            set { _nombre = value; }
            get { return _nombre; }
        }

        public string Apellido1
        {
            set { _apellido1 = value; }
            get { return _apellido1; }
        }

        public string Apellido2
        {
            set { _apellido2 = value; }
            get { return _apellido2; }
        }

    }
}