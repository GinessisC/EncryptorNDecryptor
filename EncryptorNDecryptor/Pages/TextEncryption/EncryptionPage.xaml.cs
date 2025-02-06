using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncryptionOperationProviders.CipherParams;
using EncryptionOperationProviders.EncryptionServices.TextEncryption;
using EncryptorNDecryptor.Pages.TextEncryption.ViewModels;

namespace EncryptorNDecryptor.Pages.TextEncryption;

public partial class EncryptionPage : ContentPage
{
	private TextEncrParamsViewModel _textEncrViewModel;
	
	public EncryptionPage()
	{
		InitializeComponent();
	}
	protected override void OnAppearing()
	{
		base.OnAppearing();
		_textEncrViewModel = (TextEncrParamsViewModel)BindingContext;

	}
	
	private async void EncryptMessageButton_Clicked(object? sender, EventArgs e)
	{
		var algorithm = _textEncrViewModel.Algorithm;
		try
		{
			string encryptedMessage = await algorithm.GetEncryptedMessageAsync(InputMessageEditor.Text);
			EncryptedMessageEditor.Text = encryptedMessage;
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