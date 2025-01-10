namespace EncryptorNDecryptor.Helpers;

public static class EditorHelper
{
	public static void DeleteOriginalTextWhenTabbed(object sander, string originalText)
	{
		Editor editor = sander as Editor;
		editor.Focus();

		if (editor.Text == originalText)
		{
			editor.Text = string.Empty;
		}
	}
	public static void Editor_Focused(object? sender, FocusEventArgs e)
	{
		Editor editor = sender as Editor;
		editor.TextColor = Colors.Black;
	}
}