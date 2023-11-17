using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;

namespace WindowsForms
{
	public partial class Font : Form
	{
		public System.Drawing.Font NewFont { get; set; }
		public System.Drawing.Font OldFont { get; set; }

		String selectedItem;
		public String get_cbFontSelectedItem()
		{
			return selectedItem;
		}
		public Font(System.Drawing.Font oldFont, string fontFileName)
		{
			OldFont = oldFont;
			InitializeComponent();
			if(Directory.GetCurrentDirectory().Contains("bin"))Directory.SetCurrentDirectory("..\\..\\Fonts");
			string currentDirectory = Directory.GetCurrentDirectory();
			foreach (string i in Directory.GetFiles(currentDirectory))
			{
				if(i.Split().Last().Contains(".ttf")) this.cbFont.Items.Add(i.Split('\\').Last());
				if(i.Split().Last().Contains(".TTF")) this.cbFont.Items.Add(i.Split('\\').Last());
			}
			//cbFont.SelectedIndex = 1;

			cbFont.SelectedItem = fontFileName;
			numericUpDownFontSize.Value = (decimal)OldFont.Size;
			lblExample.Font = OldFont;
		}
		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			
			OldFont = NewFont;
			this.Close();
		}

		private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
		{
			PrivateFontCollection pfs = new PrivateFontCollection();
			selectedItem = cbFont.SelectedItem.ToString();
			pfs.AddFontFile(selectedItem);
			NewFont = new System.Drawing.Font(pfs.Families[0], (float)numericUpDownFontSize.Value);
			lblExample.Font = NewFont;
		}

		private void numericUpDownFontSize_ValueChanged(object sender, EventArgs e)
		{
			comboBox1_SelectionChangeCommitted(sender, e);
		}
	}
}
