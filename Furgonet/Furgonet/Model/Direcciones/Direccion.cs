using SQLite.Net.Attributes;

namespace Furgonet.Model
{
    public class Direccion
    {
        [PrimaryKey, AutoIncrement]
        public int IDdireccion { get; set; }
        public string NombreCalle { get; set; }
        public string Ciudad { get; set; }
        public int NumeroCalle { get; set; }
        public string Horario { get; set; }
        public bool On { get; set; }

        //Propiedades de Lectura
        public string Localizacion
        {
            get
            {
                return string.Format("{0} {1} {2}", this.NombreCalle, this.NumeroCalle, this.Ciudad);
            }
        }

        
        //Para ver Inicialmente el ListView
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Localizacion,
            Horario, On);
        }
    }

}
