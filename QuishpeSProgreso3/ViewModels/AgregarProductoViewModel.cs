using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuishpeSProgreso3.Services;

namespace QuishpeSProgreso3.ViewModels
{
    public class AgregarProductoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public int Cantidad { get; set; } = 1;
        public decimal PrecioEstimado { get; set; }

        public Command GuardarCommand { get; }

        private readonly ProductoServices _productoService = new();
        private readonly LogsServices _logService = new();

        public AgregarProductoViewModel()
        {
            GuardarCommand = new Command(async () => await GuardarProductoAsync());
        }

        private async Task GuardarProductoAsync()
        {
            if (Cantidad < 1 && Categoria.ToLower() != "ropa")
            {
                await Application.Current.MainPage.DisplayAlert("Error", "La cantidad debe ser al menos 1 (excepto para Ropa)", "OK");
                return;
            }

            var producto = new Models.Producto
            {
                Nombre = Nombre,
                Categoria = Categoria,
                Cantidad = Cantidad,
                PrecioEstimado = PrecioEstimado
            };

            await _productoService.AddProductoAsync(producto);
            await _logService.AppendLogAsync(Nombre);
            await Application.Current.MainPage.DisplayAlert("Éxito", "Producto agregado", "OK");
            await Application.Current.MainPage.Navigation.PopAsync();


            Nombre = string.Empty;
            Categoria = string.Empty;
            Cantidad = 1;
            PrecioEstimado = 0;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}
