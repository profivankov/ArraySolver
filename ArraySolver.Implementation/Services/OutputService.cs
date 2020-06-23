using ArraySolver.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArraySolver.Implementation.Services
{
    public class OutputService : IOutputService
    {
        private ICacheService _cacheService;
        public OutputService(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }
        public string PrepareOutput(int[] array, Stack<int> path, bool failure)
        {
            var steps = path.Count();
            var resultString = "Array: ";
            foreach(var item in array)
            {
                resultString += item + " ";
            }
            resultString += Environment.NewLine;

            if (failure)
            {
                resultString += "Unreachable" + Environment.NewLine;
            }
            else
            {
                resultString += "Most efficient path:" + Environment.NewLine;
                while (path.Count() != 0)
                {
                    if (path.Count() > 1)
                    {
                        resultString += array[path.Pop()] + " -> ";
                    }
                    else
                    {
                        resultString += array[path.Pop()];
                    }
                }
                resultString += Environment.NewLine +"Number of steps: " + (steps - 1) + Environment.NewLine;
            }

            return resultString + Environment.NewLine;
        }

        public string PrepareCacheOutput()
        {
            var results = (Environment.NewLine + "Cache:");

            var cacheAll = _cacheService.GetCacheDisplay();
            for (int i = 1; i <= cacheAll.Count(); i++)
            {
                if (i % 2 != 0)
                {
                    results += Environment.NewLine + ("Array: " + cacheAll[i - 1]);
                }
                else
                {
                    results += Environment.NewLine + ("Indices of steps: " + cacheAll[i - 1]);
                }
            }

            return results;
        }
    }
}
