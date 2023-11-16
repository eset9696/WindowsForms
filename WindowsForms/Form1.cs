using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
	public partial class Form1 : Form
	{
		bool show_date;
		bool visible_controls;
		Font font;
		public Form1()
		{

			InitializeComponent(); // Инициализирует мои формы
			this.StartPosition = FormStartPosition.Manual;
			this.Location = new System.Drawing.Point(
				System.Windows.Forms.Screen.PrimaryScreen.Bounds.Right - this.Width - 50,
				System.Windows.Forms.Screen.PrimaryScreen.Bounds.Top + 100);
			show_date = false;
			visible_controls = false;
			btnHideControls.Visible = false;
			btnFont.Visible = false;
			btnClose.Visible = false;
			font = new Font(label1.Font);
			//font = new Font(label1.Font);
			//load("Settings.txt");
		}

		private void SetShowDate(bool show_date)
		{
			this.show_date = show_date;
			cbShowDate.Checked = show_date;
			showDateToolStripMenuItem.Checked = cbShowDate.Checked;
		}
		private void SetControlVisibility(bool visible_controls)
		{
			this.visible_controls = visible_controls;
			this.FormBorderStyle = visible_controls ? FormBorderStyle.Sizable : FormBorderStyle.None;
			this.TransparencyKey = visible_controls ? Color.AliceBlue : SystemColors.Control;
			this.ShowInTaskbar = visible_controls;
			this.cbShowDate.Visible = visible_controls;
			this.btnHideControls.Visible = visible_controls;
			this.btnFont.Visible = visible_controls;
			this.btnClose.Visible = visible_controls;
			//this.notifyIcon1.Visible = !visible;
			showControlsToolStripMenuItem.Checked = visible_controls;

		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			label1.Text = DateTime.Now.ToString("HH:mm:ss");
			if (cbShowDate.Checked) label1.Text += $"\n{DateTime.Now.ToString("dd.MM.yyyy")}";
			notifyIcon1.Text = DateTime.Now.ToString("HH:mm:ss");
		}

		private void label1_DoubleClick(object sender, EventArgs e)
		{
			SetControlVisibility(true);
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			//save("Settings.txt");
			this.Close();
		}

		private void btnHideControls_Click(object sender, EventArgs e)
		{
			SetControlVisibility(false);
		}

		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//save("Settings.txt");
			this.Close();
		}

		private void showControlsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (showControlsToolStripMenuItem.Checked) SetControlVisibility(true);
			else
			{
				showControlsToolStripMenuItem.Checked = false;
				btnHideControls_Click(sender, e);
			}
		}

		private void showDateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.show_date = showDateToolStripMenuItem.Checked;
			SetShowDate(show_date);
		}

		private void cbShowDate_CheckedChanged(object sender, EventArgs e)
		{
			//this.show_date = cbShowDate.Checked;	
			SetShowDate(cbShowDate.Checked);
		}

		private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			label1_DoubleClick(sender, e);
		}

		private void fontToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnFont_Click(sender, e);
		}

		private void btnFont_Click(object sender, EventArgs e)
		{
			
			font.ShowDialog(this);
			label1.Font = font.OldFont;
		}

		private void foregroundToolStripMenuItem_Click(object sender, EventArgs e)
		{
			colorDialog1.ShowDialog(this);
			label1.ForeColor = colorDialog1.Color;
		}

		private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
		{
			colorDialog1.ShowDialog(this);
			label1.BackColor = colorDialog1.Color;
		}

		/*private void save(string filename)
		{
			Directory.SetCurrentDirectory("C:\\Users\\sherk\\source\\repos\\WindowsForms\\WindowsForms\\bin\\Debug");
			StreamWriter sw = new StreamWriter(filename);
			sw.WriteLine($"Font={font.get_cbFont().SelectedItem.ToString()}\nFont size={label1.Font.Size}");
			if (label1.ForeColor.Name != null) sw.WriteLine($"ForeColor={label1.ForeColor.Name}");
			if (label1.BackColor.Name != null) sw.WriteLine($"BackColor={label1.BackColor.Name}");
			sw.Close();
		}
		private void load(string filename)
		{
			Directory.SetCurrentDirectory("C:\\Users\\sherk\\source\\repos\\WindowsForms\\WindowsForms\\bin\\Debug");
			StreamReader sr = new StreamReader(filename);
			string buffer = sr.ReadLine();
			if (buffer != null)
			{
				int pos = buffer.IndexOf("=");
				string fontName = buffer.Substring(pos + 1);
				buffer = sr.ReadLine();
				pos = buffer.IndexOf("=");
				string fontSize = buffer.Substring(pos + 1);
				double size = Convert.ToDouble(fontSize);
				PrivateFontCollection fontCollection = new PrivateFontCollection();
				if (Directory.GetCurrentDirectory().Contains("bin")) Directory.SetCurrentDirectory("C:\\Users\\sherk\\source\\repos\\WindowsForms\\WindowsForms\\Fonts");
				if (fontName != "Microsoft Sans Serif")
				{
					fontCollection.AddFontFile(fontName);
					System.Drawing.Font LoadFont = new System.Drawing.Font(fontCollection.Families[0], (float)size);
					label1.Font = LoadFont;
				}

				buffer = sr.ReadLine();
				if(buffer != null && buffer.Contains("ForeColor"))
				{
					pos = buffer.IndexOf('=');
					label1.ForeColor = Color.FromName(buffer.Substring(pos + 1));
					buffer = sr.ReadLine();
				}
				if (buffer != null && buffer.Contains("BackColor"))
				{
					pos = buffer.IndexOf('=');
					label1.BackColor = Color.FromName(buffer.Substring(pos + 1));
				}
			}
				sr.Close();
		}*/
	}
}
