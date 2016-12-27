using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boop
{
    public partial class Form1 : Form
    {
        SimpleHTTPServer myServer; //Server to host the cia files
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
                //Just in case, fixing the firewall again. I honestly want to be good snek now.
                string arguments = "advfirewall firewall delete rule name=\"BOOPFILESERVER\"";
                ProcessStartInfo procStartInfo = new ProcessStartInfo("netsh", arguments);
                
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;

                Process.Start(procStartInfo);
            }
            catch {}
            try
            {
                myServer.Stop();
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
                    lvFileList.Items.Add(Path.GetFileName(item));
                }
                else
                {
                    MessageBox.Show("You picked 2 files that are NOT in the same directory" + Environment.NewLine + "Cross-Directory booping would need the entire computer hosted to the network and that doesn't feel safe in my book." + Environment.NewLine + "Maybe in the future I'll find a way to do this.", "Woah there...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnBoop_Click(object sender, EventArgs e)
        {
            //Gigantic TryCatch for issue #9. It somehow still freezes.
#if DEBUG //Consider closing application on error, and having the try being applied to all builds.
            try
            {
#endif
                if (ValidateIPv4(txt3DS.Text) == false)
            {
                MessageBox.Show("That doesn't look like an IP address." + Environment.NewLine + "An IP address looks something like this: 192.168.1.6" + Environment.NewLine + "(That is: Numbers DOT numbers DOT numbers DOT numbers)", "Error on the IP address", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblIPMarker.Visible = true; //Added red boxes to point out the errors.
                return;
            }

            if (lvFileList.Items.Count == 0)
            {
                MessageBox.Show("Add some files first?", "No files to boop", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblFileMarker.Visible = true; //Added red boxes to point out the errors.
                return;
            }

            //MURDERING YOUR FIREWALL
            //I AM BAD SNEK. MUAHAHAHAHAHA
            //Please consider allowing the user to decide this.  Most TCP/UDP calls will automatically bring the firewall allowance window up.  Doing so should also remove the administrative requirement.
            //Also, most Firewalls allow LAN connections by default.

            string arguments = "advfirewall firewall add rule name=\"BOOPFILESERVER\" dir=in action=allow protocol=TCP localport=8080";
            ProcessStartInfo procStartInfo = new ProcessStartInfo("netsh", arguments);

            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;

            Process.Start(procStartInfo);

            setStatusLabel("Booping... please wait");
            enableControls(false);

            myServer = new SimpleHTTPServer(ActiveDir, 8080);
            
            System.Threading.Thread.Sleep(100);

            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IAsyncResult result = s.BeginConnect(txt3DS.Text, 5000, null, null);

            result.AsyncWaitHandle.WaitOne(5000, true);

            if (!s.Connected)
            {
                s.Close();
                myServer.Stop();
                MessageBox.Show("Failed to connect to 3DS, wrong IP address?", "Connection failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblIPMarker.Visible = true;
                setStatusLabel("Ready");
                enableControls(true);
                return;
            }

            String message = "";
            foreach (var CIA in FilesToBoop)
            {
               message += LocalIP() + ":8080/" + Uri.EscapeUriString(Path.GetFileName(CIA)) + "\n";
            }

            //boop the info to the 3ds...
            byte[] Largo = BitConverter.GetBytes((uint)Encoding.ASCII.GetBytes(message).Length);
            byte[] Adress = Encoding.ASCII.GetBytes(message);

            Array.Reverse(Largo); //Endian fix

            s.Send(AppendTwoByteArrays(Largo, Adress));

            s.BeginReceive(new byte[1], 0,1, 0, new AsyncCallback(GotData), null); //Call me back when the 3ds says something.

#if DEBUG
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
#endif
        }

        private void GotData(IAsyncResult ar)
        {
            
            // now we unlock the controls...
            //Spooky "thread safe" way to access UI from ASYNC.
            this.Invoke((MethodInvoker)delegate
            {
                enableControls(true);
                setStatusLabel("Booping complete!");
            });

            //Fixing your firewall. I am good snek now
            string arguments = "advfirewall firewall delete rule name=\"BOOPFILESERVER\"";
            ProcessStartInfo procStartInfo = new ProcessStartInfo("netsh", arguments);

            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;

            Process.Start(procStartInfo);

            s.Close();
            myServer.Stop();
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
            new Task(CheckForUpdates).Start(); //Async check for updates
            txt3DS.Text = Properties.Settings.Default["saved3DSIP"].ToString();
        }


        public static string LocalIP()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }

        /// <summary>
        /// Validates if the specified string is an IPv4 Address
        /// </summary>
        /// <param name="ipString">The string to compare</param>
        /// <returns>bool</returns>
        /// <remarks>Consider using REGEX for this.  It is less code, and could be faster.  See: https://goo.gl/580E5x </remarks>
        public bool ValidateIPv4(string ipString)
        {
            if (String.IsNullOrWhiteSpace(ipString) || ipString == "0.0.0.0" || ipString == "127.0.0.1")
            {
                return false;
            }

            string[] splitValues = ipString.Split('.');
            if (splitValues.Length != 4)
            {
                return false;
            }

            byte tempForParsing;

            return splitValues.All(r => byte.TryParse(r, out tempForParsing));
        }

        private void enableControls(bool enabled)
        {
            btnBoop.Enabled = enabled;
            btnPickFiles.Enabled = enabled;
            txt3DS.Enabled = enabled;
            btnAbout.Enabled = enabled;
        }

        private void setStatusLabel(String text)
        {
            StatusLabel.Text = text;
        }

        private String saveIPAddress(String newIPAddress)
        {
            newIPAddress = newIPAddress.Trim();
            if (ValidateIPv4(newIPAddress))
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
    }
}
