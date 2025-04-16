namespace EncryptionOperationProviders.Interfaces;

public interface IAesEncryptionService
{
	Task EncryptData(Stream inputStream, Stream outputStream);
	Task DecryptData(Stream inputStream, Stream outputStream);
	byte[] GetKey();
	byte[] GetIV();
}