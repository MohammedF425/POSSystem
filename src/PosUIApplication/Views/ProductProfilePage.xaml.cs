using POSMaui.Library.Api;
using PosUIApplication.ViewModels;

namespace PosUIApplication.Views;

public partial class ProductProfilePage : ContentPage
{
	public ProductProfilePage()
	{
		InitializeComponent();
		BindingContext = new ProductProfileViewModel(new ProductEndpoint(new APIHelper()));
	}
}
