using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArraySolver.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ArraySolver.WebApp.Controllers
{
    [ApiController]
    [Route("api/arraysolver")]
    public class ApiController : ControllerBase
    {
        private readonly IArrayService _arrayService;
        private readonly ICacheService _cacheService;
        private readonly IOutputService _outputService;

        public ApiController(IArrayService arrayService, ICacheService cacheService, IOutputService outputService)
        {
            _arrayService = arrayService;
            _cacheService = cacheService;
            _outputService = outputService;
        }


        //method for a single array
        [HttpPost]
        public string GetPath([FromBody] string array)
        {

            var strArray = array.Split(','); // create string array
            var numberList = new List<int>();
            var path = new Stack<int>();
            var results = "";

            try
            {
                strArray.ToList().ForEach(x => numberList.Add(Convert.ToInt32(x))); // convert array into int 
                var pathFromCache = _cacheService.GetCacheByArray(numberList.ToArray());

                if (pathFromCache == null)
                {
                    path = _arrayService.ReversePath(_arrayService.FindPath(numberList.ToArray()));
                    if (!_arrayService.Failure) // don't save to cache if it's unreachable
                    {
                        _cacheService.AddCacheToRepository(numberList.ToArray(), path);
                    }
                }

                else
                {
                    path = pathFromCache;
                }

                results = _outputService.PrepareOutput(numberList.ToArray(), path, _arrayService.Failure);
                _arrayService.Failure = false;
            }

            catch
            {
                Console.WriteLine("Error");
            }

            return results;
        }

        [HttpGet]
        public string GetCache()
        {
            var results = "";
            try
            {
                results = _outputService.PrepareCacheOutput();
            }
            catch
            {
                Console.WriteLine("Error");
            }
            return results;
        }
    }
}
