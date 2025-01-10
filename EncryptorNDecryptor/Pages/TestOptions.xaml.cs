using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncryptorNDecryptor.Pages.TextEncryption.ViewModels;

namespace EncryptorNDecryptor.Pages;

public partial class TestOptions : ContentPage
{
	public TestOptions()
	{
		InitializeComponent();
	}

	private void SaveButton_OnClicked(object? sender, EventArgs e)
	{
		UserViewModel userViewModel = new UserViewModel()
		{
			Username = UserName.Text,
			UserSurname = Surname.Text
		};
		
		Navigation.PushAsync(new TestPage2(userViewModel));
	}
}