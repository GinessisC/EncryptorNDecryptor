namespace EncryptionOperationProviders.CipherParams;

public class AesParams : IAlgParams
{
	//Signature in string: {Key}{Separator}{IV}
	private const string Separator = "$%ie3Loj^";
	public string Key { get; set; }
	public string IV { get; set; }
	public AesParams(string key, string iv)
	{
		Key = key;
		IV = iv;
	}

	public override string ToString()
	{
		return $"{Key}{Separator}{IV}";
	}
	
	public AesParams FromString(string input)
	{
		var aesParams = input.Split(Separator);
		string key = aesParams[0];
		string iv = aesParams[1];
		
		return new AesParams(key, iv);
	}
}