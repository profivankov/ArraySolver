using ArraySolver.Implementation.Services;
using ArraySolver.Interfaces.Services;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace ArraySolver.Tests
{
    [TestFixture]
    public class Tests
    {
        private ArrayService _arrayService;
      
        [SetUp]
        public void Setup()
        {
            _arrayService = new ArrayService();
        }

        [Test]
        public void Should_ReturnCorrectList_When_FindPathCalled()
        {

            var result1 = _arrayService.FindPath(new int[] { 1, 2, 0, 3, 0, 2, 0 });
            var result2 = _arrayService.FindPath(new int[] { 1, 2, 0, 1, 0, 2, 0 });
            var result3 = _arrayService.FindPath(new int[] { 1, 2, 0, -1, 0, 2, 0 });
            var result4 = _arrayService.FindPath(new int[] { 1, 2, 1, -1, 0, 2, 0 });
            var result5 = _arrayService.FindPath(new int[] { 3, 9, 1, 1, 1, 1, 1 });

            var expected1 = new List<int> { 6, 3, 1, 0 };
            var expected2 = new List<int>();
            var expected3 = new List<int>();
            var expected4 = new List<int>();
            var expected5 = new List<int>() { 6, 1, 0 };

            Assert.AreEqual(expected1, result1);
            Assert.AreEqual(expected2, result2);
            Assert.AreEqual(expected3, result3);
            Assert.AreEqual(expected4, result4);
            Assert.AreEqual(expected5, result5);

        }
    }
}