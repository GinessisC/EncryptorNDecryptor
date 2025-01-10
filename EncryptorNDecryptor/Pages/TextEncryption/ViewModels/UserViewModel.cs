using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EncryptorNDecryptor.Pages.TextEncryption.ViewModels;

public class UserViewModel : INotifyPropertyChanged
{
	private string _username;
	private string _userSurname;

	public string Username
	{
		get => _username;
		set
		{
			_username = value;
			OnPropertyChanged();
		}
	}
	public string UserSurname
	{
		get => _userSurname;
		set
		{
			_userSurname = value;
			OnPropertyChanged();
		}
	}
	public event PropertyChangedEventHandler? PropertyChanged;
	
	protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}