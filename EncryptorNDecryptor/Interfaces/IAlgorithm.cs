namespace EncryptorNDecryptor.Interfaces;

public interface IAlgorithm
{
	Task<string> GetDecryptedTextMessageAsync(string receivedRowMessage);
	Task<string> GetEncryptedMessageAsync(string plainText);
}