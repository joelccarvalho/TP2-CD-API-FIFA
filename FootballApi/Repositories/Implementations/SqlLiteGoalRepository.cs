using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballApi.Models;


namespace FootballApi.Repositories.Implementations
{
    public class SqlLiteGoalRepository : IGoalRepository
    {
        public void Add(Goal product)
        {
            throw new NotImplementedException();
        }
       
        public async Task<IEnumerable<Goal>> GetAll()
        {
            var listOfGoal = new List<Goal>();
            using (var connection = SqlLite.GetConnection())
            {
                await connection.OpenAsync();

                var selectCommand = connection.CreateCommand();
                //selectCommand.CommandText = "SELECT goals.id, goals.person_id, persons.name, goals.game_id, goals.team_id, goals.minute, " +
                //    "goals.offset, goals.score1, goals.score2 FROM goals JOIN persons on goals.person_id = persons.id";
                selectCommand.CommandText = "SELECT COUNT(goals.id) AS NumberOFGoals, persons.name FROM goals INNER JOIN persons On persons.id = goals.person_id Group By persons.name";

                using (var reader = await selectCommand.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var goal = new Goal()
                        {
                            NumberGols = reader.GetInt64(0),
                            //Id = reader.GetInt64(0),
                            //PersonId = reader.GetInt64(1),
                            Name = reader.GetString(1),
                            //GameId = reader.GetInt64(3),
                            //TeamId = reader.GetInt64(4),
                            //minute = reader.GetInt64(5),
                            //offset = reader.GetInt64(6),
                            //score1 = reader.GetInt64(7),
                            //score2 = reader.GetInt64(8)
                        };

                        listOfGoal.Add(goal);
                    }
                }
            };

            return listOfGoal;
          
        }

        public Goal GetByName(string name)
        {
            using (var connection = SqlLite.GetConnection())
            {
                connection.OpenAsync();

                var selectCommand = connection.CreateCommand();
                selectCommand.CommandText = "SELECT COUNT(goals.id) AS NumberOFGoals, persons.name FROM goals INNER JOIN persons On persons.id = goals.person_id Where persons.name = @name Group By persons.name";
                selectCommand.Parameters.AddWithValue("@name", name);

                using (var reader = selectCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        using (reader.ReadAsync())
                        {
                            var goal = new Goal()
                            {
                                NumberGols = reader.GetInt64(0),
                                Name = reader.GetString(1),
                            };
                            return goal;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    }
}

