using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ArraySolver.Implementation
{
    public class FileRepository
    {
        StreamReader readFile;
        StreamReader writeFile;

        public FileRepository()
        {
            readFile = new StreamReader(@"C:\Users\BonBon\source\repos\ArraySolver\ArraySolver\array.txt");
        }

        public int[] ReadArray()
        {
            var numberList = new List<int>();
            var line = "";

            while ((line = readFile.ReadLine()) != null)
            {
                var strArray = line.Split(' ');
                foreach (var item in strArray)
                {
                    numberList.Add(Convert.ToInt32(item));
                }
            }

            return numberList.ToArray();
        }

    }
}
