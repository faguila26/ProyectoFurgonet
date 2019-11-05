using Furgonet.Views;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Furgonet
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Bienvenida())
            {
            };
            
        }
        public static async void NavigatiPage(Page name)
        {
            Application.Current.MainPage = new NavigationPage(new MainPage());
            
            await name.Navigation.PushAsync(new MainPage());
        }
        public static void MainPageList()
        {
            
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        internal static async Task NavigatiPageAsync(Page name)
        {
            Application.Current.MainPage = new NavigationPage(new MainPage());

            await name.Navigation.PushAsync(new MainPage());
        }
    }
}
