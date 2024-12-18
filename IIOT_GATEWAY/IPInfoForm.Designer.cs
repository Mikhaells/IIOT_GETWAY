namespace IIOT_GATEWAY
{
    partial class IPInfoForm
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
            tbIpAdd = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(105, 0);
            label1.Name = "label1";
            label1.Size = new Size(110, 19);
            label1.TabIndex = 0;
            label1.Text = "IP ADDRESS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 35);
            label2.Name = "label2";
            label2.Size = new Size(68, 16);
            label2.TabIndex = 1;
            label2.Text = "IP Address";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(71, 35);
            label3.Name = "label3";
            label3.Size = new Size(12, 16);
            label3.TabIndex = 2;
            label3.Text = ":";
            // 
            // tbIpAdd
            // 
            tbIpAdd.Enabled = false;
            tbIpAdd.Location = new Point(87, 32);
            tbIpAdd.Name = "tbIpAdd";
            tbIpAdd.Size = new Size(228, 23);
            tbIpAdd.TabIndex = 3;
            // 
            // IPInfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tbIpAdd);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Enabled = false;
            Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "IPInfoForm";
            Size = new Size(327, 69);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tbIpAdd;
    }
}
