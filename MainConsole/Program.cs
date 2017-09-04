using System;
using System.IO;
using Common;
using DataAccess;
using DataAccess.DataTypes;

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

            using (var ctx = new HierarchModel())
            {
                var stud = new Student { StudentName = "Darouso" };

                ctx.Students.Add(stud);
                ctx.SaveChanges();
            }

            Console.ReadLine();

            using (var ctx = new HierarchModel())
            {
                var result = ctx.Students.Find(1);

                Console.WriteLine("Found {0}", result?.StudentName);
            }

            Console.ReadLine();
        }
    }
}
