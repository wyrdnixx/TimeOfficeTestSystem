using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;

namespace TimeOfficeTestSystem
{
    class Config
    {
        public string connectionstring;
        public string server;
        public string testdatabase;
        public string timeofficeTestsystemStartExe;
        public string timeofficeTestsystemStartArguments;

        public List<String>sqlcmdList = new List<string>();

        public Config() {

            readConfig();
            
        }


        private void readConfig()
        {
            Console.WriteLine("Reading Config...");
            
            server = ConfigurationManager.AppSettings.Get("server");
            testdatabase = ConfigurationManager.AppSettings.Get("testdatabase");            
            connectionstring = @"Data Source=" + server + ";Integrated Security=sspi;";
            timeofficeTestsystemStartExe = ConfigurationManager.AppSettings.Get("timeofficeTestsystemStartExe");
            timeofficeTestsystemStartArguments = ConfigurationManager.AppSettings.Get("timeofficeTestsystemStartArguments");

            NameValueCollection sAll;
            sAll = ConfigurationManager.AppSettings;

            foreach (string s in sAll.AllKeys)
            {
                //Console.WriteLine("Key: " + s + " Value: " + sAll.Get(s));
                if (s.Contains("SQL"))
                {
                    //Console.WriteLine("found sql cmd: " + sAll.Get(s));
                    sqlcmdList.Add(sAll.Get(s));
                    
                }
            }
            Console.WriteLine("SQL entrys: " + sqlcmdList.Count);
            //sqlcmdList.Sort();

            // test
            foreach (var item in sqlcmdList)
            {
                Console.WriteLine("SQL List: " + item);
            }
                
        }
    }
}
