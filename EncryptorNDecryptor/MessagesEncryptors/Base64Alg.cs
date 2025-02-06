using System.Text;
using EncryptorNDecryptor.Interfaces;

namespace EncryptorNDecryptor.MessagesEncryptors;

public class Base64Alg : IAlgorithm
{
	public async Task<string> GetDecryptedTextMessageAsync(string receivedRowMessage)
	{
		return await Task.Run(() =>
		{
			byte[] decryptedBytes = Convert.FromBase64String(receivedRowMessage);
			string decryptedText = Encoding.UTF8.GetString(decryptedBytes);
			return decryptedText;
		});
	}

	public async Task<string> GetEncryptedMessageAsync(string plainText)
	{
		return await Task.Run(() =>
		{
			byte[] encryptedBytes = Encoding.UTF8.GetBytes(plainText);
			string encryptedText = Convert.ToBase64String(encryptedBytes);
			return encryptedText;
		});
	}
}