using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace WinCredPrompt
{
	public class WinCredPromptHandler
	{
		[DllImport("credui.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		private static extern uint CredUIPromptForWindowsCredentials(
			ref CREDUI_INFO notUsedHere,
			int authError,
			ref uint authPackage,
			IntPtr InAuthBuffer,
			uint InAuthBufferSize,
			out IntPtr refOutAuthBuffer,
			out uint refOUtAuthBufferSize,
			ref bool fSave,
			int flags
			);

		[DllImport("credui.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		private static extern bool CredUnPackAuthenticationBuffer(
			int dwFlags,
			IntPtr pAuthBuffer,
			uint cbAuthBuffer,
			StringBuilder pszUserName,
			ref int pcchMaxUserName,
			StringBuilder pszDomainName,
			ref int pcchMaxDomainName,
			StringBuilder pszPassword,
			ref int pcchMaxPassword
			);

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		private struct CREDUI_INFO
		{
			public int cbSize;
			public IntPtr hwndParent;
			public string pszMessageText;
			public string pszCaptionText;
			public IntPtr hbmBanner;
		}

		public struct UserInfo
		{
			public string UserName;
			public string Domain;
			public string Password;
		}

		private string str_CaptionText;
		private string str_MessageText;
		private IntPtr ptr_BannerIconHandle;

		/// <summary>
		/// Occurs when the user successfully validates through the credential prompt.
		/// </summary>
		public event EventHandler UserValidated;

		/// <summary>
		/// Occurs when the user is declined through the credential prompt.
		/// </summary>
		public event EventHandler UserDeclined;

		public WinCredPromptHandler(string CaptionText, string MessageText, Bitmap BannerIcon = null)
		{
			str_CaptionText = CaptionText;
			str_MessageText = MessageText;
			ptr_BannerIconHandle = BannerIcon == null ? new IntPtr() : BannerIcon.GetHbitmap();
		}

		private UserInfo? ShowDialog()
		{
			CREDUI_INFO credui = new CREDUI_INFO();
			credui.cbSize = Marshal.SizeOf(credui);
			credui.hwndParent = IntPtr.Zero;
			credui.pszCaptionText = str_CaptionText;
			credui.pszMessageText = str_MessageText;
			credui.hbmBanner = ptr_BannerIconHandle;

			uint authPackage = 0;
			IntPtr outCredBuffer = new IntPtr();
			uint outCredSize;
			bool save = false;

			if (CredUIPromptForWindowsCredentials(
				ref credui, 0,
				ref authPackage,
				IntPtr.Zero, 0,
				out outCredBuffer,
				out outCredSize,
				ref save, 1
				) == 0)
			{
				int maxUserName = 10000;
				int maxDomain = 10000;
				int maxPassword = 10000;
				StringBuilder userName = new StringBuilder(maxUserName);
				StringBuilder domain = new StringBuilder(maxDomain);
				StringBuilder password = new StringBuilder(maxPassword);

				if (CredUnPackAuthenticationBuffer(
					0, outCredBuffer,
					outCredSize,
					userName,
					ref maxUserName,
					domain,
					ref maxDomain,
					password,
					ref maxPassword
					))
				{
					UserInfo userInfo = new UserInfo { UserName = userName.ToString(), Domain = domain.ToString(), Password = password.ToString() };

					UserValidated?.Invoke(this, EventArgs.Empty);
					return userInfo;
				}
				else
				{
					UserDeclined?.Invoke(this, EventArgs.Empty);
					return null;
				}
			}
			else
			{
				UserDeclined?.Invoke(this, EventArgs.Empty);
				return null;
			}
		}

		public void ValidatePrompt(UserInfo ValidUser)
		{
			UserInfo? userInfo = ShowDialog();

			bool bl_UserInfoExists = userInfo != null && userInfo.HasValue;
			bool result = false;
			
			if (bl_UserInfoExists)
				result = userInfo.Value.UserName == ValidUser.UserName && userInfo.Value.Password == ValidUser.Password;

			if (result) UserValidated?.Invoke(this, EventArgs.Empty);
			else UserDeclined?.Invoke(this, EventArgs.Empty);
		}

		public void ValidatePrompt(UserInfo[] ValidUsers)
		{
			UserInfo? userInfo = ShowDialog();

			bool bl_UserInfoExists = userInfo != null && userInfo.HasValue;
			bool result = false;

			if (bl_UserInfoExists)
				foreach (UserInfo validUser in ValidUsers)
					if (userInfo.Value.UserName == validUser.UserName && userInfo.Value.Password == validUser.Password)
					{
						result = true;
						break;
					}

			if (result) UserValidated?.Invoke(this, EventArgs.Empty);
			else UserDeclined?.Invoke(this, EventArgs.Empty);
		}
	}
}
