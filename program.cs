using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace ReadOneFileCreateMultipleFiles
{
    class Program
    {
        public static void FileSplitWriter(string path, int numberOfLines)
        {
            string name = Path.GetFileNameWithoutExtension(path);
            string extension = Path.GetExtension(path);
            string[] ss = File.ReadAllLines(path);
            int cycle = 1;
            int chunksize = numberOfLines;

            var chunk = ss.Take(chunksize);
            var rem = ss.Skip(chunksize);

            string newFilesPath = @"d:/Temp/";
            while (chunk.Take(1).Any())
            {
                string filename = newFilesPath + name + "_" + cycle + extension;
                using (StreamWriter sw = new StreamWriter(filename))
                {
                    foreach (string line in chunk)
                    {
                        sw.WriteLine(line);
                    }
                }
                chunk = rem.Take(chunksize);
                rem = rem.Skip(chunksize);
                cycle++;
            }
        }
        static void Main(string[] args)
        {
            int numberOfLines = Convert.ToInt32(args[1]);
            string path = args[0];
            FileSplitWriter(path, numberOfLines);
        }
    }
}
