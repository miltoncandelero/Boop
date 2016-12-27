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
            this.File = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnBoop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt3DS = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnPickFiles = new System.Windows.Forms.Button();
            this.HomeMadeGettoDivider = new System.Windows.Forms.Label();
            this.linkWhat = new System.Windows.Forms.LinkLabel();
            this.lblIPMarker = new System.Windows.Forms.Label();
            this.lblFileMarker = new System.Windows.Forms.Label();
            this.lblUpdates = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnGithub = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.PictureBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAbout)).BeginInit();
            this.SuspendLayout();
            // 
            // lvFileList
            // 
            this.lvFileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.File});
            this.lvFileList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvFileList.FullRowSelect = true;
            this.lvFileList.GridLines = true;
            this.lvFileList.Location = new System.Drawing.Point(12, 226);
            this.lvFileList.Name = "lvFileList";
            this.lvFileList.Size = new System.Drawing.Size(350, 198);
            this.lvFileList.TabIndex = 1;
            this.lvFileList.UseCompatibleStateImageBehavior = false;
            this.lvFileList.View = System.Windows.Forms.View.Details;
            // 
            // File
            // 
            this.File.Text = "Files to boop";
            this.File.Width = 346;
            // 
            // btnBoop
            // 
            this.btnBoop.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoop.Location = new System.Drawing.Point(12, 430);
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
            this.label1.Location = new System.Drawing.Point(9, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "3DS IP address: ";
            // 
            // txt3DS
            // 
            this.txt3DS.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt3DS.Location = new System.Drawing.Point(115, 194);
            this.txt3DS.MaxLength = 15;
            this.txt3DS.Name = "txt3DS";
            this.txt3DS.Size = new System.Drawing.Size(104, 25);
            this.txt3DS.TabIndex = 6;
            this.txt3DS.Text = "192.168.1.1";
            this.txt3DS.TextChanged += new System.EventHandler(this.txt3DS_TextChanged);
            this.txt3DS.Leave += new System.EventHandler(this.txt3DS_Leave);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 485);
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
            this.btnPickFiles.Location = new System.Drawing.Point(286, 190);
            this.btnPickFiles.Name = "btnPickFiles";
            this.btnPickFiles.Size = new System.Drawing.Size(76, 30);
            this.btnPickFiles.TabIndex = 0;
            this.btnPickFiles.Text = "Pick files";
            this.btnPickFiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPickFiles.UseVisualStyleBackColor = true;
            this.btnPickFiles.Click += new System.EventHandler(this.btnPickFiles_Click);
            // 
            // HomeMadeGettoDivider
            // 
            this.HomeMadeGettoDivider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.HomeMadeGettoDivider.Location = new System.Drawing.Point(274, 190);
            this.HomeMadeGettoDivider.Name = "HomeMadeGettoDivider";
            this.HomeMadeGettoDivider.Size = new System.Drawing.Size(2, 30);
            this.HomeMadeGettoDivider.TabIndex = 12;
            this.HomeMadeGettoDivider.Text = "label2";
            // 
            // linkWhat
            // 
            this.linkWhat.AutoSize = true;
            this.linkWhat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkWhat.Location = new System.Drawing.Point(225, 197);
            this.linkWhat.Name = "linkWhat";
            this.linkWhat.Size = new System.Drawing.Size(46, 17);
            this.linkWhat.TabIndex = 13;
            this.linkWhat.TabStop = true;
            this.linkWhat.Text = "My IP?";
            this.linkWhat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkWhat_LinkClicked);
            // 
            // lblIPMarker
            // 
            this.lblIPMarker.BackColor = System.Drawing.Color.Red;
            this.lblIPMarker.Location = new System.Drawing.Point(114, 193);
            this.lblIPMarker.Name = "lblIPMarker";
            this.lblIPMarker.Size = new System.Drawing.Size(106, 27);
            this.lblIPMarker.TabIndex = 14;
            this.lblIPMarker.Visible = false;
            // 
            // lblFileMarker
            // 
            this.lblFileMarker.BackColor = System.Drawing.Color.Red;
            this.lblFileMarker.Location = new System.Drawing.Point(285, 189);
            this.lblFileMarker.Name = "lblFileMarker";
            this.lblFileMarker.Size = new System.Drawing.Size(78, 32);
            this.lblFileMarker.TabIndex = 15;
            this.lblFileMarker.Visible = false;
            // 
            // lblUpdates
            // 
            this.lblUpdates.AutoSize = true;
            this.lblUpdates.Enabled = false;
            this.lblUpdates.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdates.Location = new System.Drawing.Point(12, 7);
            this.lblUpdates.Name = "lblUpdates";
            this.lblUpdates.Size = new System.Drawing.Size(126, 17);
            this.lblUpdates.TabIndex = 16;
            this.lblUpdates.TabStop = true;
            this.lblUpdates.Text = "Looking for updates";
            this.lblUpdates.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblUpdates_LinkClicked);
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
            // btnAbout
            // 
            this.btnAbout.Image = global::Boop.Properties.Resources.Boop1;
            this.btnAbout.Location = new System.Drawing.Point(12, 34);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(350, 150);
            this.btnAbout.TabIndex = 4;
            this.btnAbout.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 507);
            this.Controls.Add(this.lblUpdates);
            this.Controls.Add(this.linkWhat);
            this.Controls.Add(this.HomeMadeGettoDivider);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnGithub);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txt3DS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnBoop);
            this.Controls.Add(this.lvFileList);
            this.Controls.Add(this.btnPickFiles);
            this.Controls.Add(this.lblIPMarker);
            this.Controls.Add(this.lblFileMarker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Boop 1.1.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAbout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPickFiles;
        private System.Windows.Forms.ListView lvFileList;
        private System.Windows.Forms.Button btnBoop;
        private System.Windows.Forms.PictureBox btnAbout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt3DS;
        private System.Windows.Forms.ColumnHeader File;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.Button btnGithub;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Label HomeMadeGettoDivider;
        private System.Windows.Forms.LinkLabel linkWhat;
        private System.Windows.Forms.Label lblIPMarker;
        private System.Windows.Forms.Label lblFileMarker;
        private System.Windows.Forms.LinkLabel lblUpdates;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

