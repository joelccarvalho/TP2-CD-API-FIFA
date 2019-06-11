using System.Linq;
using System.Threading.Tasks;
using FootballApi.Repositories.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FootballApi.Tests.Unit.Repositories.Implementations
{
    [TestClass]
    public class SqlLiteCountryRepositoryTests
    {
        [TestMethod]
        public async Task GetAll_HappyPath()
        {
            var repository   = new SqlLiteCountryRepository();
            var allCountries = await repository.GetAll();

            Assert.AreEqual(250, allCountries.Count());

        }

        [TestMethod]
        public void GetById_HappyPath()
        {
            var repository  = new SqlLiteCountryRepository();

            var countryById = repository.GetById(1);

            Assert.AreEqual(1, countryById.Id);
        }
    }
}
