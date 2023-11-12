using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		//public static Form1 form1  = new Form1();
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
