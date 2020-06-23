using System;
using System.Collections.Generic;
using System.Text;

namespace ArraySolver.Interfaces.Services
{
    public interface ICacheService
    {
        public List<string> GetCacheDisplay();
        public void AddCacheToRepository(int[] array, List<int> path);
        public List<int> GetCacheByArray(int[] array);
    }
}
