namespace app5
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

                MainPage = new NavigationPage(new MainPage());

        }
    }
}
