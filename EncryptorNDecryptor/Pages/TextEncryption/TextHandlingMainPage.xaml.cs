using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncryptorNDecryptor.Pages.TextEncryption.ViewModels;

namespace EncryptorNDecryptor.Pages.TextEncryption;

public partial class TextHandlingMainPage : TabbedPage
{
	private TextHandlingSettingsParams _textHandlingSettingsParams;
	public TextHandlingMainPage(TextHandlingSettingsParams textHandlingSettingsParams)
	{
		InitializeComponent();
		
		_textHandlingSettingsParams = textHandlingSettingsParams;
		
		EncryptionPage.BindingContext = textHandlingSettingsParams;
		DecryptionPage.BindingContext = textHandlingSettingsParams;
	}

	private async void OnSettingsClicked(object? sender, EventArgs e)
	{
		await Navigation.PushAsync(new TextHandlingSettings(_textHandlingSettingsParams));
	}
}