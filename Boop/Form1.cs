using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
        SimpleHTTPServer myServer;
        Socket s;
        String[] FilesToBoop;
        String ActiveDir;

        public Form1()
        {
            InitializeComponent();

            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);

        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
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

        private void button1_Click(object sender, EventArgs e)
        {
            // Create an instance of the open file dialog box.
            OpenFileDialog OFD = new OpenFileDialog();

            // Set filter options and filter index.
            OFD.Filter = "FBI compatible files (*.cia, *.tik)|*.cia;*.tik";
            OFD.FilterIndex = 0;

            OFD.Multiselect = true;

            // Call the ShowDialog method to show the dialog box.



            bool? userClickedOK = (OFD.ShowDialog() == DialogResult.OK);


            // Process input if the user clicked OK.
            if (userClickedOK == true)
            {
                if (OFD.FileNames.Length > 0) {
                    lvFileList.Items.Clear();
                    FilesToBoop = OFD.FileNames;
                    ActiveDir = (Path.GetDirectoryName(FilesToBoop[0]));

                    foreach (string item in OFD.FileNames)
                    {
                        if (ActiveDir == Path.GetDirectoryName(item))
                        {
                            lvFileList.Items.Add(Path.GetFileName(item));
                        }
                        else
                        {
                            MessageBox.Show("Somehow you managed to pick 2 files that are in different folders." + Environment.NewLine + "Multi-File booping would need the entire computer hosted to the network and that doesn't feel safe in my book." + Environment.NewLine + "Maybe in the future I'll find a way to do this.", "Woah there...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        
                    }
                }

             }
        }

        private void btnBoop_Click(object sender, EventArgs e)
        {
            if (ValidateIPv4(txt3DS.Text) == false)
            {
                MessageBox.Show("That doesn't look like an IP adress." + Environment.NewLine + "An IP adress looks something like this: 192.168.1.6" + Environment.NewLine + "(That is: Numbers DOT numbers DOT numbers DOT numbers)", "Error on the IP adress", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //reenable controls?

                return;
            }

            if (lvFileList.Items.Count == 0)
            {
                MessageBox.Show("Add some files first?", "No files to boop", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            //MURDERING YOUR FIREWALL
            //I AM BAD SNEK. MUAHAHAHAHAHA

            string arguments = "advfirewall firewall add rule name=\"BOOPFILESERVER\" dir=in action=allow protocol=TCP localport=8080";
            ProcessStartInfo procStartInfo = new ProcessStartInfo("netsh", arguments);

            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;

            Process.Start(procStartInfo);



            //blocking all controls?
            StatusLabel.Text = "Booping... please wait";

            btnBoop.Enabled = false;
            button1.Enabled = false;
            txt3DS.Enabled = false;
            btnAbout.Enabled = false;


            myServer = new SimpleHTTPServer(ActiveDir, 8080);
            

            System.Threading.Thread.Sleep(100);

            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Connect(txt3DS.Text, 5000);
            String message = "";
            foreach (var CIA in FilesToBoop)
            {
               message += LocalIP() + ":8080/" + Path.GetFileName(CIA) + "\n";
            }

         
            //boop the info to the 3ds...
            byte[] Largo = BitConverter.GetBytes((uint)Encoding.ASCII.GetBytes(message).Length);
            byte[] Adress = Encoding.ASCII.GetBytes(message);

            Array.Reverse(Largo); //Endian fix


            
            s.Send(AppendTwoByteArrays(Largo, Adress));
            

            s.BeginReceive(new byte[1], 0,1, 0, new AsyncCallback(GotData), null); //Call me back when the 3ds says something.

        }

        private void GotData(IAsyncResult ar)
        {
            
            // now we unlock the controls...
            //Spooky "thread safe" way to access UI from ASYNC.
            this.Invoke((MethodInvoker)delegate
            {
                btnBoop.Enabled = true;
                button1.Enabled = true;
                txt3DS.Enabled = true;
                btnAbout.Enabled = true;
                StatusLabel.Text = "Booping complete!";
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

        static byte[] AppendTwoByteArrays(byte[] arrayA, byte[] arrayB)
        {
            byte[] outputBytes = new byte[arrayA.Length + arrayB.Length];
            Buffer.BlockCopy(arrayA, 0, outputBytes, 0, arrayA.Length);
            Buffer.BlockCopy(arrayB, 0, outputBytes, arrayA.Length, arrayB.Length);
            return outputBytes;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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

        public bool ValidateIPv4(string ipString)
        {
            if (String.IsNullOrWhiteSpace(ipString))
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

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Boop" + Environment.NewLine + "Coded by Elemental Code (Milton Candelero)" + Environment.NewLine + Environment.NewLine + "Boop is the C# port of servefiles.py for FBI by Steveice10" + Environment.NewLine + Environment.NewLine + "No sneks were harmed in the coding of this app","BOOP 1.0.Snek",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/miltoncandelero/Boop");
        }
    }
}
