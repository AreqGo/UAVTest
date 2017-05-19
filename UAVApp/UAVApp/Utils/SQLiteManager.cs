using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace UAVApp.Utils
{
    public static class SQLiteManager
    {
        static string DBFileName = "D:\\db\\UAV.db";
        public static DataView GetNWindData(string tableName)
        {
            if (DBFileName != "")
            {
                SQLiteConnection conn = null;

                string dbPath = "Data Source =" + DBFileName;
                conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置  
                conn.Open();//打开数据库，若文件不存在会自动创建  

                string sql = "SELECT TaskID,TaskName,TaskUAV,TaskTime FROM " + tableName;
                SQLiteCommand cmdQ = new SQLiteCommand(sql, conn);

                SQLiteDataReader reader = cmdQ.ExecuteReader();

                DataTable TSelectReSoult = new DataTable();  /*存放要在Gridview里面显示的最后结果*/
                TSelectReSoult.Load(reader);

                reader.Close();                        /*记得用完要关闭reader*/

                var dvTutorial = TSelectReSoult.DefaultView;

                conn.Close();

                return dvTutorial;
            }
            return null;
        }

        public static DataTable GetNWindData(string tableName, string condition)
        {
            if (DBFileName != "")
            {
                SQLiteConnection conn = null;

                string dbPath = "Data Source =" + DBFileName;
                conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置  
                conn.Open();//打开数据库，若文件不存在会自动创建  

                string sql = "SELECT * FROM " + tableName + "WHERE " + condition;
                SQLiteCommand cmdQ = new SQLiteCommand(sql, conn);

                SQLiteDataReader reader = cmdQ.ExecuteReader();

                DataTable TSelectReSoult = new DataTable();  /*存放要在Gridview里面显示的最后结果*/
                TSelectReSoult.Load(reader);

                reader.Close();                        /*记得用完要关闭reader*/

                //var dvTutorial = TSelectReSoult.DefaultView;

                conn.Close();

                return TSelectReSoult;
            }
            return null;
        }


        public static bool removeDataRow(string condition, string tableName)
        {
            try
            {
                if (DBFileName != "")
                {
                    SQLiteConnection conn = null;

                    string dbPath = "Data Source =" + DBFileName;
                    conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置  
                    conn.Open();//打开数据库，若文件不存在会自动创建  

                    string sql = "DELETE FROM " + tableName + " WHERE " + condition;
                    SQLiteCommand cmdQ = new SQLiteCommand(sql, conn);
                    cmdQ.ExecuteReader();
                    conn.Close();

                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public static DataView UpdatePoleFault(string condition)
        {
            if (DBFileName != "")
            {
                SQLiteConnection conn = null;

                string dbPath = "Data Source =" + DBFileName;
                conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置  
                conn.Open();//打开数据库，若文件不存在会自动创建  

                //string sql = "SELECT * FROM " + tableName;

                string sql = "REPLACE INTO PoleFault(ID,FPATH,FPOSITION,FDESC,FTIME)VALUES("
                    + condition + ")";

                SQLiteCommand cmdQ = new SQLiteCommand(sql, conn);

                SQLiteDataReader reader = cmdQ.ExecuteReader();

                DataTable TSelectReSoult = new DataTable();  /*存放要在Gridview里面显示的最后结果*/
                TSelectReSoult.Load(reader);

                reader.Close();                        /*记得用完要关闭reader*/

                var dvTutorial = TSelectReSoult.DefaultView;

                conn.Close();

                return dvTutorial;
            }
            return null;
        }

        static byte[] GetBytes(SQLiteDataReader reader)
        {
            const int CHUNK_SIZE = 2 * 1024;
            byte[] buffer = new byte[CHUNK_SIZE];
            long bytesRead;
            long fieldOffset = 0;
            using (MemoryStream stream = new MemoryStream())
            {
                while ((bytesRead = reader.GetBytes(0, fieldOffset, buffer, 0, buffer.Length)) > 0)
                {
                    stream.Write(buffer, 0, (int)bytesRead);
                    fieldOffset += bytesRead;
                }
                return stream.ToArray();
            }
        }

        public static string ReadBlobText()
        {
            using (var connection = new SQLiteConnection("Data Source="+ DBFileName+";Version=3"))
            using (var command = new SQLiteCommand("SELECT TaskDesign FROM T_Design WHERE TaskID = 'UAV-01'", connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read()){
                        byte[] buffer = GetBytes(reader);
                        return System.Text.Encoding.UTF8.GetString(buffer);
                    }
                    return "";
                }
            }
        }
    }
}
