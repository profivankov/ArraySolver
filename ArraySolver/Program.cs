using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ArraySolver.Implementation;
using ArraySolver.Implementation.Services;
using ArraySolver.Interfaces.Services;

namespace ArraySolver.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var arrayService = new ArrayService();
            var fileService = new FileService();
            var cacheService = new CacheService();
            var outputService = new OutputService(cacheService);

            try
            {
                var listOfArrays = fileService.ReadArray();

                var path = new List<int>();

                foreach (var array in listOfArrays)
                {
                    var pathFromCache = cacheService.GetCacheByArray(array);
                    if (pathFromCache == null)
                    {
                        path = arrayService.FindPath(array);

                        if (!arrayService.Failure) // don't save to cache if it's unreachable
                        {
                            cacheService.AddCacheToRepository(array, path);
                        }
                    }
                    else
                    {
                        path = pathFromCache;
                    }

                    Console.Write(outputService.PrepareOutput(array, path, arrayService.Failure));
                    arrayService.Failure = false;
                }

                Console.WriteLine("Would you like to see all of the cached arrays? Y/N");

                ConsoleKey response;
                do
                {
                    //Console.Write("Are you sure you want to choose this as your login key? [y/n] ");
                    response = Console.ReadKey(false).Key;   // true is intercept key (dont show), false is show
                    if (response != ConsoleKey.Enter)
                        Console.WriteLine(Environment.NewLine);

                } while (response != ConsoleKey.Y && response != ConsoleKey.N);

                if (response == ConsoleKey.Y)
                {
                    Console.WriteLine(outputService.PrepareCacheOutput());
                }
            }

            catch
            {
                Console.WriteLine("Error");
            }
        }
    }
}
