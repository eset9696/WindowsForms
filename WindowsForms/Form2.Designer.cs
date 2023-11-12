namespace WindowsForms
{
	partial class Form2
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
			this.listBoxFontMenu = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listBoxFontMenu
			// 
			this.listBoxFontMenu.FormattingEnabled = true;
			this.listBoxFontMenu.Location = new System.Drawing.Point(194, 130);
			this.listBoxFontMenu.Name = "listBoxFontMenu";
			this.listBoxFontMenu.Size = new System.Drawing.Size(450, 95);
			this.listBoxFontMenu.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(572, 399);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Apply";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.listBoxFontMenu);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form2";
			this.Text = "Font menu";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox listBoxFontMenu;
		private System.Windows.Forms.Button button1;
	}
}