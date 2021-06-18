using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Recetas.Models;
using Recetas.Views;
using Recetas.Services;
using System.IO;

namespace Recetas.ViewModels
{
    public class RecetaViewModel : BaseViewModel
    {
        public ObservableCollection<Receta> Recetas { get; set; }
        public Command LoadItemsCommand { get; set; }

        public static MockDataStore db;

        public RecetaViewModel()
        {
            Title = "Recetas de cocina";
            Recetas = new ObservableCollection<Receta>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewRecetaPage, Receta>(this, "AddReceta", async (obj, item) =>
            {
                var newItem = item as Receta;
                Recetas.Add(newItem);
                await RecetaViewModel.DB.AddRecetaAsync(newItem);
            });
        }

        public static MockDataStore DB
        {
            get
            {
                if (db == null)
                {
                    db = new MockDataStore(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Recetas.db3"));
                }
                return db;
            }

        }
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Recetas.Clear();
                var items = await RecetaViewModel.DB.GetRecetasAsync();
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