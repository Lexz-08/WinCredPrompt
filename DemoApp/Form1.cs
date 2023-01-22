using System;
using System.Windows.Forms;
using WinCredPrompt;

namespace DemoApp
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			handler.UserValidated += (s, e) =>
			{
				lbl_ValidationResult.Text = "validation successful";
			};
			handler.UserDeclined += (s, e) =>
			{
				lbl_ValidationResult.Text = "validation failed successfully";
			};

			
		}

		private WinCredPromptHandler handler = new WinCredPromptHandler("User Validation", "Please enter your username and password...");

		private void ShowCredentialPrompt_Click(object sender, EventArgs e)
		{
			handler.ValidatePrompt(new WinCredPromptHandler.UserInfo[]
			{
				new WinCredPromptHandler.UserInfo
				{
					UserName = lbl_UserName.Text,
					Password = lbl_Password.Text
				},
				new WinCredPromptHandler.UserInfo
				{
					UserName = "admin",
					Password = "password"
				},
				new WinCredPromptHandler.UserInfo
				{
					UserName = "tu",
					Password = "madre"
				}
			});
		}
	}
}
