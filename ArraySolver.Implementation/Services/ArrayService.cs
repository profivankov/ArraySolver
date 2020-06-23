using ArraySolver.Interfaces.Repositories;
using ArraySolver.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArraySolver.Implementation.Services
{
    public class ArrayService : IArrayService
    {
        private readonly IArrayRepository _arrayRepository;
        private bool failure;
        public ArrayService(IArrayRepository arrayRepository)
        {
            failure = false;
            _arrayRepository = arrayRepository;
        }

        public int[] FindPath(int[] array)
        {
            var reachLeft = new int[array.Length];
            reachLeft[0] = -1;
            var unreached = 1;

            for (int i = 0; i < array.Length; i++)
            {
                int reachMax = array[i] + i;

                for (; unreached <= reachMax && unreached < array.Length; unreached++)
                {
                    reachLeft[unreached] = i;
                }
            }

            return reachLeft;
        }

        public Stack<int> ReversePath(int[] array)
        {
            var path = new Stack<int>();
            var reachLeftIndex = array.Length - 1;

            while (reachLeftIndex != -1)
            {
                if (reachLeftIndex == array[reachLeftIndex])
                {
                    failure = true;
                    break;
                }
                path.Push(reachLeftIndex);
                reachLeftIndex = array[reachLeftIndex];
            }

            return path;
        }
        public Stack<int> SolveArray(int[] array)
        {
            var failure = false; //to check if the end is reachable

            //var reachLeft = new int[array.Length];
            //reachLeft[0] = -1;
            //var unreached = 1;

            //for (int i = 0; i < array.Length; i++)
            //{
            //    int reachMax = array[i] + i;

            //    for (; unreached <= reachMax && unreached < array.Length; unreached++)
            //    {
            //        reachLeft[unreached] = i;
            //    }
            //}

            //stack to reverse the path

            //var path = new Stack<int>();
            //var reachLeftIndex = reachLeft.Length - 1;

            //while (reachLeftIndex != -1)
            //{
            //    if (reachLeftIndex == reachLeft[reachLeftIndex])
            //    {
            //        failure = true;
            //        break;
            //    }
            //    path.Push(reachLeftIndex);
            //    reachLeftIndex = reachLeft[reachLeftIndex];
            //}



            var path = ReversePath(FindPath(array));
            var steps = path.Count();

            if (failure)
            {
                Console.WriteLine("Unreachable.");
            }
            else
            {
                Console.WriteLine("Most efficient path:");
                while (path.Count() != 0)
                {
                    if (path.Count() > 1)
                        Console.Write(array[path.Pop()] + " -> ");
                    else
                        Console.Write(array[path.Pop()]);
                }
                Console.WriteLine();
                Console.WriteLine("Number of steps: " + (steps - 1));
            }
            return path;
        }
    }
}
