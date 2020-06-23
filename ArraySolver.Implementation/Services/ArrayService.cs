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
        public bool Failure { get; set; } // need to reset when calling
        public ArrayService(IArrayRepository arrayRepository)
        {
            Failure = false;
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
                    Failure = true;
                    break;
                }
                path.Push(reachLeftIndex);
                reachLeftIndex = array[reachLeftIndex];
            }

            return path;
        }

    }
}
