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

        public async Task<Game> AddGame(Game game)
        {
            using (var connection = SqlLite.GetConnection())
            {
                await connection.OpenAsync(); // Open async connection

                var selectCommand = connection.CreateCommand();

                // Query parameterized
                selectCommand.CommandText = "INSERT INTO games (round_id, pos, team1_id, team2_id, play_at, postponed, knockout, home, score1, score2, score1i, score2i, winner, winner90, created_at, updated_at) " + 
                "VALUES(@round_id, @pos, @team1_id, @team2_id, @play_at, @postponed, @knockout, @home, @score1, @score2, @score1i, @score2i, @winner, @winner90, @created_at, @updated_at)";
                
                // Add parameters to query
                selectCommand.Parameters.AddWithValue("@round_id", game.RoundId);
                selectCommand.Parameters.AddWithValue("@pos", game.Pos);
                selectCommand.Parameters.AddWithValue("@team1_id", game.Team_1);
                selectCommand.Parameters.AddWithValue("@team2_id", game.Team_2);
                selectCommand.Parameters.AddWithValue("@play_at", game.Play_At);
                selectCommand.Parameters.AddWithValue("@postponed", game.Postponed);
                selectCommand.Parameters.AddWithValue("@knockout", game.Knockout);
                selectCommand.Parameters.AddWithValue("@home", game.Home);
                selectCommand.Parameters.AddWithValue("@score1", game.Score1);
                selectCommand.Parameters.AddWithValue("@score2", game.Score2);
                selectCommand.Parameters.AddWithValue("@score1i", game.Score1i);
                selectCommand.Parameters.AddWithValue("@score2i", game.Score2i);
                selectCommand.Parameters.AddWithValue("@winner", game.Winner);
                selectCommand.Parameters.AddWithValue("@winner90", game.Winner90);
                selectCommand.Parameters.AddWithValue("@created_at", game.Create_At);
                selectCommand.Parameters.AddWithValue("@updated_at", game.Updated_At);

                var reader = selectCommand.ExecuteNonQuery(); // Run query
                
                return game; // Return game inserted
            };            
        }

        public async Task<Int64> StartGame(int id, Game game)
        {
            using (var connection = SqlLite.GetConnection())
            {
                await connection.OpenAsync(); // Open async connection

                var selectCommand = connection.CreateCommand();

                // Query parameterized
                selectCommand.CommandText = "UPDATE games SET play_At = @play_at WHERE id = @id";

                // Add parameters to query
                selectCommand.Parameters.AddWithValue("@id", game.Id);
                selectCommand.Parameters.AddWithValue("@play_at", game.Play_At);

                var reader = selectCommand.ExecuteNonQuery(); // Run query

                if (reader == 1)
                    return 1; // Return success
                else
                    return 0; // Return insuccess
            };
        }
    }
}