using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recetas.Services
{
    public interface IDataStore<T>
    {
        Task<int> AddRecetaAsync(T receta);
        Task<List<T>> GetRecetasAsync(bool forceRefresh = false);
    }
}
