using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DedAPI.Model;

namespace DedAPI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntrieListPage : ContentPage
    {
        List<EntrieModel> Source;
        public EntrieListPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            LVDeds.ItemsSource = await App.RequestManager.GetEntrieModels();
            Source = (List<EntrieModel>)LVDeds.ItemsSource;
        }

        private void BtnSortAlph_Clicked(object sender, EventArgs e)
        {
            Source = Source.OrderBy(a => a.API).ToList();
            LVDeds.ItemsSource = Source;
        }

        private void BtnSortReversAlph_Clicked(object sender, EventArgs e)
        {
            Source = Source.OrderByDescending(a => a.API).ToList();
            LVDeds.ItemsSource = Source;
        }

        private async void LVDeds_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedModel = LVDeds.SelectedItem as EntrieModel;
            await Navigation.PushAsync(new InfoPage(selectedModel));
        }

        private void SBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SBSearch.Text != "")
                LVDeds.ItemsSource = Source.Where(a => a.API.Contains(SBSearch.Text) || a.Description.Contains(SBSearch.Text));
            else
                LVDeds.ItemsSource = Source;
        }
    }
}