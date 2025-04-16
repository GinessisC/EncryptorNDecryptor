using System.Security.Cryptography;
using System.Text;
using EncryptionOperationProviders.CipherParams;
using EncryptionOperationProviders.Interfaces;

namespace EncryptionOperationProviders.EncryptionServices;

public class AesEncryptionService : IAesEncryptionService
{
	private const int BufferSize = 8192;
	private readonly Aes _aes = Aes.Create();
	private readonly byte[] _key;
	private readonly byte[] _iv;

	public AesEncryptionService(AesParams aesParams)
	{
		_key = Convert.FromBase64String(aesParams.Key);
		_iv = Convert.FromBase64String(aesParams.IV);
		
	}
	public AesEncryptionService()
	{
		var newAes = Aes.Create();
		
		_key = newAes.Key;
		_iv = newAes.IV; 
	}
	public static AesParams GenerateAesParams()
	{
		var newAes = Aes.Create();
		return new AesParams(Convert.ToBase64String(newAes.Key),
			Convert.ToBase64String(newAes.IV));
	}
	public virtual async Task EncryptData(Stream inputStream, Stream outputStream)
	{
		using var cryptoTransform = _aes.CreateEncryptor(_key, _iv);

		await using var cryptoStream = new CryptoStream(outputStream, cryptoTransform, CryptoStreamMode.Write);

		byte[] buffer = new byte[BufferSize]; // Буфер на 8 КБ
		int bytesRead;

		while ((bytesRead = await inputStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
		{
			await cryptoStream.WriteAsync(buffer, 0, bytesRead);
		}
		await cryptoStream.FlushFinalBlockAsync();
	}

	public virtual async Task DecryptData(Stream inputStream, Stream outputStream)
	{
		using var decryptor = _aes.CreateDecryptor(_key, _iv);
		await using var cryptoStream = new CryptoStream(inputStream, decryptor, CryptoStreamMode.Read);
		
		byte[] buffer = new byte[BufferSize];
		int bytesRead;

		while ((bytesRead = await cryptoStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
		{
			await outputStream.WriteAsync(buffer, 0, bytesRead);
		}
	}
	
	public byte[] GetKey()
	{
		return _key;
	}

	public byte[] GetIV()
	{
		return _iv;
	}
}