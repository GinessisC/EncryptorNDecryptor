using EncryptorNDecryptor.Pages.TextEncryption.ViewModels;

namespace EncryptorNDecryptor.Pages;

public partial class TestPage3 : ContentPage
{ 
	private UserViewModel _userViewModel;
	public TestPage3()
	{
		//_userViewModel = userViewModel;
		//BindingContext = _userViewModel;
		InitializeComponent();
	}
	protected override void OnAppearing()
	{
		base.OnAppearing();

		// Теперь BindingContext гарантированно установлен
		_userViewModel = (UserViewModel)BindingContext;
	}
}