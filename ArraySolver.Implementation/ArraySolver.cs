using System;
using System.Collections.Generic;
using System.Linq;

namespace ArraySolver.Implementation
{
    public class ArraySolverRepository
    {
        //int[] stepArray; // steps
        public int[] globalArray { get; set; }
        public bool infLoop = false;
        public List<int> Path { get; set; }
        public List<int> StepSize { get; set; }

        public ArraySolverRepository()
        {
            Path = new List<int>();
            StepSize = new List<int>();
        }

        public bool IsWinnable(int[] array)
        {
            var winnable = false;
            //if the length of the array got down to 1, it's a win
            //if (array.GetLength(0) == 1)
            //{
            //    path.Add(array[i]);
            //    return true;
            //}

            //cycle through every number through the array
            for (int i = 0; i < array.GetLength(0); i++)
            {
                //possible steps from the current position
                var steps = GetSteps(array[i]).Reverse().ToArray();
                //if the only step is 0, then the path fails
                if ((steps.GetLength(0) == 1) && (steps[0] == 0) && array.GetLength(0) > 1)
                {
                    return false;
                }
                else if ((steps.GetLength(0) == 1) && (steps[0] == 0) && array.GetLength(0) == 1)
                {
                    Path.Add(array[i]);
                    return true;
                }
                //if it's not the only step then remove 0s as it's useless to iterate through them
                steps = steps.Where(val => val != 0).ToArray();

                //for (int stepCounter = steps.Min(); stepCounter <= steps.Max(); stepCounter++)
                foreach (var step in steps)
                {
                    if (step > 0)
                    {
                        if (IsWinnable(array.Skip(step).ToArray()))
                        {
                            Path.Add(array[i]);
                            StepSize.Add(step);
                            return true;
                        }
                    }

                    if (step < 0) // works if no inf loop
                    {
                        if (IsWinnable(globalArray.Skip(globalArray.GetLength(0) - (array.GetLength(0) - step)).ToArray()))
                        {
                            Path.Add(array[i]);
                            StepSize.Add(step);
                            return true;
                        }

                    }
                    //else if (stepCounter < 0 && stepCounter != 0 && infLoop == false) // for negative steps
                    //{
                    //    infLoop = true;
                    //    winnable = IsWinnable(globalArray.Skip(globalArray.GetLength(0) - (array.GetLength(0) - stepCounter)).ToArray());
                    //    if (winnable == false)
                    //    {
                    //        continue;
                    //    }

                    //}

                    //else if (stepCounter < 0 && stepCounter != 0 && infLoop == true) // in case it starts looping
                    //{
                    //    infLoop = false;
                    //    return false;
                    //}

                    //if (winnable == true)
                    //{
                    //    return true;
                    //}
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
                stepArray = new int[number * (-1) + 1];
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
