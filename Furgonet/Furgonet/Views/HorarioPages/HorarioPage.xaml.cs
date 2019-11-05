using Furgonet.Data;
using Furgonet.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Furgonet.Views.HorarioPages
{
	public partial class HorarioPage : ContentPage
	{
		public HorarioPage ()
		{
			InitializeComponent ();
            listView.RowHeight = 90;
            Padding = Device.OnPlatform(
            new Thickness(10, 20, 10, 10),
            new Thickness(10, 10, 10, 10),
            new Thickness(10, 10, 10, 10));

            listView.ItemTemplate = new DataTemplate(typeof(HorarioCell));
            listView.ItemSelected += listViewItemSelected;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (var datos = new HorarioDatabase())
            {
                listView.ItemsSource = datos.GetHorario();
            }
        }
        private void OnHorarioAddedClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HorarioEntry());
        }

        private void listViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new HorarioEdit((Horario)e.SelectedItem));
        }
    }
}