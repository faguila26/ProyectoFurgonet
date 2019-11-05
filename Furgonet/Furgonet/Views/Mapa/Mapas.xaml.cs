using Furgonet.Data;
using Furgonet.Model;
using Furgonet.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Furgonet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mapas : ContentPage
    {
        GeolocatorService geolocatorService;
        public Mapas()
        {
            InitializeComponent();
            geolocatorService = new GeolocatorService();
            MoveMapToCurrentPositionAsync();

            #region Pins
            var pin = new CustomPin
            {
                    Type = PinType.Place,
                    Position = new Position(-40.559725, -73.172612),
                    Label = "Punto de Partida",
                    Address = "Loncoche 2648",
                    Id = "Xamarin",
                    Url = "http://xamarin.com/about/"
            };
            var pin2 = new CustomPin
            {
                Type = PinType.SearchResult,
                Position = new Position(-40.560337, -73.170566),
                Label = "Daniel",
                Address = "Wenumapu 2519-2577",
                Id = "Xamarin",
                Url = "http://xamarin.com/about/"

            };
            var pin3 = new CustomPin
            {
                Type = PinType.SearchResult,
                Position = new Position(-40.565682, -73.164995),
                Label = "Karen",
                Address = "Sta. Rosa de Lima 55-37",
                Id = "Xamarin",
                Url = "http://xamarin.com/about/"

            };
            var pin4 = new CustomPin
            {
                Type = PinType.SearchResult,
                Position = new Position(-40.574073, -73.149542),
                Label = "Angela",
                Address = "Iquique 2525",
                Id = "Xamarin",
                Url = "http://xamarin.com/about/"

            };

            var pin5 = new CustomPin
            {
                Type = PinType.SearchResult,
                Position = new Position(-40.574384, -73.138381),
                Label = "Susana",
                Address = "Manuel Bulnes 698",
                Id = "Xamarin",
                Url = "http://xamarin.com/about/"

            };

            var pin6 = new CustomPin
            {
                Type = PinType.SearchResult,
                Position = new Position(-40.574702, -73.131332),
                Label = "Emilia",
                Address = "Av. Juan Mackenna 1095",
                Id = "Xamarin",
                Url = "http://xamarin.com/about/"

            };

            var pin7 = new CustomPin
            {
                Type = PinType.SearchResult,
                Position = new Position(-40.574431, -73.124888),
                Label = "Destino Final: AIEP",
                Address = "Patricio Lynch 1245",
                Id = "Xamarin",
                Url = "http://xamarin.com/about/"

            };
            #endregion

            #region ListaPins
            customMap.CustomPins = new List<CustomPin>
            {
                pin, pin2, pin3, pin4, pin5, pin6, pin7
            };
            customMap.Pins.Add(pin);
            customMap.Pins.Add(pin2);
            customMap.Pins.Add(pin3);
            customMap.Pins.Add(pin4);
            customMap.Pins.Add(pin5);
            customMap.Pins.Add(pin6);
            customMap.Pins.Add(pin7);
            #endregion

            #region Polylineas
            customMap.RouteCoordinates.Add(new Position(-40.559725, -73.172612)); //Punto de Partida del Viaje
            customMap.RouteCoordinates.Add(new Position(-40.560364, -73.172303));
            customMap.RouteCoordinates.Add(new Position(-40.560085, -73.171450));
            customMap.RouteCoordinates.Add(new Position(-40.559893, -73.170757));
            customMap.RouteCoordinates.Add(new Position(-40.560337, -73.170566));
            customMap.RouteCoordinates.Add(new Position(-40.560903, -73.170314));
            customMap.RouteCoordinates.Add(new Position(-40.561573, -73.170043));
            customMap.RouteCoordinates.Add(new Position(-40.561766, -73.169524));
            customMap.RouteCoordinates.Add(new Position(-40.561937, -73.168896));
            customMap.RouteCoordinates.Add(new Position(-40.561956, -73.168714));
            customMap.RouteCoordinates.Add(new Position(-40.561821, -73.168114));
            customMap.RouteCoordinates.Add(new Position(-40.562068, -73.168017));
            customMap.RouteCoordinates.Add(new Position(-40.562988, -73.167860));
            customMap.RouteCoordinates.Add(new Position(-40.564323, -73.167710));
            customMap.RouteCoordinates.Add(new Position(-40.565100, -73.167605));
            customMap.RouteCoordinates.Add(new Position(-40.565020, -73.166680));
            customMap.RouteCoordinates.Add(new Position(-40.564992, -73.165722));
            customMap.RouteCoordinates.Add(new Position(-40.565062, -73.165064));
            customMap.RouteCoordinates.Add(new Position(-40.565682, -73.164995));
            customMap.RouteCoordinates.Add(new Position(-40.566308, -73.164920));
            customMap.RouteCoordinates.Add(new Position(-40.566984, -73.164704));
            customMap.RouteCoordinates.Add(new Position(-40.567483, -73.164535));
            customMap.RouteCoordinates.Add(new Position(-40.567992, -73.164363));
            customMap.RouteCoordinates.Add(new Position(-40.568377, -73.164240));
            customMap.RouteCoordinates.Add(new Position(-40.568487, -73.164222));
            customMap.RouteCoordinates.Add(new Position(-40.568576, -73.163542));
            customMap.RouteCoordinates.Add(new Position(-40.568635, -73.163303));
            customMap.RouteCoordinates.Add(new Position(-40.568748, -73.163038));
            customMap.RouteCoordinates.Add(new Position(-40.568936, -73.162811));
            customMap.RouteCoordinates.Add(new Position(-40.569105, -73.162629));
            customMap.RouteCoordinates.Add(new Position(-40.569371, -73.161958));
            customMap.RouteCoordinates.Add(new Position(-40.569651, -73.161646));
            customMap.RouteCoordinates.Add(new Position(-40.569803, -73.161439));
            customMap.RouteCoordinates.Add(new Position(-40.569917, -73.161224));
            customMap.RouteCoordinates.Add(new Position(-40.570010, -73.160507));
            customMap.RouteCoordinates.Add(new Position(-40.570032, -73.160333));
            customMap.RouteCoordinates.Add(new Position(-40.570055, -73.160033));
            customMap.RouteCoordinates.Add(new Position(-40.570090, -73.159665));
            customMap.RouteCoordinates.Add(new Position(-40.570116, -73.159339));
            customMap.RouteCoordinates.Add(new Position(-40.570160, -73.158857));
            customMap.RouteCoordinates.Add(new Position(-40.570424, -73.158396));
            customMap.RouteCoordinates.Add(new Position(-40.570532, -73.157391));
            customMap.RouteCoordinates.Add(new Position(-40.570741, -73.155615));
            customMap.RouteCoordinates.Add(new Position(-40.570954, -73.153935));
            customMap.RouteCoordinates.Add(new Position(-40.571284, -73.152556));
            customMap.RouteCoordinates.Add(new Position(-40.571356, -73.152237));
            customMap.RouteCoordinates.Add(new Position(-40.571517, -73.151819));
            customMap.RouteCoordinates.Add(new Position(-40.571757, -73.151411));
            customMap.RouteCoordinates.Add(new Position(-40.571953, -73.151127));
            customMap.RouteCoordinates.Add(new Position(-40.572140, -73.151092));
            customMap.RouteCoordinates.Add(new Position(-40.572613, -73.151178));
            customMap.RouteCoordinates.Add(new Position(-40.573318, -73.151280));
            customMap.RouteCoordinates.Add(new Position(-40.573980, -73.151363));
            customMap.RouteCoordinates.Add(new Position(-40.574073, -73.149542));
            customMap.RouteCoordinates.Add(new Position(-40.574297, -73.146486));
            customMap.RouteCoordinates.Add(new Position(-40.574314, -73.144695));
            customMap.RouteCoordinates.Add(new Position(-40.574266, -73.142721));
            customMap.RouteCoordinates.Add(new Position(-40.574246, -73.140661));
            customMap.RouteCoordinates.Add(new Position(-40.574384, -73.138381));
            customMap.RouteCoordinates.Add(new Position(-40.574470, -73.136611));
            customMap.RouteCoordinates.Add(new Position(-40.574531, -73.134883));
            customMap.RouteCoordinates.Add(new Position(-40.574600, -73.133076));
            customMap.RouteCoordinates.Add(new Position(-40.574702, -73.131332));
            customMap.RouteCoordinates.Add(new Position(-40.574828, -73.129540));
            customMap.RouteCoordinates.Add(new Position(-40.574907, -73.127875));
            customMap.RouteCoordinates.Add(new Position(-40.574492, -73.127796));
            customMap.RouteCoordinates.Add(new Position(-40.574145, -73.127701));
            customMap.RouteCoordinates.Add(new Position(-40.574164, -73.127426));
            customMap.RouteCoordinates.Add(new Position(-40.574232, -73.126746));
            customMap.RouteCoordinates.Add(new Position(-40.574429, -73.124891));

            #endregion

            listaView.RowHeight = 90;
            Padding = Device.OnPlatform(
            new Thickness(10, 20, 10, 10),
            new Thickness(10, 10, 10, 10),
            new Thickness(10, 10, 10, 10));

            listaView.ItemTemplate = new DataTemplate(typeof(DireccionCell));
            listaView.ItemSelected += listaViewItemSelected;
            
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (var datos = new DireccionDatabase())
            {
                listaView.ItemsSource = datos.GetDirecciones();
            }
        }
        private void listaViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushModalAsync(new EditDirecciones((Direccion)e.SelectedItem));
        }
        private async Task MoveMapToCurrentPositionAsync()
        {
            await geolocatorService.GetLocation();
            if (geolocatorService.Latitude != 0 &&
                geolocatorService.Longitude != 0)
            {
                var position = new Position(
                    geolocatorService.Latitude,
                    geolocatorService.Longitude);
                    customMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                    position,
                    Distance.FromKilometers(0.5)));
            }
        }

        private void Cerrar_modal(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void OnDireccionAdded(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DireccionPage());
        }
    }
}