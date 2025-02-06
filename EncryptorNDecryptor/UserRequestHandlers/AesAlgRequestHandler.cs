using EncryptionOperationProviders.CipherParams;
using EncryptionOperationProviders.EncryptionServices;
using EncryptorNDecryptor.Interfaces;
using EncryptorNDecryptor.MessagesEncryptors;
using EncryptorNDecryptor.Pages.TextEncryption;
using EncryptorNDecryptor.Pages.TextEncryption.ViewModels;

namespace EncryptorNDecryptor.UserRequestHandlers;

public class AesAlgRequestHandler : IUserRequestHandler
{
	private ContentPage _contentPage;
	private AlgorithmSettingsViewModel _bindingContext;

	public AesAlgRequestHandler(AlgorithmSettingsViewModel bindingContext, ContentPage contentPage)
	{
		_bindingContext = bindingContext;
		_contentPage = contentPage;
	}

	public async Task PushToNextPageWithParams()
	{
		TextEncrParamsViewModel aesParamsViewModelForSend = new()
		{
			Algorithm = new AesAlg(_bindingContext.AesParams)
		};
		
		await _contentPage.Navigation.PushAsync(new TextHandlingMainPage(aesParamsViewModelForSend));
	}

	public void WhenGenerateKeys()
	{
		var keys = AesEncryptionService.GenerateAesParams();

		_bindingContext.AesParams = new(keys.Key, keys.IV);
	}
}