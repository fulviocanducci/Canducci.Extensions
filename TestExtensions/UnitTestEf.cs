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
        public void TestEfGroupSumWithSelect()
        {
            var item = SQLiteContext.People
                .Group(a => new { Value = a.Sum(c => c.Value) })
                .FirstOrDefault();

            Assert.AreEqual(item.Value, 600D);
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

        [TestMethod()]
        public void TestEfGroupCountSumWithSelect()
        {
            var objectGroup = SQLiteContext.People
                .Group(s => new { Count = s.Count(), Sum = s.Sum(p => p.Value) })
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
        public void TestEfGroupCountWithSelect()
        {
            int count = SQLiteContext.People
                .Group(s => s.Count())
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
        public void TestEfGroupMinWithSelect()
        {
            double sum = SQLiteContext.People
                .Group(s => s.Min(p => p.Value))
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

        [TestMethod]
        public void TestEfGroupMaxWithSelect()
        {
            double sum = SQLiteContext.People
                .Group(s => s.Max(p => p.Value))
                .FirstOrDefault();
            Assert.AreEqual(sum, 300D);
        }
    }
}