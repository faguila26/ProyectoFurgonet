using Xamarin.Forms;

namespace Furgonet.Model
{
    public class DireccionCell : ViewCell
    {
        public DireccionCell()
        {
            var localizacionLabel = new Label
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(NamedSize.Medium),
                HorizontalOptions = LayoutOptions.Fill
            };
            localizacionLabel.SetBinding(Label.TextProperty, new Binding("Localizacion"));

            var HorarioLabel = new Label
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(NamedSize.Medium),
                HorizontalOptions = LayoutOptions.Fill
            };
            HorarioLabel.SetBinding(Label.TextProperty, new Binding("Horario"));

            var activoSwitch = new Switch
            {
                IsEnabled = false,
                HorizontalOptions = LayoutOptions.End
            };
            activoSwitch.SetBinding(Switch.IsToggledProperty, new Binding("On"));
            
            View = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = {localizacionLabel, HorarioLabel, activoSwitch},
            };
        }
    }
}
