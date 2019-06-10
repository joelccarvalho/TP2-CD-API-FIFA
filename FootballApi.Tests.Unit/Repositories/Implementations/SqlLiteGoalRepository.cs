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
            var allGoals = await repository.GetAll();
            

            Assert.AreEqual(134, allGoals.Count()); //n ta ceerto o nº

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
