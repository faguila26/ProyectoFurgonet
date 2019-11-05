using Furgonet.Data;
using Furgonet.Model;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Furgonet.Views.HorarioPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HorarioEdit : ContentPage
    {
        private Horario horario;

        public HorarioEdit(Horario horario)
        {
            InitializeComponent();
            Padding = Device.OnPlatform(
            new Thickness(10, 20, 10, 10),
            new Thickness(10, 10, 10, 10),
            new Thickness(10, 10, 10, 10));

            this.horario = horario;

            ActualizarButton.Clicked += ActualizarButton_Clicked;
            BorrarButton.Clicked += BorrarButton_Clicked;
            turnoEntry.Text = horario.Turno;
            inicioEntry.Text = horario.HoraInicio;
            terminoEntry.Text = horario.HoraTermino;
            activoSwitch.IsToggled = horario.Activo;
        }
        private async void ActualizarButton_Clicked(object sender, EventArgs e)
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
                await DisplayAlert("Error", "Debe Ingresar una Hora", "Aceptar");
                terminoEntry.Focus();
                return;
            }
            horario.Turno = turnoEntry.Text;
            horario.HoraInicio = inicioEntry.Text;
            horario.HoraTermino = terminoEntry.Text;
            horario.Activo = activoSwitch.IsToggled;

            using (var datos = new HorarioDatabase())
            {
                datos.UpdateHorario(horario);
            }
            await DisplayAlert("Confirmación", "Horario Actualizado", "Aceptar");
            await Navigation.PopAsync();
        }
        private async void BorrarButton_Clicked(object sender, EventArgs e)
        {
            var rta = await DisplayAlert("Confirmación", "¿Desea borrar el Horario?", "Si", "No");
            if (!rta) return;

            using (var datos = new HorarioDatabase())
            {
                datos.DeleteHorario(horario);
            }
            await DisplayAlert("Confirmación", "Horario Eliminado Correctamente", "Aceptar");
            await Navigation.PushAsync(new HorarioPage());
        }
    }
}