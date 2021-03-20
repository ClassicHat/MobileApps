using Astronomy.Pages;
using Xamarin.Forms;

namespace Astronomy
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            //Create new child pages for tabs
            this.Children.Add(new SunrisePage());
            this.Children.Add(new MoonPhasePage());
            this.Children.Add(new AboutPage());
        }
    }
}
