using Furgonet.Droid.Dependencias;
using SQLite.Net;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(GetSQLiteConnnection))]
namespace Furgonet.Droid.Dependencias
{
    public class GetSQLiteConnnection : ISQLiteInterface
    {
        public GetSQLiteConnnection()
        {

        }

        public SQLiteConnection GetSQLiteConnection()
        {
            var fileName = "UsuarioDatabase.db3";
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath, fileName);
            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLiteConnection(platform, path);
            return connection;
        }
    }
}