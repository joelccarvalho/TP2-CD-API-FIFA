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

            Assert.IsTrue(allPlayers.Count() >= 134, "true"); 
        }

        [TestMethod]
        public void GetById_HappyPath()
        {
            var repository = new SqlLitePlayerRepository();

            var playerById = repository.GetById(2);

            Assert.AreEqual(2, playerById.Id);
        }


        [TestMethod]
        public async Task AddPlayer_HappyPath()
        {
            var repository     = new SqlLitePlayerRepository();
            DateTime localDate = DateTime.Now;

            var player         = new Player();
            player.Name        = "Novo Jogador";
            player.Key         = "novo jogador";
            player.Create_At   = localDate.ToString();
            player.Updated_At  = localDate.ToString();

            var addPlayer     = await repository.AddPlayer(player);

            Assert.AreEqual(player.Name, addPlayer.Name); 
        }

        [TestMethod]
        public async Task UpdatePlayer_HappyPath()
        {
            var repository   = new SqlLitePlayerRepository();

            var player       = new Player();
            player.Id        = 100;
            player.Name      = "Jogador Atualizado";
           
            var updatePlayer = await repository.UpdatePlayer((int)(player.Id), player);
            
            Assert.AreEqual(1, updatePlayer);
        }

        [TestMethod]
        //[Ignore]
        public async Task DeletePlayer_HappyPath()
        {
            var repository   = new SqlLitePlayerRepository();

            var deletePlayer = await repository.DeletePlayer(1);

            Assert.AreEqual(1, deletePlayer);
        }











    }

}
