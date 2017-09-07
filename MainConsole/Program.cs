using System;
using System.IO;
using System.Linq;
using Common;
using DataAccess;

namespace MainConsole
{
    class Program
    {
        private static void init()
        {
            GetCopyDefaultDBFile();

            SetDatadirectory();
        }

        private static void GetCopyDefaultDBFile()
        {
            if (!File.Exists(Constants.DatabaseName))
            {

                File.Copy(Constants.DefaultDatabasePath, Constants.DatabaseName);
            }
        }

        private static void SetDatadirectory()
        {
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));

            AppDomain.CurrentDomain.SetData("DataDirectory", path);
        }

        static void Main(string[] args)
        {
            init();

            using (var ctx = new DataContext())
            {
                Console.WriteLine(ctx.AppInfos.Count());
            }

            Console.ReadLine();
        }
    }
}
