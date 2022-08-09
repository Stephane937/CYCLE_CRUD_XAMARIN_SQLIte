using CrudSQLIte.Models;
using CrudSQLIte.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrudSQLIte.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowCyclePage : ContentPage
    {
        CycleService services;
        public ShowCyclePage()
        {
            InitializeComponent();
            services = new CycleService();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            showCycle();
        }
        private void showCycle()
        {
            var res = services.GetAllCycles().Result;
            lstData.ItemsSource = res;
        }

        private void btnAddRecord_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new AddCycle());
        }

        private async void lstData_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                CycleModel obj = (CycleModel)e.SelectedItem;
                string res = await DisplayActionSheet("Operation", "Cancel", null, "Update", "Delete");

                switch (res)
                {
                    case "Update":
                        await this.Navigation.PushAsync(new AddCycle(obj));
                        break;
                    case "Delete":
                        services.DeleteCycle(obj);
                        showCycle();
                        break;
                }
                lstData.SelectedItem = null;
            }
        }
    }
}