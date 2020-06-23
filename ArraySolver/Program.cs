using System;
using System.Collections.Generic;
using System.IO;
using ArraySolver.Implementation;
using ArraySolver.Implementation.Services;

namespace ArraySolver.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var solver = new ArrayService(new ArrayRepository());
            var reader = new FileService();
            var output = new OutputService();
            var cache = new CacheService();

            var listOfArrays = reader.ReadArray();
            var path = new Stack<int>();

            foreach (var array in listOfArrays)
            {
                var pathFromCache = cache.SearchCacheForSteps(array);
                if (pathFromCache == null)
                {
                    path = solver.ReversePath(solver.FindPath(array));
                    if (!solver.Failure) // don't save to cache if it's unreachable
                    {
                        cache.AddCacheToRepository(array, path);
                    }
                }
                else
                {
                    path = pathFromCache;
                }

                Console.Write(output.PrepareOutput(array, path, solver.Failure));
                solver.Failure = false;
            }
            
        }
    }
}
