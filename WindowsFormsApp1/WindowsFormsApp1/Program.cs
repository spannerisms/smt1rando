global using System;
global using System.Text;
global using System.Linq;
global using System.Collections.Generic;
global using System.Diagnostics;
global using System.Reflection;
global using System.Drawing;
global using System.IO;


global using SMTRandoApp.Modeling;
global using SMTRandoApp.Modeling.Dungeons;
global using SMTRandoApp.Randomization;
global using SMTRandoApp.SMTROM;
global using SMTRandoApp.Translation;
global using SMTRandoApp.Utility;

global using static SMTRandoApp.Utility.Constants;
global using static SMTRandoApp.Utility.IntFunctions;
global using static SMTRandoApp.Utility.ConsistentRandom;

using System.Windows.Forms;

namespace SMTRandoApp;
internal static class Program
{
	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main()
	{
		Application.EnableVisualStyles();
		Application.SetHighDpiMode(HighDpiMode.SystemAware);
		Application.SetCompatibleTextRenderingDefault(false);
		Application.Run(new MainForm());
	}
}
