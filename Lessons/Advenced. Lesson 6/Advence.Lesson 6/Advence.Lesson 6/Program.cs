using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Advence.Lesson_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Practice1();
        }        

        private static void SysteIOUsageExample()
        {
            var driveInfo = new DriveInfo("d");
            var dirInfo = new DirectoryInfo("d://temp");
            var fileInfo = new FileInfo("c://pagefile.sys");

            Directory.Delete("d://temp");
            File.Open("c://pagefile.sys", FileMode.Open);
        }

        private static void Practice1()
        {
            var dirInfo = new DirectoryInfo("c://Program Files");
            Console.WriteLine($"{dirInfo.Name} - {dirInfo.CreationTime}");

            var filesInfos = dirInfo.GetFiles();
            foreach (var file in filesInfos)
            {
                Console.WriteLine($"{file.Name} - {file.CreationTime} - {file.CreationTime}");
            }

            var newDirectory = Directory.CreateDirectory("c://Program Files Copy");
            var firstFile = filesInfos.First();
            File.Copy(firstFile.FullName, $"{newDirectory.FullName}/{firstFile.Name}");
        }
    }
}
