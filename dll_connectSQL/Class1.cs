using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace dll_connectSQL
{
    public class DataBase_SQL
    {
        public string cnstr = "Server=NEKOTRANG\\DATASQL;Database=TNUT;User Id=sa;Password=123;";
        public string Login(string uid, string pwd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cnstr))
                {
                    string query = @"
                    SELECT LoaiTK 
                    FROM TaiKhoan 
                    WHERE uid = @uid AND pwd = @pwd";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", uid);
                        cmd.Parameters.AddWithValue("@pwd", pwd);
                        var result = cmd.ExecuteScalar();
                        if (result != null) return result.ToString();
                        else return null;
                    }
                }
            }
            catch
            {
                return null;
            }
        }
        public (string, string, string, string, string, string, string) GetSV(string MSV_input)
        {
            string HVT_SV = "";
            string MaLop = "";
            string TenLop = "";
            string MaKhoa = "";
            string TenKhoa = "";
            string MGV = "";
            string HVT_GV = "";
            using (SqlConnection connection = new SqlConnection(cnstr))
            {
                connection.Open();
                string query = "SELECT HoTen, MaLop FROM ThongTin_SV WHERE MSV = @MSV";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MSV", MSV_input);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    HVT_SV = reader["HoTen"].ToString();
                    MaLop = reader["MaLop"].ToString();
                }
            }
            using (SqlConnection connection = new SqlConnection(cnstr))
            {
                connection.Open();
                string query = @"
                SELECT Lop.TenLop, Lop.MaKhoa, Khoa.TenKhoa
                FROM Lop
                INNER JOIN Khoa ON Lop.MaKhoa = Khoa.MaKhoa
                WHERE Lop.MaLop = @MaLop";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaLop", MaLop);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    TenLop = reader["TenLop"].ToString();
                    MaKhoa = reader["MaKhoa"].ToString();
                    TenKhoa = reader["TenKhoa"].ToString();
                }
            }
            using (SqlConnection connection = new SqlConnection(cnstr))
            {
                connection.Open();
                string query = @"
                SELECT MGV, HoTen
                FROM ThongTin_GV
                WHERE MaLop = @MaLop";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaLop", MaLop);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    MGV = reader["MGV"].ToString();
                    HVT_GV = reader["HoTen"].ToString();
                }
            }
            return (HVT_SV, MaLop, TenLop, MaKhoa, TenKhoa, MGV, HVT_GV);
        }
        public bool CheckPWD(string uid, string pwd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cnstr))
                {
                    string query = "SELECT COUNT(*) FROM TaiKhoan WHERE UID = @uid AND PWD = @pwd";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("uid", SqlDbType.VarChar, 50).Value = uid;
                        cmd.Parameters.Add("pwd", SqlDbType.VarChar, 50).Value = pwd;
                        int result = (int)cmd.ExecuteScalar();
                        if (result > 0) return true;
                        else return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
        public bool updatePWD(string uid, string pwd)
        {
            using (SqlConnection conn = new SqlConnection(cnstr))
            {
                string query = @"
                UPDATE TaiKhoan
                SET pwd = @NewPassword
                WHERE uid = @uid";
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NewPassword", pwd);
                    cmd.Parameters.AddWithValue("@uid", uid);
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0) return true;
                    else return false;
                }
            }
        }
        //public string getGV(string uid)
        //{

        //}
    }
}
