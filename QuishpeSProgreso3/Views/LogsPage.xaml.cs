using QuishpeSProgreso3.ViewModels;

namespace QuishpeSProgreso3.Views;

public partial class LogsPage : ContentPage
{
	public LogsPage()
	{
		InitializeComponent();
        BindingContext = new LogsViewModel();

    }
}