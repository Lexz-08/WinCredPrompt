namespace DemoApp
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lbl_ValidationResult = new System.Windows.Forms.Label();
			this.btn_ShowCredentialPrompt = new System.Windows.Forms.Button();
			this.lbl_UserName = new System.Windows.Forms.Label();
			this.lbl_Password = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lbl_ValidationResult
			// 
			this.lbl_ValidationResult.AutoSize = true;
			this.lbl_ValidationResult.Location = new System.Drawing.Point(86, 70);
			this.lbl_ValidationResult.Name = "lbl_ValidationResult";
			this.lbl_ValidationResult.Size = new System.Drawing.Size(50, 13);
			this.lbl_ValidationResult.TabIndex = 0;
			this.lbl_ValidationResult.Text = "< result >";
			// 
			// btn_ShowCredentialPrompt
			// 
			this.btn_ShowCredentialPrompt.Location = new System.Drawing.Point(89, 162);
			this.btn_ShowCredentialPrompt.Name = "btn_ShowCredentialPrompt";
			this.btn_ShowCredentialPrompt.Size = new System.Drawing.Size(102, 23);
			this.btn_ShowCredentialPrompt.TabIndex = 1;
			this.btn_ShowCredentialPrompt.Text = "Credential Prompt";
			this.btn_ShowCredentialPrompt.UseVisualStyleBackColor = true;
			this.btn_ShowCredentialPrompt.Click += new System.EventHandler(this.ShowCredentialPrompt_Click);
			// 
			// lbl_UserName
			// 
			this.lbl_UserName.AutoSize = true;
			this.lbl_UserName.Location = new System.Drawing.Point(86, 95);
			this.lbl_UserName.Name = "lbl_UserName";
			this.lbl_UserName.Size = new System.Drawing.Size(35, 13);
			this.lbl_UserName.TabIndex = 2;
			this.lbl_UserName.Text = "admin";
			// 
			// lbl_Password
			// 
			this.lbl_Password.AutoSize = true;
			this.lbl_Password.Location = new System.Drawing.Point(86, 113);
			this.lbl_Password.Name = "lbl_Password";
			this.lbl_Password.Size = new System.Drawing.Size(52, 13);
			this.lbl_Password.TabIndex = 3;
			this.lbl_Password.Text = "psawsord";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(460, 288);
			this.Controls.Add(this.lbl_Password);
			this.Controls.Add(this.lbl_UserName);
			this.Controls.Add(this.btn_ShowCredentialPrompt);
			this.Controls.Add(this.lbl_ValidationResult);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbl_ValidationResult;
		private System.Windows.Forms.Button btn_ShowCredentialPrompt;
		private System.Windows.Forms.Label lbl_UserName;
		private System.Windows.Forms.Label lbl_Password;
	}
}

