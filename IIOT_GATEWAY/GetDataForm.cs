using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IIOT_GATEWAY
{
    public partial class GetDataForm : UserControl
    {

        IIOT_Gateway _mainForm;
        Controller _controller;
        public GetDataForm(IIOT_Gateway mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            btGet.Click += BtGet_Click;
        }

        private void BtGet_Click(object? sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbIpAddress.Text))
            {
                MessageBox.Show("Please fill IP Address value first !!!");
                return;
            }

            string jSON = _controller.CreateJsonString("GetDataPLC", tbIpAddress.Text);
            _mainForm.PublishTopicAsync(jSON); 
        }
    }
}
