using Furgonet.Data;
using Furgonet.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Furgonet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditDirecciones : ContentPage
	{
        private Direccion direccion;
        public EditDirecciones (Direccion direccion)
		{
			InitializeComponent ();
            Padding = Device.OnPlatform(
            new Thickness(10, 20, 10, 10),
            new Thickness(10, 10, 10, 10),
            new Thickness(10, 10, 10, 10));

            this.direccion = direccion;

            ActualizarButton.Clicked += ActualizarButton_Clicked;
            BorrarButton.Clicked += BorrarButton_Clicked;

            nombresEntry.Text = direccion.NombreCalle;
            numeroEntry.Text = direccion.NumeroCalle.ToString();
            ciudadEntry.Text = direccion.Ciudad;
            horarioEntry.Text = direccion.Horario;
            activoSwitch.IsToggled = direccion.On;
        }

        private async void BorrarButton_Clicked(object sender, EventArgs e)
        {
            var rta = await DisplayAlert("Confirmación", "¿Desea borrar la Direccion?", "Si", "No");
            if (!rta) return;

            using (var datos = new DireccionDatabase())
            {
                datos.DeleteDireccion(direccion);
            }
            await DisplayAlert("Confirmación", "Direccion Eliminada Correctamente", "Aceptar");
            await Navigation.PopModalAsync();


        }
        private async void ActualizarButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nombresEntry.Text))
            {
                await DisplayAlert("Error", "Debe Ingresar un Nombre", "Aceptar");
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
                await DisplayAlert("Error", "Debe Ingresar Numero", "Aceptar");
                numeroEntry.Focus();
                return;
            }
            if (string.IsNullOrEmpty(horarioEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar salario", "Aceptar");
                horarioEntry.Focus();
                return;
            }

            direccion.NombreCalle = nombresEntry.Text;
            direccion.Ciudad = ciudadEntry.Text;
            direccion.NumeroCalle = int.Parse(numeroEntry.Text);
            direccion.Horario = horarioEntry.Text;
            direccion.On = activoSwitch.IsToggled;

            using (var datos = new DireccionDatabase())
            {
                datos.UpdateDireccion(direccion);
            }
            await DisplayAlert("Confirmación", "Direccion Actualizada Correctamente", "Aceptar");
            await Navigation.PopModalAsync();
        }
    }
}