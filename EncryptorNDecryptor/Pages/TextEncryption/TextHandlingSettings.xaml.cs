using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using EncryptionOperationProviders.EncryptionServices;
using EncryptionOperationProviders.Helpers;
using EncryptorNDecryptor.Helpers;
using EncryptorNDecryptor.Pages.TextEncryption.ViewModels;

namespace EncryptorNDecryptor.Pages.TextEncryption;

public partial class TextHandlingSettings : ContentPage
{
	private const string KeyOfAnotherUserOriginalText = "Enter public key of user";
	private const string PublicKeyOriginalText = "Enter your public key";
	private const string PrivateKeyOriginalText = "Enter your private key";
	public TextHandlingSettings()
	{
		InitializeComponent();
	}
	
	public TextHandlingSettings(TextHandlingSettingsParams textHandlingSettingsParams)
	{
		InitializeComponent();
		
		PubicKeyOfAnotherUserEditor.Text = textHandlingSettingsParams.PublicKeyOfAnotherUser;
		PubicKeyEditor.Text = textHandlingSettingsParams.PublicKey;
		PrivateKeyEditor.Text = textHandlingSettingsParams.PrivateKey;
	}
	private void PublicKeyOfAnotherUserEditor_Tapped(object? sender, TappedEventArgs e)
	{
		EditorHelper.DeleteOriginalTextWhenTabbed(sender, KeyOfAnotherUserOriginalText);
	}
	private void PublicKeyEditor_Tapped(object? sender, TappedEventArgs e)
	{
		EditorHelper.DeleteOriginalTextWhenTabbed(sender, PublicKeyOriginalText);
	}

	private void PrivateKeyEditor_Tapped(object? sender, TappedEventArgs e)
	{
		EditorHelper.DeleteOriginalTextWhenTabbed(sender, PrivateKeyOriginalText);
	}
	
	private async void SaveSettingsButton_Clicked(object? sender, EventArgs e)
	{
		TextHandlingSettingsParams? clientSettings = await GetTextHandlingSettingsParams(PubicKeyEditor.Text,
			PrivateKeyEditor.Text,
			PubicKeyOfAnotherUserEditor.Text);

		if (clientSettings != null)
		{
			var previousPage = Navigation.NavigationStack.Count > 1 
				? Navigation.NavigationStack[Navigation.NavigationStack.Count - 2] 
				: null;
		
			if (previousPage is TextHandlingMainPage)
			{
				await Navigation.PopAsync();
			}
			else
			{
				await Navigation.PushAsync(new TextHandlingMainPage(clientSettings));
			}
		}
	}

	private async Task<TextHandlingSettingsParams?> GetTextHandlingSettingsParams(string publicKey, string privateKey, string publicKeyOfAnotherUser)
	{
		var isPublicKeyValid = await RsaKeyHelper.IsRsaKeyValidAsync(publicKey);
		var isPrivateKeyValid = await RsaKeyHelper.IsRsaKeyValidAsync(privateKey);
		var isPublicKeyOfAnotherUserValid = await RsaKeyHelper.IsRsaKeyValidAsync(publicKeyOfAnotherUser);

		if (isPublicKeyValid && isPrivateKeyValid && isPublicKeyOfAnotherUserValid)
		{
			return new TextHandlingSettingsParams
			{
				PrivateKey = privateKey,
				PublicKey = publicKey,
				PublicKeyOfAnotherUser = publicKeyOfAnotherUser
			};
		}
		await DisplayAlert($"Error", $"Not all fields are filled or input data are incorrect", "OK");
		return null;
	}
	
	private void Editor_Focused(object? sender, FocusEventArgs e)
		=> EditorHelper.Editor_Focused(sender, e);

	private void GenerateNewKeysButton_Clicked(object? sender, EventArgs e)
	{
		var keys = RsaEncryptionService.InitializeNewRsaKeys();
		
		PubicKeyEditor.Text = keys.PublicKey;
		PrivateKeyEditor.Text = keys.PrivateKey;
		PubicKeyEditor.TextColor = Colors.Black;
		PrivateKeyEditor.TextColor = Colors.Black;
	}

	// private async Task HandleAppException(Exception exception)
	// {
	// 	switch (exception)
	// 	{
	// 		case XmlException:
	// 			await DisplayAlert($"Error", $"Not all fields are filled or input data are incorrect", "OK");
	// 			break;
	// 		default:
	// 			await DisplayAlert($"Unknown error ", $"{exception.InnerException}\nMessage: {exception.Message}", "OK");
	// 			break;
	// 	}
	// }
}