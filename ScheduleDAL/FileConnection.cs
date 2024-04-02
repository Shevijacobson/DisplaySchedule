using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleDAL
{
    public class FileConnection
    {
        string filePath = Directory.GetCurrentDirectory() + @"\..\..\..\Src\Subjects.txt";
        public void WriteToFile(string [] arr)
        {
            File.WriteAllLines(filePath, arr);
        }
        public void ReadFromFile(out string[] arr)
        {
            arr = File.ReadAllLines(filePath);
        }
    }
}
