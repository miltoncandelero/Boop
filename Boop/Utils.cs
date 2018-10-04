using System;
using System.Reflection;
using System.Diagnostics;
using System.Net;
using System.IO;

namespace Boop
{
    class Utils
    {
        public static string GetCurrentVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            return fileVersionInfo.ProductMajorPart.ToString() + "." + fileVersionInfo.ProductMinorPart.ToString() + "." + fileVersionInfo.ProductBuildPart.ToString();
        }

    }
}
