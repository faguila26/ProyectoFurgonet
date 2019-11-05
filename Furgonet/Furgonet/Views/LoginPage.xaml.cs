using Furgonet.Data;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Furgonet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        UsuarioDatabase userData = new UsuarioDatabase();
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);

            userNameEntry.ReturnCommand = new Command(() => passwordEntry.Focus());
            firstPassword.ReturnCommand = new Command(() => secondPassword.Focus());

            var forgetpassword_tap = new TapGestureRecognizer();

            forgetpassword_tap.Tapped += Forgetpassword_tap_Tapped;
            forgetLabel.GestureRecognizers.Add(forgetpassword_tap);
        }

        // Método para mostrar el modulo de Recuperación de Contraseña
        private async void Forgetpassword_tap_Tapped(object sender, EventArgs e)
        {
            popupLoadingView.IsVisible = true;
        }
        string logesh;

        // Método de Verificación de Correo
        private async void UserIdCheckEvent(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(useridValidationEntry.Text)) || (string.IsNullOrWhiteSpace(useridValidationEntry.Text)))
            {
                await DisplayAlert("Alerta", "Ingresa el Nombre del Correo", "OK");
            }
            else
            {
                logesh = useridValidationEntry.Text;
                var textresult = userData.UpdateUsuarioValidation(useridValidationEntry.Text);
                if (textresult)
                {
                    popupLoadingView.IsVisible = false;
                    passwordView.IsVisible = true;
                }
                else
                {
                    await DisplayAlert("El Usuario no Existe", "Ingrese el Usuario Correcto", "OK");
                }
            }
        }

        // Método de Cambiar o Actualizar Contraseña
        private async void Password_ClickedEvent(object sender, EventArgs e)
        {
            if (!string.Equals(firstPassword.Text, secondPassword.Text))
            {
                warningLabel.Text = "Ingresa la misma Contraseña";
                warningLabel.TextColor = Color.IndianRed;
                warningLabel.IsVisible = true;
            }
            else if ((string.IsNullOrWhiteSpace(firstPassword.Text)) || (string.IsNullOrWhiteSpace(secondPassword.Text)))
            {
                await DisplayAlert("Alerta", " Ingresa Contraseña", "OK");
            }
            else
            {
                try
                {
                    var return1 = userData.UpdateUsuario(logesh, firstPassword.Text);
                    passwordView.IsVisible = false;
                    if (return1)
                    {
                        await DisplayAlert("Contraseña Actualizada", "Datos de Usuario Actualizado", "OK");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        // Método de Autentificación de Usuario
        private async void LoginValidation_ButtonClicked(object sender, EventArgs e)
        {
            if (userNameEntry.Text != null && passwordEntry.Text != null)
            {
                var validData = userData.LoginValidacion(userNameEntry.Text, passwordEntry.Text);
                if (validData)
                {
                    popupLoadingView.IsVisible = false;
                    await App.NavigatiPageAsync(loginPage);
                }
                else
                {
                    popupLoadingView.IsVisible = false;                   
                    await DisplayAlert("Login Fallida", "Usuario o Contraseña Incorrecta", "OK");
                }
            }
            else
            {
                popupLoadingView.IsVisible = false;
                await DisplayAlert("Advertencia", "Ingresa un Usuario y Contraseña", "OK");
            }
        }
    }
}