using SQLite.Net.Attributes;
using System;

namespace Furgonet.Model
{
    public class Horario
    {
        [PrimaryKey, AutoIncrement]
        public int IDHorario { get; set; }
        public string Turno { get; set; }
        public string HoraInicio { get; set; }
        public string HoraTermino { get; set; }
        public bool Activo { get; set; }

        //Propiedades de Lectura

        public string NombredelHorario
        {
            get
            {
                return string.Format("{0}", this.Turno);
            }
        }
        public string Horas
        {
            get
            {
                return string.Format("{0} {1}", this.HoraInicio, this.HoraTermino);
            }
        }


        //Para ver Inicialmente el ListView
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", NombredelHorario, Horas, Activo);
        }
    }
}
