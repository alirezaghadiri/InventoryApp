﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryApp.WinUi
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var splashForm = new view.systemform.SplashScreenForm();
            if (splashForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Form1());
            }

            else
            {
                Application.Exit();
            }
        }
    }
}
