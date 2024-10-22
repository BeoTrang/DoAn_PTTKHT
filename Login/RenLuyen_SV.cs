using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class RenLuyen_SV : Form
    {
        public RenLuyen_SV()
        {
            InitializeComponent();
        }

        private void RenLuyen_SV_Load(object sender, EventArgs e)
        {
            comboBox_HK.Items.Add("Học kỳ 3 Năm học 2023-2024");
            comboBox_HK.Items.Add("Học kỳ 2 Năm học 2023-2024");
            CreateDGV();
        }
        public void CreateDGV()
        {
            DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DGV.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            DGV.ScrollBars = ScrollBars.Both;
            

            DGV.Columns.Add("STT", "STT");
            DGV.Columns.Add("STT", "Nội dung tiêu chí đánh giá");
            DGV.Columns.Add("STT", "Điểm tối đa");
            DGV.Columns.Add("STT", "Điểm tự đánh giá");
            DGV.Columns.Add("STT", "Điểm CVHT");
            DGV.Columns.Add("STT", "Điểm khoa");
            for (int i = 0; i <= 2; i++)
            {
                DGV.Columns[i].ReadOnly = true;
            }
            DGV.Columns[0].Width = 50;
            DGV.Columns[1].Width = 900;
            DGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            for(int i = 0; i <= 5; i++)
            {
                DGV.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            DGV.Rows.Add("1", "ĐÁNH GIÁ Ý THỨC THAM GIA HỌC TẬP: (Khung điểm đánh giá từ 0 - 20 điểm)", "20", "20", "20", "20");
            DGV.Rows.Add("", "* Phần cộng điểm", "", "", "", "");
            DGV.Rows.Add("1.1", "Điểm thưởng về học tập.", "5", "1.1", "1.1", "1.1");
            DGV.Rows.Add("1.2", "Tham gia các hoạt động khoa học sinh viên (NCKH, bài báo, thi olympic, Robocon, sáng tạo, khởi nghiệp....).", "7", "1.2", "1.2", "1.2");
            DGV.Rows.Add("1.3", "Thực hiện nội quy, quy chế học tập.", "11", "1.3", "1.3", "1.3");
            DGV.Rows.Add("", "* Phần trừ điểm", "", "", "", "");
            DGV.Rows.Add("1.4", "Tỷ lệ tham gia lớp học dưới 80% (cứ giảm 5% trừ thêm 1 điểm); nếu dưới 50% trừ 10 điểm. (Tối đa -10).", "0", "1.4", "1.4", "1.4");
            DGV.Rows.Add("1.5", "Vi phạm quy chế thi và kiểm tra (trừ theo mức độ vi phạm: Khiển trách trừ điểm 5 điểm; Cảnh cáo trừ 10 điểm; Đình chỉ trừ 15 điểm; không tiếp tục trừ tại mục II.5 và II.6). (Tối đa -15).", "0", "1.4", "1.4", "1.4");
            DGV.Rows.Add("2", "ĐÁNH GIÁ Ý THỨC VÀ KẾT QUẢ CHẤP HÀNH NỘI QUY, QUY CHẾ TRONG NHÀ TRƯỜNG: (Khung điểm đánh giá từ 0 - 25 điểm).", "25", "25", "25", "25");
            DGV.Rows.Add("", "* Phần cộng điểm", "", "", "", "");
            DGV.Rows.Add("2.1", "Có ý thức chấp hành tốt các văn bản chỉ đạo của ngành, của cơ quan chỉ đạo cấp trên triển khai trong trường.", "5", "1.1", "1.1", "1.1");
            DGV.Rows.Add("2.2", "Ý thức chấp hành các nội quy, quy chế và các quy định của trường.", "20", "2.2", "2.2", "2.2");
            DGV.Rows.Add("", "* Phần trừ điểm", "", "", "", "");
            DGV.Rows.Add("2.3", "Không tham gia Bảo hiểm Y tế. (-20).", "0", "2.3", "2.3", "2.3");
            DGV.Rows.Add("2.4", "Vi phạm quy định đóng học phí và các loại phí khác theo quy định. (-5).", "0", "2.4", "2.4", "2.4");
            DGV.Rows.Add("2.5", "Vi phạm Quy chế HSSV bị kỷ luật mức cảnh cáo trở lên. (-20).", "0", "2.5", "2.5", "2.5");
            DGV.Rows.Add("2.6", "Vi phạm Quy chế HSSV bị kỷ luật khiển trách. (-10).", "0", "2.6", "2.6", "2.6");
            DGV.Rows.Add("2.7", "Vi phạm quy định nội, ngoại trú. (-20).", "0", "2.7", "2.7", "2.7");
            DGV.Rows.Add("2.8", "Không tham gia các hoạt động khảo sát khi Nhà trường triển khai. (-5/ lần).", "0", "2.8", "2.8", "2.8");
            DGV.Rows.Add("2.9", "Vi phạm các nội quy liên quan đến giảng đường, thư viện, phòng thí nghiệm … đến mức bị lập biên bản xử lý. (-10/ lần).", "0", "2.9", "2.9", "2.9");
            DGV.Rows.Add("3", "ĐÁNH GIÁ VỀ Ý THỨC VÀ KẾT QUẢ THAM GIA CÁC HOẠT ĐỘNG CHÍNH TRỊ- XÃ HỘI, VĂN HÓA, VĂN NGHỆ, THỂ THAO, PHÒNG CHỐNG CÁC TỆ NẠN XÃ HỘI: (Khung điểm đánh giá từ 0 - 20 điểm)", "20", "20", "20", "20");
            DGV.Rows.Add("", "* Phần cộng điểm", "", "", "", "");
            DGV.Rows.Add("3.1", "Tham gia đầy đủ hoạt động tập thể của Lớp, Chi đoàn, Liên chi đoàn, Liên chi hội, Hội sinh viên (Tùy mức độ tham gia).", "5", "3.1", "3.1", "3.1");
            DGV.Rows.Add("3.2", "Tham gia các hoạt động ngoại khóa do Nhà trường, địa phương tổ chức.", "10", "3.2", "3.2", "3.2");
            DGV.Rows.Add("3.3", "Có thành tích trong học tập, rèn luyện, tham gia hoạt động văn nghệ, thể thao, đấu tranh, phòng chống TNXH, được khen thưởng cấp.", "5", "3.3", "3.3", "3.3");
            DGV.Rows.Add("", "* Phần trừ điểm", "", "", "", "");
            DGV.Rows.Add("3.4", "Bỏ sinh hoạt lớp, sinh hoạt Đoàn, sinh hoạt Hội sinh viên theo kế hoạch. (-5/ lần họp).", "0", "3.4", "3.4", "3.4");
            DGV.Rows.Add("3.5", "Không tham các hoạt động do khoa điều động (có danh sách cụ thể). (-5/ lần).", "0", "3.5", "3.5", "3.5");
            DGV.Rows.Add("3.6", "Sinh viên không hoàn thành chương trình tuần sinh hoạt công dân đầu khóa, cuối khóa, đầu năm học. (-10).", "0", "3.6", "3.6", "3.6");
            DGV.Rows.Add("4123", "ĐÁNH GIÁ VỀ PHẨM CHẤT CÔNG DÂN VÀ QUAN HỆ VỚI CỘNG ĐỒNG: (Khung điểm đánh giá từ 0 - 25 điểm)", "", "", "", "");
        }
    }
}
