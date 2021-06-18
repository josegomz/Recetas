using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recetas.Models;
using SQLite;

namespace Recetas.Services
{
    public class MockDataStore : IDataStore<Receta>
    {
        public SQLiteAsyncConnection database;


        List<Receta> recetas;

        

        public MockDataStore(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Receta>().Wait();
        }
       
        public Task<int> AddRecetaAsync(Receta receta)
        {
            if (receta.Id == 0)
            {
                return database.InsertAsync(receta);
            }
            else
            {
                return null;
            }
        }

        public Task<List<Receta>> GetRecetasAsync(bool forceRefresh = false)
        {
            return database.Table<Receta>().ToListAsync();
        }
    }
}