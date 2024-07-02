using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }



        private void btEx8_1_Click(object sender, EventArgs e) {

            var dateTime = DateTime.Now;
            var str1 = string.Format("{0:yyyy/M/d HH:mm}", dateTime);
            tbDisp.Text = str1;

            var str2 = dateTime.ToString("yyyy年MM月dd日 HH時mm分ss秒");
            tbDisp.Text = str2;

            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();

            var datestr = dateTime.ToString("ggyy",culture);
            var day0fweek = culture.DateTimeFormat.GetDayName(dateTime.DayOfWeek);

            var str3 = string.Format("{0}年{1,2}月{2,2}日{3}", datestr, dateTime.Month, dateTime.Day, day0fweek);
            tbDisp.Text = str3;
            /*var date = new DateTime(2019, 1, 15, 19, 48, 32);
            var s1 = date.ToString("yyyy/MM/dd f");
            tbDisp.Text = "ssssss\r\n";

            var s2 = date.ToString("yyyy年MM月dd日　HH時mm分ss秒");
            tbDisp.Text = "ssssss\r\n";

            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var day0fweek = culture.DateTimeFormat.GetDayName(date.DayOfWeek);
            var str = date.ToString("ggyy月 MM月dd日", culture);
            tbDisp.Text = "ssssss\r\n";
            tbDisp.Text += "ssssss";*/
        }

        private void btEx8_2_Click(object sender, EventArgs e) {
            
        }

        public static DateTime NextDay(DateTime date,DayOfWeek dayOfWeek) {
            var days = (int)dayOfWeek - (int)(date.DayOfWeek);
        }
    }
}
