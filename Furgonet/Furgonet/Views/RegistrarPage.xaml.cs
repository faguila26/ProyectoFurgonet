using Furgonet.Data;
using Furgonet.Model.Usuario;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Furgonet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistrarPage : ContentPage
	{
        // Se llama a las Clases Usuario y el Modelo para Crear un Nuevo Usuario
        Usuario users = new Usuario();
        UsuarioDatabase userDB = new UsuarioDatabase();
        public RegistrarPage ()
		{
			InitializeComponent ();

            NavigationPage.SetHasBackButton(this, false);

            emailEntry.ReturnCommand = new Command(() => userNameEntry.Focus());
            userNameEntry.ReturnCommand = new Command(() => passwordEntry.Focus());
            passwordEntry.ReturnCommand = new Command(() => confirmpasswordEntry.Focus());
            confirmpasswordEntry.ReturnCommand = new Command(() => phoneEntry.Focus());
        }

        // Método de Registro de Usuario
        private async void SignupValidation_ButtonClicked(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(userNameEntry.Text)) || (string.IsNullOrWhiteSpace(emailEntry.Text)) ||
                (string.IsNullOrWhiteSpace(passwordEntry.Text)) || (string.IsNullOrWhiteSpace(phoneEntry.Text)) ||
                (string.IsNullOrEmpty(userNameEntry.Text)) || (string.IsNullOrEmpty(emailEntry.Text)) ||
                (string.IsNullOrEmpty(passwordEntry.Text)) || (string.IsNullOrEmpty(phoneEntry.Text)))

            {
                await DisplayAlert("Ingrese Datos", "Ingrese Datos Validos", "OK");
            }
            else if (!string.Equals(passwordEntry.Text, confirmpasswordEntry.Text))
            {
                warningLabel.Text = "Ingrese la Misma Contraseña";
                passwordEntry.Text = string.Empty;
                confirmpasswordEntry.Text = string.Empty;
                warningLabel.TextColor = Color.Red;
                warningLabel.IsVisible = true;
            }
            else if (phoneEntry.Text.Length < 10)
            {
                phoneEntry.Text = string.Empty;
                phoneWarLabel.Text = "Ingrese un Número de 10 dígitos";
                phoneWarLabel.TextColor = Color.Red;
                phoneWarLabel.IsVisible = true;
            }
            else
            {
                users.Name = emailEntry.Text;
                users.UserName = userNameEntry.Text;
                users.Password = passwordEntry.Text;
                users.Phone = phoneEntry.Text.ToString();
                try
                {
                    var retrunvalue = userDB.AddUser(users);
                    if (retrunvalue == "Agregado exitosamente")
                    {
                        await DisplayAlert("Usuario Añadido", retrunvalue, "OK");

                        await Navigation.PushAsync(new LoginPage());

                    }
                    else
                    {
                        await DisplayAlert("Usuario Añadido", retrunvalue, "OK");
                        warningLabel.IsVisible = false;
                        emailEntry.Text = string.Empty;
                        userNameEntry.Text = string.Empty;
                        passwordEntry.Text = string.Empty;
                        confirmpasswordEntry.Text = string.Empty;
                        phoneEntry.Text = string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }
        private async void login_ClickedEvent(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}