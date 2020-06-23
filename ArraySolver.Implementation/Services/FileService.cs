using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ArraySolver.Implementation.Services
{
    public class FileService
    {
        string readPath;

        public FileService()
        {
            readPath = @"C:\Users\BonBon\source\repos\ArraySolver\ArraySolver\array.txt";
        }
        public List<int[]> ReadArray()
        {
            var arrayList = new List<int[]>();
            var lines = File.ReadAllLines(readPath);

            for (var i = 0; i < lines.Length; i++)
            {
                var strArray = lines[i].Split(','); // create string array
                var oneLineList = new List<int>();
                strArray.ToList().ForEach(x => oneLineList.Add(Convert.ToInt32(x))); // convert array into int 
                arrayList.Add(oneLineList.ToArray()); //store converted array in list
            }
            return arrayList;
        }
    }
}
