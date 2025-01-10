using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EncryptorNDecryptor.Pages.TextEncryption.ViewModels;

public class TextHandlingSettingsParams : INotifyPropertyChanged
{
	private string _publicKey;
	private string _privateKey;
	private string _publicKeyOfAnotherUser;
	
	public string PublicKey
	{
		get => _publicKey;
		set
		{
			if (_publicKey != value)
			{
				_publicKey = value;
				OnPropertyChanged();
			}
		}
	}
	public string PrivateKey
	{
		get => _privateKey;
		set
		{
			if (_privateKey != value)
			{
				_privateKey = value;
				OnPropertyChanged();
			}
		}
	}
	public string PublicKeyOfAnotherUser
	{
		get => _publicKeyOfAnotherUser;
		set
		{
			if (_publicKeyOfAnotherUser != value)
			{
				_publicKeyOfAnotherUser = value;
				OnPropertyChanged();
			}
		}
	}
	
	public event PropertyChangedEventHandler PropertyChanged;

	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}