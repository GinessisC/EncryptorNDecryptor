namespace EncryptionOperationProviders.EncryptionServices.TextEncryption;

public class StandardMessage
{
	//Signature:  
	//{EncryptedText}{Separator}{CipheredKey}{Separator}{CipheredIV}
	
	private const string Separator = "$%ie3Loj^";
	public string EncryptedText { get; }
	public string EncryptedAesIv { get; }
	public string EncryptedAesKey { get; }
	
	public StandardMessage(string encryptedText,
		string encryptedAesKey,
		string encryptedAesIv
		)
	{
		EncryptedText = encryptedText;
		EncryptedAesKey = encryptedAesKey;
		EncryptedAesIv = encryptedAesIv;
	}
	
	public override string ToString()
	{
		return $"{EncryptedText}{Separator}{EncryptedAesKey}{Separator}{EncryptedAesIv}";
	}
	
	public static StandardMessage FromString(string input)
	{
		var standardMessageParams = input.Split(Separator);
		var cipheredText = standardMessageParams[0];
		var cipheredAesKey = standardMessageParams[1];
		var cipheredAesIv = standardMessageParams[2];
		
		return new(cipheredText, cipheredAesKey, cipheredAesIv);
	}
}