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
            comboBox1 = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
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
            dataGridView1.Location = new Point(3, 140);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(692, 316);
            dataGridView1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(203, 40);
            label2.Name = "label2";
            label2.Size = new Size(68, 16);
            label2.TabIndex = 2;
            label2.Text = "IP Address";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(277, 40);
            label3.Name = "label3";
            label3.Size = new Size(12, 16);
            label3.TabIndex = 3;
            label3.Text = ":";
            // 
            // tbIpAddress
            // 
            tbIpAddress.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbIpAddress.Location = new Point(295, 38);
            tbIpAddress.Name = "tbIpAddress";
            tbIpAddress.Size = new Size(235, 23);
            tbIpAddress.TabIndex = 4;
            // 
            // btGet
            // 
            btGet.BackColor = Color.DarkGreen;
            btGet.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btGet.ForeColor = SystemColors.Control;
            btGet.Location = new Point(414, 95);
            btGet.Name = "btGet";
            btGet.Size = new Size(116, 23);
            btGet.TabIndex = 5;
            btGet.Text = "Get Data";
            btGet.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "INPUT", "OUTPUT" });
            comboBox1.Location = new Point(295, 67);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(235, 22);
            comboBox1.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(203, 70);
            label4.Name = "label4";
            label4.Size = new Size(35, 14);
            label4.TabIndex = 7;
            label4.Text = "Type";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(277, 69);
            label5.Name = "label5";
            label5.Size = new Size(12, 16);
            label5.TabIndex = 8;
            label5.Text = ":";
            // 
            // panel1
            // 
            panel1.BackColor = Color.SeaGreen;
            panel1.Location = new Point(10, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(678, 10);
            panel1.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.BackColor = Color.SeaGreen;
            panel2.Location = new Point(10, 124);
            panel2.Name = "panel2";
            panel2.Size = new Size(678, 10);
            panel2.TabIndex = 10;
            // 
            // GetDataForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(comboBox1);
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
        private ComboBox comboBox1;
        private Label label4;
        private Label label5;
        private Panel panel1;
        private Panel panel2;
    }
}
