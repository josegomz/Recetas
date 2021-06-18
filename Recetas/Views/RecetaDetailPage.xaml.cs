using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Recetas.Models;
using Recetas.ViewModels;

namespace Recetas.Views
{
    public partial class RecetaDetailPage : ContentPage
    {
        RecetaDetailViewModel viewModel;

        public RecetaDetailPage(RecetaDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public RecetaDetailPage()
        {
            InitializeComponent();

            var receta = new Receta
            {
                Title = "receta",
                Ingredients = "Ingredientes",
                Instruction = "Procedimiento"
            };

            viewModel = new RecetaDetailViewModel(receta);
            BindingContext = viewModel;
        }
    }
}