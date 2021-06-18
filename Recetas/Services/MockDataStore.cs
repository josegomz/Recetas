using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recetas.Models;

namespace Recetas.Services
{
    public class MockDataStore : IDataStore<Receta>
    {
        readonly List<Receta> recetas;

        public MockDataStore()
        {
            recetas = new List<Receta>()
            {
                new Receta { Id = Guid.NewGuid().ToString(), Title = "Huevo con jamón", Ingredients="huevo, jamón",Instruction="Cocinar el huevo con el jamon" },
                new Receta { Id = Guid.NewGuid().ToString(), Title = "Pollo frito", Ingredients="pollo",Instruction="freir el pollo" }
            };
        }

        public async Task<bool> AddRecetaAsync(Receta receta)
        {
            recetas.Add(receta);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateRecetaAsync(Receta receta)
        {
            var oldItem = recetas.Where((Receta arg) => arg.Id == receta.Id).FirstOrDefault();
            recetas.Remove(oldItem);
            recetas.Add(receta);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteRecetaAsync(string id)
        {
            var oldItem = recetas.Where((Receta arg) => arg.Id == id).FirstOrDefault();
            recetas.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Receta> GetRecetaAsync(string id)
        {
            return await Task.FromResult(recetas.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Receta>> GetRecetasAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(recetas);
        }
    }
}