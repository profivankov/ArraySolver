using System;
using System.Collections.Generic;
using System.Text;

namespace ArraySolver.Interfaces.Services
{
    public interface IOutputService
    {
        public string PrepareOutput(int[] array, Stack<int> path, bool failure);
        public string PrepareCacheOutput();
    }
}
