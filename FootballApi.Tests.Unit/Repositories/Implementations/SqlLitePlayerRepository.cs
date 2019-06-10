using System;
using System.Linq;
using System.Threading.Tasks;
using FootballApi.Models;
using FootballApi.Repositories.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FootballApi.Tests.Unit.Repositories.Implementations
{
    [TestClass]
    public class SqlLitePlayerRepositoryTests
    {
        [TestMethod]
        public async Task GetAll_HappyPath()
        {
            var repository = new SqlLitePlayerRepository();

            var allPlayers = await repository.GetAll();

            Assert.AreEqual(142, allPlayers.Count());
        }

        [TestMethod]
        public void GetById_HappyPath()
        {
            var repository = new SqlLitePlayerRepository();

            var playerById = repository.GetById(1);
            Assert.AreEqual(1, playerById.Id);//sera assim?
        }


        [TestMethod]
        public async Task AddPlayer_HappyPath()
        {
            var repository = new SqlLitePlayerRepository();
            DateTime localDate = DateTime.Now;

            var player = new Player();
            player.Name ="Candido";
            player.Key = "candido";
            player.Create_At = localDate.ToString();
            player.Updated_At = localDate.ToString();

            var addPlayers = await repository.AddPlayer(player);

            //Assert.AreEqual(1, addPlayers);
        }

        [TestMethod]
        public async Task UpdatePlayer_HappyPath()
        {
            var repository = new SqlLitePlayerRepository();

            var player = new Player();
            player.Id = 1;
            player.Name = "Albenkjkjka";
           

            var updatePlayer = await repository.UpdatePlayer((int)(player.Id),player);
            
            Assert.AreEqual(1, updatePlayer);
        }



        [TestMethod]
        public async Task DeletePlayer_HappyPath()
        {
            var repository = new SqlLitePlayerRepository();

            var deletePlayer = await repository.DeletePlayer(143);


             Assert.AreEqual(1, deletePlayer);
        }











    }

}
