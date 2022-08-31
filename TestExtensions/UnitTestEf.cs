using Canducci.Extensions.EntityFramework;
using TestExtensions.Ef.DataAccess;
namespace TestExtensions
{
    [TestClass]
    public class UnitTestEf
    {
        internal SQLiteContext SQLiteContext = SQLiteContextFabric.Instance;

        [TestMethod()]
        public void TestEfGroupSum()
        {
            var sum = SQLiteContext.People
                .Group()
                .Select(s => s.Sum(p => p.Value))
                .FirstOrDefault();
            Assert.AreEqual(sum, 600D);
        }

        [TestMethod()]
        public void TestEfGroupCountSum()
        {
            var objectGroup = SQLiteContext.People
                .Group()
                .Select(s => new { Count = s.Count(), Sum = s.Sum(p => p.Value) })
                .FirstOrDefault();
            Assert.AreEqual(objectGroup.Count, 3);
            Assert.AreEqual(objectGroup.Sum, 600D);
        }


        [TestMethod]
        public void TestEfGroupCount()
        {
            int count = SQLiteContext.People
                .Group()
                .Select(s => s.Count())
                .FirstOrDefault();
            Assert.AreEqual(count, 3);
        }

        [TestMethod]
        public void TestEfGroupMin()
        {
            double sum = SQLiteContext.People
                .Group()
                .Select(s => s.Min(p => p.Value))
                .FirstOrDefault();
            Assert.AreEqual(sum, 100D);
        }

        [TestMethod]
        public void TestEfGroupMax()
        {
            double sum = SQLiteContext.People
                .Group()
                .Select(s => s.Max(p => p.Value))
                .FirstOrDefault();
            Assert.AreEqual(sum, 300D);
        }
    }
}