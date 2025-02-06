using EncryptorNDecryptor.Pages;

namespace EncryptorNDecryptor;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = new NavigationPage(new MainPage()); 
		Current.UserAppTheme = AppTheme.Light;
	}
}