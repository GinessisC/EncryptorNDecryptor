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
		_aes = new AesEncryptionService(aesParams);
	}
	
	public async Task<string> GetDecryptedTextMessageAsync(string receivedRowMessage)
	{
		TextEncryptionService textEncryptionService = new(_aes);
		
		var originalText = await textEncryptionService.DecryptTextAsync(receivedRowMessage);
		return originalText;
	}
    
	public async Task<string> GetEncryptedMessageAsync(string plainText)
	{
		TextEncryptionService service = new(_aes);
		string encryptedMessage = await service.EncryptTextAsync(plainText);
		
		return encryptedMessage;
	}
}