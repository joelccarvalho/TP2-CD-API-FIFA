using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballApi.Models;
using FootballApi.Extensions;

namespace FootballApi.Repositories.Implementations
{
    public class SqlLiteGameRepository : IGameRepository
    { 
        public async Task<IEnumerable<Game>> GetAll()
        {
            var listOfGame = new List<Game>();
            using (var connection = SqlLite.GetConnection()) {
                await connection.OpenAsync();

                var selectCommand = connection.CreateCommand();
                selectCommand.CommandText = "SELECT id, round_id, pos, group_id, team1_id, team2_id, play_at FROM games";
                
                using (var reader = await selectCommand.ExecuteReaderAsync()) {
                    while (await reader.ReadAsync()) {
                        var game = new Game() {
                            Id = reader.GetInt64(0),
                            RoundId = reader.GetInt32(1),
                            Pos = reader.GetInt32(2),
                            GroupId = reader.Get<long>(3, 0),
                            Team_1 = reader.GetInt32(4),
                            Team_2 = reader.GetInt32(5),
                            Play_At = reader.GetDateTime(6)
                        };

                        listOfGame.Add(game);
                    }
                }
            };

            return listOfGame;
        }
    }
}