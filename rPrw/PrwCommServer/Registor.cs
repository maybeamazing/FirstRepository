using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrwCommServer
{
    class Registor
    {
        static public string CompanyName = "XXX 3D";
        static public string AppName = "PrwCommServer";


        public static void SetRegistryKey(string name, object value)
        {
            RegistryKey hkcu = Registry.CurrentUser;
            RegistryKey software = hkcu.OpenSubKey("SOFTWARE", true);
            RegistryKey TDG_MT = software.CreateSubKey(CompanyName);
            RegistryKey thisAPP = TDG_MT.CreateSubKey(AppName);

            thisAPP.SetValue(name, value);
        }

        public static string GetRegistryKeyString(string name, string defaultString)
        {
            object obj = GetRegistryKey(name);
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return defaultString;
            }
        }

        public static int GetRegistryKeyInt(string name, int defaultInt)
        {
            object obj = GetRegistryKey(name);
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return defaultInt;
            }
        }

        public static object GetRegistryKey(string name)
        {
            RegistryKey hkcu = Registry.CurrentUser;
            RegistryKey software = hkcu.OpenSubKey("SOFTWARE", true);
            RegistryKey TDG_MT = software.CreateSubKey(CompanyName);
            RegistryKey thisAPP = TDG_MT.CreateSubKey(AppName);
            object obj = thisAPP.GetValue(name);
            return obj;
        }
    }
}
