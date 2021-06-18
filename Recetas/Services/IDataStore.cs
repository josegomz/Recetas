using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recetas.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddRecetaAsync(T receta);
        Task<bool> UpdateRecetaAsync(T receta);
        Task<bool> DeleteRecetaAsync(string id);
        Task<T> GetRecetaAsync(string id);
        Task<IEnumerable<T>> GetRecetasAsync(bool forceRefresh = false);
    }
}
