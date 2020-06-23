using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ArraySolver.Implementation.Services
{
    public class CacheService
    {
        string cachePath;
        public CacheService()
        {
            cachePath = @"C:\Users\BonBon\source\repos\ArraySolver\ArraySolver\cache.txt";
        }
        public void AddCacheToRepository(int[] array, Stack<int> path)
        {
            using (var writer = new StreamWriter(cachePath, true))
            {
                writer.Write(string.Join(",", array) + Environment.NewLine);

                writer.Write(string.Join(" ", path.ToArray()) + Environment.NewLine);
            }
        }

        public Stack<int> SearchCacheForSteps(int[] array)
        {
            if(!File.Exists(cachePath))
            {
                return null;
            }

            var lines = File.ReadAllLines(cachePath);
            var result = new List<int>();
            for (int i = 0; i < lines.Length; i++)
            {
                if(lines[i].Equals(string.Join(",", array)))
                {
                    lines[i + 1].Split(" ").ToList().ForEach(x => result.Add(Convert.ToInt32(x)));
                }
            }

            result.Reverse();

            if (result.Any())
            {
                return new Stack<int>(result);
            }
            else
            {
                return null;
            }
        }
    }
}
