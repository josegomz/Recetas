using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Recetas.Models;

namespace Recetas.Views
{
    public partial class NewRecetaPage : ContentPage
    {
        public Receta Receta { get; set; }

        public NewRecetaPage()
        {
            InitializeComponent();

            Receta = new Receta
            {
                Title = "Título de la receta",
                Ingredients ="Ingredientes...",
                Instruction = "Procedimiento..."
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Receta);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}