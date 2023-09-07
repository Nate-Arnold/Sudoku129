using Sudoku129.Model;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Xml.Serialization;

namespace Sudoku129.Database
{
    public class SudokuPuzzleDatabase
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["sudokuPuzzleConnectionString"].ToString();

        public SudokuPuzzleDBObject Sudoku_Puzzles_GetByID(int id)
        {
            SudokuPuzzleDBObject puzzle = new SudokuPuzzleDBObject();

            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand("Sudoku_Puzzles_GetByID", connection) { CommandType = CommandType.StoredProcedure };
            command.Parameters.AddWithValue("@ID", id);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                puzzle.ID = (int)reader["ID"];
                puzzle.Name = (string)reader["PuzzleName"];
                puzzle.Author = (string)reader["PuzzleAuthor"];
                puzzle.Description = (string)reader["PuzzleDescription"];
                puzzle.Difficulty = (int)reader["PuzzleDifficulty"];
                string serializedGrid = (string)reader["PuzzleData"];

                using (TextReader stream = new StringReader(serializedGrid))
                {
                    var deserializer = new XmlSerializer(typeof(SudokuGrid));
                    puzzle.PuzzleGrid = (SudokuGrid)deserializer.Deserialize(stream);
                }
            }

            return puzzle;
        }

        public List<SudokuPuzzleDBObject> Sudoku_Puzzles_GetList()
        {
            List<SudokuPuzzleDBObject> puzzles = new List<SudokuPuzzleDBObject>();

            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand("Sudoku_Puzzles_GetList", connection) { CommandType = CommandType.StoredProcedure };

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //Have to create new one each time, or only the first populates entire list
                //May be an issue with assigning, "set", SudokuPuzzleDBObject values
                SudokuPuzzleDBObject puzzle = new SudokuPuzzleDBObject();

                puzzle.ID = (int)reader["ID"];
                puzzle.Name = (string)reader["PuzzleName"];
                puzzle.Author = (string)reader["PuzzleAuthor"];
                puzzle.Difficulty = (int)reader["PuzzleDifficulty"];
                string serializedGrid = (string)reader["PuzzleData"];

                using (TextReader stream = new StringReader(serializedGrid))
                {
                    var deserializer = new XmlSerializer(typeof(SudokuGrid));
                    puzzle.PuzzleGrid = (SudokuGrid)deserializer.Deserialize(stream);
                }

                puzzles.Add(puzzle);
            }

            return puzzles;
        }

        public void Sudoku_Puzzles_SavePuzzle(SudokuPuzzleDBObject puzzle)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand("Sudoku_Puzzles_SavePuzzle", connection) { CommandType = CommandType.StoredProcedure };

            //Serialize Sudoku Grid into xml
            StringWriter writer = new StringWriter(CultureInfo.InvariantCulture);
            XmlSerializer serializer = new XmlSerializer(typeof(SudokuGrid));
            serializer.Serialize(writer, puzzle.PuzzleGrid);

            connection.Open();
            command.Parameters.AddWithValue("@PuzzleName", puzzle.Name);
            command.Parameters.AddWithValue("@PuzzleAuthor", puzzle.Author);
            command.Parameters.AddWithValue("@PuzzleDescription", puzzle.Description);
            command.Parameters.AddWithValue("@PuzzleData", writer.ToString());
            command.Parameters.AddWithValue("@PuzzleDifficulty", puzzle.Difficulty);

            command.ExecuteNonQuery();
        }

        public void Sudoku_Puzzles_RemoveByID(int id)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand("Sudoku_Puzzles_RemoveByID", connection) { CommandType = CommandType.StoredProcedure };
            command.Parameters.AddWithValue("@ID", id);
            connection.Open();
            command.ExecuteNonQuery();
        }

    }
}