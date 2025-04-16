namespace EncryptionOperationProviders.Interfaces;

public interface IEncryptionService
{
	Task<byte[]> EncryptData(string FileToEncryptPath);
	Task<byte[]> DecryptData();
}