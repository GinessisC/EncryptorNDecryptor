using System.Text;
using EncryptionOperationProviders.Interfaces;

namespace EncryptionOperationProviders.EncryptionServices.TextEncryption;

public class TextEncryptionService : EncryptionServiceBase
{
	public TextEncryptionService(IAesEncryptionService aes) : base(aes)
	{
	}
	
	public async Task<string> EncryptTextAsync(string plainText)
	{
		using MemoryStream msinput = new MemoryStream(Encoding.UTF8.GetBytes(plainText));
		using MemoryStream msoutput = new MemoryStream();
		
		await EncryptStreamAsync(msinput, msoutput);
		string encryptedText = Convert.ToBase64String(msoutput.ToArray());
		
		return encryptedText;
	}
	
	public async Task<string> DecryptTextAsync(string encryptedMessage)
	{
		byte[] encryptedTextBytes = Convert.FromBase64String(encryptedMessage);
		
		await using MemoryStream msinput = new MemoryStream(encryptedTextBytes);
		await using MemoryStream msoutput = new MemoryStream();
		
		await DecryptStreamAsync(msinput, msoutput);
		return Encoding.UTF8.GetString(msoutput.ToArray());
	}
}