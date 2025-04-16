using EncryptorNDecryptor.Interfaces;
using EncryptorNDecryptor.Pages.TextEncryption.ViewModels;

namespace EncryptorNDecryptor.UserRequestHandlers;

public static class AlgFactory
{
	public static IUserRequestHandler GenerateAlgSettings(string selectedAlg,
		ContentPage contentPage,
		AlgorithmSettingsViewModel viewModel)
	{
		return selectedAlg switch
		{
			"RSA" => new RsaAlgRequestHandler(viewModel, contentPage),
			"AES" => new AesAlgRequestHandler(viewModel, contentPage),
			"BASE64" => new Base64AlgRequestHandler(contentPage),
		};
	}
}