using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Boop
{

	namespace NetUtil
	{
		class IPv4
		{

			public static int iIPIndex = -1;


			//Known Nintendo Mac adresses //Will no longer be supported :|
			public static readonly List<string> Nontendo = new List<string> { "E84ECE", "E0E751", "E00C7F", "D86BF7", "CCFB65", "CC9E00", "B8AE6E", "A4C0E1", "A45C27", "9CE635", "98B6E9", "8CCDE8", "8C56C5", "7CBB8A", "78A2A0", "58BDA3", "40F407", "40D28A", "34AF2C", "2C10C1", "182A7B", "002709", "002659", "0025A0", "0024F3", "002444", "00241E", "0023CC", "002331", "0022D7", "0022AA", "00224C", "0021BD", "002147", "001FC5", "001F32", "001EA9", "001E35", "001DBC", "001CBE", "001BEA", "001B7A", "001AE9", "0019FD", "00191D", "0017AB", "001656", "0009BF" };


			/// <summary>
			/// Dups the result of arp -a into a list of a really neat struct.
			/// Not the cleanest way but it works for me.
			/// </summary>
			static List<MacIpPair> GetAllMacAddressesAndIppairs()
			{
				List<MacIpPair> mip = new List<MacIpPair>();
				System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
				pProcess.StartInfo.FileName = "arp";
				pProcess.StartInfo.Arguments = "-a ";
				pProcess.StartInfo.UseShellExecute = false;
				pProcess.StartInfo.RedirectStandardOutput = true;
				pProcess.StartInfo.CreateNoWindow = true;
				pProcess.Start();
				string cmdOutput = pProcess.StandardOutput.ReadToEnd();
				string pattern = @"(?<ip>([0-9]{1,3}\.?){4})\s*(?<mac>([a-f0-9]{2}-?){6})";

				foreach (Match m in Regex.Matches(cmdOutput, pattern, RegexOptions.IgnoreCase))
				{
					mip.Add(new MacIpPair()
					{
						MacAddress = m.Groups["mac"].Value,
						IpAddress = m.Groups["ip"].Value
					});
				}

				return mip;
			}
			public struct MacIpPair
			{
				public string MacAddress;
				public string IpAddress;
			}

			/// <summary>
			/// Returns the first ip adress whose MAC adress matches one from the known nintendo list.
			/// </summary>
			public static string GetFirstNintendoIP()
			{
				foreach (var item in GetAllMacAddressesAndIppairs())
				{
					string MAC = "";
					MAC = item.MacAddress.Replace("-", "");
					MAC = MAC.Substring(0, 6);
					MAC = MAC.ToUpper();
					if (Nontendo.Contains(MAC))
					{
						return item.IpAddress;
					}
				}
				return ""; //Empty string means "No 3ds in range". To be used by the main thread to inform the user. (should I raise an exception? :S )
			}

			/// <summary>
			/// Retrieves the local IPv4 Address
			/// </summary>
			/// <remarks>Returns your computer's Loopback if no Network detected.</remarks>
			public static string Local
			{
				get { return Dns.GetHostEntry(Dns.GetHostName()).AddressList.DefaultIfEmpty(IPAddress.Loopback).Where(ip => ip.AddressFamily == AddressFamily.InterNetwork).ElementAt(iIPIndex).ToString(); }
			}


			/// <summary>
			/// Validates if the specified string is an IPv4 Address
			/// </summary>
			/// <param name="ipString">The string to compare</param>
			/// <returns>True if the address is valid.</returns>
			public static bool Validate(string ipString)
			{
				if (ipString == "0.0.0.0" || ipString == "127.0.0.1")
				{
					return false;
				}
				return new Regex(@"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$").IsMatch(ipString); //Check the octets
			}

			/// <summary>
			/// Validates if the specified string is a port
			/// </summary>
			/// <param name="portString">The string to compare</param>
			/// <returns>True if the port is a number.</returns>
			public static bool ValidatePort(string portString)
			{
				return (new Regex(@"[0-9]{1,5}").IsMatch(portString)); //between 1 and 5 digits.
			}

			/// <summary>
			/// TestPort
			/// </summary>
			/// <param name="port"></param>
			/// <returns></returns>
			public static bool PortInUse(int port)
			{
				bool inUse = false;
				IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
				IPEndPoint[] ipEndPoints = ipProperties.GetActiveTcpListeners();
				foreach (IPEndPoint endPoint in ipEndPoints)
				{
					if (endPoint.Port == port)
					{
						inUse = true;
						break;
					}
				}
				return inUse;
			}

		}
	}
}
