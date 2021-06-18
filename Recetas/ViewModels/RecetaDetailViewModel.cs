using System;

using Recetas.Models;

namespace Recetas.ViewModels
{
    public class RecetaDetailViewModel : BaseViewModel
    {
        public Receta Receta { get; set; }
        public RecetaDetailViewModel(Receta receta = null)
        {
            Title = receta?.Title;
            Receta = receta;
        }
    }
}
