using Furgonet.Model;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Furgonet.Data
{
    public class DireccionDatabase : IDisposable
    {
        private SQLiteConnection connection;
        public DireccionDatabase()
        {
            var config = DependencyService.Get<IConfig>();
            connection = new SQLiteConnection(config.Plataforma,
            System.IO.Path.Combine(config.DirectorioDB, "Direcciones.db3"));
            connection.CreateTable<Direccion>();
        }
        public void InsertDireccion(Direccion direccion)
        {
            connection.Insert(direccion);
        }
        public void UpdateDireccion(Direccion direccion)
        {
            connection.Update(direccion);
        }
        public void DeleteDireccion(Direccion direccion)
        {
            connection.Delete(direccion);
        }
        public Direccion GetDireccion(int IDdireccion)
        {
            return connection.Table<Direccion>().FirstOrDefault(c => c.IDdireccion == IDdireccion
            );
        }
        public List<Direccion> GetDirecciones()
        {
            return connection.Table<Direccion>().OrderBy(c => c.IDdireccion).ToList();
        }
        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
