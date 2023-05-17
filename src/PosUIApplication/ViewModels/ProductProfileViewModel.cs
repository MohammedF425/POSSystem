using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using POS.Core.DTOs;
using POS.Core.ServiceContracts;

namespace PosUIApplication.ViewModels
{
	public class ProductProfileViewModel : ViewModelBase
	{
		private bool _isOpen;
		private ObservableCollection<ProductResponse> _productList = new ObservableCollection<ProductResponse>();
		private readonly IProductsService _productsService;

		public ProductProfileViewModel(IProductsService productsService)
		{
			_productsService = productsService;
			LoadProductListCommand = new Command(
				execute: async () =>
				{
					await LoadProductList();
				},
				canExecute: () => true);
		}

		public ObservableCollection<ProductResponse> ProductList
		{
			get => _productList;
			set
			{
				_productList = value;
				OnPropertyChanged();
			}
		}

		public void ResetProductList(IEnumerable<ProductResponse> products)
		{
			if (ProductList == null)
			{
				ProductList = new ObservableCollection<ProductResponse>();
			}
			else
			{
				ProductList.Clear();
			}

			foreach (ProductResponse p in products)
			{
				ProductList.Add(p);
			}
		}

		public async Task LoadProductList()
		{
			List<ProductResponse> products = await _productsService.GetAllProducts();
			ResetProductList(products);
		}

		public ICommand LoadProductListCommand { get; set; }
	}
}

