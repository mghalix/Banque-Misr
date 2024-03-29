﻿using Banque_Misr.Control;
using Banque_Misr.Model;
using System;
using System.IO;
using System.Windows.Forms;

namespace Banque_Misr {
  internal static class Program {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() {
      DatabaseHandler dataHandler = DatabaseHandler.GetInstance();
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      FileStream fs = new FileStream("ClientInfo.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
      StreamReader sr = new StreamReader(fs);
      if (sr.ReadLine() == ((int)Mode.Dark).ToString())
        Preferences.Mode = Mode.Dark;
      else
        Preferences.Mode = Mode.Light;
      sr.Close();
      fs.Close();

      Application.Run(new FrmLogin());
    }
  }
}
