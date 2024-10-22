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
            DGV.Rows.Add("4", "ĐÁNH GIÁ VỀ PHẨM CHẤT CÔNG DÂN VÀ QUAN HỆ VỚI CỘNG ĐỒNG: (Khung điểm đánh giá từ 0 - 25 điểm)", "", "", "", "");
            DGV.Rows.Add("", "* Phần cộng điểm", "", "", "", "");
            DGV.Rows.Add("4.1", "Chấp hành tốt và tham gia tuyên truyền các chủ trương của Đảng, chính sách, pháp luật của Nhà nước trong cộng đồng.", "5", "4.1", "4.1", "4.1");
            DGV.Rows.Add("4.2", "Tham gia hoạt động hỗ trợ nhau trong học tập (Có đăng ký từ đầu kỳ và minh chứng kết quả cụ thể), hoạt động kết nối cộng động (STEM, truyền thông, tuyên truyền tuyển sinh, tham gia đội tự quản…).", "10", "4.2", "4.2", "4.2");
            DGV.Rows.Add("4.3", "Tham gia công tác tình nguyện, chung sức vì cộng đồng, có tinh thần chia sẻ, giúp đỡ người thân, người có khó khăn, hoạn nạn, các hoạt động tại địa phương nơi cư trú (Tùy mức độ tham gia, có minh chứng cụ thể).", "10", "4.3", "4.3", "4.3");
            DGV.Rows.Add("4.4", "Giữ gìn đoàn kết nội bộ, quan hệ tốt với bạn bè, tập thể nơi cư trú.", "5", "4.4", "4.4", "4.4");
            DGV.Rows.Add("", "* Phần trừ điểm", "", "", "", "");
            DGV.Rows.Add("4.5", "Vi phạm pháp luật (chưa đến mức truy cứu trách nhiệm hình sự), thiếu ý thức tham gia giữ gìn trật tự an toàn xã hội, không chấp hành đầy đủ đường lối, chủ trương của Đảng, chính sách, pháp luật của Nhà nước. (-10).", "0", "4.5", "4.5", "4.5");
            DGV.Rows.Add("4.6", "Gây mất đoàn kết trong lớp, trong trường, trong KTX, địa bàn nơi cư trú. (-5/ lần).", "0", "4.6", "4.6", "4.6");
            DGV.Rows.Add("5", "ĐÁNH GIÁ VỀ Ý THỨC VÀ KẾT QUẢ THAM GIA PHỤ TRÁCH LỚP, CÁC ĐOÀN THỂ, TỔ CHỨC TRONG NHÀ TRƯỜNG, HOẶC ĐẠT ĐƯỢC THÀNH TÍCH ĐẶC BIỆT TRONG HỌC TẬP, RÈN LUYÊN CỦA SINH VIÊN (Khung điểm đánh giá từ 0 - 10 điểm)", "10", "0", "0", "0");
            DGV.Rows.Add("", "* Phần cộng điểm", "", "", "", "");
            DGV.Rows.Add("5.1", "Sinh viên tham gia cấp ủy chi bộ, Ban chấp hành Đoàn, Hội SV từ cấp chi đoàn, chi hội trở lên hoàn thành tốt nhiệm vụ, có uy tín và hiệu quả trong công việc được phân công.", "5", "5.1", "5.1", "5.1");
            DGV.Rows.Add("5.2", "Sinh viên tham gia cấp ủy chi bộ, Ban chấp hành Đoàn, Hội SV từ cấp chi đoàn, chi hội trở lên; khi tập thể tham gia, phụ trách được cấp trên khen thưởng.", "3", "5.2", "5.2", "5.2");
            DGV.Rows.Add("5.3", "Tập thể phụ trách có điểm rèn luyện đạt 85% xếp loại từ khá trở lên.", "2", "5.3", "5.3", "5.3");
            DGV.Rows.Add("5.4", "* Phần cộng điểm", "10", "5.4", "5.4", "5.4");
            DGV.Rows.Add("", "* Phần trừ điểm", "", "", "", "");
            DGV.Rows.Add("5.5", "Không tổ chức thực hiện sinh hoạt tập thể theo kế hoạch của khoa, trường, Đoàn thanh niên, hội sinh viên cấp trên. (-5/ lần).", "0", "5.5", "5.5", "5.5");
            DGV.Rows.Add("5.6", "Tập thể lớp có điểm rèn luyện dưới 60% đạt loại trung bình trở lên. (-5).", "0", "5.6", "5.6", "5.6");


        }
    }
}
