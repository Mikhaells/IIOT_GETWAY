namespace IIOT_GATEWAY
{
    partial class IIOT_Gateway
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabPage1 = new TabPage();
            btSearch = new Button();
            pnlHome = new Panel();
            trDeviceList = new TreeView();
            tabControl1 = new TabControl();
            lblInfo = new Label();
            tabPage1.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btSearch);
            tabPage1.Controls.Add(pnlHome);
            tabPage1.Controls.Add(trDeviceList);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(893, 471);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Home";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btSearch
            // 
            btSearch.Location = new Point(6, 6);
            btSearch.Name = "btSearch";
            btSearch.Size = new Size(177, 23);
            btSearch.TabIndex = 1;
            btSearch.Text = "Search";
            btSearch.UseVisualStyleBackColor = true;
            // 
            // pnlHome
            // 
            pnlHome.Location = new Point(189, 6);
            pnlHome.Name = "pnlHome";
            pnlHome.Size = new Size(698, 459);
            pnlHome.TabIndex = 1;
            // 
            // trDeviceList
            // 
            trDeviceList.Location = new Point(6, 35);
            trDeviceList.Name = "trDeviceList";
            trDeviceList.Size = new Size(177, 430);
            trDeviceList.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(901, 499);
            tabControl1.TabIndex = 0;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(12, 514);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(12, 15);
            lblInfo.TabIndex = 1;
            lblInfo.Text = "-";
            // 
            // IIOT_Gateway
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(925, 535);
            Controls.Add(lblInfo);
            Controls.Add(tabControl1);
            Name = "IIOT_Gateway";
            Text = "IIOT_Gateway";
            tabPage1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabPage tabPage1;
        private Panel pnlHome;
        private TreeView trDeviceList;
        private TabControl tabControl1;
        private Button btSearch;
        private Label lblInfo;
    }
}