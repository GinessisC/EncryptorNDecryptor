using System.Text;
using EncryptionOperationProviders.CipherParams;
using EncryptionOperationProviders.EncryptionServices;
using EncryptorNDecryptor.Interfaces;

namespace EncryptorNDecryptor.MessagesEncryptors;

public class RsaAlg : IAlgorithm
{
	private readonly RsaEncryptionService _rsa;
	
	public RsaAlg(RsaParams rsaParams)
	{
		_rsa = new RsaEncryptionService(rsaParams);
	}

	public async Task<string> GetDecryptedTextMessageAsync(string receivedRowMessage)
	{
		byte[] encryptedMessageBytes = Convert.FromBase64String(receivedRowMessage);
		var decryptedBytes = await _rsa.DecryptDataAsync(encryptedMessageBytes);
		
		return Encoding.UTF8.GetString(decryptedBytes);
	}

	public async Task<string> GetEncryptedMessageAsync(string plainText)
	{
		byte[] plainTextInBytes = Encoding.UTF8.GetBytes(plainText);
		byte[] encryptedMessage = await _rsa.EncryptDataAsync(plainTextInBytes);
		
		return Convert.ToBase64String(encryptedMessage);
	}
}