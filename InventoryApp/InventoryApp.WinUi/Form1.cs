﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryApp.Repositories;
using InventoryApp.RepositortAbstracts;
using InventoryApp.Entities;

namespace InventoryApp.WinUi
{
    public partial class Form1 : Framwork.MainFormBase
    {
        public Form1()
        {
            InitializeComponent(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            viewEngine.ViewInForm<view.Corporation.Add>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ICorporation corporation = new CorporationRepository();
            lblcorporation.Text = string.Format("تعداد شرکت : {0} شرکت", corporation.Count());
        }
    }
}
