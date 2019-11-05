using Furgonet.Data;
using Furgonet.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Furgonet.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DireccionPage : ContentPage
	{
		public DireccionPage ()
		{
			InitializeComponent ();
            AgregarButton.Clicked += AgregarButton_Clicked;
        }

        private async void AgregarButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nombresEntry.Text))
            {
                await DisplayAlert("Error", "Debe Ingresar Nombre de la Calle", "Aceptar");
                nombresEntry.Focus();
                return;
            }
            if (string.IsNullOrEmpty(ciudadEntry.Text))
            {
                await DisplayAlert("Error", "Debe Ingresar Ciudad", "Aceptar");
                ciudadEntry.Focus();
                return;
            }
            if (string.IsNullOrEmpty(numeroEntry.Text))
            {
                await DisplayAlert("Error", "Debe Ingresar Numero de Calle", "Aceptar");
                numeroEntry.Focus();
                return;
            }
            if (string.IsNullOrEmpty(horarioEntry.Text))
            {
                await DisplayAlert("Error", "Debe Ingresar Horario", "Aceptar");
                horarioEntry.Focus();
                return;
            }

            var direccion = new Direccion
            {
                NombreCalle = nombresEntry.Text,
                Ciudad = ciudadEntry.Text,
                NumeroCalle = int.Parse(numeroEntry.Text),
                Horario = horarioEntry.Text,
                On = activoSwitch.IsToggled
            };

            using (var datos = new DireccionDatabase())
            {

                datos.InsertDireccion(direccion);
                
            }

            nombresEntry.Text = string.Empty;
            ciudadEntry.Text = string.Empty;
            numeroEntry.Text = string.Empty;
            horarioEntry.Text = string.Empty;
            activoSwitch.IsToggled = true;
            await DisplayAlert("Confirmación", "Direccion Agregada", "Aceptar");
            await Navigation.PopAsync();
        }

    }
}