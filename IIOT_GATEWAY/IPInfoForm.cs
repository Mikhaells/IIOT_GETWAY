﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IIOT_GATEWAY
{
    public partial class IPInfoForm : UserControl
    {

        public string TextBoxValue
        {
            get => tbIpAdd.Text;         
            set => tbIpAdd.Text = value; 
        }

        public IPInfoForm()
        {
            InitializeComponent();
        }
    }
}
