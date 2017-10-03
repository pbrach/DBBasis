using System;
using System.IO;
using System.Linq;
using DataAccess;

namespace MainConsole
{
    class Program
    {
        private static void Init()
        {
            SetDatadirectory();
        }

        private static void SetDatadirectory()
        {
            var executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var path = (Path.GetDirectoryName(executable));

            AppDomain.CurrentDomain.SetData("DataDirectory", path + @"\..\..\..");
        }

        static void Main(string[] args)
        {
            Init();

            using (var ctx = new DataContext())
            {
                Console.WriteLine(ctx.AppInfos.Count());
            }

            Console.ReadLine();
        }
    }
}
