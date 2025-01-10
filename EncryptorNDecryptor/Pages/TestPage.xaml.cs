using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncryptorNDecryptor.Pages.TextEncryption.ViewModels;

namespace EncryptorNDecryptor.Pages;

public partial class TestPage : ContentPage
{
	UserViewModel _userViewModel;
	public TestPage()
	{
		InitializeComponent();
	}
	
	protected override void OnAppearing()
	{
		base.OnAppearing();
	
		// Теперь BindingContext гарантированно установлен
		_userViewModel = (UserViewModel)BindingContext;
	}
	private async void OnBackButtonClicked(object? sender, EventArgs e)
	{
		
		await DisplayAlert("Data", $"{_userViewModel.Username}, Hi!", "OK");
	}
}