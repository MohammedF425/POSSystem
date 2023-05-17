using POSMaui.Library.Api;
using PosUIApplication.ViewModels;

namespace PosUIApplication.Views;

public partial class InventoryPage : ContentPage
{
	public InventoryPage()
	{
		InitializeComponent();
		APIHelper apiHelper = new APIHelper();
		BindingContext = new InventoryViewModel(new InventoryEndpoint(apiHelper), new ProductEndpoint(apiHelper));
	}
}
