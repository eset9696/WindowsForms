using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
	public partial class Form2 : Form
	{
		PrivateFontCollection myFontCollection = new PrivateFontCollection();
		public Form2()
		{
			InitializeComponent();
			LoadMyFonts();
		}

		private void LoadMyFonts()
		{

			string[] fontNames = { "Mantinia", "SlideR", "OptimusPrinceps", "Mason Chronicles" };
			//myFontCollection.AddFontFile("DarkSouls.ttf");
			for (int i = 0; i < fontNames.Length; i++)
			{
				myFontCollection.AddFontFile($"C:\\Users\\sherk\\source\\repos\\WindowsForms\\WindowsForms\\Fonts\\{fontNames[i]}.ttf");
			}
			PreviewFont();
		}

		private void PreviewFont()
		{
			for (int i = 0; i < myFontCollection.Families.Length; i++)
			{
				listBoxFontMenu.Items.Add(myFontCollection.Families[i]);
			}
		}
		
		private void button1_Click(object sender, EventArgs e)
		{
			Form1 form1 = (Form1) this.MdiParent;
			//Form1 form1 = this.Parent as Form1;
			System.Windows.Forms.Label label1 = form1.get_label();
			string selectedFont = listBoxFontMenu.SelectedItem.ToString();
			switch (selectedFont)
			{
				case "OptimusPrinceps":
					label1.Font = new Font(myFontCollection.Families[2], 8);
					break;
				case "Mantinia":
					label1.Font = new Font(myFontCollection.Families[0], 24);
					break;
				case "SlideR":
					label1.Font = new Font(myFontCollection.Families[1], 24);
					break;
				case "Mason Chronicles":
					label1.Font = new Font(myFontCollection.Families[3], 24);
					break;
			}
		}
	}
	}
