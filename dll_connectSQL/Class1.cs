﻿using System;
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
        public string cnstr = "Server=NEKOTRANG\\TRANG;Database=TNUT12;User Id=sa;Password=123;";
        public string Login(string uid, string pwd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cnstr))
                {
                    string query = "sp_Login";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@uid", uid);
                        cmd.Parameters.AddWithValue("@pwd", pwd);
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                            return result.ToString();
                        else
                            return null;
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
                string query = "EXEC GetTTGV @MGV_input";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MGV_input", MGV_input);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    HVT_GV = reader["HVT_GV"].ToString();
                    MaLop = reader["MaLop"].ToString();
                    TenLop = reader["TenLop"].ToString();
                    MaKhoa = reader["MaKhoa"].ToString();
                    TenKhoa = reader["TenKhoa"].ToString();
                }
            }

            return (HVT_GV, MaLop, TenLop, MaKhoa, TenKhoa);
        }

        public (string, string, string) getKHOA(string MGV)
        {
            string HoTen = "";
            string MaKhoa = "";
            string TenKhoa = "";

            using (SqlConnection connection = new SqlConnection(cnstr))
            {
                connection.Open();
                string query = "EXEC GetTTKHOA @MGV";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MGV", MGV);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    HoTen = reader["HoTen"].ToString();
                    MaKhoa = reader["MaKhoa"].ToString();
                    TenKhoa = reader["TenKhoa"].ToString();
                }
            }
            return (HoTen, MaKhoa, TenKhoa);
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

            using (SqlConnection conn = new SqlConnection(cnstr))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("GetTTSV", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MSV_input", MSV_input);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    HVT_SV = reader["HVT_SV"].ToString();
                    MaLop = reader["MaLop"].ToString();
                    TenLop = reader["TenLop"].ToString();
                    MaKhoa = reader["MaKhoa"].ToString();
                    TenKhoa = reader["TenKhoa"].ToString();
                    MGV = reader["MGV"].ToString();
                    HVT_GV = reader["HVT_GV"].ToString();
                }
            }

            return (HVT_SV, MaLop, TenLop, MaKhoa, TenKhoa, MGV, HVT_GV);
        }

        public bool CheckAndUpdatePWD(string uid, string pwd, string newPwd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cnstr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("CheckAndUpdatePWD", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@uid", uid);
                    cmd.Parameters.AddWithValue("@pwd", pwd);
                    cmd.Parameters.AddWithValue("@newPwd", newPwd);
                    SqlParameter outputParam = new SqlParameter("@result", SqlDbType.Bit);
                    outputParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputParam);
                    cmd.ExecuteNonQuery();
                    bool result = (bool)outputParam.Value;
                    return result;
                }
            }
            catch
            {
                return false;
            }
        }


        public int[] getDiemSV(string MB_SV)
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
                        for (int i = 1; i <= 32; i++)
                        {
                            SV[i] = reader.GetInt32(i);
                        }
                    }
                    reader.Close();
                }
            }
            return SV;
        }
        public int[] getDiemCVHT(string MB_CVHT)
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
                        for (int i = 1; i <= 32; i++)
                        {
                            CVHT[i] = reader.GetInt32(i);
                        }
                    }
                    reader.Close();
                }
            }
            return CVHT;
        }
        public int[] getDiemKHOA(string MB_KHOA)
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
                        for (int i = 1; i <= 32; i++)
                        {
                            KHOA[i] = reader.GetInt32(i);
                        }
                    }
                    reader.Close();
                }
            }
            return KHOA;
        }

        public (List<string>, List<string>) GetHK()
        {
            var MaHK = new List<string>();
            var TenHK = new List<string>();

            using (SqlConnection conn = new SqlConnection(cnstr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("GetHocky", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MaHK.Add(reader["MaHK"].ToString());
                            TenHK.Add(reader["TenHK"].ToString());
                        }
                    }
                }
            }
            return (MaHK, TenHK);
        }


        public (string, string, string) getMaBang(string MSV, string MaHK)
        {
            string MB_SV = null, MB_CVHT = null, MB_Khoa = null;
            using (SqlConnection conn = new SqlConnection(cnstr))
            {
                string query = "GetMB";
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MSV", MSV);
                    cmd.Parameters.AddWithValue("@MaHK", MaHK);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        MB_SV = reader.GetString(0);
                        MB_CVHT = reader.GetString(1);
                        MB_Khoa = reader.GetString(2);
                    }
                    reader.Close();
                }
                return (MB_SV, MB_CVHT, MB_Khoa);
            }
        }

        public bool UpdateDiemSV(int[] Diem, string MB)
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
        public bool UpdateDiemCVHT(int[] Diem, string MB)
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
        public bool UpdateDiemKhoa(int[] Diem, string MB)
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
        public DataTable DS_sinhvien(string MaLop)
        {
            string query = "GetDSSV";
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(cnstr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaLop", MaLop);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }

        public DataTable DS_Lop(string MaKhoa)
        {
            string query = "GetDSCLASS";
            DataTable dataTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(cnstr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaKhoa", MaKhoa); 

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }

        public DataTable GetMinhchung(int id)
        {
            DataTable imagesTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(cnstr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("GetMinhChung", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        imagesTable.Load(reader);
                    }
                }
            }
            return imagesTable;
        }

        public void LuuMinhchung(string MSV, string MaHK, string Tieuchi, byte[] imageData)
        {
            using (SqlConnection conn = new SqlConnection(cnstr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("LuuMinhChung", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MSV", MSV);
                    cmd.Parameters.AddWithValue("@MaHK", MaHK);
                    cmd.Parameters.AddWithValue("@Tieuchi", Tieuchi);
                    cmd.Parameters.Add("@ImageData", SqlDbType.VarBinary).Value = imageData;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<int> LayAnh(string MSV, string MaHK, string Tieuchi)
        {
            var Anh = new List<int>();
            string query = "SELECT id FROM Minhchung where MSV=@MSV AND MaHK=@MaHK AND Tieuchi=@Tieuchi";
            using (SqlConnection conn = new SqlConnection(cnstr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MSV", MSV);
                    cmd.Parameters.AddWithValue("@MaHK", MaHK);
                    cmd.Parameters.AddWithValue("@Tieuchi", Tieuchi);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Anh.Add((int)reader["id"]);
                        }
                    }
                }
            }
            return Anh;
        }
        public bool XoaMinhchung(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cnstr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("XoaMinhchung", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
