using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuishpeSProgreso3.Models;
using QuishpeSProgreso3.Services;

namespace QuishpeSProgreso3.ViewModels
{
    public class ListaProductoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Producto> Productos { get; } = new();

        private readonly ProductoServices _productoService = new();

        public ListaProductoViewModel()
        {
            CargarProductos();
        }

        public async void CargarProductos()
        {
            var productos = await _productoService.GetProductosAsync();
            Productos.Clear();
            foreach (var p in productos)
                Productos.Add(p);
        }

    }
}
