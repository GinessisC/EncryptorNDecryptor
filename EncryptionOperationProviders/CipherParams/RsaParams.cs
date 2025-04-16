namespace EncryptionOperationProviders.CipherParams;

public class RsaParams :  IAlgParams
{
	public string PublicKeyOfAnotherUser { get; set; }
	public string PrivateKey { get; set; }
	public string PublicKey { get; set; }


	public RsaParams(string privateKey, string publicKeyOfAnotherUser, string publicKey)
	{
		PrivateKey = privateKey;
		PublicKeyOfAnotherUser = publicKeyOfAnotherUser;
		PublicKey = publicKey;
	}
	public RsaParams(string privateKey, string publicKey)
	{
		PrivateKey = privateKey;
		PublicKey = publicKey;
	}
}