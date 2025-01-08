namespace IIOT_GATEWAY
{
    partial class SetDataForm
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
            label2 = new Label();
            label3 = new Label();
            tbCoil = new TextBox();
            tbVal = new TextBox();
            label4 = new Label();
            label5 = new Label();
            btSet = new Button();
            tbIPAdd = new TextBox();
            label8 = new Label();
            label9 = new Label();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(254, 13);
            label1.Name = "label1";
            label1.Size = new Size(156, 19);
            label1.TabIndex = 0;
            label1.Text = "SET DATA TO PLC";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(199, 82);
            label2.Name = "label2";
            label2.Size = new Size(28, 16);
            label2.TabIndex = 1;
            label2.Text = "Coil";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(273, 82);
            label3.Name = "label3";
            label3.Size = new Size(12, 16);
            label3.TabIndex = 2;
            label3.Text = ":";
            // 
            // tbCoil
            // 
            tbCoil.Location = new Point(291, 80);
            tbCoil.Name = "tbCoil";
            tbCoil.Size = new Size(211, 23);
            tbCoil.TabIndex = 3;
            // 
            // tbVal
            // 
            tbVal.Location = new Point(291, 109);
            tbVal.Name = "tbVal";
            tbVal.Size = new Size(211, 23);
            tbVal.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(273, 111);
            label4.Name = "label4";
            label4.Size = new Size(12, 16);
            label4.TabIndex = 5;
            label4.Text = ":";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(199, 111);
            label5.Name = "label5";
            label5.Size = new Size(39, 16);
            label5.TabIndex = 4;
            label5.Text = "Value";
            // 
            // btSet
            // 
            btSet.BackColor = Color.Green;
            btSet.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btSet.ForeColor = SystemColors.Control;
            btSet.Location = new Point(199, 138);
            btSet.Name = "btSet";
            btSet.Size = new Size(310, 23);
            btSet.TabIndex = 10;
            btSet.Text = "SET";
            btSet.UseVisualStyleBackColor = false;
            // 
            // tbIPAdd
            // 
            tbIPAdd.Location = new Point(291, 51);
            tbIPAdd.Name = "tbIPAdd";
            tbIPAdd.Size = new Size(211, 23);
            tbIPAdd.TabIndex = 13;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(273, 55);
            label8.Name = "label8";
            label8.Size = new Size(12, 16);
            label8.TabIndex = 12;
            label8.Text = ":";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(199, 53);
            label9.Name = "label9";
            label9.Size = new Size(68, 16);
            label9.TabIndex = 11;
            label9.Text = "IP Address";
            // 
            // panel1
            // 
            panel1.BackColor = Color.SeaGreen;
            panel1.Location = new Point(10, 35);
            panel1.Name = "panel1";
            panel1.Size = new Size(678, 10);
            panel1.TabIndex = 14;
            // 
            // SetDataForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(tbIPAdd);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(btSet);
            Controls.Add(tbVal);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(tbCoil);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SetDataForm";
            Size = new Size(698, 166);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tbCoil;
        private TextBox tbVal;
        private Label label4;
        private Label label5;
        private Button btSet;
        private TextBox tbIPAdd;
        private Label label8;
        private Label label9;
        private Panel panel1;
    }
}
