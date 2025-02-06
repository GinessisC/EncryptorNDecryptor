using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncryptionOperationProviders.EncryptionServices.TextEncryption;
using EncryptorNDecryptor.Pages.TextEncryption.ViewModels;

namespace EncryptorNDecryptor.Pages.TextEncryption;

public partial class DecryptionPage : ContentPage
{
	private TextEncrParamsViewModel _textEncrViewModel;
	public DecryptionPage()
	{
		InitializeComponent();
	}
	protected override void OnAppearing()
	{
		base.OnAppearing();
		_textEncrViewModel = (TextEncrParamsViewModel)BindingContext;
		
	}
	private async void DecryptMessageButton_Clicked(object? sender, EventArgs e)
	{
		var algorithm = _textEncrViewModel.Algorithm;
		try
		{
			string decryptedMessage = await algorithm.GetDecryptedTextMessageAsync(InputEncryptedMessageEditor.Text);
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