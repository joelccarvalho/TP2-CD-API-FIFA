using System.Linq;
using System.Threading.Tasks;
using FootballApi.Repositories.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FootballApi.Tests.Unit.Repositories.Implementations
{
    [TestClass]
    public class SqlLiteGoalRepositoryTests
    {
        [TestMethod]
        public async Task GetAll_HappyPath()
        {
            var repository = new SqlLiteGoalRepository();
            var allGoals   = await repository.GetAll();

            Assert.IsTrue(allGoals.Count() >= 132, "true"); 
        }

        [TestMethod]
        public void GetByName_HappyPath()
        {
            var repository = new SqlLiteGoalRepository();

            var goalByName = repository.GetByName("Messi");
            
            Assert.AreEqual("Messi", goalByName.Name);
        }

    }
}
