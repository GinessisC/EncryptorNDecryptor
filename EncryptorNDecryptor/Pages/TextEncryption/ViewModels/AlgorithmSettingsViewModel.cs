using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using EncryptionOperationProviders.CipherParams;
using EncryptorNDecryptor.Interfaces;

namespace EncryptorNDecryptor.Pages.TextEncryption.ViewModels;

public class AlgorithmSettingsViewModel : INotifyPropertyChanged
{
	private RsaParams _rsaParams;
	private AesParams _aesParams;
	
	private IUserRequestHandler? _userRequestHandler;
	public ICommand SaveSettingsCommand { get; }
	public ICommand GenerateNewKeysCommand { get; }
	
	public AlgorithmSettingsViewModel()
	{
		SaveSettingsCommand = new Command(async () => await SaveSettingsAsync());
		GenerateNewKeysCommand = new Command(async () => await GenerateNewKeysAsync());
	}
	public RsaParams RsaParams
	{
		get => _rsaParams;
		set
		{
			_rsaParams = value;
			OnPropertyChanged();
		}
	}

	public AesParams AesParams
	{
		get => _aesParams;
		set
		{
			_aesParams = value;
			OnPropertyChanged();
		}
	}
	public IUserRequestHandler? UserRequestHandler
	{
		get => _userRequestHandler;
		set
		{
			_userRequestHandler = value;
			OnPropertyChanged();
		}
	}
	private async Task GenerateNewKeysAsync()
	{
		if (_userRequestHandler is null)
		{
			await Application.Current.MainPage.DisplayAlert("Error", "Select type of algorithm", "OK");
		}
		else
		{
			_userRequestHandler.WhenGenerateKeys();
		}
	}
	private async Task SaveSettingsAsync()
	{
		if (_userRequestHandler is null)
		{
			await Application.Current.MainPage.DisplayAlert("Error", "Select type of algorithm", "OK");
			return;
		}
		try
		{
			await _userRequestHandler.PushToNextPageWithParams();
		}
		catch (Exception exception)
		{
			await Application.Current.MainPage.DisplayAlert("Error", $"Check all fields on validity. Message: {exception}", "OK");
		}
	}
	public event PropertyChangedEventHandler? PropertyChanged;

	protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	protected bool SetField<T>(ref T field,
		T value,
		[CallerMemberName] string? propertyName = null)
	{
		if (EqualityComparer<T>.Default.Equals(field, value))
			return false;

		field = value;
		OnPropertyChanged(propertyName);

		return true;
	}
}