using ArraySolver.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ArraySolver.Implementation.Services
{
    public class FileService : IFileService
    {
        private readonly string readPath;

        public FileService()
        {
            readPath = @"array.txt";
        }
        public List<int[]> ReadArray()
        {
            var arrayList = new List<int[]>();
            
            if (!File.Exists(readPath))
            {
                CreateArrays();
            }

            var lines = File.ReadAllLines(readPath);

            for (var i = 0; i < lines.Length; i++)
            {
                var strArray = lines[i].Split(','); // create string array
                var oneLineList = new List<int>();
                try
                {
                    strArray.ToList().ForEach(x => oneLineList.Add(Convert.ToInt32(x))); // convert array into int 
                } 
                catch
                { 
                    Console.WriteLine("Error. Other symbols than numbers in the array.");
                }
                arrayList.Add(oneLineList.ToArray()); //store converted array in list
            }

            return arrayList;
        }

        public void CreateArrays() //if no arrays.txt, it will be created with some default values
        {
            using (var writer = new StreamWriter(readPath, true))
            {
                writer.Write(string.Concat("3, 9, 1, 1, 1") + Environment.NewLine);

                writer.Write(string.Concat("1, 2, 0, 3, 0, 2") + Environment.NewLine);

                writer.Write(string.Concat("1, 2, 0, 1, 0, 2") + Environment.NewLine);

                writer.Write(string.Concat("1, 2, 0, -1, 0, 2") + Environment.NewLine);
            }
        }
    }
}
