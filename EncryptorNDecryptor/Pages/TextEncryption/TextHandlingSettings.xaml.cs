using System.Windows.Input;
using EncryptionOperationProviders.CipherParams;
using EncryptionOperationProviders.EncryptionServices;
using EncryptorNDecryptor.Interfaces;
using EncryptorNDecryptor.MessagesEncryptors;
using EncryptorNDecryptor.Pages.TextEncryption.ViewModels;
using EncryptorNDecryptor.UserRequestHandlers;

namespace EncryptorNDecryptor.Pages.TextEncryption;

public partial class TextHandlingSettings : ContentPage
{
	//private IUserRequestHandler? _userRequestHandler;
	//public AlgorithmSettingsViewModel SettingsViewModel { get; }

	public TextHandlingSettings()
	{
		InitializeComponent();
		//BindingContext = new AlgorithmSettingsViewModel();
	}
	
	
	
	// private void SetSettings(TextEncrParamsViewModel textEncrDecrSettingsParams)
	// {
	// 	if (textEncrDecrSettingsParams.UserRsaParams != null)
	// 	{
	// 		SetSettingsForRsaAlg(textEncrDecrSettingsParams.UserRsaParams);
	// 	}
	// 	else if (textEncrDecrSettingsParams.UserAesParams != null)
	// 	{
	// 		SetSettingsForAesAlg(textEncrDecrSettingsParams.UserAesParams);
	// 	}
	// }

	private void SetSettingsForRsaAlg(RsaParams rsaParams)
	{
		PubicKeyOfAnotherUserEditor.Text = rsaParams.PublicKeyOfAnotherUser;
		PubicKeyEditor.Text = rsaParams.PublicKey;
		PrivateKeyEditor.Text = rsaParams.PrivateKey;
	}

	private void SetSettingsForAesAlg(AesParams aesParams)
	{
		AesKeyEditor.Text = aesParams.Key;
		AesIvEditor.Text = aesParams.IV;
	}
	// private async void SaveSettingsButton_Clicked(object? sender, EventArgs e)
	// {
	// 	try
	// 	{
	// 		await _userRequestHandler.PushToNextPageWithParams();
	// 	}
	// 	catch (Exception exception)
	// 	{
	// 		await DisplayAlert("Error", $"Check all fields on validity. Message: {exception}", "OK");
	// 	}
	// }
	
	
	private async void EncAlgorithmPicker_OnSelectedIndexChanged(object? sender, EventArgs e)
	{
		string selectedItem = EncAlgorithmPicker.SelectedItem.ToString();
		
		if (string.IsNullOrEmpty(selectedItem))
		{
			await DisplayAlert("Error", "Please select an encryption algorithm", "OK");

			return;
		}
		HandleAlgorithmChoice(selectedItem);
		
		var bindingContext = BindingContext as AlgorithmSettingsViewModel;
		bindingContext.UserRequestHandler = AlgFactory.GenerateAlgSettings(selectedItem, this, bindingContext);
	}
	private void HandleAlgorithmChoice(string selectedItem)
	{
		switch (selectedItem)
		{
			case "AES":
				WhenAesIsSelected();
				break;
			case "RSA":
				WhenRsaIsSelected();
				break;
			default:
				WhenNoneIsSelected();
				break;
		}
	}
	
	private void WhenAesIsSelected()
	{
		MakeVisibleRsaEditorsAndLabels(false);
		MakeVisibleAesEditorsAndLabels(true);
	}
	private void WhenRsaIsSelected()
	{
		MakeVisibleRsaEditorsAndLabels(true);
		MakeVisibleAesEditorsAndLabels(false);
	}
	
	private void WhenNoneIsSelected()
	{
		MakeVisibleAesEditorsAndLabels(false);
		MakeVisibleRsaEditorsAndLabels(false);
	}
	private void MakeVisibleAesEditorsAndLabels(bool isVisible)
	{
		MakeVisibleAesLabels(isVisible);
		MakeVisibleAesEditors(isVisible);
	}
	private void MakeVisibleAesLabels(bool isVisible)
	{
		AesKeyLabel.IsVisible = isVisible;
		AesIvLabel.IsVisible = isVisible;
	}
	private void MakeVisibleAesEditors(bool isVisible)
	{
		AesKeyEditor.IsVisible = isVisible;
		AesIvEditor.IsVisible = isVisible;
	}
	
	private void MakeVisibleRsaEditorsAndLabels(bool isVisible)
	{
		MakeVisibleRsaLabels(isVisible);
		MakeVisibleRsaEditors(isVisible);
	}
	
	private void MakeVisibleRsaLabels(bool isVisible)
	{
		PubicKeyOfAnotherUserLabel.IsVisible = isVisible;
		PublicKeyLabel.IsVisible = isVisible;
		PrivateKeyLabel.IsVisible = isVisible;
	}
	
	private void MakeVisibleRsaEditors(bool isVisible)
	{
		PubicKeyOfAnotherUserEditor.IsVisible = isVisible;
		PubicKeyEditor.IsVisible = isVisible;
		PrivateKeyEditor.IsVisible = isVisible;
	}
	
}