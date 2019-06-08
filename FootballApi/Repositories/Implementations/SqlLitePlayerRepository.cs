﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballApi.Models;


namespace FootballApi.Repositories.Implementations
{
    public class SqlLitePlayerRepository : IPlayerRepository
    {
        public void Add(Player product)
        {
            throw new NotImplementedException();
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
                            key = reader.GetString(1),
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

        public async Task<IEnumerable<Player>> InsertPlayer(string key, string name, DateTime created_at, DateTime updated_at)
        {
            var playerInserted = new List<Player>();
            using (var connection = SqlLite.GetConnection())
            {
                await connection.OpenAsync();

                var selectCommand = connection.CreateCommand();
                selectCommand.CommandText = "INSERT INTO persons (key, name, created_at,updated_at) VALUES("+key+", "+name+", "+created_at+", "+updated_at+")";

                //using (var reader = await selectCommand.ExecuteReaderAsync())    É preciso?
                //{
                //    while (await reader.ReadAsync())
                //    {
                //        var player = new Player()
                //        {
                //            Id = reader.GetInt64(0),
                //            key = reader.GetString(1),
                //            Name = reader.GetString(2),
                //        };

                //        playerInserted.Add(player);
                //    }
                //}
            };

            return playerInserted;
        }
    }
}
