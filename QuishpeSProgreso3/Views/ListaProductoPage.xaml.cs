using QuishpeSProgreso3.ViewModels;

namespace QuishpeSProgreso3.Views;

public partial class ListaProductoPage : ContentPage
{
    public ListaProductoPage()
    {
        InitializeComponent();
        BindingContext = new ListaProductoViewModel(); 
    }

}