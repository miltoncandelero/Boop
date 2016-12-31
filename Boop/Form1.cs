using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using rmortega77.CsHTTPServer;

namespace Boop
{
    public partial class Form1 : Form
    {        
        CsHTTPServer HTTPServer;
        Socket s; //Socket to tell FBI where the server is
        string[] FilesToBoop; //Files to be boop'd
        string ActiveDir; //Used to mount the server
        UpdateChecker UC; // Update checker.

        public Form1()
        {
            InitializeComponent();

            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);

            //Drag and drop support
            string[] args = Environment.GetCommandLineArgs();
            if (args != null && args.Length > 0) //If drag and drop
            {
                List<String> Boops = new List<String>(); //Initialize a temporal list.
                foreach (string arg in args)
                {
                    if (System.IO.File.Exists(arg)) //Is it a file?
                    {
                        if (Path.GetExtension(arg) == ".cia" || Path.GetExtension(arg) == ".tik") //Is it a supported file?
                        {
                            Boops.Add(arg); //Add it.
                        }
                    }
                }
                if (Boops.Count > 0) //If we had any supported file
                {
                    FilesToBoop = Boops.ToArray(); //Set them
                    ProcessFilenames(); //Add them to the list.
                }
            }

        }

        /// <summary>
        /// Used as a task to not freeze the thread. (I am not really good with asyncs, maybe there are better ways to do this)
        /// </summary>
        private void CheckForUpdates()
        {
            UC = new UpdateChecker();
            try
            {
                if (UC.CheckForUpdates())
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        lblUpdates.Enabled = true;
                        lblUpdates.Text = "New version found!";
                    });
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        lblUpdates.Enabled = false;
                        lblUpdates.Text = "No updates availables";
                    });
                }
            }
            catch (Exception) //Most likely, internet connection is down.
            {
                this.Invoke((MethodInvoker)delegate
                {
                    lblUpdates.Enabled = false;
                    lblUpdates.Text = "Error contacting update server";
                });
            }
        }


        private void OnApplicationExit(object sender, EventArgs e)
        {
            //Individual trycatches to make sure everything is off before leaving.
            try
            {
                HTTPServer.Stop();
            }
            catch { }

            try
            {
                s.Close();
            }
            catch { }

        }

        private void btnPickFiles_Click(object sender, EventArgs e)
        {
            // Create an instance of the open file dialog box.
            lblFileMarker.Visible = false;
            OpenFileDialog OFD = new OpenFileDialog();

            // Set filter options and filter index.
            OFD.Filter = "FBI compatible files (*.cia, *.tik)|*.cia;*.tik";
            //This doesn't really enforce .cia and .tik but it makes it really hard to open other kind of file.
            //Should we enforce it?

            OFD.FilterIndex = 0;

            OFD.Multiselect = true;

            bool? userClickedOK = (OFD.ShowDialog() == DialogResult.OK);


            // Process input if the user clicked OK.
            if (userClickedOK == true)
            {
                if (OFD.FileNames.Length > 0) {
                    lvFileList.Items.Clear();
                    FilesToBoop = OFD.FileNames;
                    ProcessFilenames(); // I splited this button in order to reuse the code for the drag and drop support.
                }

             }
        }

        /// <summary>
        /// Processes The Files
        /// </summary>
        private void ProcessFilenames()
        {
            ActiveDir = (Path.GetDirectoryName(FilesToBoop[0]));

            foreach (string item in FilesToBoop)
            {
                if (ActiveDir == Path.GetDirectoryName(item))
                {
                    if (Path.GetExtension(item) == ".cia")
                    {
                        byte[] desc = new Byte[256];

                        byte[] tit = new Byte[128];

                        using (BinaryReader b = new BinaryReader(File.Open(item, FileMode.Open)))
                        {
                            b.BaseStream.Seek(-14016 + 520, SeekOrigin.End);
                            tit = b.ReadBytes(128);

                            b.BaseStream.Seek(-14016 + 520 + 128, SeekOrigin.End);
                            desc = b.ReadBytes(256);
                        }

                        string[] tmp = new string[3];
                        tmp[0] = Path.GetFileName(item);
                        tmp[1] = Encoding.Unicode.GetString(tit).Trim();
                        tmp[2] = Encoding.Unicode.GetString(desc).Trim();



                        lvFileList.Items.Add(new ListViewItem(tmp));
                    }
                    else
                    {
                        lvFileList.Items.Add(Path.GetFileName(item));
                    }

                }
                else
                {
                    MessageBox.Show("You picked 2 files that are NOT in the same directory" + Environment.NewLine + "Cross-Directory booping would need the entire computer hosted to the network and that doesn't feel safe in my book." + Environment.NewLine + "Maybe in the future I'll find a way to do this.", "Woah there...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnBoop_Click(object sender, EventArgs e)
        {
            //Try catch will go away in the future. Left in case somebody still has trouble with the server.

            try
            {
                //#endif

                //Fastest check first.
            if (lvFileList.Items.Count == 0)
            {
                MessageBox.Show("Add some files first?", "No files to boop", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblFileMarker.Visible = true; //Added red boxes to point out the errors.
                return;
            }


            string s3DSip = "";
            if (chkGuess.Checked)
            {
                setStatusLabel("Guessing 3DS IP adress...");
                s3DSip = NetUtil.IPv4.GetFirst3DS();
                if (s3DSip == "")
                {
                    MessageBox.Show("Cannot detect the 3DS in the network" + Environment.NewLine + "Try writing the IP adress manually", "Connection failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblIPMarker.Visible = true; //Added red boxes to point out the errors.
                    setStatusLabel("Ready");
                    return;
                }

                }
                else
            {
                if (NetUtil.IPv4.Validate(txt3DS.Text) == false)
                {
                    MessageBox.Show("That doesn't look like an IP address." + Environment.NewLine + "An IP address looks something like this: 192.168.1.6" + Environment.NewLine + "(That is: Numbers DOT numbers DOT numbers DOT numbers)", "Error on the IP address", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblIPMarker.Visible = true; //Added red boxes to point out the errors.
                    setStatusLabel("Ready");
                    return;
                }

                s3DSip = txt3DS.Text;
            }

                // THE FIREWALL IS NO LONGER POKED!
                // THE SNEK IS FREE FROM THE HTTPLISTENER TIRANY!

            setStatusLabel("Opening the new and improved snek server...");
            enableControls(false);

            HTTPServer = new MyServer(8080, ActiveDir);
            HTTPServer.Start();
                
            
            System.Threading.Thread.Sleep(100);

            setStatusLabel("Opening socket to send the file list...");

            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                IAsyncResult result = s.BeginConnect(s3DSip, 5000, null, null);
                result.AsyncWaitHandle.WaitOne(5000, true);

                if (!s.Connected)
                {
                    s.Close();
                    HTTPServer.Stop();
                    MessageBox.Show("Failed to connect to 3DS"+Environment.NewLine+"Please check:"+Environment.NewLine+ "Did you write the right IP adress?" +Environment.NewLine + "Is FBI open and listening?", "Connection failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblIPMarker.Visible = true;
                    setStatusLabel("Ready");
                    enableControls(true);
                    return;
                }

                setStatusLabel("Sending the file list...");

            String message = "";
            foreach (var CIA in FilesToBoop)
            {
               message += NetUtil.IPv4.Local + ":8080/" + Uri.EscapeUriString(Path.GetFileName(CIA)) + "\n";
            }

            //boop the info to the 3ds...
            byte[] Largo = BitConverter.GetBytes((uint)Encoding.ASCII.GetBytes(message).Length);
            byte[] Adress = Encoding.ASCII.GetBytes(message);

            Array.Reverse(Largo); //Endian fix

            s.Send(AppendTwoByteArrays(Largo, Adress));

            setStatusLabel("Booping files... Please wait");
            s.BeginReceive(new byte[1], 0,1, 0, new AsyncCallback(GotData), null); //Call me back when the 3ds says something.

//#if DEBUG
            }
            catch (Exception ex)
            {
                //Hopefully, some day we can have all the different exceptions handled... One can dream, right? *-*
                MessageBox.Show("Something went really wrong: " + Environment.NewLine + Environment.NewLine + "\"" + ex.Message + "\"" + Environment.NewLine + Environment.NewLine + "If this keeps happening, please take a screenshot of this message and post it on our github." + Environment.NewLine + Environment.NewLine + "The program will close now","Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Application.Exit();
            }
//#endif
        }

        private void GotData(IAsyncResult ar)
        {
            
            // now we unlock the controls...
            //Spooky "thread safe" way to access UI from ASYNC.
            this.Invoke((MethodInvoker)delegate
            {
                enableControls(true);
                setStatusLabel("Booping complete!");
                MessageBox.Show("Booping complete!", "Yay!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });

            s.Close();
            HTTPServer.Stop();
        }

        static byte[] AppendTwoByteArrays(byte[] arrayA, byte[] arrayB) //Aux function to append the 2 byte arrays.
        {
            byte[] outputBytes = new byte[arrayA.Length + arrayB.Length];
            Buffer.BlockCopy(arrayA, 0, outputBytes, 0, arrayA.Length);
            Buffer.BlockCopy(arrayB, 0, outputBytes, arrayA.Length, arrayB.Length);
            return outputBytes;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblImageVersion.Text = UpdateChecker.GetCurrentVersion();
            this.Text = "Boop " + UpdateChecker.GetCurrentVersion();
            new Task(CheckForUpdates).Start(); //Async check for updates
            txt3DS.Text = Properties.Settings.Default["saved3DSIP"].ToString();
            chkGuess.Checked = (bool) Properties.Settings.Default["bGuess"];
            txt3DS.Enabled = !chkGuess.Checked;
        }

        private void enableControls(bool enabled)
        {
            btnBoop.Enabled = enabled;
            btnPickFiles.Enabled = enabled;
            chkGuess.Enabled = enabled;
            if (chkGuess.Checked) txt3DS.Enabled = false; else txt3DS.Enabled = enabled;
            btnAbout.Enabled = enabled;
        }

        private void setStatusLabel(String text)
        {
            StatusLabel.Text = text;
            //Force-update text to appear. If we still crash from #9 we should get where it crashed.
            statusStrip1.Invalidate();
            statusStrip1.Refresh();
        }

        private String saveIPAddress(String newIPAddress)
        {
            newIPAddress = newIPAddress.Trim();
            if (NetUtil.IPv4.Validate(newIPAddress))
            {
                Properties.Settings.Default["saved3DSIP"] = newIPAddress;
                Properties.Settings.Default.Save();
            }
            return newIPAddress;
        }

        private void txt3DS_Leave(object sender, EventArgs e)
        {
            txt3DS.Text = saveIPAddress(txt3DS.Text);
        }

        private void txt3DS_TextChanged(object sender, EventArgs e)
        {
            saveIPAddress(txt3DS.Text);
            lblIPMarker.Visible = false;
        }

        private void linkWhat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //Added help picture to find IP adress.
        {
            MyIP frmIP = new MyIP();
            frmIP.ShowDialog();
        }

        private void btnGithub_Click(object sender, EventArgs e) //New cooler github button
        {
            Process.Start(@"https://github.com/miltoncandelero/Boop");
        }

        private void lblUpdates_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //Go to update page
        {
            Process.Start(UC.sUrl);
        }

        private void btnInfo_Click(object sender, EventArgs e) //New super cool snek about form
        {
            InfoBox frmInfo = new InfoBox();
            frmInfo.ShowDialog();
        }

        private void chkGuess_CheckedChanged(object sender, EventArgs e)
        {
            txt3DS.Enabled = !chkGuess.Checked;
            Properties.Settings.Default["bGuess"] = chkGuess.Checked;
            Properties.Settings.Default.Save();
        }

        private void lvFileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Pls no touching the snek list.
            lvFileList.SelectedIndices.Clear();
        }
    }
}
