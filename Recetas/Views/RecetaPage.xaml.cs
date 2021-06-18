using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Recetas.Models;
using Recetas.Views;
using Recetas.ViewModels;

namespace Recetas.Views
{
    public partial class RecetaPage : ContentPage
    {
        RecetaViewModel viewModel;

        public RecetaPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new RecetaViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (Receta)layout.BindingContext;
            await Navigation.PushAsync(new RecetaDetailPage(new RecetaDetailViewModel(item)));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewRecetaPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Recetas.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}
    