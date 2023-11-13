using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
		private PrivateFontCollection myFontCollection = new PrivateFontCollection();
		private Form fontWindow = new Form();
		private ListBox lbFontMenu = new ListBox();
		private Button btnApply = new Button();
		private Button btnCancel = new Button();
		private Label labelFontPreview = new Label();
		private string[] fileNames = { "Mantinia", "SlideR", "OptimusPrinceps", "Mason Chronicles" };
		
		public Form1()
		{

			InitializeComponent();
			InitializeMyComponents(); // Инициализирует мои формы
			this.StartPosition = FormStartPosition.Manual;
			this.Location= new System.Drawing.Point(
				System.Windows.Forms.Screen.PrimaryScreen.Bounds.Right - this.Width - 50,
				System.Windows.Forms.Screen.PrimaryScreen.Bounds.Top + 100);
			show_date = false;
			visible_controls = false;
			btnHideControls.Visible = false;
			btnClose.Visible = false;
			
		}

		private void InitializeMyComponents()
		{
			fontWindow.Size = new Size(600, 400);
			fontWindow.StartPosition = FormStartPosition.CenterScreen;
			fontWindow.Text = "Font menu";
			fontWindow.TopMost = true;

			lbFontMenu.Size = new Size(500, 200);
			lbFontMenu.Location = new Point(50, 30);
			lbFontMenu.Font = new Font("", 24);
			LoadMyFonts();
			this.lbFontMenu.Click += new System.EventHandler(this.lbFontMenu_Click);

			labelFontPreview.Size = new Size(500, 100);
			labelFontPreview.Location = new Point(40, 220);
			labelFontPreview.TextAlign = ContentAlignment.TopCenter;
			labelFontPreview.Text = "0123456789";
			labelFontPreview.Font = new Font("Times new Roman", 48);

			btnApply.Text = "Apply";
			btnApply.Size = new Size(60, 30);
			btnApply.Location = new Point(400, 300);
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);

			btnCancel.Text = "Cancel";
			btnCancel.Size = new Size(60, 30);
			btnCancel.Location = new Point(470, 300);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

			fontWindow.Controls.Add(btnApply);
			fontWindow.Controls.Add(btnCancel);
			fontWindow.Controls.Add(lbFontMenu);
			fontWindow.Controls.Add(labelFontPreview);
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
			//My components
			/*fontWindow.Size = new Size(600, 400);
			fontWindow.StartPosition = FormStartPosition.CenterScreen;
			fontWindow.Text = "Font menu";
			fontWindow.TopMost = true;

			lbFontMenu.Size = new Size(500, 200);
			lbFontMenu.Location = new Point(50, 30);
			lbFontMenu.Font = new Font("", 24);
			LoadMyFonts();
			this.lbFontMenu.Click += new System.EventHandler(this.lbFontMenu_Click);

			labelFontPreview.Size = new Size(500, 100);
			labelFontPreview.Location = new Point(40, 220);
			labelFontPreview.TextAlign = ContentAlignment.TopCenter;
			labelFontPreview.Text = "0123456789";
			labelFontPreview.Font = new Font("Times new Roman", 48);

			btnApply.Text = "Apply";
			btnApply.Size = new Size(60, 30);
			btnApply.Location = new Point(400, 300);
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);


			fontWindow.Controls.Add(btnApply);
			fontWindow.Controls.Add(lbFontMenu);
			fontWindow.Controls.Add(labelFontPreview);*/
			fontWindow.ShowDialog();
		}
		private void btnCancel_Click(object sender, EventArgs e)
		{
			fontWindow.Close();
		}
		private void btnApply_Click(object sender, EventArgs e) // Вызывает метод, который применяет выбранный шрифт к часам
		{
			if (lbFontMenu.SelectedItem != null)
			{
				string selectedFont = lbFontMenu.SelectedItem.ToString();
				switch (selectedFont)
				{
					case "OptimusPrinceps":
						label1.Font = new Font(myFontCollection.Families[2], 48F);

						break;
					case "Mantinia":
						label1.Font = new Font(myFontCollection.Families[0], 48F);
						break;
					case "SlideR":
						label1.Font = new Font(myFontCollection.Families[1], 48F);
						break;
					case "Mason Chronicles":
						label1.Font = new Font(myFontCollection.Families[3], 48F);
						break;
				}
			}
		}

		private void LoadMyFonts() // Загружает шрифты в программу
		{
			for (int i = 0; i < fileNames.Length; i++)
			{
				myFontCollection.AddFontFile($"C:\\Users\\sherk\\source\\repos\\WindowsForms\\WindowsForms\\Fonts\\{fileNames[i]}.ttf");
			}

			for (int i = 0; i < myFontCollection.Families.Length; i++)
			{
				lbFontMenu.Items.Add(myFontCollection.Families[i].Name);
			}
		}

		private void lbFontMenu_Click(object sender, EventArgs e) //Применяет выбранный в листбоксе шрифт к лейблу - превью
		{
			if (lbFontMenu.SelectedItem != null)
			{
				string selectedFont = lbFontMenu.SelectedItem.ToString();
				switch (selectedFont)
				{
					case "OptimusPrinceps":
						labelFontPreview.Font = new Font(myFontCollection.Families[2], 48F);
						break;
					case "Mantinia":
						labelFontPreview.Font = new Font(myFontCollection.Families[0], 48F);
						break;
					case "SlideR":
						labelFontPreview.Font = new Font(myFontCollection.Families[1], 48F);
						break;
					case "Mason Chronicles":
						labelFontPreview.Font = new Font(myFontCollection.Families[3], 48F);
						break;
				}
			}
	}
	}
}
