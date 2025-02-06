using EncryptionOperationProviders.CipherParams;
using EncryptionOperationProviders.EncryptionServices;
using EncryptionOperationProviders.EncryptionServices.TextEncryption;
using EncryptorNDecryptor.Interfaces;

namespace EncryptorNDecryptor.MessagesEncryptors;

public class AesAlg : IAlgorithm
{
	private readonly AesEncryptionService _aes;
	public AesAlg(AesParams aesParams)
	{
		_aes = new AesEncryptionService(
			Convert.FromBase64String(aesParams.Key),
			Convert.FromBase64String(aesParams.IV));
	}
	
	public async Task<string> GetDecryptedTextMessageAsync(string receivedRowMessage)
	{
		TextEncryptionService textEncryptionService = new(_aes);
		
		var originalText = await textEncryptionService.DecryptTextAsync(receivedRowMessage);
		return originalText;
	}

	public async Task<string> GetEncryptedMessageAsync(string plainText)
	{
		AesEncryptionService aes = new(_aes.GetKey(), _aes.GetIV());
		TextEncryptionService service = new(aes);
		string encryptedMessage = await service.EncryptTextAsync(plainText);
		
		return encryptedMessage;
	}
}