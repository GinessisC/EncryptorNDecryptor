using EncryptorNDecryptor.Interfaces;
using EncryptorNDecryptor.MessagesEncryptors;
using EncryptorNDecryptor.Pages.TextEncryption;
using EncryptorNDecryptor.Pages.TextEncryption.ViewModels;

namespace EncryptorNDecryptor.UserRequestHandlers;

public class Base64AlgRequestHandler : IUserRequestHandler
{
	private ContentPage _contentPage;

	public Base64AlgRequestHandler(ContentPage contentPag)
	{
		_contentPage = contentPag;
	}

	public async Task PushToNextPageWithParams()
	{
		TextEncrParamsViewModel b64ParamsViewModel = new()
		{
			Algorithm = new Base64Alg()
		};
		await _contentPage.Navigation.PushAsync(new TextHandlingMainPage(b64ParamsViewModel));
	}

	public void WhenGenerateKeys()
	{
		_contentPage.DisplayAlert("Alert", "BASE64 don't need keys", "Ok");
	}
}