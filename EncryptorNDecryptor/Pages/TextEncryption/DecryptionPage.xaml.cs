using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncryptionOperationProviders.EncryptionServices.TextEncryption;
using EncryptorNDecryptor.Helpers;
using EncryptorNDecryptor.MessagesHandler;
using EncryptorNDecryptor.Pages.TextEncryption.ViewModels;

namespace EncryptorNDecryptor.Pages.TextEncryption;

public partial class DecryptionPage : ContentPage
{
	private const string InputEncryptedMessageOriginalText = "Enter encrypted message"; 
	private TextHandlingSettingsParams _textHandlingSettingsViewModel;
	private Receiver _receiver;
	public DecryptionPage()
	{
		InitializeComponent();
	}
	protected override void OnAppearing()
	{
		base.OnAppearing();
	
		_textHandlingSettingsViewModel = (TextHandlingSettingsParams)BindingContext;
		
		var privateKey = _textHandlingSettingsViewModel.PrivateKey;
		var publicKey = _textHandlingSettingsViewModel.PublicKey;
		
		_receiver = new(new(privateKey, publicKey));
	}
	private void Editor_Focused(object? sender, FocusEventArgs e)
		=> EditorHelper.Editor_Focused(sender, e);

	private void InputEncryptedMessageEditor_Tapped(object? sender, TappedEventArgs e)
	{
		EditorHelper.DeleteOriginalTextWhenTabbed(sender, InputEncryptedMessageOriginalText);
	}

	private async void DecryptMessageButton_Clicked(object? sender, EventArgs e)
	{
		try
		{
			var standardizedMessage = StandardMessage.FromString(InputEncryptedMessageEditor.Text);
			string decryptedMessage = await _receiver.GetDecryptedTextMessageAsync(standardizedMessage);
			DecryptedMessageEditor.Text = decryptedMessage;
		}
		catch (Exception exception)
		{
			await DisplayAlert("Error", exception.Message, "OK");
		}
	}
	private async void CopyDecryptedMessage_OnClicked(object? sender, EventArgs e)
	{
		await Clipboard.SetTextAsync(DecryptedMessageEditor.Text);
	}
}