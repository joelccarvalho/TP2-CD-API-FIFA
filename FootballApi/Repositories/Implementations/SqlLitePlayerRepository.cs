using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballApi.Models;


namespace FootballApi.Repositories.Implementations
{
    public class SqlLitePlayerRepository : IPlayerRepository
    {
        public void Add(Player player)
        {
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<Player>> GetAll()
        {
            var listOfPlayers = new List<Player>();
            using (var connection = SqlLite.GetConnection())
            {
                await connection.OpenAsync();

                var selectCommand = connection.CreateCommand();
                selectCommand.CommandText = "SELECT id, key, name FROM persons";

                using (var reader = await selectCommand.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var player = new Player()
                        {
                            Id = reader.GetInt64(0),
                            Key = reader.GetString(1),
                            Name = reader.GetString(2),
                        };

                        listOfPlayers.Add(player);
                    }
                }
            };

            return listOfPlayers;
        }
        public Player GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Player> AddPlayer(Player player)
        {
            using (var connection = SqlLite.GetConnection())
            {
                await connection.OpenAsync(); // Open async connection

                var selectCommand = connection.CreateCommand();

                // Query parameterized
                selectCommand.CommandText = "INSERT INTO persons (name, key, created_at, updated_at) VALUES(@name, @key, @created_at, @updated_at)";
                
                // Add parameters to query
                selectCommand.Parameters.AddWithValue("@name", player.Name);
                selectCommand.Parameters.AddWithValue("@key", player.Key);
                selectCommand.Parameters.AddWithValue("@created_at", player.Create_At);
                selectCommand.Parameters.AddWithValue("@updated_at", player.Updated_At);

                selectCommand.ExecuteNonQuery(); // Run query
                
                return player; // Return player inserted
            };            
        }

        public async Task<Int64> UpdatePlayer(int id, Player player)
        {
            using (var connection = SqlLite.GetConnection())
            {
                await connection.OpenAsync(); // Open async connection

                var selectCommand = connection.CreateCommand();

                // Query parameterized
                selectCommand.CommandText = "UPDATE persons SET name = @name WHERE id = @id";
                
                // Add parameters to query
                selectCommand.Parameters.AddWithValue("@id", player.Id);
                selectCommand.Parameters.AddWithValue("@name", player.Name);

                var reader = selectCommand.ExecuteNonQuery(); // Run query

                if(reader == 1)
                    return 1; // Return success
                else
                    return 0; // Return insuccess
            };            
        }

        public async Task<Int64> DeletePlayer(int id)
        {
            using (var connection = SqlLite.GetConnection())
            {
                await connection.OpenAsync(); // Open async connection

                var selectCommand = connection.CreateCommand();

                // Query parameterized
                selectCommand.CommandText = "DELETE FROM persons WHERE id = @id";
                
                // Add parameters to query
                selectCommand.Parameters.AddWithValue("@id", id);

                var reader = selectCommand.ExecuteNonQuery(); // Run query

                if(reader == 1)
                    return 1; // Return success
                else
                    return 0; // Return insuccess
            };            
        }
    }
}
