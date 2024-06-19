using Npgsql;
using WebApplication1.Models;

namespace WebApplication1.Database
{
    public class DatabaseHandler
    {
        NpgsqlConnection conn = new NpgsqlConnection(Constants.DB_Connection);

        public async Task DB_Data_insert (DatabaseModel databaseModel)
        {
            var sql = "insert into public.\"RegisteredParcelsDB\"(\"user_id\",\"parcel_code\",\"parcel_tag\",\"parcel_description\",\"registration_time\")"
                + $"values (@user_id, @parcel_code, @parcel_tag, @parcel_description, @registration_time)";

            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("user_id", databaseModel.User_id);
            cmd.Parameters.AddWithValue("parcel_code", databaseModel.Parcel_code);
            cmd.Parameters.AddWithValue("parcel_tag", databaseModel.Parcel_tag);
            cmd.Parameters.AddWithValue("parcel_description", databaseModel.Parcel_description);
            cmd.Parameters.AddWithValue("registration_time", databaseModel.Registration_time);

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await conn.CloseAsync();

            return;
        }

        public async Task <List <DatabaseModel>> DB_Data_select(int user_id)
        {
            List <DatabaseModel> databaseModels = new List<DatabaseModel>();

            var sql = $"select \"user_id\",\"parcel_code\",\"parcel_tag\",\"parcel_description\",\"registration_time\" from public.\"RegisteredParcelsDB\" where user_id = {user_id}";

            await conn.OpenAsync();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                databaseModels.Add(new DatabaseModel(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4) ));
            }

            await conn.CloseAsync();

            return databaseModels;
        }

        public async Task DB_Data_delete(string parcel_code)
        {
            var sql = $"delete from public.\"RegisteredParcelsDB\" where parcel_code = '{parcel_code}'";

            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await conn.CloseAsync();

            return;
        }

    }
}
