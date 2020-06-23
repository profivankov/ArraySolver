using System;
using System.Collections.Generic;
using System.Text;

namespace ArraySolver.Interfaces.Services
{
    public interface IArrayService
    {
        public bool Failure { get; set; }
        public int[] FindPath(int[] array);
        public Stack<int> ReversePath(int[] array);
    }
}
