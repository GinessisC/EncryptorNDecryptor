using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncryptorNDecryptor.Pages.TextEncryption.ViewModels;

namespace EncryptorNDecryptor.Pages.TextEncryption;

public partial class TextHandlingMainPage : TabbedPage // rename to TextEncryptionDecryptionMainPage
{
	private readonly TextEncrParamsViewModel _textEncrParamsViewModel;
	public TextHandlingMainPage(TextEncrParamsViewModel textEncrParamsViewModel)
	{
		InitializeComponent();
		
		_textEncrParamsViewModel = textEncrParamsViewModel;
		
		EncryptionPage.BindingContext = textEncrParamsViewModel;
		DecryptionPage.BindingContext = textEncrParamsViewModel;
	}

	private async void OnSettingsClicked(object? sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}
}