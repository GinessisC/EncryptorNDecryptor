using System.Security.Cryptography;
using EncryptionOperationProviders.Interfaces;

namespace EncryptionOperationProviders.EncryptionServices;

public abstract class EncryptionServiceBase
{
	protected readonly IAesEncryptionService Aes;

	protected EncryptionServiceBase(IAesEncryptionService aes)
	{
		Aes = aes;
	}
	protected async Task EncryptStreamAsync(Stream inputStream, Stream outputStream)
	{
		await Aes.EncryptData(inputStream, outputStream);
	}
	protected async Task DecryptStreamAsync(Stream inputStream, Stream outputStream)
	{
		await Aes.DecryptData(inputStream, outputStream);
	}
}