using Furgonet.Model.Usuario;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Furgonet.Data
{
    public class UsuarioDatabase : IDisposable
    {
        private SQLiteConnection _SQLiteConnection;

        public UsuarioDatabase()
        {
            _SQLiteConnection = DependencyService.Get<ISQLiteInterface>().GetSQLiteConnection();
            _SQLiteConnection.CreateTable<Usuario>();
        }

        public Usuario GetUsers(int IDUsuario)
        {
            return _SQLiteConnection.Table<Usuario>().FirstOrDefault(c => c.Id == IDUsuario
            );
        }
        public List<Usuario> GetUsers()
        {
            return _SQLiteConnection.Table<Usuario>().OrderBy(c => c.Id).ToList();
        }
        public Usuario GetSpecificUsuario(int id)
        {
            return _SQLiteConnection.Table<Usuario>().FirstOrDefault(t => t.Id == id);
        }
        public void DeleteUsuario(int id)
        {
            _SQLiteConnection.Delete<Usuario>(id);
        }
        public string AddUser(Usuario usuario)
        {
            var data = _SQLiteConnection.Table<Usuario>();
            var d1 = data.Where(x => x.Name == usuario.Name && x.UserName == usuario.UserName).FirstOrDefault();
            if (d1 == null)
            {
                _SQLiteConnection.Insert(usuario);
                return "Agregado exitosamente";
            }
            else
                return "Ya existe un ID de Correo";
        }
        public bool UpdateUsuarioValidation(string usuarioid)
        {
            var data = _SQLiteConnection.Table<Usuario>();
            var d1 = (from values in data
                      where values.Name == usuarioid
                      select values).Single();
            if (d1 != null)
            {
                return true;
            }
            else
                return false;
        }
        public bool UpdateUsuario(string username, string pwd)
        {
            var data = _SQLiteConnection.Table<Usuario>();
            var d1 = (from values in data
                      where values.Name == username
                      select values).Single();
            if (true)
            {
                d1.Password = pwd;
                _SQLiteConnection.Update(d1);
                return true;
            }
            else
                return false;
        }

        public bool LoginValidacion(string userName1, string pwd1)
        {
            var data = _SQLiteConnection.Table<Usuario>();
            var d1 = data.Where(x => x.Name == userName1 && x.Password == pwd1).FirstOrDefault();

            if (d1 != null)
            {
                return true;
            }
            else
                return false;
        }

        public void Dispose()
        {
            _SQLiteConnection.Dispose();
        }
    }
}
