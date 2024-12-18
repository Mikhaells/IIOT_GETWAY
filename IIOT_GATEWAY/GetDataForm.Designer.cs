namespace IIOT_GATEWAY
{
    partial class GetDataForm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            tbIpAddress = new TextBox();
            btGet = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(267, 0);
            label1.Name = "label1";
            label1.Size = new Size(130, 19);
            label1.TabIndex = 0;
            label1.Text = "Data From PLC";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 62);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(692, 394);
            dataGridView1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 35);
            label2.Name = "label2";
            label2.Size = new Size(68, 16);
            label2.TabIndex = 2;
            label2.Text = "IP Address";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(77, 35);
            label3.Name = "label3";
            label3.Size = new Size(12, 16);
            label3.TabIndex = 3;
            label3.Text = ":";
            // 
            // tbIpAddress
            // 
            tbIpAddress.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbIpAddress.Location = new Point(95, 33);
            tbIpAddress.Name = "tbIpAddress";
            tbIpAddress.Size = new Size(478, 23);
            tbIpAddress.TabIndex = 4;
            // 
            // btGet
            // 
            btGet.BackColor = Color.DarkGreen;
            btGet.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btGet.ForeColor = SystemColors.Control;
            btGet.Location = new Point(579, 33);
            btGet.Name = "btGet";
            btGet.Size = new Size(116, 23);
            btGet.TabIndex = 5;
            btGet.Text = "Get Data";
            btGet.UseVisualStyleBackColor = false;
            // 
            // GetDataForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btGet);
            Controls.Add(tbIpAddress);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Name = "GetDataForm";
            Size = new Size(698, 459);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private Label label2;
        private Label label3;
        private TextBox tbIpAddress;
        private Button btGet;
    }
}
