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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.lvFileList = new System.Windows.Forms.ListView();
            this.File = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnBoop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt3DS = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnAbout = new System.Windows.Forms.PictureBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAbout)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(287, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Pick files";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lvFileList
            // 
            this.lvFileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.File});
            this.lvFileList.FullRowSelect = true;
            this.lvFileList.GridLines = true;
            this.lvFileList.Location = new System.Drawing.Point(12, 201);
            this.lvFileList.Name = "lvFileList";
            this.lvFileList.Size = new System.Drawing.Size(350, 151);
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
            this.btnBoop.Location = new System.Drawing.Point(12, 358);
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
            this.label1.Location = new System.Drawing.Point(12, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "3DS IP address: ";
            // 
            // txt3DS
            // 
            this.txt3DS.Location = new System.Drawing.Point(99, 174);
            this.txt3DS.MaxLength = 15;
            this.txt3DS.Name = "txt3DS";
            this.txt3DS.Size = new System.Drawing.Size(92, 20);
            this.txt3DS.TabIndex = 6;
            this.txt3DS.Text = "192.168.1.1";
            this.txt3DS.TextChanged += new System.EventHandler(this.txt3DS_TextChanged);
            this.txt3DS.Leave += new System.EventHandler(this.txt3DS_Leave);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 415);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(375, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(39, 17);
            this.StatusLabel.Text = "Ready";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(160, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(204, 13);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://github.com/miltoncandelero/Boop";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnAbout
            // 
            this.btnAbout.Image = global::Boop.Properties.Resources.Boop;
            this.btnAbout.Location = new System.Drawing.Point(12, 16);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(350, 150);
            this.btnAbout.TabIndex = 4;
            this.btnAbout.TabStop = false;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 437);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txt3DS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnBoop);
            this.Controls.Add(this.lvFileList);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Boop";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAbout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView lvFileList;
        private System.Windows.Forms.Button btnBoop;
        private System.Windows.Forms.PictureBox btnAbout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt3DS;
        private System.Windows.Forms.ColumnHeader File;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

