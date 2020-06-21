using System;
using System.Linq;

namespace ArraySolver.Implementation
{
    public class ArraySolverRepository
    {
        //int[] stepArray; // steps
        public int[] globalArray { get; set; }
        public ArraySolverRepository()
        {

        }

        public bool IsWinnable(int[] array)
        {
            var winnable = false;
            //if the length of the array got down to 1, it's a win
            if (array.GetLength(0) == 1)
            {
                return true;
            }

            //cycle through every number through the array
            for (int i = 0; i < array.GetLength(0); i++)
            {
                //possible steps from the current position
                var steps = GetSteps(array[i]);
                //if the only step is 0, then the path fails
                if ((steps.GetLength(0) == 1) && (steps[0] == 0))
                {
                    return false;
                }

                for (int stepCounter = steps.Min(); stepCounter <= steps.Max(); stepCounter++) 
                {
                    if (stepCounter > 0 && stepCounter != 0)
                    {
                        winnable = IsWinnable(array.Skip(stepCounter).ToArray());
                    }

                    else if (stepCounter < 0 && stepCounter != 0)
                    {
                        winnable = IsWinnable(globalArray.Skip(globalArray.GetLength(0) - (array.GetLength(0) - stepCounter)).ToArray());
                    }
                    if (winnable == true)
                    {
                        return true;
                    }
                }
            }

            return false;

        }

        public int[] GetSteps(int number)
        {
            int[] stepArray;
            var counter = 0;
            if (number >= 0)
            {
                stepArray = new int[number + 1];
                for (int i = 0; i <= number; i++)
                {
                    stepArray[i] = i;
                }
            }
            else
            {
                stepArray = new int[number*(-1) + 1];
                for (int i = number; i <= 0; i++)
                {
                    stepArray[counter] = i;
                    counter++;
                }
            }

            return stepArray;
        }
    }
}
