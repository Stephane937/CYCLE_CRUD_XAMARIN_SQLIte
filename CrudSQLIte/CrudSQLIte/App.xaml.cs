using Crud_Demo_UsingSQLIte.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crud_Demo_UsingSQLIte
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ShowCyclePage());
        }
    }
}
