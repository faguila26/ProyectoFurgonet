using Furgonet.Data;
using Furgonet.Model.Usuario;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Furgonet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DatosUsuario : ContentPage
	{
        public DatosUsuario ()
		{
            InitializeComponent();
            listView.RowHeight = 90;
            Padding = Device.OnPlatform(
            new Thickness(10, 20, 10, 10),
            new Thickness(10, 10, 10, 10),
            new Thickness(10, 10, 10, 10));

            listView.ItemTemplate = new DataTemplate(typeof(UsuarioCell));

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (var datos = new UsuarioDatabase())
            {
                listView.ItemsSource = datos.GetUsers();
            }
        }

    }
}