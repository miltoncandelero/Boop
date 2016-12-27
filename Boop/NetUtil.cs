using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace Boop
{
    namespace NetUtil
    {
        class IPv4
        {
            /// <summary>
            /// Retrieves the local IPv4 Address
            /// </summary>
            /// <remarks>Returns your computer's Loopback if no Network detected.</remarks>
            public static string Local
            {
                get { return Dns.GetHostEntry(Dns.GetHostName()).AddressList.DefaultIfEmpty(IPAddress.Loopback).FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToString(); }
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

        }
    }
}
