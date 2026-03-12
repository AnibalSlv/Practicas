namespace MSistema_de_Control_de_Finanzas
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage()) { Title = "MSistema de Control de Finanzas" };
        }
    }
}
