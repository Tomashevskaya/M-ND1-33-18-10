using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace Advence.Lesson_6
{
    class Program
    {
        static void Main(string[] args)
        {
            //SysteIOUsageExample();
            //WriteToFileWithStream();
            //Practice1();
            //ReadFromFileWithStream();
            //WriteToFileWithStream();
            //Practice2();
            //BufferedStreamExample();
            //SericalizationExample();
            //XMLDocumentExample();
            XMLReaderExample();
            Console.ReadLine();
        } 

        private static void XMLReaderExample()
        {
            using (XmlReader reader = XmlReader.Create("XMLFile.xml"))
            {
                while (reader.Read())
                {                    
                    if (reader.IsStartElement())
                    {
                        var name = reader.Name;
                        reader.Read();
                        var value = reader.Value.Trim();
                        Console.WriteLine($"{name}: {value}");
                    }
                }
            }
        }
        
        private static void XMLDocumentExample()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("XMLFile.xml");
          
            XmlElement arraysOfSong = xDoc.DocumentElement;
            foreach (XmlNode song in arraysOfSong)
            {
                foreach (XmlNode property in song.ChildNodes)
                {
                    Console.WriteLine($"{property.Name}: {property.InnerText}");
                }
            }
        }
        
        private static void SericalizationExample()
        {
            var arr = new Song[]
            {
                new Song() {
                    Title = "Title 1",
                    Duration = 247,
                    Lyrics = "Lyrics 1"
                },
                new Song() {
                    Title = "Title 2",
                    Duration = 456,
                    Lyrics = "Lyrics 2"
                }
            };

            XmlSerializer xmlSerializer = new XmlSerializer(arr.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, arr);
                var result =  textWriter.ToString();
            }
        }

        private static void SysteIOUsageExample()
        {
            var driveInfo = new DriveInfo("d");
            var dirInfo = new DirectoryInfo("d://temp");
            var fileInfo = new FileInfo("c://pagefile.sys");

            Directory.Delete("d://temp");
            File.Open("c://pagefile.sys", FileMode.Open);
        }

        private static void WriteToFileWithStream()
        {
            /*FileInfo file = new FileInfo(@"d:\File.txt");
            FileStream fs = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);

            StreamWriter sw = new StreamWriter(fs, Encoding.Default);
            sw.Write("Hello World");
            sw.Close(); */ 
            
            StreamWriter sw = new StreamWriter(@"d:\File.txt");
            sw.Write("Hello World");
            sw.Close();         
        }

        private static void WriteToFileWithStreamWriter()
        {
            FileInfo file = new FileInfo(@"d:\File.txt");
            FileStream fs = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);

            byte[] word = Encoding.Default.GetBytes("Hello World");
            fs.Write(word, 0, word.Length);

            fs.Close();
        }

        private static void ReadFromFileWithStream()
        {
            FileInfo file = new FileInfo(@"d:\File.txt");
            FileStream fs = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);

            byte[] word = new byte[fs.Length];
            fs.Read(word, 0, (int)fs.Length);
            Console.Write(Encoding.Default.GetChars(word));    
            fs.Close();
        }

        private static void Practice2()
        {
            var iteration = 0;

            using (StreamWriter sw = new StreamWriter(@"d:\File.txt"))
            {
                while (iteration++ < 2)
                {
                    for (int i = 1; i <= 2; i++)
                    {
                        Console.Write($"User {i}: ");
                        sw.Write($"User {i} [{DateTime.Now.ToString()}]: {Console.ReadLine()}");
                        sw.WriteLine();
                    }                    
                }
            }
        }

        private static void BufferedStreamExample()
        {
            FileInfo file = new FileInfo(@"d:\File.txt");

            using (FileStream fileStream = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {               
                using (BufferedStream bs = new BufferedStream(fileStream, 10000))
                {
                    for (int i = 1; i < 100; i++)
                    {
                        var data = Encoding.Default.GetBytes($"{i}). Hello World\n");
                        bs.Write(data, 0, data.Length);
                    }
                }
            }

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
