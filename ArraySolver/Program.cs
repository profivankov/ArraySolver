using System;
using System.Collections.Generic;
using System.IO;
using ArraySolver.Implementation;

namespace ArraySolver.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            StreamReader file;
            string line = "";
            file = new StreamReader(@"C:\Users\BonBon\source\repos\ArraySolver\ArraySolver\array.txt");
            var numberList = new List<int>();

            //read numbers into array from file
            while ((line = file.ReadLine()) != null)
            {
                var strArray = line.Split(' ');
                foreach(var item in strArray)
                {
                    numberList.Add(Convert.ToInt32(item));
                }
            }

            var array = numberList.ToArray();

            var solver = new ArraySolverRepository();
            solver.globalArray = array;
            Console.WriteLine(solver.IsWinnable(array));
            

        }
    }
}
