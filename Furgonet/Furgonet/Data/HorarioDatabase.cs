using Furgonet.Model;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Furgonet.Data
{
    public class HorarioDatabase :IDisposable
    {
        private SQLiteConnection _database;

        public HorarioDatabase()
        {
            var config = DependencyService.Get<IConfig>();
            _database = new SQLiteConnection(config.Plataforma,
            System.IO.Path.Combine(config.DirectorioDB, "Horarios.db3"));
            _database.CreateTable<Horario>();
        }
        public void InsertHorario(Horario horario)
        {
            _database.Insert(horario);
        }
        public void UpdateHorario(Horario horario)
        {
            _database.Update(horario);
        }
        public void DeleteHorario(Horario horario)
        {
            _database.Delete(horario);
        }
        public Horario GetHorario(int IdHorario)
        {
            return _database.Table<Horario>().FirstOrDefault(c => c.IDHorario == IdHorario
            );
        }
        public List<Horario> GetHorario()
        {
            return _database.Table<Horario>().OrderBy(c => c.IDHorario).ToList();
        }
        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
