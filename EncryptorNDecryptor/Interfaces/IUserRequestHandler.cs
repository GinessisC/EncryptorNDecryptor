using EncryptorNDecryptor.Pages.TextEncryption.ViewModels;

namespace EncryptorNDecryptor.Interfaces;

public interface IUserRequestHandler
{
	Task PushToNextPageWithParams();
	void WhenGenerateKeys();
	
}