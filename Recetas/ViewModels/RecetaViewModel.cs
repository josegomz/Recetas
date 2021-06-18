using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Recetas.Models;
using Recetas.Views;

namespace Recetas.ViewModels
{
    public class RecetaViewModel : BaseViewModel
    {
        public ObservableCollection<Receta> Recetas { get; set; }
        public Command LoadItemsCommand { get; set; }

        public RecetaViewModel()
        {
            Title = "Recetas de cocina";
            Recetas = new ObservableCollection<Receta>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewRecetaPage, Receta>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Receta;
                Recetas.Add(newItem);
                await DataStore.AddRecetaAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Recetas.Clear();
                var items = await DataStore.GetRecetasAsync(true);
                foreach (var item in items)
                {
                    Recetas.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}