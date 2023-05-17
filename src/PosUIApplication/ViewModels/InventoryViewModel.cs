using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using POS.Core.DTOs;
using POS.Core.ServiceContracts;
using POSMaui.Library.Models;

namespace PosUIApplication.ViewModels
{
	public class InventoryViewModel : ViewModelBase
	{
		private bool _isOpen;
		private readonly IInventoriesService _inventoriesService;
		private readonly IProductsService _productsService;
		private ObservableCollection<InventoryModel> _inventoryList = new ObservableCollection<InventoryModel>();

		public InventoryViewModel(IInventoriesService inventoryService, IProductsService productsService) 
		{
			_inventoriesService = inventoryService;
			_productsService = productsService;

			LoadInventoryListCommand = new Command(
				execute: async () =>
				{
					await LoadInventoryList();
				},
				canExecute: () => true
				);
		}

		public ObservableCollection<InventoryModel> InventoryList
		{
			get => _inventoryList;
			set
			{
				_inventoryList = value;
				OnPropertyChanged();
			}
		}

		public void ResetInventoryList(IEnumerable<InventoryModel> inventories)
		{
			if (InventoryList == null)
			{
				InventoryList = new ObservableCollection<InventoryModel>();
			}
			else
			{
				InventoryList.Clear();
			}
			foreach (InventoryModel i in inventories)
			{
				InventoryList.Add(i);
			}
		}

		public async Task LoadInventoryList()
		{
			List<InventoryResponse> inventoryResponses = await _inventoriesService.GetAllInventories();
			List<InventoryModel> inventoryList = new List<InventoryModel>();
			foreach(InventoryResponse inventoryResponse in inventoryResponses)
			{
				ProductResponse productResponse = await _productsService.GetProductByProductID(inventoryResponse.productID);
				InventoryModel inventoryModel = new InventoryModel()
				{
					InventoryID = inventoryResponse.InventoryID,
					InventoryDescription = inventoryResponse.Description,
					Units = inventoryResponse.Units,
					WholesalePricePerInventory = inventoryResponse.WholesalePricePerInventory,
					ProductID = productResponse.ID,
					ProductDescription = productResponse.ProductDescription,
					Barcode = productResponse.Barcode
				};
				inventoryList.Add(inventoryModel);
			}
			ResetInventoryList(inventoryList);
		}

		public ICommand LoadInventoryListCommand { get; set; }
	}
}

