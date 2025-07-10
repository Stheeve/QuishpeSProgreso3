using QuishpeSProgreso3.ViewModels;

namespace QuishpeSProgreso3.Views;

public partial class AgregarProductoPage : ContentPage
{
	public AgregarProductoPage()
	{
		InitializeComponent();
        BindingContext = new AgregarProductoViewModel();

    }
}