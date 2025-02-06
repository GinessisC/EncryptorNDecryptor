using EncryptionOperationProviders.CipherParams;
using EncryptionOperationProviders.EncryptionServices;
using EncryptorNDecryptor.Interfaces;
using EncryptorNDecryptor.MessagesEncryptors;
using EncryptorNDecryptor.Pages.TextEncryption;
using EncryptorNDecryptor.Pages.TextEncryption.ViewModels;

namespace EncryptorNDecryptor.UserRequestHandlers;

public class RsaAlgRequestHandler : IUserRequestHandler
{
	private AlgorithmSettingsViewModel _bindingContext;
	private ContentPage _contentPage;
	
	public RsaAlgRequestHandler(AlgorithmSettingsViewModel bindingContext, ContentPage contentPage)
	{
		_contentPage = contentPage;
		_bindingContext = bindingContext;
	}
	public async Task PushToNextPageWithParams()
	{
		TextEncrParamsViewModel rsaParamsViewModelToPass = new()
		{
			Algorithm = new RsaAlg(_bindingContext.RsaParams)
		};
		await _contentPage.Navigation.PushAsync(new TextHandlingMainPage(rsaParamsViewModelToPass));
	}

	public void WhenGenerateKeys()
	{
		var keys = RsaEncryptionService.GenerateRsaKeys();
		
		_bindingContext.RsaParams = new(keys.PrivateKey, keys.PublicKeyOfAnotherUser, keys.PublicKey);
	}
}