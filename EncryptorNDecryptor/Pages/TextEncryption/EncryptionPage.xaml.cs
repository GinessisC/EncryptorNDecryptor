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

public partial class EncryptionPage : ContentPage
{
	private const string InputMessageEditorOriginalText = "Enter message";
	
	private TextHandlingSettingsParams _textHandlingSettingsViewModel;
	private Sender _sender;
	public EncryptionPage()
	{
		InitializeComponent();
	}
	protected override void OnAppearing()
	{
		base.OnAppearing();
		
		_textHandlingSettingsViewModel = (TextHandlingSettingsParams)BindingContext;
		
		var publicKeyOfAnotherUser = _textHandlingSettingsViewModel.PublicKeyOfAnotherUser;
		var publicKey = _textHandlingSettingsViewModel.PublicKey;
		var privateKey = _textHandlingSettingsViewModel.PrivateKey;
			
		_sender = new(new(privateKey, publicKey), publicKeyOfAnotherUser);
	}
	private void Editor_Focused(object? sender, FocusEventArgs e) 
		=> EditorHelper.Editor_Focused(sender, e);

	private void InputMessageEditor_Tapped(object? sender, TappedEventArgs e)
	{
		EditorHelper.DeleteOriginalTextWhenTabbed(sender, InputMessageEditorOriginalText);
	}

	private async void EncryptMessageButton_Clicked(object? sender, EventArgs e)
	{
		try
		{
			StandardMessage message = await _sender.GetMessageToSendAsync(InputMessageEditor.Text);
			EncryptedMessageEditor.Text = message.ToString();
		}
		catch (Exception exception)
		{
			await DisplayAlert("Error", exception.Message, "OK");
		}
	}

	public async void CopyEncryptedMessage_OnClicked(object? sender, EventArgs e)
	{
		await Clipboard.SetTextAsync(EncryptedMessageEditor.Text);
	}
}