using ArraySolver.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArraySolver.Implementation.Services
{
    public class OutputService : IOutputService
    {
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
    }
}
