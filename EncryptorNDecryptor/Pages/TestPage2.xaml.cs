using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncryptorNDecryptor.Pages.TextEncryption.ViewModels;

namespace EncryptorNDecryptor.Pages;

public partial class TestPage2 : TabbedPage
{
	private UserViewModel _userViewModel;
	public TestPage2(UserViewModel userViewModel)
	{
		_userViewModel = userViewModel;
		InitializeComponent();
		
		TestPage.BindingContext = userViewModel;
		TestPage3.BindingContext = userViewModel;
	}
}