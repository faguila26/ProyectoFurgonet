using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Furgonet.Model.Usuario
{
    public class UsuarioCell : ViewCell
    {
        public UsuarioCell()
        {
            // Datos que se verán en el ListView
            var NameLabel = new Label
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(NamedSize.Medium),
                HorizontalOptions = LayoutOptions.Fill
            };
            NameLabel.SetBinding(Label.TextProperty, new Binding("Name"));

            var PhoneLabel = new Label
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(NamedSize.Medium),
                HorizontalOptions = LayoutOptions.Fill
            };
            PhoneLabel.SetBinding(Label.TextProperty, new Binding("Phone"));
            
            View = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { NameLabel, PhoneLabel },
            };

        }
    }
}
