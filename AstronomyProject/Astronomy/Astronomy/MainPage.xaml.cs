using Astronomy.Pages;
using Xamarin.Forms;

namespace Astronomy
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //Click Events for Buttons
            btnSunrise.Clicked += (s, e) => Navigation.PushAsync(new SunrisePage());
            btnMoonPhase.Clicked += (s, e) => Navigation.PushAsync(new MoonPhasePage());
            btnSpaceInfo.Clicked += (s, e) => Navigation.PushAsync(new AstronomicalBodiesPage());
            btnAbout.Clicked += (s, e) => Navigation.PushAsync(new AboutPage());
        }//End MainPage
    }
}
