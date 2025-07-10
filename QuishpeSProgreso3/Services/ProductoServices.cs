using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuishpeSProgreso3.Models;
using SQLite;

namespace QuishpeSProgreso3.Services
{
    public class ProductoServices
    {
        private SQLiteAsyncConnection _db;

        public async Task Init()
        {
            if (_db != null)
                return;

            var path = Path.Combine(FileSystem.AppDataDirectory, "productos.db");
            _db = new SQLiteAsyncConnection(path);
            await _db.CreateTableAsync<Producto>();
        }

        public async Task<List<Producto>> GetProductosAsync()
        {
            await Init();
            return await _db.Table<Producto>().ToListAsync();
        }

        public async Task AddProductoAsync(Producto producto)
        {
            await Init();
            await _db.InsertAsync(producto);
        }
    }
}
