using Xamarin.Forms;

namespace Furgonet.Model
{
    public class HorarioCell : ViewCell
    {
        public HorarioCell()
        {
            
            var NombreHorarioLabel = new Label
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(NamedSize.Medium),
                HorizontalOptions = LayoutOptions.Fill
            };
            NombreHorarioLabel.SetBinding(Label.TextProperty, new Binding("NombredelHorario"));

            var HorasLabel = new Label
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(NamedSize.Medium),
                HorizontalOptions = LayoutOptions.Fill
            };
            HorasLabel.SetBinding(Label.TextProperty, new Binding("Horas"));

            var activoSwitch = new Switch
            {
                IsEnabled = false,
                HorizontalOptions = LayoutOptions.End
            };
            activoSwitch.SetBinding(Switch.IsToggledProperty, new Binding("Activo"));


            View = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { NombreHorarioLabel, HorasLabel, activoSwitch },
            };

        }
    }
}
