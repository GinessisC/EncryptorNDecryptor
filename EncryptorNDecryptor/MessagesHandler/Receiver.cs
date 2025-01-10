using EncryptionOperationProviders.CipherParams;
using EncryptionOperationProviders.EncryptionServices;
using EncryptionOperationProviders.EncryptionServices.TextEncryption;

namespace EncryptorNDecryptor.MessagesHandler;

public class Receiver
{
	public RsaEncryptionService Rsa { get; }


	public Receiver(RsaParams rsaParams)
	{
		RsaEncryptionService rsa = new(rsaParams.PrivateKey);
		Rsa = rsa;
	}
	
	public async Task<string> GetDecryptedTextMessageAsync(StandardMessage receivedRowMessage)
	{
		byte[] encryptedAesKey = Convert.FromBase64String(receivedRowMessage.EncryptedAesKey);
		byte[] encryptedAesIv = Convert.FromBase64String(receivedRowMessage.EncryptedAesIv);
		
		var aesKey = await Rsa.DecryptDataAsync(encryptedAesKey);
		var aesIv = await Rsa.DecryptDataAsync(encryptedAesIv);
		
		AesEncryptionService aes = new(aesKey, aesIv);
		
		HybridTextEncryptionService hybridTextEncryptionService = new(aes, Rsa);
		
		var originalText = await hybridTextEncryptionService.DecryptTextAsync(receivedRowMessage);
		return originalText;
	}
}