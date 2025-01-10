using EncryptionOperationProviders.CipherParams;
using EncryptionOperationProviders.EncryptionServices;
using EncryptionOperationProviders.EncryptionServices.TextEncryption;

namespace EncryptorNDecryptor.MessagesHandler;

public class Sender
{
	public RsaEncryptionService Rsa { get; }


	public Sender(RsaParams rsaParams, string pubKeyOfAnotherUserXmlString)
	{
		RsaEncryptionService rsa = new(rsaParams.PrivateKey, pubKeyOfAnotherUserXmlString);
		Rsa = rsa;
	}
	
	public async Task<StandardMessage> GetMessageToSendAsync(string plainText)
	{
		AesEncryptionService aes = new();
		
		HybridTextEncryptionService service = new(aes, Rsa);
		StandardMessage encryptedMessage = await service.EncryptTextAsync(plainText);
		
		return encryptedMessage;
	}
}