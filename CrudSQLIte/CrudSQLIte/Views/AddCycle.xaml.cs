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
    public partial class AddCycle : ContentPage
    {
        CycleService _services;
        bool _isUpdate;
        int cycleID;
        public AddCycle()
        {
            InitializeComponent();
            _services = new CycleService();
            _isUpdate = false;
        }

     

        public AddCycle(CycleModel obj)
        {
            InitializeComponent();
            _services = new CycleService();
            if (obj != null)
            {
                cycleID = obj.Id;
                txtStation.Text = obj.Station;
                txtveloManuelle.Text = obj.veloManuelle;
                txtveloElectriques.Text = obj.veloElectriques;
                _isUpdate = true;
            }
        }
        private async void btnSaveUpdate_Clicked(object sender, EventArgs e)
        {
            CycleModel obj = new CycleModel();
            obj.Station = txtStation.Text;
            obj.veloManuelle = txtveloManuelle.Text;
            obj.veloElectriques = txtveloElectriques.Text;
            if (_isUpdate)
            {
                obj.Id = cycleID;
                await _services.UpdateCycle(obj);
            }
            else
            {
                _services.InsertCycle(obj);
            }
            await this.Navigation.PopAsync();
        }
    }
}