using System;
using System.Collections.Generic;
using System.Linq;

namespace ArraySolver.Implementation
{
    public class ArraySolverRepository
    {
        public ArraySolverRepository()
        {        }

        public void SolveArray(int[] array)
        {
            var failure = false; //to check if the end is reachable

            var reachLeft = new int[array.Length];
            reachLeft[0] = -1;
            var unreached = 1; 

            for (int i = 0; i < array.Length; i++)
            {
                int reachMax = array[i] + i;

                for(; unreached <= reachMax && unreached < array.Length; unreached++)
                {
                    reachLeft[unreached] = i;
                }
            }

            //stack to reverse the path

            var path = new Stack<int>();
            var reachLeftIndex = reachLeft.Length - 1;

            while (reachLeftIndex != -1)
            {
                if(reachLeftIndex == reachLeft[reachLeftIndex])
                {
                    failure = true;
                    break;
                }
                path.Push(reachLeftIndex);
                reachLeftIndex = reachLeft[reachLeftIndex];
            }

            var steps = path.Count();

            if (failure)
            {
                Console.WriteLine("Unreachable.");
            }
            else
            {
                Console.WriteLine("Most efficient path:");
                while (path.Count != 0)
                {
                    if (path.Count > 1)
                        Console.Write(array[path.Pop()] + " -> ");
                    else
                        Console.Write(array[path.Pop()]);
                }
                Console.WriteLine();
                Console.WriteLine("Number of steps: " + (steps - 1));
            }

        }

    }
}
