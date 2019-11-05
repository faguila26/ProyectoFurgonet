using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furgonet.Model.Usuario
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public Usuario()
        {

        }


        public override string ToString()
        {
            return string.Format("{0} {1} ", Name, Phone);
        }
    }
}
