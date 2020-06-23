using ArraySolver.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArraySolver.Implementation.Services
{
    public class ArrayService : IArrayService
    {
        public bool Failure { get; set; }
        public ArrayService()
        {
            Failure = false;
        }

        public List<int> FindPath(int[] array)
        {
            return StorePath(GetReach(array));
        }

        public int[] GetReach(int[] array)  // checks which farthest number on the left reaches the end number, then jumps to it and repeats with the new number as the end  
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

        public List<int> StorePath(int[] array) // reverse the path and store it
        {
            var path = new Stack<int>();
            var reachLeftIndex = array.Length - 1;

            while (reachLeftIndex != -1)
            {
                if (reachLeftIndex == array[reachLeftIndex])
                {
                    Failure = true;
                    return new List<int>();
                }
                path.Push(reachLeftIndex);
                reachLeftIndex = array[reachLeftIndex];
            }

            var result = path.ToList();
            result.Reverse();

            return result;
        }

    }
}
