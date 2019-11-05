using Furgonet.Data;
using Furgonet.Views;
using Furgonet.Views.HorarioPages;
using System;
using Xamarin.Forms;

namespace Furgonet
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void Clicked_mapas(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Mapas());
        }
        private void Button_Clicked_Direccion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DireccionPage());
        }
        private void Button_Clicked_Horario(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HorarioPage());
        }
        private void Button_Clicked_DatosUsuario(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DatosUsuario());
        }
        private async void Cerrar_MenuAsync(object sender, EventArgs e)
        {
            var rta = await DisplayAlert("Confirmación", "¿Desea Salir?", "Si", "No");
            if (!rta) return;
            await Navigation.PushAsync(new Bienvenida());
        }
    }
}
