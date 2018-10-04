// CsHTTPServer
//
// rmortega77@yahoo.es
// The use of this software is subject to the following agreement
//
// 1. Don't use it to kill.
// 2. Don't use to lie.
// 3. If you learned something give it back.
// 4. If you make money with it, consider sharing with the author.
// 5. If you do not complies with 1 to 5, you may not use this software.
//
// If you have money to spare, and found useful, or funny, or anything 
// worth on this software, and want to contribute with future free 
// software development.
// You may contact the author at rmortega77@yahoo.es 
// Contributions can be from money to hardware spareparts (better), or 
// a bug fix (best), or printed bibliografy, or thanks... 
// just write me.

using System;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.Net;
using System.Windows.Forms;
using System.Net.NetworkInformation;


//using System.Text;

namespace HTTPServer
{
	/// <summary>
	/// Summary description for CsHTTPServer.
	/// </summary>
	public abstract class CsHTTPServer
	{
		private int portNum = 8080;
		private TcpListener listener;
		System.Threading.Thread Thread;

		public Hashtable respStatus;

		public string Name = "CsHTTPServer/1.0.*";

		public bool IsAlive
		{
			get 
			{
				return this.Thread.IsAlive; 
			}
		}

		public CsHTTPServer()
		{
			//
			respStatusInit();
		}

		public CsHTTPServer(int thePort)
		{
			portNum = thePort;
			respStatusInit();
		}

		private void respStatusInit()
		{
			respStatus = new Hashtable();
			
			respStatus.Add(200, "200 Ok");
			respStatus.Add(201, "201 Created");
			respStatus.Add(202, "202 Accepted");
			respStatus.Add(204, "204 No Content");

			respStatus.Add(301, "301 Moved Permanently");
			respStatus.Add(302, "302 Redirection");
			respStatus.Add(304, "304 Not Modified");
			
			respStatus.Add(400, "400 Bad Request");
			respStatus.Add(401, "401 Unauthorized");
			respStatus.Add(403, "403 Forbidden");
			respStatus.Add(404, "404 Not Found");

			respStatus.Add(500, "500 Internal Server Error");
			respStatus.Add(501, "501 Not Implemented");
			respStatus.Add(502, "502 Bad Gateway");
			respStatus.Add(503, "503 Service Unavailable");
		}

		public void Listen() 
		{

			bool done = false;
            IPAddress ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];

            //listener = new TcpListener(portNum);
            listener = new TcpListener(IPAddress.Any,portNum);

            if (PortInUse(portNum))
            {
                MessageBox.Show("Port "+portNum+" In Use\nTry with a different one.", "Port Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            try
            {
                listener.Start();
            }
            catch (SocketException _ex)
            {
                WriteLog("Socket Error: " + _ex.ErrorCode);
                MessageBox.Show("Error Code:" + _ex.ErrorCode, "Socket Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            WriteLog("Listening On: " + portNum.ToString());

			while (!done) 
			{
                try
                {
				    WriteLog("Waiting for connection...");
				    CsHTTPRequest newRequest = new CsHTTPRequest(listener.AcceptTcpClient(),this);
				    Thread Thread = new Thread(new ThreadStart(newRequest.Process));
				    Thread.Name = "HTTP Request";
				    Thread.Start();
                }
                catch (Exception)
                {
                    //from time to time this went boom boom. So a nice trycatch stops it.
                }
            }

		}

        /// <summary>
        /// TestPort
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        internal bool PortInUse(int port)
        {
            bool inUse = false;
            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] ipEndPoints = ipProperties.GetActiveTcpListeners();
            foreach (IPEndPoint endPoint in ipEndPoints)
            {
                if (endPoint.Port == port)
                {
                    WriteLog(endPoint.Port + "");
                    inUse = true;
                    break;
                }
            }
            return inUse;
        }

        public void WriteLog(string EventMessage)
		{
			Console.WriteLine(EventMessage);
		}

		public void Start()
		{
			// CsHTTPServer HTTPServer = new CsHTTPServer(portNum);
			this.Thread = new Thread(new ThreadStart(this.Listen));
			this.Thread.Start();
		}

		public void Stop()
		{
			listener.Stop();
			this.Thread.Abort();
		}

/*		public void Suspend()
		{
			this.Thread.Suspend();
		}

		public void Resume()
		{
			this.Thread.Resume();
		}*/

		public abstract void OnResponse(ref HTTPRequestStruct rq, ref HTTPResponseStruct rp);

	}
}
