using System;
using Xamarin.Forms;
using CalculadoraMovilMVVM_AESM.Vistas;
using Xamarin.Forms.Xaml;

namespace CalculadoraMovilMVVM_AESM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PaginaPrincipal();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
