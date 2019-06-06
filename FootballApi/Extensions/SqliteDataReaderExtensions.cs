using System;
using Microsoft.Data.Sqlite;

namespace FootballApi.Extensions
{
    public static class SqliteDataReaderExtensions
    {
        // Se fosse só para um tipo expecifico
        // public static int GetInt32(this SqliteDataReader reader, int index, int defaultValue) {
        //     var value = reader[index];

        //     if (value.GetType() == typeof(DBNull)) {
        //         return (int)defaultValue;
        //     } else {
        //         return (int)value;
        //     }
        // }

        public static T Get<T>(this SqliteDataReader reader, int index, T defaultValue) {
            var value = reader[index];

            if (value.GetType() == typeof(DBNull)) {
                return defaultValue;
            } else {
                return (T)Convert.ChangeType(value, Type.GetTypeCode(typeof(T)));
            }
        }
    }
}