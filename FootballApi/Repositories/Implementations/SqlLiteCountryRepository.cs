using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballApi.Models;

namespace FootballApi.Repositories.Implementations
{
    public class SqlLiteCountryRepository : ICountryRepository
    {
        public void Add(Country product)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            var listOfCountries = new List<Country>();
            using (var connection = SqlLite.GetConnection()) {
                await connection.OpenAsync();

                var selectCommand = connection.CreateCommand();
                selectCommand.CommandText = "SELECT id, name, slug, code, pop, area FROM countries";
                
                using (var reader = await selectCommand.ExecuteReaderAsync()) {
                    while (await reader.ReadAsync()) {
                        var country = new Country() {
                            Id = reader.GetInt64(0),
                            Name = reader.GetString(1),
                            Slug = reader.GetString(2),
                            Code = reader.GetString(3),
                            Population = reader.GetInt64(4),
                            Area = reader.GetInt64(5)
                        };

                        listOfCountries.Add(country);
                    }
                }
            };

            return listOfCountries;
        }

        public Country GetById(int id)
        {
            using (var connection = SqlLite.GetConnection()) {
                connection.OpenAsync();

                var selectCommand = connection.CreateCommand();
                selectCommand.CommandText = "SELECT id, name, slug, code, pop, area FROM countries WHERE id = @id";
                selectCommand.Parameters.AddWithValue("@id", id);

                using (var reader = selectCommand.ExecuteReader()) {
                    if (reader.HasRows) {
                        using (reader.ReadAsync()) {
                            var country = new Country() {
                                Id = reader.GetInt64(0),
                                Name = reader.GetString(1),
                                Slug = reader.GetString(2),
                                Code = reader.GetString(3),
                                Population = reader.GetInt64(4),
                                Area = reader.GetInt64(5)
                            };
                            return country;
                        }
                    } else {
                        return null;
                    }
                }
            }
        }
    }
}