using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
namespace ChessApp
{
    class DatabaseConnection
    {
        public void  saveToDatabase(string player1,string player2,string timeOfGame) {
            SQLiteConnection conn;
            try
            {
                String connectionString = "Data Source='info.db';Version=3;";
                conn = new SQLiteConnection(connectionString);
                conn.Open();
                String insertCommand = "Insert into games(player1,player2,time) values('"+player1+"','"+player2+"','"+timeOfGame+"')";
                SQLiteCommand cmd = new SQLiteCommand(insertCommand, conn);
                int count=cmd.ExecuteNonQuery();
               

                conn.Close();
                Console.WriteLine(count);
            }
            catch (SQLiteException e) {
                Console.WriteLine(e);
            }
        
        }
    }
}
