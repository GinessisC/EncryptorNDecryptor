using System.Security.Cryptography;
using System.Text;
using EncryptionOperationProviders.CipherParams;
using EncryptionOperationProviders.Helpers;
using EncryptionOperationProviders.Interfaces;

namespace EncryptionOperationProviders.EncryptionServices;

public class RsaEncryptionService : IRsaEncryptionService
{
	private readonly RSAParameters _privateKey;
	private readonly RSAParameters _publicKeyOfAnotherUser;
	private readonly RSACryptoServiceProvider _rsa = new(2048);

	public RsaEncryptionService(RsaParams rsaParams)
	{
		_privateKey = RsaKeyHelper.FromXmlString(rsaParams.PrivateKey);
		_publicKeyOfAnotherUser = RsaKeyHelper.FromXmlString(rsaParams.PublicKeyOfAnotherUser);
	}
	
	public static RsaParams GenerateRsaKeys()
	{
		RSACryptoServiceProvider newRsa = new(2048);
		var publicKey = newRsa.ExportParameters(false);
		var privateKey = newRsa.ExportParameters(true);
		string publicKeyXmlString = RsaKeyHelper.ToXmlString(publicKey, false);
		string privateKeyXmlString = RsaKeyHelper.ToXmlString(privateKey, true);
		
		return new(privateKeyXmlString, publicKeyXmlString);
	}
	
	public async Task<byte[]> EncryptDataAsync(byte[] plainTextInBytes)
	{
		_rsa.ImportParameters(_publicKeyOfAnotherUser);
		return await Task.Run(() => _rsa.Encrypt(plainTextInBytes, false));
	}

	public async Task<byte[]> DecryptDataAsync(byte[] encryptedDataInBytes)
	{
		_rsa.ImportParameters(_privateKey);
		return await Task.Run(() => _rsa.Decrypt(encryptedDataInBytes, false));
	}
	public string GetPublicKeyOfAnotherUser()
	{
		return RsaKeyHelper.ToXmlString(_publicKeyOfAnotherUser, false);
	}
	public string GetPrivateKey()
	{
		return _rsa.ToXmlString(true);
	}
}