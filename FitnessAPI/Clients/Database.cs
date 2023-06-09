using Npgsql;
using FitnessAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Xml.Linq;
using System;

namespace FitnessAPI.Clients
{
    public class Database
    {
        NpgsqlConnection con = new NpgsqlConnection(Constants.database);
        List<Exercise> exercises = new List<Exercise>();
        public async Task InsertExerciseAsync(Exercise exercise)
        {
            var sql = "INSERT into public.\"Exercises\"(\"Name\", \"Type\", \"Muscle\", \"Equipment\", \"Difficulty\", \"Instructions\", \"UserID\")"
                        + $"values (@Name, @Type, @Muscle, @Equipment, @Difficulty, @Instructions, @UserID)";
            NpgsqlCommand comm = new NpgsqlCommand(sql, con);
            comm.Parameters.AddWithValue("Name", exercise.name);
            comm.Parameters.AddWithValue("Type", exercise.type);
            comm.Parameters.AddWithValue("Muscle", exercise.muscle);
            comm.Parameters.AddWithValue("Equipment", exercise.equipment);
            comm.Parameters.AddWithValue("Difficulty", exercise.difficulty);
            comm.Parameters.AddWithValue("Instructions", exercise.instructions);
            comm.Parameters.AddWithValue("UserID", exercise.userid);
            await con.OpenAsync();
            await comm.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }
        public async Task DeleteExerciseByIdAsync(int id, long userID)
        {
            var sql = "DELETE from public.\"Exercises\" where \"ID\" = @Id AND \"UserID\" = @UserID";
            NpgsqlCommand comm = new NpgsqlCommand(sql, con);
            comm.Parameters.AddWithValue("Id", id);
            comm.Parameters.AddWithValue("UserID", userID);
            await con.OpenAsync();
            await comm.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task PutExerciseAsync(Exercise exercise)
        {
            var sql = "UPDATE public.\"Exercises\" set \"Name\" = @Name, \"Type\" = @Type, \"Muscle\" = @Muscle, \"Equipment\" = @Equipment, \"Difficulty\" = @Difficulty, \"Instructions\" = @Instructions WHERE \"ID\" = @Id AND \"UserID\" = @UserID";
            NpgsqlCommand comm = new NpgsqlCommand(sql, con);
            comm.Parameters.AddWithValue("Name", exercise.name);
            comm.Parameters.AddWithValue("Type", exercise.type);
            comm.Parameters.AddWithValue("Muscle", exercise.muscle);
            comm.Parameters.AddWithValue("Equipment", exercise.equipment);
            comm.Parameters.AddWithValue("Difficulty", exercise.difficulty);
            comm.Parameters.AddWithValue("Instructions", exercise.instructions);
            comm.Parameters.AddWithValue("Id", exercise.id);
            comm.Parameters.AddWithValue("UserID", exercise.userid);
            await con.OpenAsync();
            await comm.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task<List<Exercise>> GetExerciseByNameAsync(string name, long userId)
        {
            await con.OpenAsync();
            var sql = "SELECT * from public.\"Exercises\" where \"Name\" = @Name AND \"UserID\" = @UserID";
            NpgsqlCommand comm = new NpgsqlCommand(sql, con);
            comm.Parameters.AddWithValue("Name", name);
            comm.Parameters.AddWithValue("UserID", userId);
            NpgsqlDataReader npgsqlDataReader = await comm.ExecuteReaderAsync();
            while (await npgsqlDataReader.ReadAsync())
            {
                exercises.Add(new Exercise {
                    name = npgsqlDataReader.GetString(0),
                    type = npgsqlDataReader.GetString(1),
                    muscle = npgsqlDataReader.GetString(2),
                    equipment = npgsqlDataReader.GetString(3),
                    difficulty = npgsqlDataReader.GetString(4),
                    instructions = npgsqlDataReader.GetString(5),
                    userid = npgsqlDataReader.GetInt64(6),
                    id = npgsqlDataReader.GetInt32(7)
                });
            }
            await con.CloseAsync();
            return exercises;
        }

        public async Task<List<Exercise>> GetAllExerciseAsync(long userId)
        {
            await con.OpenAsync();
            var sql = "SELECT * from public.\"Exercises\" where \"UserID\" = @UserID";
            NpgsqlCommand comm = new NpgsqlCommand(sql, con);
            comm.Parameters.AddWithValue("UserID", userId);
            NpgsqlDataReader npgsqlDataReader = await comm.ExecuteReaderAsync();
            while (await npgsqlDataReader.ReadAsync())
            {
                exercises.Add(new Exercise
                {
                    name = npgsqlDataReader.GetString(0),
                    type = npgsqlDataReader.GetString(1),
                    muscle = npgsqlDataReader.GetString(2),
                    equipment = npgsqlDataReader.GetString(3),
                    difficulty = npgsqlDataReader.GetString(4),
                    instructions = npgsqlDataReader.GetString(5),
                    userid = npgsqlDataReader.GetInt64(6),
                    id = npgsqlDataReader.GetInt32(7)
                });;
            }
            await con.CloseAsync();
            return exercises;
        }

        public async Task<List<Exercise>> GetAllExerciseByMuscleAsync(string muscle, long userId)
        {
            await con.OpenAsync();
            var sql = "SELECT * from public.\"Exercises\" where \"Muscle\" = @Muscle AND \"UserID\" = @UserID";
            NpgsqlCommand comm = new NpgsqlCommand(sql, con);
            comm.Parameters.AddWithValue("Muscle", muscle);
            comm.Parameters.AddWithValue("UserID", userId);
            NpgsqlDataReader npgsqlDataReader = await comm.ExecuteReaderAsync();
            while (await npgsqlDataReader.ReadAsync())
            {
                exercises.Add(new Exercise
                {
                    name = npgsqlDataReader.GetString(0),
                    type = npgsqlDataReader.GetString(1),
                    muscle = npgsqlDataReader.GetString(2),
                    equipment = npgsqlDataReader.GetString(3),
                    difficulty = npgsqlDataReader.GetString(4),
                    instructions = npgsqlDataReader.GetString(5)
                });
            }
            await con.CloseAsync();
            return exercises;
        }

        public async Task<List<Exercise>> GetAllExerciseByTypeAsync(string type, long userId)
        {
            await con.OpenAsync();
            var sql = "SELECT * from public.\"Exercises\" where \"Type\" = @Type AND \"UserID\" = @userID";
            NpgsqlCommand comm = new NpgsqlCommand(sql, con);
            comm.Parameters.AddWithValue("Type", type);
            comm.Parameters.AddWithValue("UserID", userId);
            NpgsqlDataReader npgsqlDataReader = await comm.ExecuteReaderAsync();
            while (await npgsqlDataReader.ReadAsync())
            {
                exercises.Add(new Exercise
                {
                    name = npgsqlDataReader.GetString(0),
                    type = npgsqlDataReader.GetString(1),
                    muscle = npgsqlDataReader.GetString(2),
                    equipment = npgsqlDataReader.GetString(3),
                    difficulty = npgsqlDataReader.GetString(4),
                    instructions = npgsqlDataReader.GetString(5)
                });
            }
            await con.CloseAsync();
            return exercises;
        }

        public async Task<List<Exercise>> GetAllExerciseByDifficultyAsync(string difficulty, long userId)
        {
            await con.OpenAsync();
            var sql = "SELECT * from public.\"Exercises\" where \"Difficulty\" = @Difficulty AND \"UserID\" = @userID";
            NpgsqlCommand comm = new NpgsqlCommand(sql, con);
            comm.Parameters.AddWithValue("Difficulty", difficulty);
            comm.Parameters.AddWithValue("userID", userId);
            NpgsqlDataReader npgsqlDataReader = await comm.ExecuteReaderAsync();
            while (await npgsqlDataReader.ReadAsync())
            {
                exercises.Add(new Exercise
                {
                    name = npgsqlDataReader.GetString(0),
                    type = npgsqlDataReader.GetString(1),
                    muscle = npgsqlDataReader.GetString(2),
                    equipment = npgsqlDataReader.GetString(3),
                    difficulty = npgsqlDataReader.GetString(4),
                    instructions = npgsqlDataReader.GetString(5)
                });
            }
            await con.CloseAsync();
            return exercises;
        }

        public async Task DeleteExerciseByNameAsync(string name, long userId)
        {
            var sql = "DELETE from public.\"Exercises\" where \"Name\" = @Name AND \"UserID\" = @userID";
            NpgsqlCommand comm = new NpgsqlCommand(sql, con);
            comm.Parameters.AddWithValue("Name", name);
            comm.Parameters.AddWithValue("userID", userId);
            await con.OpenAsync();
            await comm.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }
    }
}
