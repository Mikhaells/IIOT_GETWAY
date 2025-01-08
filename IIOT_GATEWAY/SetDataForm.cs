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
    public partial class SetDataForm : UserControl
    {
        Controller _controller = new Controller();
        IIOT_Gateway _iiotGateway;
        public SetDataForm(IIOT_Gateway mainForm)
        {
            InitializeComponent();
            btSet.Click += BtSet_Click;
            _iiotGateway = mainForm;
        }

        private void BtSet_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbIPAdd.Text) || string.IsNullOrEmpty(tbCoil.Text) || string.IsNullOrEmpty(tbVal.Text))
            {
                MessageBox.Show("Please Fill all field first !!!", "WARNING !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string buildString = string.Empty;
            buildString = $@"IpAdd={tbIPAdd.Text},Address={tbCoil.Text},Value={tbVal.Text}";

           string Json =  _controller.CreateJsonString("SetCoil",buildString); 
            _iiotGateway.PublishTopicAsync(Json);


        }
    }
}
