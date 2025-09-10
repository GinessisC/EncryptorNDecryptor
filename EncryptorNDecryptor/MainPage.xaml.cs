using EncryptorNDecryptor.Pages.TextEncryption;
using EncryptorNDecryptor.Pages;
using EncryptorNDecryptor.Pages.FileEncryption;

namespace EncryptorNDecryptor;

public partial class MainPage : ContentPage
{
	private const string TelegramUrl = "t.me/your_link";
	private const string YouTubeUrl = "https://www.youtube.com/@yourchannel";
	private const string GithubUrl = "https://github.com/GinessisC";
	
	public MainPage()
	{
		InitializeComponent();
	}
	private async void OnToEncryptPlainTextPageClicked(object? sender, EventArgs e)
	{
		await Navigation.PushAsync(new TextHandlingSettings());
		
	}
	private async void OnToEncryptFilePageClicked(object? sender, EventArgs e)
	{
		await Navigation.PushAsync(new FileEncryptionPage());

	}
	private async void YoutubeImageButton_OnClicked(object? sender, EventArgs e)
	{
		await OpenLinkSafely(YouTubeUrl);
	}

	private async void TelegramImageButton_OnClicked(object? sender, EventArgs e)
	{
		await OpenLinkSafely(TelegramUrl);
	}
	private async void GithubImageButton_OnClicked(object? sender, EventArgs e)
	{
		await OpenLinkSafely(GithubUrl);
	}
	private async Task OpenLinkSafely(string link)
	{
		try
		{
			await Launcher.OpenAsync(new Uri(link));
		}
		catch (Exception exception)
		{
			await DisplayAlert("Error", exception.Message, "OK");
		}
	}
}
