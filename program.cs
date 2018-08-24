/*

    Copyright Jalel TOUNSI.

    Licensed under the Apache License, Version 2.0 (the "License");
    you may not use this file except in compliance with the License.
    You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

    Unless required by applicable law or agreed to in writing, software
    distributed under the License is distributed on an "AS IS" BASIS,
    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    See the License for the specific language governing permissions and
    limitations under the License.

*/
    
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
