namespace EncryptionOperationProviders.Interfaces;

public interface IRsaEncryptionService
{
	Task<byte[]> EncryptDataAsync(byte[] plainTextInBytes);
	Task<byte[]> DecryptDataAsync(byte[] encryptedDataInBytes);
	string GetPublicKeyOfAnotherUser();
	string GetPrivateKey();
}