using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Data.SQLite;

namespace RomulatorFrontend.Controller
{
    public class PlayStats
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Init()
        {
            if (!File.Exists(Vars.StatsDatabase))
            {

                if(!Directory.Exists(Path.GetDirectoryName(Vars.StatsDatabase)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(Vars.StatsDatabase));
                }
                SQLiteConnection.CreateFile(Vars.StatsDatabase);

                var m_dbConnection = new SQLiteConnection(string.Format("Data Source=\"{0}\";Version=3;", Vars.StatsDatabase));
                m_dbConnection.Open();

                var createRatingsTable = "create table GameRatings(emulator text, rom text, rating int )";
                var createPlaytimeTable = "create table PlayTime(emulator text, rom text, beginTimeStamp int, endTimeStamp int)";


                new SQLiteCommand(createRatingsTable, m_dbConnection).ExecuteNonQuery();
                new SQLiteCommand(createPlaytimeTable, m_dbConnection).ExecuteNonQuery();

                m_dbConnection.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emulator"></param>
        /// <param name="rom"></param>
        /// <param name="rating"></param>
        public static void SetRating(string emulator, string rom, int rating)
        {
            var m_dbConnection = new SQLiteConnection(string.Format("Data Source=\"{0}\";Version=3;", Vars.StatsDatabase));
            m_dbConnection.Open();

            var insertRatingText = "insert into GameRatings (emulator, rom, rating) values (@emulator, @rom, @rating)";
            var updateRatingText = "update GameRatings set rating= @rating where emulator=@emulator and rom = @rom";
            var checkTestText = "select count(*) from GameRatings where emulator = @emulator and rom = @rom";

            var checkExistsCmd = new SQLiteCommand(checkTestText, m_dbConnection);
            checkExistsCmd.Parameters.AddWithValue("@emulator", emulator);
            checkExistsCmd.Parameters.AddWithValue("@rom", rom);

            if ((long)checkExistsCmd.ExecuteScalar() > 0)
            {
                var updateCommand = new SQLiteCommand(updateRatingText, m_dbConnection);
                updateCommand.Parameters.AddWithValue("@emulator", emulator);
                updateCommand.Parameters.AddWithValue("@rom", rom);
                updateCommand.Parameters.AddWithValue("@rating", rating);
                updateCommand.ExecuteNonQuery();
            }
            else
            {
                var insertCommand = new SQLiteCommand(insertRatingText, m_dbConnection);
                insertCommand.Parameters.AddWithValue("@emulator", emulator);
                insertCommand.Parameters.AddWithValue("@rom", rom);
                insertCommand.Parameters.AddWithValue("@rating", rating);
                insertCommand.ExecuteNonQuery();
            }

            m_dbConnection.Close();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emulator"></param>
        /// <param name="rom"></param>
        /// <returns></returns>
        public static int GetRating(string emulator, string rom)
        {
            long result = 0;

            var m_dbConnection = new SQLiteConnection(string.Format("Data Source=\"{0}\";Version=3;", Vars.StatsDatabase));
            m_dbConnection.Open();

            var getRatingText = "select rating from GameRatings where emulator = @emulator and rom = @rom";

            var getRatingCmd = new SQLiteCommand(getRatingText, m_dbConnection);
            getRatingCmd.Parameters.AddWithValue("@emulator", emulator);
            getRatingCmd.Parameters.AddWithValue("@rom", rom);
            try
            {
                result = (long) getRatingCmd.ExecuteScalar();
            }
            catch { }
            m_dbConnection.Close();

            return (int)result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emulator"></param>
        /// <param name="rom"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public static void InsertPlayTime(string emulator, string rom, DateTime start, DateTime end)
        {
            var m_dbConnection = new SQLiteConnection(string.Format("Data Source=\"{0}\";Version=3;", Vars.StatsDatabase));
            m_dbConnection.Open();

            var insertText = "insert into PlayTime (emulator, rom, beginTimestamp, endTimeStamp) values (@emulator, @rom, @begin, @end)";

            var insertCmd = new SQLiteCommand(insertText, m_dbConnection);
            insertCmd.Parameters.AddWithValue("@emulator", emulator);
            insertCmd.Parameters.AddWithValue("@rom", rom);
            insertCmd.Parameters.AddWithValue("@begin", start.ToBinary());
            insertCmd.Parameters.AddWithValue("@end", end.ToBinary());

            try
            {
                insertCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            m_dbConnection.Close();
        }

        public static TimeSpan GetPlayTime(string emulator, string rom)
        {
            var ts = new TimeSpan();

            var m_dbConnection = new SQLiteConnection(string.Format("Data Source=\"{0}\";Version=3;", Vars.StatsDatabase));
            m_dbConnection.Open();

            var playTimeCommand = "select sum(endTimestamp - beginTimestamp) from PlayTime where emulator = @emulator and rom = @rom";

            var cmd = new SQLiteCommand(playTimeCommand, m_dbConnection);
            cmd.Parameters.AddWithValue("@emulator", emulator);
            cmd.Parameters.AddWithValue("@rom", rom);

            try
            {
                long tspanInmSeconds = (long)cmd.ExecuteScalar();
                ts = TimeSpan.FromTicks(tspanInmSeconds);
            }
            catch { }
            m_dbConnection.Close();

            return ts;

        }

        public static int GetPlayCount(string emulator, string rom)
        {
            int playcount = 0;
            var m_dbConnection = new SQLiteConnection(string.Format("Data Source=\"{0}\";Version=3;", Vars.StatsDatabase));
            m_dbConnection.Open();

            var playTimeCommand = "select count(*) from PlayTime where emulator = @emulator and rom = @rom";

            var cmd = new SQLiteCommand(playTimeCommand, m_dbConnection);
            cmd.Parameters.AddWithValue("@emulator", emulator);
            cmd.Parameters.AddWithValue("@rom", rom);

            var px = (long)cmd.ExecuteScalar();

            playcount = (int)px;

         

            m_dbConnection.Close();

            return playcount;
        }

    }
}
