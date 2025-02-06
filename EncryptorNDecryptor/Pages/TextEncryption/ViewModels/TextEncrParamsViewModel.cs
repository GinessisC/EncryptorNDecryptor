using System.ComponentModel;
using System.Runtime.CompilerServices;
using EncryptionOperationProviders.CipherParams;
using EncryptorNDecryptor.Interfaces;

namespace EncryptorNDecryptor.Pages.TextEncryption.ViewModels;

public class TextEncrParamsViewModel : INotifyPropertyChanged
{
	private IAlgorithm _algorithm;
	
	public IAlgorithm Algorithm
	{
		get => _algorithm;
		set
		{
			if (_algorithm != value)
			{
				_algorithm = value;
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