using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dll_connectSQL;

namespace Login
{
    public partial class RenLuyen_SV : Form
    {
        public string HocKy {  get; set; }
        public string MSV { get; set; }
        public string LoaiTK { get; set; }
        public int[] SV {  get; set; }
        public int[] CVHT { get; set; }
        public int[] KHOA { get; set; }
        public int[] DiemNew { get; set; }
        public int MB {  get; set; }
        public RenLuyen_SV()
        {
            InitializeComponent();
        }

        private void BT_Save_Click(object sender, EventArgs e)
        {
            DataBase_SQL dataBase_SQL = new DataBase_SQL();
            bool KQ = false;
            if (LoaiTK == "SV")
            {
                KQ = dataBase_SQL.UpdateDiemSV(DiemNew, MB);
            }
            else if(LoaiTK == "GV")
            {
                KQ = dataBase_SQL.UpdateDiemCVHT(DiemNew, MB);
            }
            else if (LoaiTK == "KHOA")
            {
                KQ = dataBase_SQL.UpdateDiemKhoa(DiemNew, MB);
            }
            if (KQ == true)
            {
                MessageBox.Show("Lưu điểm thành công");
            }
            else
            {
                MessageBox.Show("Lưu điểm không thành công");
            }
        }

        private void RenLuyen_SV_Load(object sender, EventArgs e)
        {
            comboBox_HK.Items.Add("Học kỳ 3 Năm học 2023-2024");
            comboBox_HK.Items.Add("Học kỳ 2 Năm học 2023-2024");
        }
        public void CreateDGV(string MSV, string HocKY)
        {
            DGV.Rows.Clear();
            DGV.Columns.Clear();
            DataBase_SQL dataBase_SQL = new DataBase_SQL();
            var (MB_SV, MB_CVHT, MB_KHOA) = dataBase_SQL.getMaBang(MSV, HocKy);
            if (MB_SV==0 ||MB_CVHT==0 || MB_KHOA == 0)
            {
                MessageBox.Show("Lỗi rồi nhưng không biết ở đâu");
                return;
            }
            SV = dataBase_SQL.getDiemSV(MB_SV);
            CVHT = dataBase_SQL.getDiemCVHT(MB_CVHT);
            KHOA = dataBase_SQL.getDiemKHOA(MB_KHOA);
            DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DGV.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            DGV.ScrollBars = ScrollBars.Both;
            DGV.Rows.Clear();
            DGV.Columns.Clear();
            DGV.Columns.Add("0", "STT");
            DGV.Columns.Add("1", "Nội dung tiêu chí đánh giá");
            DGV.Columns.Add("2", "Điểm tối đa");
            DGV.Columns.Add("3", "Điểm tự đánh giá");
            DGV.Columns.Add("4", "Điểm CVHT");
            DGV.Columns.Add("5", "Điểm khoa");
            DiemNew = new int[SV.Length];
            for (int i = 0; i <= 5; i++)
            {
                DGV.Columns[i].ReadOnly = true;
            }
            if (LoaiTK == "SV")
            {
                DGV.Columns[3].ReadOnly = false;
                for (int i = 0; i < SV.Length; i++)
                {
                    DiemNew[i] = SV[i];
                }
                MB = MB_SV;
            }
            else if (LoaiTK == "GV")
            {
                DGV.Columns[4].ReadOnly = false;
                for (int i = 0; i < CVHT.Length; i++)
                {
                    DiemNew[i] = CVHT[i];
                }
                MB = MB_CVHT;
            }
            else if (LoaiTK == "KHOA")
            {
                DGV.Columns[5].ReadOnly = false;
                for (int i = 0; i < KHOA.Length; i++)
                {
                    DiemNew[i] = KHOA[i];
                }
                MB = MB_KHOA;
            }
            DGV.Columns[0].Width = 50;
            DGV.Columns[1].Width = 900;
            DGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            for (int i = 0; i <= 5; i++)
            {
                DGV.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            DGV.Rows.Add("1", "ĐÁNH GIÁ Ý THỨC THAM GIA HỌC TẬP: (Khung điểm đánh giá từ 0 - 20 điểm)", "20", "20", "20", "20");
            DGV.Rows.Add("", "* Phần cộng điểm", "", "", "", "");
            DGV.Rows.Add("1.1", "Điểm thưởng về học tập.", "5", SV[1], CVHT[1], KHOA[1]);
            DGV.Rows.Add("1.2", "Tham gia các hoạt động khoa học sinh viên (NCKH, bài báo, thi olympic, Robocon, sáng tạo, khởi nghiệp....).", "7", SV[2], CVHT[2], KHOA[2]);
            DGV.Rows.Add("1.3", "Thực hiện nội quy, quy chế học tập.", "11", SV[3], CVHT[3], KHOA[3]);
            DGV.Rows.Add("", "* Phần trừ điểm", "", "", "", "");
            DGV.Rows.Add("1.4", "Tỷ lệ tham gia lớp học dưới 80% (cứ giảm 5% trừ thêm 1 điểm); nếu dưới 50% trừ 10 điểm. (Tối đa -10).", "0", SV[4], CVHT[4], KHOA[4]);
            DGV.Rows.Add("1.5", "Vi phạm quy chế thi và kiểm tra (trừ theo mức độ vi phạm: Khiển trách trừ điểm 5 điểm; Cảnh cáo trừ 10 điểm; Đình chỉ trừ 15 điểm; không tiếp tục trừ tại mục II.5 và II.6). (Tối đa -15).", "0", SV[5], CVHT[5], KHOA[5]);
            DGV.Rows.Add("2", "ĐÁNH GIÁ Ý THỨC VÀ KẾT QUẢ CHẤP HÀNH NỘI QUY, QUY CHẾ TRONG NHÀ TRƯỜNG: (Khung điểm đánh giá từ 0 - 25 điểm).", "25", "25", "25", "25");
            DGV.Rows.Add("", "* Phần cộng điểm", "", "", "", "");
            DGV.Rows.Add("2.1", "Có ý thức chấp hành tốt các văn bản chỉ đạo của ngành, của cơ quan chỉ đạo cấp trên triển khai trong trường.", "5", SV[6], CVHT[6], KHOA[6]);
            DGV.Rows.Add("2.2", "Ý thức chấp hành các nội quy, quy chế và các quy định của trường.", "20", SV[7], CVHT[7], KHOA[7]);
            DGV.Rows.Add("", "* Phần trừ điểm", "", "", "", "");
            DGV.Rows.Add("2.3", "Không tham gia Bảo hiểm Y tế. (-20).", "0", SV[8], CVHT[8], KHOA[8]);
            DGV.Rows.Add("2.4", "Vi phạm quy định đóng học phí và các loại phí khác theo quy định. (-5).", "0", SV[9], CVHT[9], KHOA[9]);
            DGV.Rows.Add("2.5", "Vi phạm Quy chế HSSV bị kỷ luật mức cảnh cáo trở lên. (-20).", "0", SV[10], CVHT[10], KHOA[10]);
            DGV.Rows.Add("2.6", "Vi phạm Quy chế HSSV bị kỷ luật khiển trách. (-10).", "0", SV[11], CVHT[11], KHOA[11]);
            DGV.Rows.Add("2.7", "Vi phạm quy định nội, ngoại trú. (-20).", "0", SV[12], CVHT[12], KHOA[12]);
            DGV.Rows.Add("2.8", "Không tham gia các hoạt động khảo sát khi Nhà trường triển khai. (-5/ lần).", "0", SV[13], CVHT[13], KHOA[13]);
            DGV.Rows.Add("2.9", "Vi phạm các nội quy liên quan đến giảng đường, thư viện, phòng thí nghiệm … đến mức bị lập biên bản xử lý. (-10/ lần).", "0", SV[14], CVHT[14], KHOA[14]);
            DGV.Rows.Add("3", "ĐÁNH GIÁ VỀ Ý THỨC VÀ KẾT QUẢ THAM GIA CÁC HOẠT ĐỘNG CHÍNH TRỊ- XÃ HỘI, VĂN HÓA, VĂN NGHỆ, THỂ THAO, PHÒNG CHỐNG CÁC TỆ NẠN XÃ HỘI: (Khung điểm đánh giá từ 0 - 20 điểm)", "20", "20", "20", "20");
            DGV.Rows.Add("", "* Phần cộng điểm", "", "", "", "");
            DGV.Rows.Add("3.1", "Tham gia đầy đủ hoạt động tập thể của Lớp, Chi đoàn, Liên chi đoàn, Liên chi hội, Hội sinh viên (Tùy mức độ tham gia).", "5", SV[15], CVHT[15], KHOA[15]);
            DGV.Rows.Add("3.2", "Tham gia các hoạt động ngoại khóa do Nhà trường, địa phương tổ chức.", "10", SV[16], CVHT[16], KHOA[16]);
            DGV.Rows.Add("3.3", "Có thành tích trong học tập, rèn luyện, tham gia hoạt động văn nghệ, thể thao, đấu tranh, phòng chống TNXH, được khen thưởng cấp.", "5", SV[17], CVHT[17], KHOA[17]);
            DGV.Rows.Add("", "* Phần trừ điểm", "", "", "", "");
            DGV.Rows.Add("3.4", "Bỏ sinh hoạt lớp, sinh hoạt Đoàn, sinh hoạt Hội sinh viên theo kế hoạch. (-5/ lần họp).", "0", SV[18], CVHT[18], KHOA[18]);
            DGV.Rows.Add("3.5", "Không tham các hoạt động do khoa điều động (có danh sách cụ thể). (-5/ lần).", "0", SV[19], CVHT[19], KHOA[19]);
            DGV.Rows.Add("3.6", "Sinh viên không hoàn thành chương trình tuần sinh hoạt công dân đầu khóa, cuối khóa, đầu năm học. (-10).", "0", SV[20], CVHT[20], KHOA[20]);
            DGV.Rows.Add("4", "ĐÁNH GIÁ VỀ PHẨM CHẤT CÔNG DÂN VÀ QUAN HỆ VỚI CỘNG ĐỒNG: (Khung điểm đánh giá từ 0 - 25 điểm)", "", "", "", "");
            DGV.Rows.Add("", "* Phần cộng điểm", "", "", "", "");
            DGV.Rows.Add("4.1", "Chấp hành tốt và tham gia tuyên truyền các chủ trương của Đảng, chính sách, pháp luật của Nhà nước trong cộng đồng.", "5", SV[21], CVHT[21], KHOA[21]);
            DGV.Rows.Add("4.2", "Tham gia hoạt động hỗ trợ nhau trong học tập (Có đăng ký từ đầu kỳ và minh chứng kết quả cụ thể), hoạt động kết nối cộng động (STEM, truyền thông, tuyên truyền tuyển sinh, tham gia đội tự quản…).", "10", SV[22], CVHT[22], KHOA[22]);
            DGV.Rows.Add("4.3", "Tham gia công tác tình nguyện, chung sức vì cộng đồng, có tinh thần chia sẻ, giúp đỡ người thân, người có khó khăn, hoạn nạn, các hoạt động tại địa phương nơi cư trú (Tùy mức độ tham gia, có minh chứng cụ thể).", "10", SV[23], CVHT[23], KHOA[23]);
            DGV.Rows.Add("4.4", "Giữ gìn đoàn kết nội bộ, quan hệ tốt với bạn bè, tập thể nơi cư trú.", "5", SV[24], CVHT[24], KHOA[24]);
            DGV.Rows.Add("", "* Phần trừ điểm", "", "", "", "");
            DGV.Rows.Add("4.5", "Vi phạm pháp luật (chưa đến mức truy cứu trách nhiệm hình sự), thiếu ý thức tham gia giữ gìn trật tự an toàn xã hội, không chấp hành đầy đủ đường lối, chủ trương của Đảng, chính sách, pháp luật của Nhà nước. (-10).", "0", SV[25], CVHT[25], KHOA[25]);
            DGV.Rows.Add("4.6", "Gây mất đoàn kết trong lớp, trong trường, trong KTX, địa bàn nơi cư trú. (-5/ lần).", "0", SV[26], CVHT[26], KHOA[26]);
            DGV.Rows.Add("5", "ĐÁNH GIÁ VỀ Ý THỨC VÀ KẾT QUẢ THAM GIA PHỤ TRÁCH LỚP, CÁC ĐOÀN THỂ, TỔ CHỨC TRONG NHÀ TRƯỜNG, HOẶC ĐẠT ĐƯỢC THÀNH TÍCH ĐẶC BIỆT TRONG HỌC TẬP, RÈN LUYÊN CỦA SINH VIÊN (Khung điểm đánh giá từ 0 - 10 điểm)", "10", "0", "0", "0");
            DGV.Rows.Add("", "* Phần cộng điểm", "", "", "", "");
            DGV.Rows.Add("5.1", "Sinh viên tham gia cấp ủy chi bộ, Ban chấp hành Đoàn, Hội SV từ cấp chi đoàn, chi hội trở lên hoàn thành tốt nhiệm vụ, có uy tín và hiệu quả trong công việc được phân công.", "5", SV[27], CVHT[27], KHOA[27]);
            DGV.Rows.Add("5.2", "Sinh viên tham gia cấp ủy chi bộ, Ban chấp hành Đoàn, Hội SV từ cấp chi đoàn, chi hội trở lên; khi tập thể tham gia, phụ trách được cấp trên khen thưởng.", "3", SV[28], CVHT[28], KHOA[28]);
            DGV.Rows.Add("5.3", "Tập thể phụ trách có điểm rèn luyện đạt 85% xếp loại từ khá trở lên.", "2", SV[29], CVHT[29], KHOA[29]);
            DGV.Rows.Add("5.4", "Sinh viên đạt được các thành tích đặc biệt trong học tập, rèn luyện: đạt các danh hiệu: SV giỏi, SV xuất sắc, SV 5 tốt từ cấp tỉnh trở lên, Sao tháng riêng, Đảng viên xếp loại đủ tư cách hoành thành XS nhiệm vụ, SV có thành tích đặc biệt xuất sắc trong hoạt động Văn nghệ, thể thao.", "10", SV[30], CVHT[30], KHOA[30]);
            DGV.Rows.Add("", "* Phần trừ điểm", "", "", "", "");
            DGV.Rows.Add("5.5", "Không tổ chức thực hiện sinh hoạt tập thể theo kế hoạch của khoa, trường, Đoàn thanh niên, hội sinh viên cấp trên. (-5/ lần).", "0", SV[31], CVHT[31], KHOA[31]);
            DGV.Rows.Add("5.6", "Tập thể lớp có điểm rèn luyện dưới 60% đạt loại trung bình trở lên. (-5).", "0", SV[32], CVHT[32], KHOA[32]);

            DGV.Rows[0].ReadOnly = true;
            DGV.Rows[1].ReadOnly = true;
            DGV.Rows[5].ReadOnly = true;
            DGV.Rows[8].ReadOnly = true;
            DGV.Rows[9].ReadOnly = true;
            DGV.Rows[12].ReadOnly = true;
            DGV.Rows[20].ReadOnly = true;
            DGV.Rows[21].ReadOnly = true;
            DGV.Rows[27].ReadOnly = true;
            DGV.Rows[29].ReadOnly = true;
            DGV.Rows[30].ReadOnly = true;
            DGV.Rows[35].ReadOnly = true;
            DGV.Rows[38].ReadOnly = true;
            DGV.Rows[39].ReadOnly = true;
            DGV.Rows[44].ReadOnly = true;
        }

        private void BT_Reload_Click(object sender, EventArgs e)
        {
            if (HocKy==null)
            {
                MessageBox.Show("Bạn chưa chọn học kỳ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult result = MessageBox.Show("Quá trình này sẽ mất những điểm bạn vừa nhập. Bạn có chắc chắn tải lại điểm không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                CreateDGV(MSV, HocKy);
            }
            else return;
        }

        private void comboBox_HK_SelectedIndexChanged(object sender, EventArgs e)
        {
            HocKy = comboBox_HK.SelectedItem.ToString();
            if (HocKy == "Học kỳ 3 Năm học 2023-2024")
            {
                HocKy = "HK3-2023-2024";
            }
            else HocKy = "HK2-2023-2024";
            CreateDGV(MSV, HocKy);
        }
        public void DGV_Load()
        {
            int[] row = {0,3,4,5,7,11,12,14,15,16,17,18,19,20,23,24,25,26,27,28,29,32,33,34,35,37,38,41,42,43,44,46,47};
            if (LoaiTK=="SV")
            {
                for (int i = 1; i <= 32; i++)
                {
                    DGV.Rows[(row[i] - 1)].Cells[3].Value = DiemNew[i].ToString();
                }
            }
            else if (LoaiTK=="GV")
            {
                for (int i = 1; i <= 32; i++)
                {
                    DGV.Rows[(row[i] - 1)].Cells[4].Value = DiemNew[i].ToString();
                }
            }
            else
            {
                for (int i = 1; i <= 32; i++)
                {
                    DGV.Rows[(row[i] - 1)].Cells[4].Value = DiemNew[i].ToString();
                }
            }
        }

        private void DGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DGV.EndEdit();
            int KT;
            int row = e.RowIndex;
            int column = e.ColumnIndex;
            var TEST = DGV.Rows[row].Cells[column].Value.ToString().Trim();
            if (!int.TryParse(TEST, out int result))
            {
                MessageBox.Show("Giá trị không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DGV_Load();
                return;
            }
            else
            {
                KT = int.Parse(TEST);
                switch (row)
                {
                    case 2:
                        {
                            if (!(KT >= 0 && KT <= 5))
                            {
                                MessageBox.Show("Giá trị vừa nhập không đúng trong khung điểm chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DGV_Load();
                                return;
                            }
                            else
                            {
                                DiemNew[1] = KT;
                            }
                            break;
                        }
                    case 3:
                        {
                            if (!(KT>=0 && KT<=7))
                            {
                                MessageBox.Show("Giá trị vừa nhập không đúng trong khung điểm chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DGV_Load();
                                return;
                            }
                            else
                            {
                                DiemNew[2] = KT;
                            }
                            break;
                        }
                    case 4:
                        {
                            if (!(KT >= 0 && KT <= 11))
                            {
                                MessageBox.Show("Giá trị vừa nhập không đúng trong khung điểm chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DGV_Load();
                                return;
                            }
                            else
                            {
                                DiemNew[3] = KT;
                            }
                            break;
                        }
                    case 6:
                        {
                            if (!(KT <= 0 && KT >= -10))
                            {
                                MessageBox.Show("Giá trị vừa nhập không đúng trong khung điểm chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DGV_Load();
                                return;
                            }
                            else
                            {
                                DiemNew[4] = KT;
                            }
                            break;
                        }
                    case 7:
                        {
                            if (!(KT <= 0 && KT >= -15))
                            {
                                MessageBox.Show("Giá trị vừa nhập không đúng trong khung điểm chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DGV_Load();
                                return;
                            }
                            else
                            {
                                DiemNew[5] = KT;
                            }
                            break;
                        }
                    case 10:
                        {
                            if (!(KT >= 0 && KT <= 5))
                            {
                                MessageBox.Show("Giá trị vừa nhập không đúng trong khung điểm chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DGV_Load();
                                return;
                            }
                            else
                            {
                                DiemNew[6] = KT;
                            }
                            break;
                        }
                    case 11:
                        {
                            if (!(KT >= 0 && KT <= 20))
                            {
                                MessageBox.Show("Giá trị vừa nhập không đúng trong khung điểm chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DGV_Load();
                                return;
                            }
                            else
                            {
                                DiemNew[7] = KT;
                            }
                            break;
                        }
                    case 13:
                        {
                            if (!(KT <= 0))
                            {
                                MessageBox.Show("Giá trị vừa nhập không đúng trong khung điểm chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DGV_Load();
                                return;
                            }
                            else
                            {
                                DiemNew[8] = KT;
                            }
                            break;
                        }
                    case 14:
                        {
                            if (!(KT <= 0))
                            {
                                MessageBox.Show("Giá trị vừa nhập không đúng trong khung điểm chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DGV_Load();
                                return;
                            }
                            else
                            {
                                DiemNew[9] = KT;
                            }
                            break;
                        }
                    case 15:
                        {
                            if (!(KT <= 0))
                            {
                                MessageBox.Show("Giá trị vừa nhập không đúng trong khung điểm chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DGV_Load();
                                return;
                            }
                            else
                            {
                                DiemNew[10] = KT;
                            }
                            break;
                        }
                    case 16:
                        {
                            if (!(KT <= 0))
                            {
                                MessageBox.Show("Giá trị vừa nhập không đúng trong khung điểm chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DGV_Load();
                                return;
                            }
                            else
                            {
                                DiemNew[11] = KT;
                            }
                            break;
                        }
                    case 17:
                        {
                            if (!(KT <= 0))
                            {
                                MessageBox.Show("Giá trị vừa nhập không đúng trong khung điểm chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DGV_Load();
                                return;
                            }
                            else
                            {
                                DiemNew[12] = KT;
                            }
                            break;
                        }
                    case 18:
                        {
                            if (!(KT <= 0))
                            {
                                MessageBox.Show("Giá trị vừa nhập không đúng trong khung điểm chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DGV_Load();
                                return;
                            }
                            else
                            {
                                DiemNew[13] = KT;
                            }
                            break;
                        }
                    case 19:
                        {
                            if (!(KT <= 0))
                            {
                                MessageBox.Show("Giá trị vừa nhập không đúng trong khung điểm chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DGV_Load();
                                return;
                            }
                            else
                            {
                                DiemNew[14] = KT;
                            }
                            break;
                        }
                    case 22:
                        {
                            if (!(KT >=0&& KT<=5))
                            {
                                MessageBox.Show("Giá trị vừa nhập không đúng trong khung điểm chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DGV_Load();
                                return;
                            }
                            else
                            {
                                DiemNew[15] = KT;
                            }
                            break;
                        }
                    case 23:
                        {
                            if (!(KT >= 0 && KT <= 10))
                            {
                                MessageBox.Show("Giá trị vừa nhập không đúng trong khung điểm chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DGV_Load();
                                return;
                            }
                            else
                            {
                                DiemNew[16] = KT;
                            }
                            break;
                        }
                    case 24:
                        {
                            if (!(KT >= 0 && KT <= 5))
                            {
                                MessageBox.Show("Giá trị vừa nhập không đúng trong khung điểm chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DGV_Load();
                                return;
                            }
                            else
                            {
                                DiemNew[17] = KT;
                            }
                            break;
                        }
                    case 26:
                        {
                            if (!(KT<=0))
                            {
                                MessageBox.Show("Giá trị vừa nhập không đúng trong khung điểm chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DGV_Load();
                                return;
                            }
                            else
                            {
                                DiemNew[18] = KT;
                            }
                            break;
                        }
                    case 27:
                        {
                            if (!(KT <= 0))
                            {
                                MessageBox.Show("Giá trị vừa nhập không đúng trong khung điểm chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DGV_Load();
                                return;
                            }
                            else
                            {
                                DiemNew[19] = KT;
                            }
                            break;
                        }
                    case 28:
                        {
                            if (!(KT <= 0))
                            {
                                MessageBox.Show("Giá trị vừa nhập không đúng trong khung điểm chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DGV_Load();
                                return;
                            }
                            else
                            {
                                DiemNew[20] = KT;
                            }
                            break;
                        }
                    case 31:
                        {
                            if (!(KT >= 0 && KT<=5))
                            {
                                MessageBox.Show("Giá trị vừa nhập không đúng trong khung điểm chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DGV_Load();
                                return;
                            }
                            else
                            {
                                DiemNew[21] = KT;
                            }
                            break;
                        }
                    case 32:
                        {
                            if (!(KT >= 0 && KT <= 10))
                            {
                                MessageBox.Show("Giá trị vừa nhập không đúng trong khung điểm chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DGV_Load();
                                return;
                            }
                            else
                            {
                                DiemNew[22] = KT;
                            }
                            break;
                        }
                    case 33:
                        {
                            if (!(KT >= 0 && KT <= 10))
                            {
                                MessageBox.Show("Giá trị vừa nhập không đúng trong khung điểm chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DGV_Load();
                                return;
                            }
                            else
                            {
                                DiemNew[23] = KT;
                            }
                            break;
                        }
                    case 34:
                        {
                            if (!(KT >= 0 && KT <= 5))
                            {
                                MessageBox.Show("Giá trị vừa nhập không đúng trong khung điểm chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DGV_Load();
                                return;
                            }
                            else
                            {
                                DiemNew[24] = KT;
                            }
                            break;
                        }
                    case 36:
                        {
                            if (!(KT <= 0))
                            {
                                MessageBox.Show("Giá trị vừa nhập không đúng trong khung điểm chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DGV_Load();
                                return;
                            }
                            else
                            {
                                DiemNew[25] = KT;
                            }
                            break;
                        }
                    case 37:
                        {
                            if (!(KT <= 0))
                            {
                                MessageBox.Show("Giá trị vừa nhập không đúng trong khung điểm chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DGV_Load();
                                return;
                            }
                            else
                            {
                                DiemNew[26] = KT;
                            }
                            break;
                        }
                    case 40:
                        {
                            if (!(KT >= 0 && KT<=5))
                            {
                                MessageBox.Show("Giá trị vừa nhập không đúng trong khung điểm chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DGV_Load();
                                return;
                            }
                            else
                            {
                                DiemNew[27] = KT;
                            }
                            break;
                        }
                    case 41:
                        {
                            if (!(KT >= 0 && KT <= 3))
                            {
                                MessageBox.Show("Giá trị vừa nhập không đúng trong khung điểm chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DGV_Load();
                                return;
                            }
                            else
                            {
                                DiemNew[28] = KT;
                            }
                            break;
                        }
                    case 42:
                        {
                            if (!(KT >= 0 && KT <= 2))
                            {
                                MessageBox.Show("Giá trị vừa nhập không đúng trong khung điểm chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DGV_Load();
                                return;
                            }
                            else
                            {
                                DiemNew[29] = KT;
                            }
                            break;
                        }
                    case 43:
                        {
                            if (!(KT >= 0 && KT <= 10))
                            {
                                MessageBox.Show("Giá trị vừa nhập không đúng trong khung điểm chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DGV_Load();
                                return;
                            }
                            else
                            {
                                DiemNew[30] = KT;
                            }
                            break;
                        }
                    case 45:
                        {
                            if (!(KT <= 0))
                            {
                                MessageBox.Show("Giá trị vừa nhập không đúng trong khung điểm chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DGV_Load();
                                return;
                            }
                            else
                            {
                                DiemNew[31] = KT;
                            }
                            break;
                        }
                    case 46:
                        {
                            if (!(KT <= 0))
                            {
                                MessageBox.Show("Giá trị vừa nhập không đúng trong khung điểm chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DGV_Load();
                                return;
                            }
                            else
                            {
                                DiemNew[32] = KT;
                            }
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Có gì đó sai sai!");
                            break;
                        }
                }
            }
        }
    }
}
