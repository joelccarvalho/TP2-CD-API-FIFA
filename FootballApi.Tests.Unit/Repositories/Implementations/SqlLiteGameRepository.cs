using System;
using System.Linq;
using System.Threading.Tasks;
using FootballApi.Models;
using FootballApi.Repositories.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FootballApi.Tests.Unit.Repositories.Implementations
{
    [TestClass]
    public class SqlLiteGameRepositoryTests
    {
        [TestMethod]
        public async Task GetAll_HappyPath()
        {
            var repository = new SqlLiteGameRepository();
            var allGames   = await repository.GetAll();
           
            Assert.IsTrue(allGames.Count() >= 64, "true"); 
        }

        [TestMethod]
        public async Task AddGame_HappyPath()
        {
            var repository     = new SqlLiteGameRepository();
            DateTime localDate = DateTime.Now;

            var game        = new Game();
            game.RoundId    = 2;
            game.Pos        = 1;
            game.GroupId    = 1;
            game.Team_1     = 1;
            game.Team_2     = 2;
            game.Play_At    = localDate;
            game.Postponed  = false;
            game.Knockout   = false;
            game.Home       = true;
            game.Score1     = 1;
            game.Score2     = 0;
            game.Score1i    = 2;
            game.Score2i    = 0;
            game.Winner     = 1;
            game.Winner90   = 1;
            game.Create_At  = localDate.ToString();
            game.Updated_At = localDate.ToString();

            var addGame     = await repository.AddGame(game); 

            Assert.AreEqual(game.RoundId, addGame.RoundId); 
        }


        [TestMethod]
        public async Task StartGame_HappyPath()
        {
            var repository = new SqlLiteGameRepository();
            
            DateTime startingDate = DateTime.Parse("2019-06-11 20:00:00");

            var game     = new Game();
            game.Id      = 1;
            game.Play_At = startingDate;

            var StartingGame = await repository.StartGame((int)(game.Id), game);

            Assert.AreEqual(1, StartingGame);
        }

    }

}
