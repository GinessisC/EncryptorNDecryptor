using EncryptionOperationProviders.Interfaces;

namespace EncryptionOperationProviders.EncryptionServices.FileEncryption;

public class FileEncryptionService : EncryptionServiceBase
{
	public FileEncryptionService(IAesEncryptionService aes) : base(aes)
	{
	}
	
	public async Task EncryptDataFromFileAsync(string inputFilePath, string outputFilePath)
	{
		await using FileStream msinput = new FileStream(inputFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
		await using FileStream msoutput = new FileStream(outputFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
		
		await EncryptStreamAsync(msinput, msoutput);
	}
	public async Task DecryptDataFromFileAsync(string inputFilePath, string outputFilePath)
	{
		await using FileStream msinput = new FileStream(inputFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
		await using FileStream msoutput = new FileStream(outputFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
		
		await DecryptStreamAsync(msinput, msoutput);
	}
}