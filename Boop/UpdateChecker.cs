using System;
using System.Reflection;
using System.Diagnostics;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Boop
{
    class UpdateChecker
    {
        int iMajor;
        int iMinor;
        int iFix;

        public String sUrl { get; private set; }

        public static string GetCurrentVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            return fileVersionInfo.ProductMajorPart.ToString() + "." + fileVersionInfo.ProductMinorPart.ToString() + "." + fileVersionInfo.ProductBuildPart.ToString();
        }

        public UpdateChecker(int Major, int Minor, int Fix)
        {
            sUrl = "";
            iMajor = Major;
            iMinor = Minor;
            iFix = Fix;
        }

        public UpdateChecker()
        {
            sUrl = "";
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            iMajor = fileVersionInfo.ProductMajorPart;
            iMinor = fileVersionInfo.ProductMinorPart;
            iFix = fileVersionInfo.ProductBuildPart;
        }

        public bool CheckForUpdates() //To maybe do: The json object that gitgub exposes has a field that marks the release as "pre-release" or not. Maybe optional to check if release or pre release?
        {
            HttpWebRequest HttpRequestObj = (HttpWebRequest)HttpWebRequest.Create(@"https://api.github.com/repos/miltoncandelero/boop/releases/latest");
            HttpRequestObj.Credentials = CredentialCache.DefaultCredentials;
            HttpRequestObj.ContentType = "application/json";
            HttpRequestObj.Method = "GET";
            HttpRequestObj.Accept = "application/json";
            HttpRequestObj.UserAgent = "Boop"; // NEEDS SOMETHING WRITTEN!
            HttpWebResponse response = (HttpWebResponse)HttpRequestObj.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();

            JObject jObject = JObject.Parse(content);
            string Ver = (string)jObject["tag_name"];
            sUrl = (string)jObject["html_url"];
            try
            {
                String[] SplitVer = Ver.Split('.');

                int sMajor = int.Parse(SplitVer[0]);
                int sMinor = int.Parse(SplitVer[1]);
                int sFix = int.Parse(SplitVer[2]);

                //There must be a WAAAAY better way of doing this, but I can't see it right now.
                if (sMajor > iMajor) return true;
                if (sMajor < iMajor) return false;

                if (sMajor == iMajor)
                {
                    if (sMinor > iMinor) return true;
                    if (sMinor < iMinor) return false;
                    if (sMinor == iMinor)
                    {
                        if (sFix > iFix) return true; else return false;
                    }

                }


                return false;
            }
            catch (Exception)
            { 
                throw new Exception("Probably messed up the Tags in Github");
            }

        }


    }
}
