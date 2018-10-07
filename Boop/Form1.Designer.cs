namespace Boop
{
    partial class Form1
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.lvFileList = new System.Windows.Forms.ListView();
			this.CiaFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.CiaName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.CiaDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnBoop = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtConsole = new System.Windows.Forms.TextBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.btnPickFiles = new System.Windows.Forms.Button();
			this.HomeMadeGettoDivider = new System.Windows.Forms.Label();
			this.linkWhat = new System.Windows.Forms.LinkLabel();
			this.lblIPMarker = new System.Windows.Forms.Label();
			this.lblFileMarker = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.btnInfo = new System.Windows.Forms.Button();
			this.btnGithub = new System.Windows.Forms.Button();
			this.lblImageVersion = new System.Windows.Forms.Label();
			this.cboLocalIP = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lblPCIP = new System.Windows.Forms.LinkLabel();
			this.label4 = new System.Windows.Forms.Label();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.lblPortMarker = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.picSplash = new System.Windows.Forms.PictureBox();
			this.lblMode = new System.Windows.Forms.Label();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picSplash)).BeginInit();
			this.SuspendLayout();
			// 
			// lvFileList
			// 
			this.lvFileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CiaFile,
            this.CiaName,
            this.CiaDesc});
			this.lvFileList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lvFileList.FullRowSelect = true;
			this.lvFileList.GridLines = true;
			this.lvFileList.Location = new System.Drawing.Point(12, 328);
			this.lvFileList.Name = "lvFileList";
			this.lvFileList.Size = new System.Drawing.Size(350, 179);
			this.lvFileList.TabIndex = 1;
			this.lvFileList.UseCompatibleStateImageBehavior = false;
			this.lvFileList.View = System.Windows.Forms.View.Details;
			this.lvFileList.SelectedIndexChanged += new System.EventHandler(this.lvFileList_SelectedIndexChanged);
			// 
			// CiaFile
			// 
			this.CiaFile.Text = "File";
			this.CiaFile.Width = 150;
			// 
			// CiaName
			// 
			this.CiaName.Text = "Name";
			this.CiaName.Width = 150;
			// 
			// CiaDesc
			// 
			this.CiaDesc.Text = "Description";
			this.CiaDesc.Width = 300;
			// 
			// btnBoop
			// 
			this.btnBoop.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnBoop.Location = new System.Drawing.Point(12, 513);
			this.btnBoop.Name = "btnBoop";
			this.btnBoop.Size = new System.Drawing.Size(350, 42);
			this.btnBoop.TabIndex = 2;
			this.btnBoop.Text = "BOOP";
			this.btnBoop.UseVisualStyleBackColor = true;
			this.btnBoop.Click += new System.EventHandler(this.btnBoop_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 259);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(127, 17);
			this.label1.TabIndex = 5;
			this.label1.Text = "Console IP address: ";
			// 
			// txtConsole
			// 
			this.txtConsole.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtConsole.Location = new System.Drawing.Point(144, 256);
			this.txtConsole.MaxLength = 15;
			this.txtConsole.Name = "txtConsole";
			this.txtConsole.Size = new System.Drawing.Size(104, 25);
			this.txtConsole.TabIndex = 6;
			this.txtConsole.Text = "192.168.1.1";
			this.txtConsole.TextChanged += new System.EventHandler(this.txt3DS_TextChanged);
			this.txtConsole.Leave += new System.EventHandler(this.txt3DS_Leave);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
			this.statusStrip1.Location = new System.Drawing.Point(0, 561);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(373, 22);
			this.statusStrip1.TabIndex = 7;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// StatusLabel
			// 
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size(44, 17);
			this.StatusLabel.Text = "Ready";
			// 
			// btnPickFiles
			// 
			this.btnPickFiles.AutoSize = true;
			this.btnPickFiles.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnPickFiles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnPickFiles.Location = new System.Drawing.Point(12, 292);
			this.btnPickFiles.Name = "btnPickFiles";
			this.btnPickFiles.Size = new System.Drawing.Size(350, 30);
			this.btnPickFiles.TabIndex = 0;
			this.btnPickFiles.Text = "Pick files";
			this.btnPickFiles.UseVisualStyleBackColor = true;
			this.btnPickFiles.Click += new System.EventHandler(this.btnPickFiles_Click);
			// 
			// HomeMadeGettoDivider
			// 
			this.HomeMadeGettoDivider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.HomeMadeGettoDivider.Location = new System.Drawing.Point(12, 287);
			this.HomeMadeGettoDivider.Name = "HomeMadeGettoDivider";
			this.HomeMadeGettoDivider.Size = new System.Drawing.Size(352, 2);
			this.HomeMadeGettoDivider.TabIndex = 12;
			this.HomeMadeGettoDivider.Text = "label2";
			// 
			// linkWhat
			// 
			this.linkWhat.AutoSize = true;
			this.linkWhat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.linkWhat.Location = new System.Drawing.Point(259, 259);
			this.linkWhat.Name = "linkWhat";
			this.linkWhat.Size = new System.Drawing.Size(110, 17);
			this.linkWhat.TabIndex = 13;
			this.linkWhat.TabStop = true;
			this.linkWhat.Text = "What is an my IP?";
			this.linkWhat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkWhat_LinkClicked);
			// 
			// lblIPMarker
			// 
			this.lblIPMarker.BackColor = System.Drawing.Color.Red;
			this.lblIPMarker.Location = new System.Drawing.Point(143, 255);
			this.lblIPMarker.Name = "lblIPMarker";
			this.lblIPMarker.Size = new System.Drawing.Size(106, 27);
			this.lblIPMarker.TabIndex = 14;
			this.lblIPMarker.Visible = false;
			// 
			// lblFileMarker
			// 
			this.lblFileMarker.BackColor = System.Drawing.Color.Red;
			this.lblFileMarker.Location = new System.Drawing.Point(11, 291);
			this.lblFileMarker.Name = "lblFileMarker";
			this.lblFileMarker.Size = new System.Drawing.Size(352, 32);
			this.lblFileMarker.TabIndex = 15;
			this.lblFileMarker.Visible = false;
			// 
			// btnInfo
			// 
			this.btnInfo.AutoSize = true;
			this.btnInfo.Image = global::Boop.Properties.Resources.info;
			this.btnInfo.Location = new System.Drawing.Point(295, 2);
			this.btnInfo.Name = "btnInfo";
			this.btnInfo.Size = new System.Drawing.Size(29, 29);
			this.btnInfo.TabIndex = 11;
			this.toolTip1.SetToolTip(this.btnInfo, "About Boop");
			this.btnInfo.UseVisualStyleBackColor = true;
			this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
			// 
			// btnGithub
			// 
			this.btnGithub.AutoSize = true;
			this.btnGithub.Image = global::Boop.Properties.Resources.github;
			this.btnGithub.Location = new System.Drawing.Point(330, 2);
			this.btnGithub.Name = "btnGithub";
			this.btnGithub.Size = new System.Drawing.Size(29, 29);
			this.btnGithub.TabIndex = 10;
			this.toolTip1.SetToolTip(this.btnGithub, "Fork us on GitHub");
			this.btnGithub.UseVisualStyleBackColor = true;
			this.btnGithub.Click += new System.EventHandler(this.btnGithub_Click);
			// 
			// lblImageVersion
			// 
			this.lblImageVersion.BackColor = System.Drawing.Color.Transparent;
			this.lblImageVersion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblImageVersion.ForeColor = System.Drawing.Color.White;
			this.lblImageVersion.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.lblImageVersion.Location = new System.Drawing.Point(201, 149);
			this.lblImageVersion.Name = "lblImageVersion";
			this.lblImageVersion.Size = new System.Drawing.Size(160, 34);
			this.lblImageVersion.TabIndex = 18;
			this.lblImageVersion.Text = "0.0.0";
			this.lblImageVersion.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// cboLocalIP
			// 
			this.cboLocalIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboLocalIP.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cboLocalIP.FormattingEnabled = true;
			this.cboLocalIP.Items.AddRange(new object[] {
            "666.666.666.666"});
			this.cboLocalIP.Location = new System.Drawing.Point(144, 188);
			this.cboLocalIP.Name = "cboLocalIP";
			this.cboLocalIP.Size = new System.Drawing.Size(125, 25);
			this.cboLocalIP.TabIndex = 19;
			this.cboLocalIP.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 191);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(131, 17);
			this.label2.TabIndex = 20;
			this.label2.Text = "Computer IP Adress: ";
			// 
			// label3
			// 
			this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label3.Location = new System.Drawing.Point(15, 250);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(352, 2);
			this.label3.TabIndex = 21;
			this.label3.Text = "label2";
			// 
			// lblPCIP
			// 
			this.lblPCIP.AutoEllipsis = true;
			this.lblPCIP.AutoSize = true;
			this.lblPCIP.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPCIP.Location = new System.Drawing.Point(277, 191);
			this.lblPCIP.Name = "lblPCIP";
			this.lblPCIP.Size = new System.Drawing.Size(86, 17);
			this.lblPCIP.TabIndex = 22;
			this.lblPCIP.TabStop = true;
			this.lblPCIP.Text = "Computer IP?";
			this.lblPCIP.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblPCIP_LinkClicked);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(12, 222);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(101, 17);
			this.label4.TabIndex = 23;
			this.label4.Text = "Computer Port: ";
			// 
			// txtPort
			// 
			this.txtPort.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPort.Location = new System.Drawing.Point(144, 219);
			this.txtPort.MaxLength = 15;
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(44, 25);
			this.txtPort.TabIndex = 24;
			this.txtPort.Text = "8080";
			this.txtPort.TextChanged += new System.EventHandler(this.txtPort_TextChanged);
			// 
			// lblPortMarker
			// 
			this.lblPortMarker.BackColor = System.Drawing.Color.Red;
			this.lblPortMarker.Location = new System.Drawing.Point(143, 218);
			this.lblPortMarker.Name = "lblPortMarker";
			this.lblPortMarker.Size = new System.Drawing.Size(46, 27);
			this.lblPortMarker.TabIndex = 25;
			this.lblPortMarker.Visible = false;
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoEllipsis = true;
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.linkLabel1.Location = new System.Drawing.Point(194, 222);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(169, 17);
			this.linkLabel1.TabIndex = 26;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "and now Port? What is this?";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// picSplash
			// 
			this.picSplash.Image = ((System.Drawing.Image)(resources.GetObject("picSplash.Image")));
			this.picSplash.Location = new System.Drawing.Point(12, 34);
			this.picSplash.Name = "picSplash";
			this.picSplash.Size = new System.Drawing.Size(350, 150);
			this.picSplash.TabIndex = 4;
			this.picSplash.TabStop = false;
			// 
			// lblMode
			// 
			this.lblMode.AutoSize = true;
			this.lblMode.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMode.Location = new System.Drawing.Point(12, 2);
			this.lblMode.Name = "lblMode";
			this.lblMode.Size = new System.Drawing.Size(0, 30);
			this.lblMode.TabIndex = 27;
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(373, 583);
			this.Controls.Add(this.lblMode);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.txtPort);
			this.Controls.Add(this.lblPortMarker);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lblPCIP);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cboLocalIP);
			this.Controls.Add(this.lblImageVersion);
			this.Controls.Add(this.linkWhat);
			this.Controls.Add(this.HomeMadeGettoDivider);
			this.Controls.Add(this.btnInfo);
			this.Controls.Add(this.btnGithub);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.txtConsole);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.picSplash);
			this.Controls.Add(this.btnBoop);
			this.Controls.Add(this.lvFileList);
			this.Controls.Add(this.btnPickFiles);
			this.Controls.Add(this.lblIPMarker);
			this.Controls.Add(this.lblFileMarker);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Boop 1.2.0";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picSplash)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPickFiles;
        private System.Windows.Forms.ListView lvFileList;
        private System.Windows.Forms.Button btnBoop;
        private System.Windows.Forms.PictureBox picSplash;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.ColumnHeader CiaFile;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.Button btnGithub;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Label HomeMadeGettoDivider;
        private System.Windows.Forms.LinkLabel linkWhat;
        private System.Windows.Forms.Label lblIPMarker;
        private System.Windows.Forms.Label lblFileMarker;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ColumnHeader CiaName;
        private System.Windows.Forms.ColumnHeader CiaDesc;
        private System.Windows.Forms.Label lblImageVersion;
        private System.Windows.Forms.ComboBox cboLocalIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel lblPCIP;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.Label lblPortMarker;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Label lblMode;
	}
}

