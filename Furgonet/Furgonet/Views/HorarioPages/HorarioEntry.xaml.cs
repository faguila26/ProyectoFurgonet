
using Furgonet.Data;
using Furgonet.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Furgonet.Views.HorarioPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HorarioEntry : ContentPage
    {
        public HorarioEntry()
        {
            InitializeComponent();

        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(turnoEntry.Text))
            {
                await DisplayAlert("Error", "Debe Ingresar Turno", "Aceptar");
                turnoEntry.Focus();
                return;
            }
            if (string.IsNullOrEmpty(inicioEntry.Text))
            {
                await DisplayAlert("Error", "Debe Ingresar Numero de Vueltas", "Aceptar");
                inicioEntry.Focus();
                return;
            }
            if (string.IsNullOrEmpty(terminoEntry.Text))
            {
                await DisplayAlert("Error", "Debe Ingresar Numero de Vueltas", "Aceptar");
                terminoEntry.Focus();
                return;
            }

            var horario = new Horario
            {
                Turno = turnoEntry.Text,
                HoraInicio = inicioEntry.Text,
                HoraTermino = terminoEntry.Text,
                Activo = activoSwitch.IsToggled
            };

            using (var datos = new HorarioDatabase())
            {
                datos.InsertHorario(horario);
            }
            turnoEntry.Text = string.Empty;
            inicioEntry.Text = string.Empty;
            terminoEntry.Text = string.Empty;
            activoSwitch.IsToggled = true;
            await DisplayAlert("Confirmación", "Direccion Agregada", "Aceptar");
            await Navigation.PopAsync();
        }
        
    }
}