using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace dll_connectSQL
{
    public class DataBase_SQL
    {
        public string cnstr = "Server=NEKOTRANG\\DATASQL;Database=TNUT3;User Id=sa;Password=123;";
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
        public (string, string, string, string, string) GetGV(string MGV_input)
        {
            string MaLop = "";
            string TenLop = "";
            string MaKhoa = "";
            string TenKhoa = "";
            string HVT_GV = "";
            using (SqlConnection connection = new SqlConnection(cnstr))
            {
                connection.Open();
                string query = "SELECT HoTen, MaLop FROM ThongTin_GV WHERE MGV = @MGV";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MGV", MGV_input);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    HVT_GV = reader["HoTen"].ToString();
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
            return (HVT_GV, MaLop, TenLop, MaKhoa, TenKhoa );
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
        public int[] getDiemSV(int MB_SV)
        {
            int[] SV = new int[33];
            using (SqlConnection conn = new SqlConnection(cnstr))
            {
                string query = "SELECT * FROM DG_SV WHERE MB_SV = @MB_SV";
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MB_SV", MB_SV);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        for (int i = 0; i <= 32; i++)
                        {
                            SV[i] = reader.GetInt32(i);
                        }
                    }
                    reader.Close();
                }
            }
            return SV;
        }
        public int[] getDiemCVHT(int MB_CVHT)
        {
            int[] CVHT = new int[33];
            using (SqlConnection conn = new SqlConnection(cnstr))
            {
                string query = "SELECT * FROM DG_CVHT WHERE MB_CVHT = @MB_CVHT";
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MB_CVHT", MB_CVHT);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        for (int i = 0; i <= 32; i++)
                        {
                            CVHT[i] = reader.GetInt32(i);
                        }
                    }
                    reader.Close();
                }
            }
            return CVHT;
        }
        public int[] getDiemKHOA(int MB_KHOA)
        {
            int[] KHOA = new int[33];
            using (SqlConnection conn = new SqlConnection(cnstr))
            {
                string query = "SELECT * FROM DG_KHOA WHERE MB_KHOA = @MB_KHOA";
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MB_KHOA", MB_KHOA);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        for (int i = 0; i <= 32; i++)
                        {
                            KHOA[i] = reader.GetInt32(i);
                        }
                    }
                    reader.Close();
                }
            }
            return KHOA;
        }
        public (int, int, int) getMaBang(string MSV, string HocKi)
        {
            int MB_SV=0, MB_CVHT=0, MB_Khoa=0;
            using (SqlConnection conn = new SqlConnection(cnstr))
            {
                string query = "SELECT MB_SV, MB_CVHT, MB_Khoa FROM Diem_RL WHERE MSV = @MSV AND HocKi = @HocKi";
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MSV", MSV);
                    cmd.Parameters.AddWithValue("@HocKi", HocKi);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        MB_SV = reader.GetInt32(0);
                        MB_CVHT = reader.GetInt32(1);
                        MB_Khoa = reader.GetInt32(2); 
                    }
                    reader.Close();
                }
                return (MB_SV, MB_CVHT, MB_Khoa);
            }    
        }
        public bool UpdateDiemSV(int[] Diem, int MB)
        {
            string checkQuery = "SELECT COUNT(*) FROM DG_SV WHERE MB_SV = @MB_SV";
            string updateQuery = @"
            UPDATE DG_SV
            SET [1.1] = @Diem1_1, [1.2] = @Diem1_2, [1.3] = @Diem1_3, [1.4] = @Diem1_4, [1.5] = @Diem1_5,
                [2.1] = @Diem2_1, [2.2] = @Diem2_2, [2.3] = @Diem2_3, [2.4] = @Diem2_4, [2.5] = @Diem2_5,
                [2.6] = @Diem2_6, [2.7] = @Diem2_7, [2.8] = @Diem2_8, [2.9] = @Diem2_9,
                [3.1] = @Diem3_1, [3.2] = @Diem3_2, [3.3] = @Diem3_3, [3.4] = @Diem3_4, [3.5] = @Diem3_5, [3.6] = @Diem3_6,
                [4.1] = @Diem4_1, [4.2] = @Diem4_2, [4.3] = @Diem4_3, [4.4] = @Diem4_4, [4.5] = @Diem4_5, [4.6] = @Diem4_6,
                [5.1] = @Diem5_1, [5.2] = @Diem5_2, [5.3] = @Diem5_3, [5.4] = @Diem5_4, [5.5] = @Diem5_5, [5.6] = @Diem5_6
            WHERE MB_SV = @MB_SV";

            using (SqlConnection conn = new SqlConnection(cnstr))
            {
                conn.Open();
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@MB_SV", MB);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@MB_SV", MB);
                            cmd.Parameters.AddWithValue("@Diem1_1", Diem[1]);
                            cmd.Parameters.AddWithValue("@Diem1_2", Diem[2]);
                            cmd.Parameters.AddWithValue("@Diem1_3", Diem[3]);
                            cmd.Parameters.AddWithValue("@Diem1_4", Diem[4]);
                            cmd.Parameters.AddWithValue("@Diem1_5", Diem[5]);

                            cmd.Parameters.AddWithValue("@Diem2_1", Diem[6]);
                            cmd.Parameters.AddWithValue("@Diem2_2", Diem[7]);
                            cmd.Parameters.AddWithValue("@Diem2_3", Diem[8]);
                            cmd.Parameters.AddWithValue("@Diem2_4", Diem[9]);
                            cmd.Parameters.AddWithValue("@Diem2_5", Diem[10]);
                            cmd.Parameters.AddWithValue("@Diem2_6", Diem[11]);
                            cmd.Parameters.AddWithValue("@Diem2_7", Diem[12]);
                            cmd.Parameters.AddWithValue("@Diem2_8", Diem[13]);
                            cmd.Parameters.AddWithValue("@Diem2_9", Diem[14]);

                            cmd.Parameters.AddWithValue("@Diem3_1", Diem[15]);
                            cmd.Parameters.AddWithValue("@Diem3_2", Diem[16]);
                            cmd.Parameters.AddWithValue("@Diem3_3", Diem[17]);
                            cmd.Parameters.AddWithValue("@Diem3_4", Diem[18]);
                            cmd.Parameters.AddWithValue("@Diem3_5", Diem[19]);
                            cmd.Parameters.AddWithValue("@Diem3_6", Diem[20]);

                            cmd.Parameters.AddWithValue("@Diem4_1", Diem[21]);
                            cmd.Parameters.AddWithValue("@Diem4_2", Diem[22]);
                            cmd.Parameters.AddWithValue("@Diem4_3", Diem[23]);
                            cmd.Parameters.AddWithValue("@Diem4_4", Diem[24]);
                            cmd.Parameters.AddWithValue("@Diem4_5", Diem[25]);
                            cmd.Parameters.AddWithValue("@Diem4_6", Diem[26]);

                            cmd.Parameters.AddWithValue("@Diem5_1", Diem[27]);
                            cmd.Parameters.AddWithValue("@Diem5_2", Diem[28]);
                            cmd.Parameters.AddWithValue("@Diem5_3", Diem[29]);
                            cmd.Parameters.AddWithValue("@Diem5_4", Diem[30]);
                            cmd.Parameters.AddWithValue("@Diem5_5", Diem[31]);
                            cmd.Parameters.AddWithValue("@Diem5_6", Diem[32]);
                            cmd.ExecuteNonQuery();
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        public bool UpdateDiemCVHT(int[] Diem, int MB)
        {
            string checkQuery = "SELECT COUNT(*) FROM DG_CVHT WHERE MB_CVHT = @MB_CVHT";
            string updateQuery = @"
            UPDATE DG_CVHT
            SET [1.1] = @Diem1_1, [1.2] = @Diem1_2, [1.3] = @Diem1_3, [1.4] = @Diem1_4, [1.5] = @Diem1_5,
                [2.1] = @Diem2_1, [2.2] = @Diem2_2, [2.3] = @Diem2_3, [2.4] = @Diem2_4, [2.5] = @Diem2_5,
                [2.6] = @Diem2_6, [2.7] = @Diem2_7, [2.8] = @Diem2_8, [2.9] = @Diem2_9,
                [3.1] = @Diem3_1, [3.2] = @Diem3_2, [3.3] = @Diem3_3, [3.4] = @Diem3_4, [3.5] = @Diem3_5, [3.6] = @Diem3_6,
                [4.1] = @Diem4_1, [4.2] = @Diem4_2, [4.3] = @Diem4_3, [4.4] = @Diem4_4, [4.5] = @Diem4_5, [4.6] = @Diem4_6,
                [5.1] = @Diem5_1, [5.2] = @Diem5_2, [5.3] = @Diem5_3, [5.4] = @Diem5_4, [5.5] = @Diem5_5, [5.6] = @Diem5_6
            WHERE MB_CVHT = @MB_CVHT";

            using (SqlConnection conn = new SqlConnection(cnstr))
            {
                conn.Open();
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@MB_CVHT", MB);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@MB_CVHT", MB);
                            cmd.Parameters.AddWithValue("@Diem1_1", Diem[1]);
                            cmd.Parameters.AddWithValue("@Diem1_2", Diem[2]);
                            cmd.Parameters.AddWithValue("@Diem1_3", Diem[3]);
                            cmd.Parameters.AddWithValue("@Diem1_4", Diem[4]);
                            cmd.Parameters.AddWithValue("@Diem1_5", Diem[5]);

                            cmd.Parameters.AddWithValue("@Diem2_1", Diem[6]);
                            cmd.Parameters.AddWithValue("@Diem2_2", Diem[7]);
                            cmd.Parameters.AddWithValue("@Diem2_3", Diem[8]);
                            cmd.Parameters.AddWithValue("@Diem2_4", Diem[9]);
                            cmd.Parameters.AddWithValue("@Diem2_5", Diem[10]);
                            cmd.Parameters.AddWithValue("@Diem2_6", Diem[11]);
                            cmd.Parameters.AddWithValue("@Diem2_7", Diem[12]);
                            cmd.Parameters.AddWithValue("@Diem2_8", Diem[13]);
                            cmd.Parameters.AddWithValue("@Diem2_9", Diem[14]);

                            cmd.Parameters.AddWithValue("@Diem3_1", Diem[15]);
                            cmd.Parameters.AddWithValue("@Diem3_2", Diem[16]);
                            cmd.Parameters.AddWithValue("@Diem3_3", Diem[17]);
                            cmd.Parameters.AddWithValue("@Diem3_4", Diem[18]);
                            cmd.Parameters.AddWithValue("@Diem3_5", Diem[19]);
                            cmd.Parameters.AddWithValue("@Diem3_6", Diem[20]);

                            cmd.Parameters.AddWithValue("@Diem4_1", Diem[21]);
                            cmd.Parameters.AddWithValue("@Diem4_2", Diem[22]);
                            cmd.Parameters.AddWithValue("@Diem4_3", Diem[23]);
                            cmd.Parameters.AddWithValue("@Diem4_4", Diem[24]);
                            cmd.Parameters.AddWithValue("@Diem4_5", Diem[25]);
                            cmd.Parameters.AddWithValue("@Diem4_6", Diem[26]);

                            cmd.Parameters.AddWithValue("@Diem5_1", Diem[27]);
                            cmd.Parameters.AddWithValue("@Diem5_2", Diem[28]);
                            cmd.Parameters.AddWithValue("@Diem5_3", Diem[29]);
                            cmd.Parameters.AddWithValue("@Diem5_4", Diem[30]);
                            cmd.Parameters.AddWithValue("@Diem5_5", Diem[31]);
                            cmd.Parameters.AddWithValue("@Diem5_6", Diem[32]);
                            cmd.ExecuteNonQuery();
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        public bool UpdateDiemKhoa(int[] Diem, int MB)
        {
            string checkQuery = "SELECT COUNT(*) FROM DG_KHOA WHERE MB_KHOA = @MB_KHOA";
            string updateQuery = @"
            UPDATE DG_Khoa
            SET [1.1] = @Diem1_1, [1.2] = @Diem1_2, [1.3] = @Diem1_3, [1.4] = @Diem1_4, [1.5] = @Diem1_5,
                [2.1] = @Diem2_1, [2.2] = @Diem2_2, [2.3] = @Diem2_3, [2.4] = @Diem2_4, [2.5] = @Diem2_5,
                [2.6] = @Diem2_6, [2.7] = @Diem2_7, [2.8] = @Diem2_8, [2.9] = @Diem2_9,
                [3.1] = @Diem3_1, [3.2] = @Diem3_2, [3.3] = @Diem3_3, [3.4] = @Diem3_4, [3.5] = @Diem3_5, [3.6] = @Diem3_6,
                [4.1] = @Diem4_1, [4.2] = @Diem4_2, [4.3] = @Diem4_3, [4.4] = @Diem4_4, [4.5] = @Diem4_5, [4.6] = @Diem4_6,
                [5.1] = @Diem5_1, [5.2] = @Diem5_2, [5.3] = @Diem5_3, [5.4] = @Diem5_4, [5.5] = @Diem5_5, [5.6] = @Diem5_6
            WHERE MB_KHOA = @MB_KHOA";

            using (SqlConnection conn = new SqlConnection(cnstr))
            {
                conn.Open();
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@MB_KHOA", MB);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@MB_KHOA", MB);
                            cmd.Parameters.AddWithValue("@Diem1_1", Diem[1]);
                            cmd.Parameters.AddWithValue("@Diem1_2", Diem[2]);
                            cmd.Parameters.AddWithValue("@Diem1_3", Diem[3]);
                            cmd.Parameters.AddWithValue("@Diem1_4", Diem[4]);
                            cmd.Parameters.AddWithValue("@Diem1_5", Diem[5]);

                            cmd.Parameters.AddWithValue("@Diem2_1", Diem[6]);
                            cmd.Parameters.AddWithValue("@Diem2_2", Diem[7]);
                            cmd.Parameters.AddWithValue("@Diem2_3", Diem[8]);
                            cmd.Parameters.AddWithValue("@Diem2_4", Diem[9]);
                            cmd.Parameters.AddWithValue("@Diem2_5", Diem[10]);
                            cmd.Parameters.AddWithValue("@Diem2_6", Diem[11]);
                            cmd.Parameters.AddWithValue("@Diem2_7", Diem[12]);
                            cmd.Parameters.AddWithValue("@Diem2_8", Diem[13]);
                            cmd.Parameters.AddWithValue("@Diem2_9", Diem[14]);

                            cmd.Parameters.AddWithValue("@Diem3_1", Diem[15]);
                            cmd.Parameters.AddWithValue("@Diem3_2", Diem[16]);
                            cmd.Parameters.AddWithValue("@Diem3_3", Diem[17]);
                            cmd.Parameters.AddWithValue("@Diem3_4", Diem[18]);
                            cmd.Parameters.AddWithValue("@Diem3_5", Diem[19]);
                            cmd.Parameters.AddWithValue("@Diem3_6", Diem[20]);

                            cmd.Parameters.AddWithValue("@Diem4_1", Diem[21]);
                            cmd.Parameters.AddWithValue("@Diem4_2", Diem[22]);
                            cmd.Parameters.AddWithValue("@Diem4_3", Diem[23]);
                            cmd.Parameters.AddWithValue("@Diem4_4", Diem[24]);
                            cmd.Parameters.AddWithValue("@Diem4_5", Diem[25]);
                            cmd.Parameters.AddWithValue("@Diem4_6", Diem[26]);

                            cmd.Parameters.AddWithValue("@Diem5_1", Diem[27]);
                            cmd.Parameters.AddWithValue("@Diem5_2", Diem[28]);
                            cmd.Parameters.AddWithValue("@Diem5_3", Diem[29]);
                            cmd.Parameters.AddWithValue("@Diem5_4", Diem[30]);
                            cmd.Parameters.AddWithValue("@Diem5_5", Diem[31]);
                            cmd.Parameters.AddWithValue("@Diem5_6", Diem[32]);
                            cmd.ExecuteNonQuery();
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        public void DS_sinhvien()
        {

        }
    }
}
