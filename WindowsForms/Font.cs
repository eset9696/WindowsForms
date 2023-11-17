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
		//public System.Drawing.Font DfltFont { get; set; }
		public String get_cbFontSelectedItem()
		{
			return cbFont.SelectedItem.ToString();
		}

		public Font(System.Drawing.Font oldFont)
		{
			OldFont = oldFont;
			//DfltFont = oldFont;
			InitializeComponent();
			if(Directory.GetCurrentDirectory().Contains("bin"))Directory.SetCurrentDirectory("..\\..\\Fonts");
			string currentDirectory = Directory.GetCurrentDirectory();
			//MessageBox.Show(this, currentDirectory, "Current directory", MessageBoxButtons.OK);
			foreach (string i in Directory.GetFiles(currentDirectory))
			{
				if(i.Split().Last().Contains(".ttf")) this.cbFont.Items.Add(i.Split('\\').Last());
			}
			//cbFont.Items.Add(OldFont);
			cbFont.SelectedIndex = 1;
			numericUpDownFontSize.Value = (decimal)OldFont.Size;
			lblExample.Font = OldFont;
		}
		
		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			comboBox1_SelectionChangeCommitted(sender, e);
			OldFont = NewFont;
			this.Close();
		}

		private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
		{
			/*PrivateFontCollection pfs = new PrivateFontCollection();
			if (DfltFont.Name.ToString() == cbFont.SelectedItem.ToString())
			{
				NewFont = DfltFont;
				lblExample.Font = NewFont;
			}
			else
			{
				pfs.AddFontFile(cbFont.SelectedItem.ToString());
				//NewFont = new System.Drawing.Font(pfs.Families[0], lblExample.Font.Size);
				NewFont = new System.Drawing.Font(pfs.Families[0], (float)numericUpDownFontSize.Value);
				lblExample.Font = NewFont;
			}*/
			
			PrivateFontCollection pfs = new PrivateFontCollection();
			pfs.AddFontFile(cbFont.SelectedItem.ToString());
			NewFont = new System.Drawing.Font(pfs.Families[0], (float)numericUpDownFontSize.Value);
			lblExample.Font = NewFont;
		}

		private void numericUpDownFontSize_ValueChanged(object sender, EventArgs e)
		{
			comboBox1_SelectionChangeCommitted(sender, e);
		}
	}
}
