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
    public partial class InfoPage : ContentPage
    {
        public InfoPage(EntrieModel model)
        {
            InitializeComponent();
            BindingContext = model;
            if (model.HTTPS)
                Lb.Text = "Поддерживает HTTPS";
            else
                Lb.Text = "Не поддерживает HTTPS";
        }
    }
}